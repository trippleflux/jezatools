#define	_WIN32_WINNT	0x0403

#include "stdio.h"
#include "stdlib.h"
#include "ctype.h"
#include "string.h"
//#include "time.h"
//#include "windows.h"

#include <Tchar.h>
#include <Winsock2.h>
#include <MsWsock.h>
#include <Windows.h>
#include <wincrypt.h>
#include <wintrust.h>
#include <schannel.h>
#define SECURITY_WIN32
#include <security.h>
#include <sspi.h>
#include <time.h>
#include <sys/stat.h>


/*
#include <ServerLimits.h>
#include <UserFile.h>
#include <VFS.h>
#include <WinMessages.h>
#include <DataCopy.h>
#include <Lists.h>
#include <IoMemory.h>
#include <IoError.h>
#include <Resource.h>
#include <StdDef.h>
#include <GroupFile.h>
#include <Time.h>
#include <StdIo.h>
#include <IoString.h>
#include <VirtualPath.h>
#include <LockObject.h>
#include <Select.h>
#include <IoTime.h>
#include <IoOverlapped.h>
#include <IoFile.h>
#include <IoService.h>
#include <IoSocket.h>
#include <NewClient.h>
#include <Identify.h>
#include <ConnectionInfo.h>
#include <Timer.h>
#include <Buffer.h>
#include <User.h>
#include <Group.h>
#include <Log.h>
#include <Job.h>
#include <DirectoryCache.h>
#include <ConfigReader.h>
#include <ControlConnection.h>
#include <DataConnection.h>
#include <Threads.h>
#include <FTP.h>
#include <HTTP.h>
#include <Telnet.h>
#include <Who.h>
#include <Event.h>
#include <Stats.h>
#include <IoProc.h>
#include <DataOffset.h>
#include <TimerProcedure.h>
#include <Scheduler.h>
#include <IdDataBase.h>
#include <RowParser.h>
#include <Client.h>
#include <Array.h>
#include <MessageFile.h>
#include <AdminCommands.h>
#include <Tcl.h>
#include <Php.h>
#include <SHA1.h>
*/

#define	CopyString	strcpy
#define HEAD	0
#define TAIL	1


#define DAEMON_ACTIVE	0
#define DAEMON_INACTIVE	1
#define DAEMON_RESTART	2
#define DAEMON_SHUTDOWN	3


VOID CrashGuard_Remove(VOID);
BOOL CrashGuard_Wait(LPTSTR *lpCommandLine);
BOOL CrashGuard_Create(LPTSTR tszConfigFile);

DWORD GetDaemonStatus(VOID);
BOOL ProcessMessages(VOID);
BOOL CrashGuard_Wait(LPTSTR *tszCommandLine);
VOID SetDaemonStatus(DWORD dwStatus);


#ifndef _UNICODE
#define _tmemchr memchr
#else
#define _tmemchr wmemchr
#endif