// File: SimpleFTP.cs - compiled as a class library.
// Out: SimpleFTP.dll
// Date: 23 May 2005
// by Walter Smith
// Purpose: Communicate with an FTP server to
// View files and folders, upload and download files
//
// Modified 9 May 06 - 
//   Added Upload method using stream
//   Changed File Upload to use Filestream and added new stream upload method.
//
// Modified 1 Sep 06
//   Changed GetDir() method to prevent returning blank last element
//
// Modified 6 Sep 06
//   Added public properties Connected and LoggedIn
//
// Modified 19 Aug 07
//   Added code to Login method to put system in binary transfer mode 
//   for uploading and downloading files. (sends command "TYPE I")
//

using System;
using System.IO;			// StreamReader,StreamWriter
using System.Net;			// IPEndPoint
using System.Net.Sockets;	// Socket,TcpClient
using System.Text;			// Encoding

namespace SimpleFTP
{
	/// <summary>
	/// FtpClient class performs the actions of a simple ftp client
	/// </summary>
	public class FtpClient
	{
		///////  Class Variables  ///////
		private bool bConnected = false;		// indicate connection to host
		private bool bLoggedIn = false;			// indicate user is logged on
		private bool bVerbrose = Boolean.Parse(jcReleaseCollector.Settings.GetConfig("ftp.Verbose"));			// send feedback
		//private bool bVerbrose = false;			// send feedback
		private int nPortFTP = 21;				// default FTP port
		private TcpClient m_tcpClient = null;	// command channel
		private StreamReader m_comRead = null;	// text reader
		private StreamWriter m_comWrite = null; // text writer

        /// <summary>
        /// flags for directory description
        /// </summary>
		public enum DirMode : int { Complete, NamesOnly };

		/////////////////  PUBLIC EVENTS  //////////////////

		/// <summary>
		/// Delegate to supply all commands sent and replies to user
		/// </summary>
		public delegate void CmdEventHandler(string sCmd);

		/// <summary>
		/// receive all commands
		/// </summary>
		public event CmdEventHandler cmdEvent;

        /////////////////  PUBLIC PROPERTIES  ///////////////

        /// <summary>
        /// flag indicating that user is logged in
        /// </summary>
        public bool LoggedIn { get { return bLoggedIn; } }

        /// <summary>
        /// flag indicating that user is connected to server
        /// </summary>
        public bool Connected { get { return bConnected; } }

        /////////////////  PUBLIC METHODS  //////////////////

		//////////////////////////////////////////////////////////////
		/// <summary>
		/// Constructor: Default
		/// </summary>
		public FtpClient() {}

		/////////////////////////////////////////////////////////////
		/// <summary>
		/// Connect to the remote Host FTP server
		/// </summary>
		/// <param name="sHost">Host name of FTP server</param>
		/// <param name="sPort">Port of the FTP Server</param>
		public void Connect(string sHost, int sPort)
		{
			if (bConnected) throw new FtpClientException("Connection already open");
			bVerbrose = true;	// send all commands and replies to CmdEvent handlers
			try 
			{	// create a TcpClient control for Transport connection
				m_tcpClient = new TcpClient(sHost, sPort);
				m_tcpClient.ReceiveTimeout = 20000; // wait 10 seconds before aborting read
				m_tcpClient.SendTimeout = 20000; // wait 10 seconds before aborting write
				m_comRead = new StreamReader(m_tcpClient.GetStream());  // reads lines of text
				m_comWrite = new StreamWriter(m_tcpClient.GetStream()); // write lines of text
				bConnected = true;
			} 
			catch (Exception ex) 
			{
				throw new FtpClientException("Cannot establish a connection with " + sHost, ex);
			}
			string sReply = ReadReply();	// 220 reply(multiline) if successful
			if (sReply[0] != '2') throw new FtpClientException(sReply);
		}

		/////////////////////////////////////////////////////////////
		/// <summary>
		/// Log in user to a connected remote FTP server
		/// </summary>
		/// <param name="sUsername">User name</param>
		/// <param name="sPassword">User Password</param>
		public void Login(string sUsername, string sPassword)
		{
			if(!bConnected) throw new FtpClientException("Not Connected to Host");
			if(sUsername == "") sUsername = "anonymous";
			if(sPassword == "") sPassword = "anonymous";
			string sReply = SendCommand("USER " + sUsername);
			// the server must reply with 331
			if (sReply[0] != '3') throw new FtpClientException(sReply);
			sReply = SendCommand("PASS " + sPassword);
            if (sReply[0] == '5')
            {
                //530- The server has been shut down, try again later.
                bLoggedIn = false;
                return;
            }
		    // the server must reply with 230, which is a successful login
			if (sReply[0] != '2') throw new FtpClientException(sReply);
            sReply = SendCommand("TYPE I"); // set system to binary transfer mode
            if (sReply[0] != '2') throw new FtpClientException(sReply);
            bLoggedIn = true;
		}

		////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Sets the current remote directory
		/// </summary>
		/// <param name="sDirectory">Directory name</param>
		public bool SetCurrentDirectory(string sDirectory)
		{
			if (!bLoggedIn) return false;
			string sReply = SendCommand("CWD " + sDirectory);
			// server must reply with 250, else the directory does not exist
			if (sReply[0] != '2') throw new FtpClientException(sReply);
			return true;
		}
		
		///////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Download a file to a directory (using same filename)
		/// </summary>
		/// <param name="remFilename">Filename on host</param>
		/// <param name="locDir">Directory on local computer</param>
		public bool Download(string remFilename,string locDir)
		{
			if(!bLoggedIn) throw new FtpClientException("User not logged in"); 
			if(remFilename == "") throw new FtpClientException("Remote Filename Empty");
			if(locDir != "")
				if(locDir[locDir.Length-1] != '\\' && locDir[locDir.Length-1] != '/')
					locDir += "\\"; // ensure there is a seperator character
			string locFilename = locDir + Path.GetFileName(remFilename);
			Socket dSocket = CreateDataSocket();	// set for data transfer
			string sReply = SendCommand("RETR " + remFilename); // request a file
			if(sReply.Substring(0,1) != "1") throw new FtpClientException(sReply);
			byte[] bytes = new byte[1024];	// read buffer
			int nBytes = 0;
			FileStream fs = new FileStream(locFilename,FileMode.Create);
			while((nBytes = dSocket.Receive(bytes,bytes.Length,0)) > 0)
				fs.Write(bytes,0,nBytes);
			fs.Close();		// close filestream
			dSocket.Close();	// close data connection
			sReply = ReadReply();	// wait for result code 226 Transfer complete
			if(sReply[0] != '2') throw new FtpClientException(sReply);
			return true;
		}

        ///////////////////////////////////////////////////////////////
		/// <summary>
		/// Upload a file to a server directory (using same filename)
		/// </summary>
		/// <param name="locFilename">Filename on local computer</param>
		/// <param name="remDir">Directory to upload to on host. ("" = Current Working Directory)</param>
		public bool Upload(string locFilename, string remDir)
		{
			FileStream fs = new FileStream(locFilename,FileMode.Open);
			return Upload(locFilename,remDir,fs);
		}

		///////////////////////////////////////////////////////////////
		/// <summary>
		/// Upload a stream to a server directory
		/// </summary>
		/// <param name="Filename">Filename on local computer</param>
		/// <param name="remDir">Directory to upload to on host. ("" = CurrentWorkingDirectory)</param>
		/// <param name="SourceStream">Stream with source content</param>
		public bool Upload(string Filename, string remDir, Stream SourceStream)
		{
			if(!bLoggedIn) throw new FtpClientException("User not logged in");
			if(SourceStream.Length==0) throw new FtpClientException("Source stream empty");
			if(remDir != "")
				if(remDir[remDir.Length-1] != '/') remDir += "/";  // ensure there is a seperator
			string remFilename = remDir + Path.GetFileName(Filename); // file path to store under
			Socket dSocket = CreateDataSocket(); // create data connection with host
			string sReply = SendCommand("STOR " + remFilename);
			if(sReply[0] != '1') throw new FtpClientException(sReply);
			byte[] bytes = new byte[1024];
			int nBytes = 0;
			while((nBytes = SourceStream.Read(bytes,0,bytes.Length)) > 0) // read data
				dSocket.Send(bytes, nBytes,0);	// send to host
			SourceStream.Close(); // close filestream
			dSocket.Close(); // close data connection
			sReply = ReadReply();	// wait for message 226 Transfer Complete
			if(sReply[0] != '2') throw new FtpClientException(sReply);
			return true;
		}

		///////////////////////////////////////////////////////////////
		/// <summary>
		/// disconnect remote host
		/// </summary>
		public void Disconnect()
		{
			if(bConnected) SendCommand("QUIT");
			Close();
		}

		////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Closes TcpClient and cleans up
		/// </summary>
		public void Close()
		{
			if(!bConnected) return;
			m_comRead.Close();		// close text reader
			m_comWrite.Close();		// close text writer
			m_tcpClient.Close();	// close command channel
			bConnected = false;
			bLoggedIn = false;
		}

		//////////////////////////////////////////////////////////////////
		/// <summary>
		/// Sends a command to remote host and waits for reply
		/// </summary>
		/// <param name="sCmd">command to server</param>
		public string SendCommand(string sCmd)
		{
			if(!bConnected) return "000";
			WriteLog(sCmd);
			try
			{
				m_comWrite.WriteLine(sCmd);
				m_comWrite.Flush();	// send the data
			}
			catch(Exception ex)
			{
				WriteLog("Write timeout Error:" + ex.Message);
				Close(); // disconnect and cleanup
				throw new FtpClientException("Write Failed: Closing connection", ex);
			}
			return ReadReply();	// wait for reply from Host
		}	

		//////////////////////////////////////////////////////////
		/// <summary>
		/// Get List of host files and directories from server
		/// return names in a string array 
		/// </summary>
		/// <param name="sDir">Directory path. "" = CWD</param>
		/// <param name="nFlag">Mode</param>
		public string[] GetDir(string sDir, DirMode nFlag)
		{
			if(!bConnected) throw new FtpClientException("Not connected to Host");
			if(!bLoggedIn) throw new FtpClientException("User not logged in");
			WriteLog("Reading Directory: " + sDir);
			bVerbrose = false;	// disable feedback
			Socket dSocket = CreateDataSocket();
			string sCmd = "LIST " + sDir;
			if(nFlag == DirMode.NamesOnly) sCmd = "NLST " + sDir;
			string sReply = SendCommand(sCmd.Trim());
			if(sReply[0] != '1') throw new FtpClientException(sReply);
			byte[] bytes = new byte[4096];	// buffer to receive data bytes
			int nBytes = 0; // number of bytes read
			string s = "";	// string to hold all converted ASCII data
			while((nBytes = dSocket.Receive(bytes,bytes.Length,0)) > 0)
			{
				s += Encoding.ASCII.GetString(bytes,0,nBytes); // convert to ASCII
			}
			dSocket.Close();	// close data connection
			sReply = ReadReply();	// 226- Transfer Complete
			bVerbrose = true;	// re-enable feedback
			if(sReply[0] != '2') throw new FtpClientException(sReply);
            if(s.Length > 0)
                if(s[s.Length - 1] == '\n')
                    s = s.Substring(0, s.Length - 1); // remove last "\n"
            return s.Replace("\r", "").Split('\n'); // convert to string array
		}

		/////////////////////  LOCAL METHODS  //////////////////////
		
		// Read entire (multi-line) replies from server
		private string ReadReply()
		{
			string s = "";
			try
			{
				s = m_comRead.ReadLine();		// get first line of reply
				string sEnd = s.Substring(0,3) + " ";	// save reply number plus space
				while(s.Substring(0,4) != sEnd)
				{
					WriteLog(s);				// log line
					s = m_comRead.ReadLine();	// read multi-line replies
				}
				WriteLog(s);					// log last line
			}
			catch(Exception ex)
			{
				WriteLog("Timeout Error:" + ex.Message);
				Close(); // disconnect and cleanup
				throw new FtpClientException("Read Error: Closing connection", ex);
			}
			if(s.Length < 4) throw new FtpClientException("Invalid Reply From Server");
			if(s[0] == '2') WriteLog(""); // add blank line - end of sequence
			return s;	// return last line read
		}

		// create socket for data transfer
		// returns null on error
		private Socket CreateDataSocket()
		{
			string sReply = SendCommand("PASV"); // request a data connection
			// returns: "227 Entering Passive Mode (204,127,12,38,13,193)."
			if(sReply[0] != '2') throw new FtpClientException(sReply);
			// extract IP Address and Port number
			int n1 = sReply.IndexOf("(");
			int n2 = sReply.IndexOf(")");
			string[] sa = sReply.Substring(n1+1,n2-n1-1).Split(',');
			string sIPAddress = sa[0] + "." + sa[1] + "." + sa[2] + "." + sa[3];
			int nPort = int.Parse(sa[4]) * 256 + int.Parse(sa[5]);
			Socket socket = null;	// data transfer socket
			try
			{	// connect to host data channel
				socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
				socket.Connect(new IPEndPoint(IPAddress.Parse(sIPAddress),nPort));	
			}
			catch(Exception ex)
			{
				if(socket != null) socket.Close();
				WriteLog(ex.Message);
				throw new FtpClientException("Error creating data connection",ex);
			}
			return socket;
		}

		// supply commands and replies to "cmdEvent" subscribers
		private void WriteLog(string sLog)
		{
			if (bVerbrose)
			{
				//Console.WriteLine("->" + sLog);
				if (cmdEvent != null)
				{
					cmdEvent(sLog);
				}
			}
		}
	}

	/// <summary>
	/// FTP exception class
	/// </summary>
	public class FtpClientException : Exception
	{
		/// <summary>
		/// An instance of FtpClientException
		/// </summary>
		/// <param name="sMsg">Explains what happend</param>
		public FtpClientException(string sMsg) : base(sMsg) { }

		/// <summary>
		/// An instance of FtpClientException
		/// </summary>
		/// <param name="sMsg">Explains what happend</param>
		/// <param name="ex">InnerException</param>
		public FtpClientException(string sMsg, Exception ex) : base(sMsg, ex) { }
	} // end-class

} // end-namespace SimpleFTP
