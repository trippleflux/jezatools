/*
	Created...: 2005.09.18
	Changed...: 
	By........: Jeza
	Desription: Format Date to Seconds Since 01.01.1970 00:00:00.
*/
DWORD FormatTime (char *Date)
{
	COleDateTime dt;
	dt.ParseDateTime(Date);

	CTime t(dt.GetYear(), dt.GetMonth(), dt.GetDay(), dt.GetHour(), dt.GetMinute(), dt.GetSecond());
	//printf("date='%s' time=%d\n", Date, t.GetTime());
	return (DWORD)t.GetTime();

}

/*
	Created...: 2005.08.01
	Changed...: 
	By........: Jeza
	Desription: Format Size to 'kMGTPE' Bytes.
				fSize = B
*/
char *FormatRealSize (double fSize)
{
	char sSize[8] = " kMGTPE";
	int i;

	for (i = 0;fSize >= 1024.;i++)
	{
		fSize /= 1024.;
	}
	sprintf(sR,"%4.2f %cB",fSize,sSize[i]);
  
	return sR;
}

/*
	Created...: 2005.08.01
	Changed...: 
	By........: Jeza
	Desription: Format Size to 'kMGTPE' Bytes.
				fSize = kB
*/
char *FormatSize (double fSize)
{
	char sSize[7] = "kMGTPE";
	int i;

	for (i = 0;fSize >= 1024.;i++)
	{
		fSize /= 1024.;
	}
	sprintf(sR,"%4.2f %cB",fSize,sSize[i]);
  
	return sR;
}

/*
	Created...: 2005.09.19
	Changed...: 
	By........: Jeza
	Desription: Format Size to 'kMGTPE' Bytes.
				Size = kB
				Used In SITE USER
*/
char *FormatUserSize (INT64 Size)
{

	char sSize[7] = "kMGTPE";
	int i;

	for (i = 0;Size >= 1024;i++)
	{
		Size /= 1024;
	}
	sprintf(sR,"%I64d%c",Size,sSize[i]);
  
	return sR;
}

/*
	Created...: 2005.08.01
	Changed...: 
	By........: Jeza
	Desription: Format Seconds to 'HH:MM:SS'.
*/
char* FormatTime(long secs)
{
	int mins, hrs;

	if ( secs == 0 )
	{
		sprintf(ttime, "00:00:00");
	}
	else
	{
		if ( secs < 60 )
		{
			sprintf(ttime, "00:00:%02i", secs);
			return ttime;
		}
		else
		{
			mins = secs / 60;
			secs = secs % 60;
		}
	
		if ( mins < 60 )
		{
			sprintf(ttime, "00:%02i:%02i", mins, secs);
			return ttime;
		}
		else
		{
			hrs = mins / 60;
			mins = mins % 60;
		}
		
		sprintf(ttime, "%02i:%02i:%02i", hrs, mins, secs);
	}
	
	return ttime;

}

/*
	Created...: 
	Changed...: 2005.09.04
	By........: d1
	Desription: Format Input String.
*/
char *FormatString (char *sWhat, int iNew)
{
	int			iVALL, iVALR;
	char		*buff;
	char		*sTemp;
	char		sCTRL[10];
	char		sBLA[64];

	buff = OUTPUT;

	for ( ; *sWhat ; sWhat++ )
	{ 
		if ( *sWhat == '$' )
		{
			sWhat++;
			sTemp = sWhat;
	      
			if (*sWhat == '-' && isdigit(*(sWhat + 1))) 
			{
				sWhat += 2;
			}
		      
			while (isdigit(*sWhat))
			{
				sWhat++;
			}
		      
			if ( sTemp != sWhat )
			{
				sprintf(sCTRL, "%.*s", sWhat - sTemp, sTemp);
				iVALL = atoi(sCTRL);
			}
			else
			{
				iVALL = 0;
			}
	        	
			if ( *sWhat == '.' )
			{
				sWhat++;
				sTemp = sWhat;
		        
				if (*sWhat == '-' && isdigit(*(sWhat + 1))) 
				{
					sWhat += 2;
				}
		        
				while (isdigit(*sWhat))
				{
					sWhat++;
				}
		      	
      			if ( sTemp != sWhat )
      			{
					sprintf(sCTRL, "%.*s", sWhat - sTemp, sTemp);
					iVALR = atoi(sCTRL);
				}
				else
				{
					iVALR = 0;
				}
		        
			}
			else 
			{
				iVALR = -1;
			}
		  
			sTemp = sWhat;

			while ( *sWhat != '$' )
			{
				sWhat++;
			}
	      	
			if ( sTemp != sWhat )
			{
				sprintf(sBLA, "%.*s", sWhat - sTemp, sTemp);
			}

			if ( strcmp(sBLA,"script_version") == 0 )					buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)jScripts_default_version );

			else if ( strcmp(sBLA,"irc_bold") == 0 )					buff += sprintf(buff, "%s", "\\002" );
			else if ( strcmp(sBLA,"irc_color") == 0 )					buff += sprintf(buff, "%s", "\\003" );
			else if ( strcmp(sBLA,"irc_underline") == 0 )				buff += sprintf(buff, "%s", "\\003" );
			else if ( strcmp(sBLA,"irc_username") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.site.invite_ircnick );

			else if ( strcmp(sBLA,"who_username") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.jWho.UserName );
			else if ( strcmp(sBLA,"who_groupname") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.jWho.GroupName );
			else if ( strcmp(sBLA,"who_idle_count") == 0 )				buff += sprintf(buff, "%*.*i", iVALL, iVALR, var.jWho.iIDLE );
			else if ( strcmp(sBLA,"who_up_count") == 0 )				buff += sprintf(buff, "%*.*i", iVALL, iVALR, var.jWho.iUP );
			else if ( strcmp(sBLA,"who_dn_count") == 0 )				buff += sprintf(buff, "%*.*i", iVALL, iVALR, var.jWho.iDN );
			else if ( strcmp(sBLA,"who_up_total_speed") == 0 )			buff += sprintf(buff, "%*.*u", iVALL, iVALR, var.jWho.dwUP );
			else if ( strcmp(sBLA,"who_dn_total_speed") == 0 )			buff += sprintf(buff, "%*.*u", iVALL, iVALR, var.jWho.dwDN );
			else if ( strcmp(sBLA,"who_total_count") == 0 )				buff += sprintf(buff, "%*.*i", iVALL, iVALR, (var.jWho.iIDLE + var.jWho.iUP + var.jWho.iDN) );
			else if ( strcmp(sBLA,"who_total_speed") == 0 )				buff += sprintf(buff, "%*.*i", iVALL, iVALR, (var.jWho.dwUP + var.jWho.dwDN) );
			else if ( strcmp(sBLA,"who_idle_time") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)FormatTime(var.jWho.IdleTime) );
			else if ( strcmp(sBLA,"who_login_time") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)FormatTime((long)var.jWho.LoginTime) );
			else if ( strcmp(sBLA,"who_user_speed") == 0 )				buff += sprintf(buff, "%*.*u", iVALL, iVALR, var.jWho.dwSpeed );
			else if ( strcmp(sBLA,"who_virtualpath") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.jWho.VirtualPath );
			else if ( strcmp(sBLA,"who_virtualdatapath") == 0 )			buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.jWho.VirtualDataPath );
			else if ( strcmp(sBLA,"who_action") == 0 )					buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.jWho.Action );
			else if ( strcmp(sBLA,"who_bytes_transfered") == 0 )		buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)FormatRealSize((double)var.jWho.totalBytesTransfered));
			else if ( strcmp(sBLA,"who_file_name") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.jWho.FileName );
			else if ( strcmp(sBLA,"who_file_size") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)FormatRealSize((double)var.jWho.FileSize) );
			else if ( strcmp(sBLA,"who_percent_done") == 0 )			buff += sprintf(buff, "%*.*i", iVALL, iVALR, (int)((100*var.jWho.totalBytesTransfered)/var.jWho.FileSize) );

			else if ( strcmp(sBLA,"env_username") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.env.user );
			else if ( strcmp(sBLA,"env_groupname") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.env.group );
			else if ( strcmp(sBLA,"env_path") == 0 )					buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.env.path );
			else if ( strcmp(sBLA,"env_virtualpath") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.env.virtualpath );
			else if ( strcmp(sBLA,"env_tagline") == 0 )					buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.env.tagline );
			else if ( strcmp(sBLA,"env_uid") == 0 )						buff += sprintf(buff, "%*.*i", iVALL, iVALR, (int)var.env.uid );
			else if ( strcmp(sBLA,"env_gid") == 0 )						buff += sprintf(buff, "%*.*i", iVALL, iVALR, (int)var.env.gid );

			else if ( strcmp(sBLA,"ban_ip") == 0 )						buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.user.ip );
			else if ( strcmp(sBLA,"master_login") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.user.Master );
			else if ( strcmp(sBLA,"show_login") == 0 )					buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.user.Show );
			else if ( strcmp(sBLA,"user_login") == 0 )					buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.user.User );

			else if ( strcmp(sBLA,"user_uid") == 0 )					buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.user.User );

			else if ( strcmp(sBLA,"dupeuser") == 0 )					buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.sql.UserName );
			else if ( strcmp(sBLA,"dupedate") == 0 )					buff += sprintf(buff, "%*.*s", iVALL, iVALR, (_TCHAR *)var.sql.DupeDate );
			else if ( strcmp(sBLA,"dupepwd") == 0 )						buff += sprintf(buff, "%*.*s", iVALL, iVALR, (_TCHAR *)var.sql.DupePwd );
			else if ( strcmp(sBLA,"duperls") == 0 )						buff += sprintf(buff, "%*.*s", iVALL, iVALR, (_TCHAR *)var.args.arg02 );
			else if ( strcmp(sBLA,"dupefoundcount") == 0 )				buff += sprintf(buff, "%*.*i", iVALL, iVALR, (INT)var.sql.DupeFoundCount );
			else if ( strcmp(sBLA,"dupetotalcount") == 0 )				buff += sprintf(buff, "%*.*i", iVALL, iVALR, (INT)var.sql.DupeTotalCount );

			else														buff += sprintf(buff, "%c%s%c",'$', (char *)sBLA, '$' );
	
		}
		else
		{
			*buff++ = *sWhat;
		}
  
	}
  
	*buff = 0;
  
	return OUTPUT;
  
}

/*
	Created...: 2006.03.17
	Changed...: 
	By........: d1
	Desription: Format Input String.
*/
char *FormatStr1ng (char *sWhat, int iNew)
{
	int			iVALL, iVALR;
	char		*buff;
	char		*sTemp;
	char		sCTRL[10];
	char		sBLA[64];

	buff = OUTPUT;

	for ( ; *sWhat ; sWhat++ )
	{ 
		if ( *sWhat == '$' )
		{
			sWhat++;
			sTemp = sWhat;
	      
			if (*sWhat == '-' && isdigit(*(sWhat + 1))) 
			{
				sWhat += 2;
			}
		      
			while (isdigit(*sWhat))
			{
				sWhat++;
			}
		      
			if ( sTemp != sWhat )
			{
				sprintf(sCTRL, "%.*s", sWhat - sTemp, sTemp);
				iVALL = atoi(sCTRL);
			}
			else
			{
				iVALL = 0;
			}
	        	
			if ( *sWhat == '.' )
			{
				sWhat++;
				sTemp = sWhat;
		        
				if (*sWhat == '-' && isdigit(*(sWhat + 1))) 
				{
					sWhat += 2;
				}
		        
				while (isdigit(*sWhat))
				{
					sWhat++;
				}
		      	
      			if ( sTemp != sWhat )
      			{
					sprintf(sCTRL, "%.*s", sWhat - sTemp, sTemp);
					iVALR = atoi(sCTRL);
				}
				else
				{
					iVALR = 0;
				}
		        
			}
			else 
			{
				iVALR = -1;
			}
		  
			sTemp = sWhat;

			while ( *sWhat != '$' )
			{
				sWhat++;
			}
	      	
			if ( sTemp != sWhat )
			{
				sprintf(sBLA, "%.*s", sWhat - sTemp, sTemp);
			}

			if ( strcmp(sBLA,"script_version") == 0 )					buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)jScripts_default_version );

			else if ( strcmp(sBLA,"ustats_username") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.usertable[iNew].tUserName );
			else if ( strcmp(sBLA,"ustats_groupname") == 0 )			buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.usertable[iNew].tGroupName );
			else if ( strcmp(sBLA,"ustats_flags") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.usertable[iNew].tFlags );
			else if ( strcmp(sBLA,"ustats_timeadded") == 0 )			buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.usertable[iNew].DateAddedTime );
			//else if ( strcmp(sBLA,"ustats_lastseen") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.usertable[iNew].LastSeen );
			else if ( strcmp(sBLA,"ustats_lastseen") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.user.LastSeen );
			else if ( strcmp(sBLA,"ustats_position") == 0 )				buff += sprintf(buff, "%*.*i", iVALL, iVALR, (int)(iNew+1) );
			else if ( strcmp(sBLA,"ustats_section") == 0 )				buff += sprintf(buff, "%*.*i", iVALL, iVALR, (short)var.ustats.iSection );
			else if ( strcmp(sBLA,"ustats_count") == 0 )				buff += sprintf(buff, "%*.*i", iVALL, iVALR, (int)var.ustats.iCount );				
			else if ( strcmp(sBLA,"ustats_name") == 0 )					buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.ustats.sWhat );		
			else if ( strcmp(sBLA,"ustats_credits") == 0 )				buff += sprintf(buff, "%*.*d", iVALL, iVALR, (INT64)var.usertable[iNew].tCredits/(1024) ); 
			
			else if ( strcmp(sBLA,"ustats_allupf") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.usertable[iNew].tAllUPf) ); 
			else if ( strcmp(sBLA,"ustats_alldnf") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.usertable[iNew].tAllDNf) ); 
			else if ( strcmp(sBLA,"ustats_mnupf") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.usertable[iNew].tMnUPf) ); 
			else if ( strcmp(sBLA,"ustats_mndnf") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.usertable[iNew].tMnDNf) );
			else if ( strcmp(sBLA,"ustats_wkupf") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.usertable[iNew].tWkUPf) );
			else if ( strcmp(sBLA,"ustats_wkdnf") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.usertable[iNew].tWkDNf) );
			else if ( strcmp(sBLA,"ustats_dayupf") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.usertable[iNew].tDayUPf) );
			else if ( strcmp(sBLA,"ustats_daydnf") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.usertable[iNew].tDayDNf) );
				
			else if ( strcmp(sBLA,"ustats_allups") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.usertable[iNew].tAllUPs) ); 
			else if ( strcmp(sBLA,"ustats_alldns") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.usertable[iNew].tAllDNs) ); 
			else if ( strcmp(sBLA,"ustats_mnups") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.usertable[iNew].tMnUPs) ); 
			else if ( strcmp(sBLA,"ustats_mndns") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.usertable[iNew].tMnDNs) );
			else if ( strcmp(sBLA,"ustats_wkups") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.usertable[iNew].tWkUPs) );
			else if ( strcmp(sBLA,"ustats_wkdns") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.usertable[iNew].tWkDNs) );
			else if ( strcmp(sBLA,"ustats_dayups") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.usertable[iNew].tDayUPs) );
			else if ( strcmp(sBLA,"ustats_daydns") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.usertable[iNew].tDayDNs) );

			else if ( strcmp(sBLA,"ustats_allup") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)FormatSize((double)var.usertable[iNew].tAllUP) ); 
			else if ( strcmp(sBLA,"ustats_alldn") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)FormatSize((double)var.usertable[iNew].tAllDN) ); 
			else if ( strcmp(sBLA,"ustats_mnup") == 0 )					buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)FormatSize((double)var.usertable[iNew].tMnUP) ); 
			else if ( strcmp(sBLA,"ustats_mndn") == 0 )					buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)FormatSize((double)var.usertable[iNew].tMnDN) );
			else if ( strcmp(sBLA,"ustats_wkup") == 0 )					buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)FormatSize((double)var.usertable[iNew].tWkUP) );
			else if ( strcmp(sBLA,"ustats_wkdn") == 0 )					buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)FormatSize((double)var.usertable[iNew].tWkDN) );
			else if ( strcmp(sBLA,"ustats_dayup") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)FormatSize((double)var.usertable[iNew].tDayUP) );
			else if ( strcmp(sBLA,"ustats_daydn") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)FormatSize((double)var.usertable[iNew].tDayDN) );

			else if ( strcmp(sBLA,"gstats_groupname") == 0 )			buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.grouptable[iNew].tGroupName );
			else if ( strcmp(sBLA,"gstats_credits") == 0 )				buff += sprintf(buff, "%*.*d", iVALL, iVALR, (INT64)var.grouptable[iNew].tCredits/(1024) ); 
			else if ( strcmp(sBLA,"gstats_position") == 0 )				buff += sprintf(buff, "%*.*i", iVALL, iVALR, (int)(iNew+1) );
			else if ( strcmp(sBLA,"gstats_section") == 0 )				buff += sprintf(buff, "%*.*i", iVALL, iVALR, (short)var.gstats.iSection );
			else if ( strcmp(sBLA,"gstats_count") == 0 )				buff += sprintf(buff, "%*.*i", iVALL, iVALR, (int)var.gstats.iCount );				
			else if ( strcmp(sBLA,"gstats_name") == 0 )					buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.gstats.sWhat );		
			else if ( strcmp(sBLA,"TotalUsersInGroup") == 0 )			buff += sprintf(buff, "%*.*i", iVALL, iVALR, (INT)(var.grouptable[iNew].tTotalUsersInGroup) );		

			else if ( strcmp(sBLA,"gstats_allupf") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.grouptable[iNew].tAllUPf) ); 
			else if ( strcmp(sBLA,"gstats_alldnf") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.grouptable[iNew].tAllDNf) ); 
			else if ( strcmp(sBLA,"gstats_mnupf") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.grouptable[iNew].tMnUPf) ); 
			else if ( strcmp(sBLA,"gstats_mndnf") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.grouptable[iNew].tMnDNf) );
			else if ( strcmp(sBLA,"gstats_wkupf") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.grouptable[iNew].tWkUPf) );
			else if ( strcmp(sBLA,"gstats_wkdnf") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.grouptable[iNew].tWkDNf) );
			else if ( strcmp(sBLA,"gstats_dayupf") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.grouptable[iNew].tDayUPf) );
			else if ( strcmp(sBLA,"gstats_daydnf") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.grouptable[iNew].tDayDNf) );

			else if ( strcmp(sBLA,"gstats_allups") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.grouptable[iNew].tAllUPs) ); 
			else if ( strcmp(sBLA,"gstats_alldns") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.grouptable[iNew].tAllDNs) ); 
			else if ( strcmp(sBLA,"gstats_mnups") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.grouptable[iNew].tMnUPs) ); 
			else if ( strcmp(sBLA,"gstats_mndns") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.grouptable[iNew].tMnDNs) );
			else if ( strcmp(sBLA,"gstats_wkups") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.grouptable[iNew].tWkUPs) );
			else if ( strcmp(sBLA,"gstats_wkdns") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.grouptable[iNew].tWkDNs) );
			else if ( strcmp(sBLA,"gstats_dayups") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.grouptable[iNew].tDayUPs) );
			else if ( strcmp(sBLA,"gstats_daydns") == 0 )				buff += sprintf(buff, "%*.*I64d", iVALL, iVALR, (var.grouptable[iNew].tDayDNs) );

			else if ( strcmp(sBLA,"gstats_allup") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)FormatSize((double)var.grouptable[iNew].tAllUP) ); 
			else if ( strcmp(sBLA,"gstats_alldn") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)FormatSize((double)var.grouptable[iNew].tAllDN) ); 
			else if ( strcmp(sBLA,"gstats_mnup") == 0 )					buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)FormatSize((double)var.grouptable[iNew].tMnUP) ); 
			else if ( strcmp(sBLA,"gstats_mndn") == 0 )					buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)FormatSize((double)var.grouptable[iNew].tMnDN) );
			else if ( strcmp(sBLA,"gstats_wkup") == 0 )					buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)FormatSize((double)var.grouptable[iNew].tWkUP) );
			else if ( strcmp(sBLA,"gstats_wkdn") == 0 )					buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)FormatSize((double)var.grouptable[iNew].tWkDN) );
			else if ( strcmp(sBLA,"gstats_dayup") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)FormatSize((double)var.grouptable[iNew].tDayUP) );
			else if ( strcmp(sBLA,"gstats_daydn") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)FormatSize((double)var.grouptable[iNew].tDayDN) );

			else if ( strcmp(sBLA,"bgstats_pos_allup") == 0 )			buff += sprintf(buff, "%*.*d", iVALL, iVALR, var.grouptable[iNew].tAllUPPos ); 
			else if ( strcmp(sBLA,"bgstats_pos_alldn") == 0 )			buff += sprintf(buff, "%*.*d", iVALL, iVALR, var.grouptable[iNew].tAllDNPos ); 
			else if ( strcmp(sBLA,"bgstats_pos_mnup") == 0 )			buff += sprintf(buff, "%*.*d", iVALL, iVALR, var.grouptable[iNew].tMnUPPos ); 
			else if ( strcmp(sBLA,"bgstats_pos_mndn") == 0 )			buff += sprintf(buff, "%*.*d", iVALL, iVALR, var.grouptable[iNew].tMnDNPos );
			else if ( strcmp(sBLA,"bgstats_pos_wkup") == 0 )			buff += sprintf(buff, "%*.*d", iVALL, iVALR, var.grouptable[iNew].tWkUPPos );
			else if ( strcmp(sBLA,"bgstats_pos_wkdn") == 0 )			buff += sprintf(buff, "%*.*d", iVALL, iVALR, var.grouptable[iNew].tWkDNPos );
			else if ( strcmp(sBLA,"bgstats_pos_dayup") == 0 )			buff += sprintf(buff, "%*.*d", iVALL, iVALR, var.grouptable[iNew].tDayUPPos );
			else if ( strcmp(sBLA,"bgstats_pos_daydn") == 0 )			buff += sprintf(buff, "%*.*d", iVALL, iVALR, var.grouptable[iNew].tDayDNPos );

			else if ( strcmp(sBLA,"bgstats_allup") == 0 )				buff += sprintf(buff, "%*.*d", iVALL, iVALR, (INT64)var.grouptable[iNew].tAllUP/(1024) ); 
			else if ( strcmp(sBLA,"bgstats_alldn") == 0 )				buff += sprintf(buff, "%*.*d", iVALL, iVALR, (INT64)var.grouptable[iNew].tAllDN/(1024) ); 
			else if ( strcmp(sBLA,"bgstats_mnup") == 0 )				buff += sprintf(buff, "%*.*d", iVALL, iVALR, (INT64)var.grouptable[iNew].tMnUP/(1024) ); 
			else if ( strcmp(sBLA,"bgstats_mndn") == 0 )				buff += sprintf(buff, "%*.*d", iVALL, iVALR, (INT64)var.grouptable[iNew].tMnDN/(1024) );
			else if ( strcmp(sBLA,"bgstats_wkup") == 0 )				buff += sprintf(buff, "%*.*d", iVALL, iVALR, (INT64)var.grouptable[iNew].tWkUP/(1024) );
			else if ( strcmp(sBLA,"bgstats_wkdn") == 0 )				buff += sprintf(buff, "%*.*d", iVALL, iVALR, (INT64)var.grouptable[iNew].tWkDN/(1024) );
			else if ( strcmp(sBLA,"bgstats_dayup") == 0 )				buff += sprintf(buff, "%*.*d", iVALL, iVALR, (INT64)var.grouptable[iNew].tDayUP/(1024) );
			else if ( strcmp(sBLA,"bgstats_daydn") == 0 )				buff += sprintf(buff, "%*.*d", iVALL, iVALR, (INT64)var.grouptable[iNew].tDayDN/(1024) );

			else if ( strcmp(sBLA,"bustats_allup") == 0 )				buff += sprintf(buff, "%*.*d", iVALL, iVALR, (INT64)var.usertable[iNew].tAllUP/(1024) ); 
			else if ( strcmp(sBLA,"bustats_alldn") == 0 )				buff += sprintf(buff, "%*.*d", iVALL, iVALR, (INT64)var.usertable[iNew].tAllDN/(1024) ); 
			else if ( strcmp(sBLA,"bustats_mnup") == 0 )				buff += sprintf(buff, "%*.*d", iVALL, iVALR, (INT64)var.usertable[iNew].tMnUP/(1024) ); 
			else if ( strcmp(sBLA,"bustats_mndn") == 0 )				buff += sprintf(buff, "%*.*d", iVALL, iVALR, (INT64)var.usertable[iNew].tMnDN/(1024) );
			else if ( strcmp(sBLA,"bustats_wkup") == 0 )				buff += sprintf(buff, "%*.*d", iVALL, iVALR, (INT64)var.usertable[iNew].tWkUP/(1024) );
			else if ( strcmp(sBLA,"bustats_wkdn") == 0 )				buff += sprintf(buff, "%*.*d", iVALL, iVALR, (INT64)var.usertable[iNew].tWkDN/(1024) );
			else if ( strcmp(sBLA,"bustats_dayup") == 0 )				buff += sprintf(buff, "%*.*d", iVALL, iVALR, (INT64)var.usertable[iNew].tDayUP/(1024) );
			else if ( strcmp(sBLA,"bustats_daydn") == 0 )				buff += sprintf(buff, "%*.*d", iVALL, iVALR, (INT64)var.usertable[iNew].tDayDN/(1024) );

			else if ( strcmp(sBLA,"bustats_pos_allup") == 0 )			buff += sprintf(buff, "%*.*d", iVALL, iVALR, var.usertable[iNew].tAllUPPos ); 
			else if ( strcmp(sBLA,"bustats_pos_alldn") == 0 )			buff += sprintf(buff, "%*.*d", iVALL, iVALR, var.usertable[iNew].tAllDNPos ); 
			else if ( strcmp(sBLA,"bustats_pos_mnup") == 0 )			buff += sprintf(buff, "%*.*d", iVALL, iVALR, var.usertable[iNew].tMnUPPos ); 
			else if ( strcmp(sBLA,"bustats_pos_mndn") == 0 )			buff += sprintf(buff, "%*.*d", iVALL, iVALR, var.usertable[iNew].tMnDNPos );
			else if ( strcmp(sBLA,"bustats_pos_wkup") == 0 )			buff += sprintf(buff, "%*.*d", iVALL, iVALR, var.usertable[iNew].tWkUPPos );
			else if ( strcmp(sBLA,"bustats_pos_wkdn") == 0 )			buff += sprintf(buff, "%*.*d", iVALL, iVALR, var.usertable[iNew].tWkDNPos );
			else if ( strcmp(sBLA,"bustats_pos_dayup") == 0 )			buff += sprintf(buff, "%*.*d", iVALL, iVALR, var.usertable[iNew].tDayUPPos );
			else if ( strcmp(sBLA,"bustats_pos_daydn") == 0 )			buff += sprintf(buff, "%*.*d", iVALL, iVALR, var.usertable[iNew].tDayDNPos );

			else if ( strcmp(sBLA,"env_username") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.env.user );
			else if ( strcmp(sBLA,"env_groupname") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.env.group );
			else if ( strcmp(sBLA,"env_path") == 0 )					buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.env.path );
			else if ( strcmp(sBLA,"env_virtualpath") == 0 )				buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.env.virtualpath );
			else if ( strcmp(sBLA,"env_tagline") == 0 )					buff += sprintf(buff, "%*.*s", iVALL, iVALR, (char *)var.env.tagline );
			else if ( strcmp(sBLA,"env_uid") == 0 )						buff += sprintf(buff, "%*.*i", iVALL, iVALR, (int)var.env.uid );
			else if ( strcmp(sBLA,"env_gid") == 0 )						buff += sprintf(buff, "%*.*i", iVALL, iVALR, (int)var.env.gid );

			else														buff += sprintf(buff, "%c%s%c",'$', (char *)sBLA, '$' );
	
		}
		else
		{
			*buff++ = *sWhat;
		}
  
	}
  
	*buff = 0;
  
	return OUTPUT;
  
}
