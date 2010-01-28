void ErrorPrint(_TCHAR *lpszFunction) 
{ 
    _TCHAR *lpMsgBuf;
    _TCHAR *lpDisplayBuf;
    DWORD dw = GetLastError(); 

    FormatMessage(
        FORMAT_MESSAGE_ALLOCATE_BUFFER | 
        FORMAT_MESSAGE_FROM_SYSTEM,
        NULL,
        dw,
        MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
        (LPTSTR) &lpMsgBuf,
        0, NULL );

//    lpDisplayBuf = LocalAlloc(LMEM_ZEROINIT, 
//        (strlen(lpMsgBuf)+strlen(lpszFunction)+40)*sizeof(_TCHAR));
	lpDisplayBuf = (_TCHAR *)calloc((strlen(lpMsgBuf)+strlen(lpszFunction)+40), sizeof(_TCHAR));
    wsprintf(lpDisplayBuf, 
		TEXT(".......: %s : GetLastError = %d -> %s"), 
        lpszFunction, dw, lpMsgBuf); 
    //MessageBox(NULL, lpDisplayBuf, TEXT("Error"), MB_OK); 
	debug(lpDisplayBuf);

    LocalFree(lpMsgBuf);
    LocalFree(lpDisplayBuf);
    //ExitProcess(dw); 
}

/*
	Created...: 2005.10.22
	Changed...: 
	By........: Jeza
	Desription: SITE CHANGEGROUP <UserName> <GroupName>.
*/
BOOL ChangeGroup ( _TCHAR* argv[], INT GID )
{
	if ( (argv[2] != NULL) && (argv[3] != NULL) && (strcmp(strupr(argv[1]), "CHANGEGROUP") == 0) )
	{

		int UID = ResolveUserNameToUid(argv[2]);

		if ( UID > -1 )
		{
			if ( ChangeGroupID (UID, GID) )
			{
				
				/*
				debug("change group ok\n");
				
				debug("increase group users\n");

				if ( IncreaseGroupUsers( GID ) )
				{
					
					debug("increase group users OK\n");
					
					return TRUE;
				}
				else
				{
					debug ("IncreaseGroupUsers FAiLED\n");

					return FALSE;
				}
				*/

				return TRUE;

			}
			else
				return FALSE;
		}
		else
		{
			return FALSE;
		}
		
	}
	else
	{
		return FALSE;
	}

	return FALSE;
}

/*
	Created...: 2005.09.11
	Changed...: 
	By........: Jeza
	Desription: SITE INVITE <IRCNICK>.
*/
VOID CheckInvite ( _TCHAR* argv[] )
{
	if ( (argv[2] != NULL) && (strcmp(strupr(argv[1]), "INVITE") == 0) )
	{
		sprintf(var.site.invite_ircnick, "%s", argv[2]);
		printf(FormatString(jScripts_site_invite_ircnick, 0));
		WriteLog(FormatString(jScripts_mirc_anounce_invite, 0));
	}
	else
	{
		printf(FormatString(jScripts_site_invite_help, 0));
	}
}

/*
	Created...: 2005.10.03
	Changed...: 
	By........: Jeza
	Desription: List Of BANNED IPs.
*/
VOID BanList ( )
{
	
	sqlite3 *db;
	CHAR *zErrMsg = 0;
	INT rc;
	
	printf(FormatString(jScripts_site_ban_list_head, 0));

	sqlite3_open(jScripts_default_ban_db, &db);

	var.sql.bBanList = TRUE;

	rc = sqlite3_exec(db, "SELECT * FROM BANS;", callback, 0, &zErrMsg);

	var.sql.bBanList = FALSE;

	sqlite3_close(db);

	printf(FormatString(jScripts_site_ban_list_foot, 0));

}

/*
	Created...: 2005.10.03
	Changed...: 
	By........: Jeza
	Desription: BAN IP.
*/
VOID AddBan ( _TCHAR* argv[] )
{

	sqlite3 *db;
	CHAR *zErrMsg = 0;
	INT rc;
	CHAR buff[256] = {0};
	
	sqlite3_open(jScripts_default_ban_db, &db);

	if ( argv[3] == NULL )
		sprintf(buff, "INSERT INTO BANS (IP, Reason) VALUES('%s', 'No Reason');", argv[2]);
	else
		sprintf(buff, "INSERT INTO BANS (IP, Reason) VALUES('%s', '%s');", argv[2], argv[3]);

	rc = sqlite3_exec(db, buff, callback, 0, &zErrMsg);

	sqlite3_close(db);

	printf(FormatString(jScripts_site_ban_add, 0));

}

/*
	Created...: 2005.09.12
	Changed...: 
	By........: Jeza
	Desription: Check If Users IP is In BANNED LIST.
				YES -> disconnect
*/
BOOL CheckBan ( )
{

	sqlite3 *db;
	CHAR *zErrMsg = 0;
	INT rc;
	CHAR buff[256] = {0};
	
	var.sql.bIsBanned = FALSE;
	var.sql.bCheckBan = TRUE;

	sqlite3_open(jScripts_default_ban_db, &db);

	sprintf(buff, "SELECT IP FROM BANS WHERE IP = '%s';", getenv("IP"));

	rc = sqlite3_exec(db, buff, callback, 0, &zErrMsg);

	sqlite3_close(db);

	var.sql.bCheckBan = FALSE;

	if ( var.sql.bIsBanned )
		return TRUE;
	else
        return FALSE;

}


/*
	Created...: 2005.09.13
	Changed...: 
	By........: Jeza
	Desription: Remove BANNED IP.
*/
VOID DelBan ( )
{

	sqlite3 *db;
	CHAR *zErrMsg = 0;
	INT rc;
	CHAR buff[256] = {0};
	
	var.sql.bIsBanned = FALSE;
	var.sql.bDelBan = TRUE;

	sqlite3_open(jScripts_default_ban_db, &db);

	sprintf(buff, "SELECT IP FROM BANS WHERE IP = '%s';", var.user.ip);

	rc = sqlite3_exec(db, buff, callback, 0, &zErrMsg);

	var.sql.bDelBan = FALSE;

	if ( var.sql.bIsBanned )
	{
		
		sprintf(buff, "DELETE FROM BANS WHERE IP = '%s';", var.user.ip);
		rc = sqlite3_exec(db, buff, callback, 0, &zErrMsg);

		printf(FormatString(jScripts_site_ban_del, 0));
	}
	else
	{
		printf(FormatString(jScripts_site_ban_notfound, 0));
	}

	sqlite3_close(db);

}

/*
	Created...: 2005.09.18
	Changed...: 
	By........: Jeza
	Desription: SITE ADDMASTER <UserName>.
*/
VOID AddMaster ( _TCHAR* argv[] )
{
	if ( (argv[2] != NULL) && (strcmp(strupr(argv[1]), "ADDMASTER") == 0) )
	{

		int UID = ResolveUserNameToUid(argv[2]);

		if ( UID > -1 )
		{
			if ( AddFlag(UID, "M") )
				printf(FormatString(jScripts_site_addmaster_success, 0));
			else
				printf(FormatString(jScripts_site_addmaster_failed, 0));
		}
		else
		{
			printf(FormatString(jScripts_site_addmaster_notfound, 0));
		}
		
	}
	else
	{
		printf(FormatString(jScripts_site_addmaster_help, 0));
	}
}

/*
	Created...: 2005.09.18
	Changed...: 
	By........: Jeza
	Desription: SITE DELMASTER <UserName>.
*/
VOID DelMaster ( _TCHAR* argv[] )
{
	if ( (argv[2] != NULL) && (strcmp(strupr(argv[1]), "DELMASTER") == 0) )
	{

		int UID = ResolveUserNameToUid(argv[2]);

		if ( UID > -1 )
		{
			if ( DelFlag(UID, 'M') )
				printf(FormatString(jScripts_site_delmaster_success, 0));
			else
				printf(FormatString(jScripts_site_delmaster_failed, 0));
		}
		else
		{
			printf(FormatString(jScripts_site_delmaster_notfound, 0));
		}
		
	}
	else
	{
		printf(FormatString(jScripts_site_delmaster_help, 0));
	}
}

/*
	Created...: 2005.09.18
	Changed...: 
	By........: Jeza
	Desription: SITE SHOW <UserName>.
*/
VOID SiteShow ( _TCHAR* argv[] )
{
	if ( (argv[2] != NULL) && (strcmp(strupr(argv[1]), "SHOW") == 0) )
	{

		int UserId = ResolveUserNameToUid(argv[2]);

		if ( UserId > -1 )
		{

			FILE		*input;
			char		data[READLINE];
			
			char*UserFile = (char *)calloc(strlen(jScripts_default_user_files)+4+1, sizeof(char));

			sprintf(UserFile, "%s%i", jScripts_default_user_files, UserId);

			if ((input = fopen(UserFile, "r+")) != NULL )
			{
				
				while (1)
				{
					fgets(data, READLINE, input);

					if (feof(input) != 0)
						break;

					printf("%s",data);
				}
				
				fclose(input);

			}

			free(UserFile);

		}
		else
		{
			printf(FormatString(jScripts_site_show_notfound, 0));
		}
		
	}
	else
	{
		printf(FormatString(jScripts_site_show_help, 0));
	}
}

/*
	Created...: 2005.09.18
	Changed...: 
	By........: Jeza
	Desription: SITE SHOW <UserName>.
*/
VOID SiteUser ( _TCHAR* argv[] )
{
	if ( (argv[2] != NULL) && (strcmp(strupr(argv[1]), "USER") == 0) )
	{

		int UserId = ResolveUserNameToUid(argv[2]);

		if ( UserId > -1 )
		{
			BOOL bOK				= FALSE;

			PUSERFILE pUserFile		= (PUSERFILE)lpMessage->lpContext;
			lpMessage->dwIdentifier	= DC_USERFILE_OPEN;
			
			pUserFile->Uid			= UserId;

			if ( !SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory) )
			{
				// Wait until processed (5 secs)
				if ( WaitForSingleObject(hEvent, 5000) == WAIT_TIMEOUT ) 
					goto s_DONE;

				bOK									= TRUE;

				BOOL bFlags							= FALSE;	//siteop can see all users
				BOOL bGadmin						= FALSE;	//gadmin can see users from own group
				BOOL bUser							= FALSE;	//normal user can see only own userinfo

				if ( (CompareFlags(var.env.flags, jScripts_user_power_flags)) || (CompareStrings(jScripts_user_power_users, var.env.user, " ", TRUE)) || (CompareStrings(jScripts_user_power_groups, var.env.group, " ", TRUE)) )
					bFlags		= TRUE;


				if ( strcmp(argv[2], var.env.user) == 0 )
					bUser		= TRUE;

				if ( CheckGadmin(var.env.uid, UserId) )
					bGadmin		= TRUE;
/*
				if ( bUser )
					printf("+bUser\n");
				else
					printf("-bUser\n");

				if ( bGadmin )
					printf("+bGadmin\n");
				else
					printf("-bGadmin\n");

				if ( bFlags )
					printf("+bFlags\n");
				else
					printf("-bFlags\n");
*/
				if ( !bFlags && !bGadmin && !bUser)
				{
					printf(FormatString(jScripts_site_user_not_allowed, 0));
					goto s_FIN;
				}

				short i								= 0;
				//int UserId							= pUserFile->Uid;
				int GroupId							= pUserFile->Gid;
				char GroupName[GROUPNAME_LENGTH]	= {0};

				GetGroupName(UserId, GroupName);

				printf(" ------------------------------------------------------------------------------------------ \n" );
				printf(" USERNAME.............: %-15.15s  GROUPNAME............: %-15.15s \n", argv[2], GroupName);
				if ( bFlags )
					printf(" UID..................: %-15i  GID..................: %-15i \n", UserId, GroupId );
				//if ( bFlags || bUser )
					printf(" FLAGS................: %-15s  FTP LOGiNS...........: %-15i \n", pUserFile->Flags, pUserFile->Limits[3] );
				if ( bFlags )
					printf(" HTTP LOGiNS..........: %-15i  TELNET LOGiNS........: %-15i \n", pUserFile->Limits[4], pUserFile->Limits[2] );
				if ( pUserFile->Ratio[0] == 0 )
					printf(" RATiO................: Unlimited        CREDiTS..............: %i MB \n", pUserFile->Credits[0]/1024 );
				else
					printf(" RATiO................: %-15i  CREDiTS..............: %i MB \n", pUserFile->Ratio[0], pUserFile->Credits[0]/1024 );
				printf(" UPLOAD SPEED LiMiT...: %-15i  DOWNLOAD SPEED LiMiT.: %-15i \n", pUserFile->Limits[1], pUserFile->Limits[0] );
				
				//printf(" LOGiN COUNT..........: %-15i  LAST LOGiN...........: 2005-09-18 13:03:04 \n"  );
				sqlite3 *db;
				CHAR *zErrMsg = 0;
				INT rc;
				CHAR buff[256] = {0};
				
				var.sql.bUserExists = FALSE;
				
				sprintf(buff, "SELECT LoginCount, LastLogin FROM USERS WHERE UserName = '%s'", argv[2]);

				debug(".......: SELECT LoginCount, LastLogin FROM USERS WHERE UserName = '%s'\n", argv[2]);

				sqlite3_open(jScripts_default_user_db, &db);

				var.sql.bSiteUser = TRUE;

				rc = sqlite3_exec(db, buff, callback, 0, &zErrMsg);

				var.sql.bSiteUser = FALSE;

				if ( !var.sql.bUserExists )
				{

					printf(" LOGiN COUNT..........: 0                LAST LOGiN...........: - \n");
					printf(" ADDED BY.............: System           DATE ADDED...........: - \n");

				}
				else
				{
				
					sprintf(buff, "SELECT AddedBy, DateAdded FROM USERS WHERE UserName = '%s'", argv[2]);

					debug(".......: SELECT AddedBy, DateAdded FROM USERS WHERE UserName = '%s'\n", argv[2]);

					var.sql.bAddedBy = TRUE;
					
					rc = sqlite3_exec(db, buff, callback, 0, &zErrMsg);

					var.sql.bAddedBy = FALSE;
					
				}

				var.sql.bUserExists = FALSE;

				sqlite3_close(db);

				printf(" TAGLiNE..............: %s \n", pUserFile->Tagline );
				if ( bFlags )
					printf(" VFS..................: %s \n", pUserFile->MountFile );
				if ( bFlags || bUser )
					printf(" HOME.................: %s \n", pUserFile->Home );
				if ( bFlags || bUser )
				{
					CHAR GroupList[1024]	= {0};
					for ( i = 0 ; ( (i<MAX_GROUPS) && (pUserFile->Groups[i] > -1) ) ; i++ )
					{
						INT GID							= pUserFile->Groups[i];
						CHAR Group[GROUPNAME_LENGTH]	= {0};

						sprintf(Group, jScripts_default_group);
						ResolveGidToGroupName(GID, Group);

						strcat(GroupList, Group);
						strcat(GroupList, " ");
					}

					printf(" GROUPS...............: %s\n", GroupList);
				}
				if ( bFlags || bUser )
				{
					CHAR AdmGroupList[1024]	= {0};
					for ( i = 0 ; ( (i<MAX_GROUPS) && (pUserFile->AdminGroups[i] > -1) ) ; i++ )
					{
						INT AdmGID							= pUserFile->AdminGroups[i];
						CHAR AdmGroup[GROUPNAME_LENGTH]		= {0};

						sprintf(AdmGroup, jScripts_default_group);
						ResolveGidToGroupName(AdmGID, AdmGroup);

						strcat(AdmGroupList, AdmGroup);
						strcat(AdmGroupList, " ");
					}

					printf(" ADMiN GROUPS.........: %s\n", AdmGroupList);
				}
				printf(" ------------------------------------------------------------------------------------------ \n" );

				for (i=0;(i<=MAX_IPS) && ( (strlen(pUserFile->Ip[i]) > 0) || (strlen(pUserFile->Ip[i+1]) > 0) );i+=2)
				{
					printf(" %-39s %-39s\n", pUserFile->Ip[i], pUserFile->Ip[i+1]);
				}

				printf(" ------------------------------------------------------------------------------------------ \n" );
				printf(" SECTiON ' RATiO ' CREDiTS ' ALLUP ' ALLDN '  MNUP '  MNDN '  WKUP '  WKDN ' DAYUP ' DAYDN \n");
				printf(" ------------------------------------------------------------------------------------------ \n" );
				for (i=0;i<jScripts_user_number_of_sections;i++)
				{
					
					char Credits[5];	sprintf(Credits,	FormatUserSize(pUserFile->Credits[i]));
					char AllUp[5];		sprintf(AllUp,		FormatUserSize(pUserFile->AllUp[3*i+1]));
					char AllDn[5];		sprintf(AllDn,		FormatUserSize(pUserFile->AllDn[3*i+1]));
					char MonthUp[5];	sprintf(MonthUp,	FormatUserSize(pUserFile->MonthUp[3*i+1]));
					char MonthDn[5];	sprintf(MonthDn,	FormatUserSize(pUserFile->MonthDn[3*i+1]));
					char WkUp[5];		sprintf(WkUp,		FormatUserSize(pUserFile->WkUp[3*i+1]));
					char WkDn[5];		sprintf(WkDn,		FormatUserSize(pUserFile->WkDn[3*i+1]));
					char DayUp[5];		sprintf(DayUp,		FormatUserSize(pUserFile->DayUp[3*i+1]));
					char DayDn[5];		sprintf(DayDn,		FormatUserSize(pUserFile->DayDn[3*i+1]));

					printf(" %7.7s ' %5i ' %7.7s ' %5.5s ' %5.5s ' %5.5s ' %5.5s ' %5.5s ' %5.5s ' %5.5s ' %5.5s\n", jScripts_user_section[i],  pUserFile->Ratio[i], Credits, AllUp, AllDn, MonthUp, MonthDn, WkUp, WkDn, DayUp, DayDn);

				}
				printf(FormatString(" -------------------------------------------------------=[ jS $script_version$ by Jeza (C) 2006 ]=-- \n", 0) );

			}

			lpMessage->dwIdentifier	= DC_USERFILE_CLOSE;;
			
			if ( !SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory) )
			{
				if ( WaitForSingleObject(hEvent, 5000) == WAIT_TIMEOUT ) goto s_DONE;
			}
			
			s_DONE:

			if ( !bOK )
				printf(FormatString(jScripts_site_user_failed, 0));
		}
		else
		{
			printf(FormatString(jScripts_site_user_notfound, 0));
		}
		
	}
	else
	{
		printf(FormatString(jScripts_site_user_help, 0));
	}

	s_FIN:
		debug("s_FIN..: SITE USER %s\n", argv[2]);

}

/*
	Created...: 2005.09.20
	Changed...: 
	By........: Jeza
	Desription: SITE NFO.
				Shows All .nfo Files To Client in Dir
*/
VOID SiteNFO( )
{

	WIN32_FIND_DATA	FindFileData;
	HANDLE hFind					= INVALID_HANDLE_VALUE;
	CHAR DirSpec[MAX_PATH];
	DWORD dwError;
	LPVOID lpMsgBuf;
	  
	strncpy (DirSpec, var.env.path, strlen(var.env.path)+1);
	strncat (DirSpec, "\\*.nfo", 7);
	  
	hFind = FindFirstFile(DirSpec, &FindFileData);

	if (hFind != INVALID_HANDLE_VALUE) 
	{
		dwError = GetLastError();

		FormatMessage(
			FORMAT_MESSAGE_ALLOCATE_BUFFER | 
			FORMAT_MESSAGE_FROM_SYSTEM,
			NULL,
			dwError,
			MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
			(LPTSTR) &lpMsgBuf,
			0, NULL );

		if (dwError == ERROR_NO_MORE_FILES) 
		{
			FindClose(hFind);
		}
		else 
		{
			debug("\n -[ SiteNFOe -> %s\n -[ ERROR %u\n -[ %s\n", var.env.path, dwError, lpMsgBuf);
			FindClose(hFind);
		}

		//sprintf(var.file.sfv_file,"%s\\%s",input,FindFileData.cFileName);
		//CHAR NFO[MAX_PATH+FILEMAX] = {0};
		HANDLE hNFOFile;
		DWORD dwBytesRead;
		char buffer[BUFSIZE]; 

		char *NFO = (char *)calloc(MAX_PATH+1, sizeof(char));
		
		sprintf(NFO, "%s\\%s", var.env.path, FindFileData.cFileName);

		// Open the existing file. 
		hNFOFile = CreateFile(NFO,					   // file name 
							GENERIC_READ,          // open for reading 
							0,                     // do not share 
							NULL,                  // default security 
							OPEN_EXISTING,         // existing file only 
							FILE_ATTRIBUTE_NORMAL, // normal file 
							NULL);                 // no template 
		
		free(NFO);

		if (hNFOFile != INVALID_HANDLE_VALUE) 
		{ 
			// Read BUFSIZE blocks to the buffer. 
			do 
			{
				if (ReadFile(hNFOFile, 
							buffer, 
							BUFSIZE, 
							&dwBytesRead, 
							NULL)) 
				{ 
					printf("%s\n", buffer);
				} 
			} while (dwBytesRead == BUFSIZE); 

			CloseHandle (hNFOFile);

		} 
//
	}

}

/*
	Created...: 2005.10.03
	Changed...: 
	By........: Jeza
	Desription: Increase LoginCound and change LastLogin.
*/
VOID OnFtpLogIn ()
{

	sqlite3 *db;
	CHAR *zErrMsg = 0;
	INT rc;
	CHAR buff[DUPEBUFF] = { 0 };

	var.sql.bOnFtpLogin = TRUE;
	var.sql.bUserExists = FALSE;
	
	sqlite3_open(jScripts_default_user_db, &db);

	sprintf(buff, "SELECT LoginCount FROM USERS WHERE UserName = '%s';", var.env.user);

	debug(".......: SELECT LoginCount FROM USERS WHERE UserName = '%s';\n", var.env.user);

	rc = sqlite3_exec(db, buff, callback, 0, &zErrMsg);

	var.sql.bOnFtpLogin = FALSE;

	if ( var.sql.bUserExists )
	{

		sprintf(buff, "UPDATE USERS SET LoginCount = %i WHERE UserName = '%s';", var.sql.iCount+1, var.env.user);

		debug(".......: UPDATE USERS SET LoginCount = %i WHERE UserName = '%s';\n", var.sql.iCount+1, var.env.user);

		rc = sqlite3_exec(db, buff, callback, 0, &zErrMsg);

		time_t now;

		sprintf(buff, "UPDATE USERS SET LastLogin = %d WHERE UserName = '%s';", (DWORD)time(&now), var.env.user);

		debug(".......: UPDATE USERS SET LastLogin = %d WHERE UserName = '%s';\n", (DWORD)time(&now), var.env.user);

		rc = sqlite3_exec(db, buff, callback, 0, &zErrMsg);

		sqlite3_close(db);

	} 
	else
	{
	
		time_t now;

		sprintf(buff, "INSERT INTO USERS (UserName, DateAdded, AddedBy, LoginCount, LastLogin) VALUES ('%s', %i, 'System', 0, 0)"
						, var.env.user, (DWORD)time(&now));

		debug(".......: INSERT INTO USERS (UserName, DateAdded, AddedBy, LoginCount, LastLogin) VALUES ('%s', %i, 'System', 0, 0);\n"
						, var.env.user, (DWORD)time(&now));

		rc = sqlite3_exec(db, buff, callback, 0, &zErrMsg);

		sqlite3_close(db);

	}

}

/*
	Created...: 2005.10.03
	Changed...: 
	By........: Jeza
	Desription: Add DateAdded, ... to USERS TABLE.
*/
VOID AddUser ( _TCHAR* argv[] )
{

	sqlite3 *db;
	CHAR *zErrMsg = 0;
	INT rc;
	CHAR buff[DUPEBUFF] = { 0 };
	time_t now;

	sqlite3_open(jScripts_default_user_db, &db);

	sprintf(buff, "INSERT INTO \
					USERS (UserName, GroupName, GID, DateAdded, AddedBy, LoginCount, LastLogin) \
					VALUES ('%s', '%s', %i, %i, '%s', 0, 0)" \
					, argv[2], var.env.group, var.env.gid, (DWORD)time(&now), var.env.user);

	debug ("AddUser : %s\n", buff);

	rc = sqlite3_exec(db, buff, callback, 0, &zErrMsg);

	sqlite3_close(db);

}

/*
	Created...: 2005.10.23
	Changed...: 
	By........: Jeza
	Desription: UPDATES DateAdded In Users TABLE.
*/
VOID UpdateDateAdded ( _TCHAR* argv[] )
{

	sqlite3 *db;
	CHAR *zErrMsg = 0;
	INT rc;
	CHAR buff[DUPEBUFF] = { 0 };
	time_t now;

	sqlite3_open(jScripts_default_user_db, &db);

	sprintf(buff, "UPDATE USERS\
					SET DateAdded = %i \
					WHERE UserName = '%s'" \
					, (DWORD)time(&now), argv[2]);

	debug ("UpdateDateAdded : %s\n", buff);

	rc = sqlite3_exec(db, buff, callback, 0, &zErrMsg);

	sqlite3_close(db);

}

/*
	Created...: 2005.10.03
	Changed...: 
	By........: Jeza
	Desription: Add DateAdded, ... to USERS TABLE.
*/
VOID GAddUser ( _TCHAR* argv[] )
{

	sqlite3 *db;
	CHAR *zErrMsg = 0;
	INT rc;
	CHAR buff[DUPEBUFF] = { 0 };
	time_t now;

	sqlite3_open(jScripts_default_user_db, &db);

	sprintf(buff, "INSERT INTO USERS (UserName, GroupName, GID, DateAdded, AddedBy, LoginCount, LastLogin) VALUES ('%s', '%s', %i, %i, '%s', 0, 0)"
					, argv[3], var.env.group, var.env.gid, (DWORD)time(&now), var.env.user);

	debug(".......: INSERT INTO USERS (UserName, GroupName, GID, DateAdded, AddedBy, LoginCount, LastLogin) VALUES ('%s', '%s', %i, %i, '%s', 0, 0)\n"
					, argv[3], var.env.group, var.env.gid, (DWORD)time(&now), var.env.user);

	//debug ("GAddUser : %s\n", buff);

	rc = sqlite3_exec(db, buff, callback, 0, &zErrMsg);

	sqlite3_close(db);

}

/*
	Created...: 2006.02.01
	Changed...: 
	By........: Jeza
	Desription: Change Number Of Users In Group.
				jScripts.exe CHANGEUSERS iND 23
				Will change Number Of Users in Group Ind To 23
*/
BOOL UpdateUsersInGroup ( _TCHAR* argv[] )
{

	if ( (argv[2] != NULL) && (strcmp(strupr(argv[1]), "CHANGEUSERS") == 0) )
	{

		int GID = ResolveGroupNameToGid(argv[2]);

		if ( GID > -1 )
		{
			if ( UpdateGroupUsers(GID, atoi(argv[3])) )
				return TRUE;
			else
				return FALSE;
		}
		else
		{
			return FALSE;
		}
		
	}
	else
	{
		return FALSE;
	}
}

/*
	Created...: 2006.02.05
	Changed...: 
	By........: Jeza
	Desription: DUPE NEWDIR.
				Checks if dir is in dupe DB.
				if yes return FALSE else add to DB and return TRUE
*/
BOOL CheckDupeNEWDIR ( _TCHAR* argv[] )
{

	debug("START..: CheckDupeNEWDIR\n");
	
	debug(".......: Check If Skip Path\n");

	if ( CompareStrings (jScripts_dupe_newdir_skip, var.env.virtualpath, " ", FALSE) )
	{
		
		debug(".......: Skip Path '%s' Because '%s'\n", var.env.virtualpath, jScripts_dupe_newdir_skip);

		return TRUE;

	}

	_TCHAR DirName[256] = {0};

	debug(".......: Find Release Name :: PathFindFileName('%s')\n", argv[2]);

	StrCpy(DirName, PathFindFileName(argv[2]));

	if ( DirName == NULL)
	{
		debug(".......: Release Name Not Found\n");
		
		return TRUE;
	}
	
	debug(".......: Release Name Is '%s'\n", DirName);

	debug(".......: Check If Skip Release Name\n");

	if ( CompareStrings (jScripts_dupe_release_skip, DirName, " ", FALSE) )
	{
		
		debug(".......: Skip Release Name '%s' Because '%s'\n", DirName, jScripts_dupe_release_skip);

		return TRUE;

	}

	sqlite3 *db;
	CHAR *zErrMsg = 0;
	INT rc;
	CHAR buff[DUPEBUFF] = {0};
	
	var.sql.bDupe			= FALSE;
	var.sql.bCheckDirDupe	= TRUE;

	sqlite3_open(jScripts_default_dupe_dir_db, &db);

	debug(".......: SELECT DISTINCT ReleaseTime, UserName FROM DIRDUPE WHERE ReleaseName = '%s';\n", DirName);

	sprintf(buff, "SELECT DISTINCT ReleaseTime, UserName FROM DIRDUPE WHERE ReleaseName = '%s';", DirName);

	rc = sqlite3_exec(db, buff, callback, 0, &zErrMsg);

	sqlite3_close(db);
	
	var.sql.bCheckDirDupe	= FALSE;

	debug("STOP...: CheckDupeNEWDIR\n");

	if ( !var.sql.bDupe )	
	{
		
		debug(".......: Add Release Name To Dir DUPE DB\n");

		zErrMsg = 0;

		_TCHAR buf[DUPEBUFF] = {0};

		sqlite3_open(jScripts_default_dupe_dir_db, &db);

		time_t now;

		debug(".......: INSERT INTO DIRDUPE \
						(ReleaseTime, ReleaseName, Pwd, UserName, GroupName) \
						VALUES(%d, '%s', '%s', '%s', '%s');\n", 
						(DWORD)time(&now), DirName, argv[3], 
						var.env.user, var.env.group);

		sprintf(buf, "INSERT INTO DIRDUPE \
						(ReleaseTime, ReleaseName, Pwd, UserName, GroupName) \
						VALUES(%d, '%s', '%s', '%s', '%s');", 
						(DWORD)time(&now), DirName, argv[3], 
						var.env.user, var.env.group);

		rc = sqlite3_exec(db, buf, callback, 0, &zErrMsg);
		
		debug(".......: rc = sqlite3_exec(db, buf, callback, 0, &zErrMsg) = %i '%s'\n", rc, sqlite3_errmsg(db));

		if( rc != SQLITE_OK )
		{

			debug(".......: SQL error: %s, %s\n", zErrMsg, sqlite3_errmsg(db));
		
		}
		
		sqlite3_close(db);

		return TRUE;

	}
	else
	{
		return FALSE;
	}
}

/*
	Created...: 2006.02.05
	Changed...: 
	By........: Jeza
	Desription: DUPE DELDIR.
				Removes Release Name From DB.
*/
BOOL DupeDELDIR ( _TCHAR* argv[] )
{

	debug("START..: DupeDELDIR\n");
	
	debug(".......: Check If Skip Path\n");

	if ( CompareStrings (jScripts_dupe_newdir_skip, var.env.virtualpath, " ", FALSE) )
	{
		
		debug(".......: Skip Path '%s' Because '%s'\n", var.env.virtualpath, jScripts_dupe_newdir_skip);

		return TRUE;

	}

	_TCHAR DirName[1024] = {0};

	debug(".......: Find Release Name :: PathFindFileName('%s')\n", argv[2]);

	StrCpy(DirName, PathFindFileName(argv[2]));

	if ( DirName == NULL)
	{
		debug(".......: Release Name Not Found\n");
		
		return TRUE;
	}
	
	debug(".......: Release Name Is '%s'\n", DirName);

	debug(".......: Check If Skip Release Name\n");

	if ( CompareStrings (jScripts_dupe_release_skip, DirName, " ", FALSE) )
	{
		
		debug(".......: Skip Release Name '%s' Because '%s'\n", DirName, jScripts_dupe_release_skip);

		return TRUE;

	}

	sqlite3 *db;
	CHAR *zErrMsg = 0;
	INT rc;
	CHAR buff[DUPEBUFF] = {0};
	
	var.sql.bDupe			= FALSE;
	var.sql.bCheckDirDupe	= TRUE;

	sqlite3_open(jScripts_default_dupe_dir_db, &db);

	debug(".......: DELETE FROM DIRDUPE WHERE ReleaseName = '%s';\n", DirName);

	sprintf(buff, "DELETE FROM DIRDUPE WHERE ReleaseName = '%s';", DirName);

	rc = sqlite3_exec(db, buff, callback, 0, &zErrMsg);

	sqlite3_close(db);
	
	var.sql.bCheckDirDupe	= FALSE;

	debug("STOP...: DupeDELDIR\n");

	return TRUE;

}

/*
	Created...: 2006.02.05
	Changed...: 
	By........: Jeza
	Desription: Shows DUPE.
				jScripts.exe DUPE SearchString.
*/
BOOL ShowDupe ( _TCHAR* argv[] )
{

	debug("START..: ShowDupe\n");
	
	sqlite3 *db;
	CHAR *zErrMsg = 0;
	INT rc;
	CHAR buff[DUPEBUFF] = {0};
	
	printf(FormatString(jScripts_dupe_show_head, 0));
	
	var.sql.bFindDupe = TRUE;

	var.sql.DupeFoundCount = 0;

	sqlite3_open(jScripts_default_dupe_dir_db, &db);

	debug(".......: SELECT DISTINCT ReleaseTime, Pwd FROM DIRDUPE WHERE Pwd LIKE '%%%s%%' ORDER BY ReleaseTime DESC;\n", argv[2]);

	sprintf(buff, "SELECT DISTINCT ReleaseTime, Pwd FROM DIRDUPE WHERE Pwd LIKE '%%%s%%' ORDER BY ReleaseTime DESC;", argv[2]);

	rc = sqlite3_exec(db, buff, callback, 0, &zErrMsg);

	var.sql.bFindDupe = FALSE;

	var.sql.bCountDupes = TRUE;

	debug(".......: SELECT DISTINCT Count(*) FROM DIRDUPE;\n");

	sprintf(buff, "SELECT DISTINCT Count(*) FROM DIRDUPE");

	rc = sqlite3_exec(db, buff, callback, 0, &zErrMsg);

	var.sql.bCountDupes = FALSE;

	sqlite3_close(db);

	printf(FormatString(jScripts_dupe_show_foot, 0));
	
	debug("STOP...: ShowDupe\n");

	return TRUE;

}

/*
	Created...: 2006.04.30
	Changed...: 
	By........: Jeza
	Desription: Imports Dirnames to DUPE DB.
*/
VOID ImportDirNamesToDB ( _TCHAR Path[MAX_PATH], _TCHAR Pwd[MAX_PATH], INT iLevel )
{

	debug("START..: ImportDirNamesToDB <> Level = %i '%s' '%s'\n", iLevel, Path, Pwd);
	
	WIN32_FIND_DATA					FindFileData;
	HANDLE hFind					= INVALID_HANDLE_VALUE;
	_TCHAR							DirSpec[MAX_PATH];
	DWORD							dwError;

	strncpy (DirSpec, Path, strlen(Path)+1);
	strncat (DirSpec, "\\*", 3);

	//debug(".......: DirSpec = '%s'\n", DirSpec);

	hFind = FindFirstFile(DirSpec, &FindFileData);

	if (hFind != INVALID_HANDLE_VALUE) 
	{

		printf("!buffer off\n");
		
		//debug(".......: <> %s\n", FindFileData.cFileName);

		if ( FindFileData.cFileName[0] != '.' )
		{
			
			_TCHAR *DirName	= (_TCHAR *)calloc(MAX_PATH+MAX_FILE, sizeof(_TCHAR));
			sprintf(DirName, "%s\\%s", Path, FindFileData.cFileName);
			
			if ( PathIsDirectory(DirName) )
			{

				PathRemoveBackslash(DirName);

				//PathFindFileName(DirName);

				printf("-> '%s'\n", PathFindFileName(DirName));

				if ( iLevel > 1 )
				{
					
					_TCHAR *PwdDirName	= (_TCHAR *)calloc(MAX_PATH+MAX_FILE, sizeof(_TCHAR));
					sprintf(PwdDirName, "%s/%s", Pwd, FindFileData.cFileName);
					
					ImportDirNamesToDB ( DirName, PwdDirName, iLevel - 1 );

					free(PwdDirName);
				}
				else
				{

					time_t now;

					sqlite3 *db;
					CHAR *zErrMsg = 0;
					INT rc;
					CHAR buff[DUPEBUFF] = {0};
					
					sprintf(buff, "INSERT INTO DIRDUPE \
								(ReleaseTime, ReleaseName, Pwd, UserName, GroupName) \
								VALUES(%d, '%s', '%s%s', '%s', '%s');", 
								(DWORD)time(&now), PathFindFileName(DirName), 
								var.env.virtualpath, PathFindFileName(DirName), 
								jScripts_default_user, jScripts_default_group);

					debug(buff);

					sqlite3_open(jScripts_default_dupe_dir_db, &db);
					rc = sqlite3_exec(db, buff, callback, 0, &zErrMsg);
					sqlite3_close(db);

				}
	
			}
			else
			{
				ErrorPrint(DirName);
			}

			free(DirName);
			
		}
				
	}
	else
	{
		debug(".......: hFind == INVALID_HANDLE_VALUE");
	}

	while (FindNextFile(hFind, &FindFileData) != 0) 
	{
		if ( FindFileData.cFileName[0] != '.' )
		{

			_TCHAR *DirName	= (_TCHAR *)calloc(MAX_PATH+MAX_FILE+2, sizeof(_TCHAR));
			sprintf(DirName, "%s\\%s\\", var.env.path, FindFileData.cFileName);

			//debug(".......: DirName '%s'\n", DirName);

			//ErrorPrint("vmes");

			if ( PathIsDirectory(DirName) )
			{

				//ErrorPrint("jeIDR");

				//debug(".......: DIR: %s\n", FindFileData.cFileName);

				PathRemoveBackslash(DirName);

				//PathFindFileName(DirName);

				printf("-> '%s'\n", PathFindFileName(DirName));

				if ( iLevel > 1 )
				{
					
					_TCHAR *PwdDirName	= (_TCHAR *)calloc(MAX_PATH+MAX_FILE, sizeof(_TCHAR));
					sprintf(PwdDirName, "%s/%s", Pwd, FindFileData.cFileName);
					
					ImportDirNamesToDB ( DirName, PwdDirName, iLevel - 1 );

					free(PwdDirName);
				}
				else
				{

					time_t now;

					sqlite3 *db;
					CHAR *zErrMsg = 0;
					INT rc;
					CHAR buff[DUPEBUFF] = {0};
					
					sprintf(buff, "INSERT INTO DIRDUPE \
								(ReleaseTime, ReleaseName, Pwd, UserName, GroupName) \
								VALUES(%d, '%s', '%s%s', '%s', '%s');", 
								(DWORD)time(&now), PathFindFileName(DirName), 
								var.env.virtualpath, PathFindFileName(DirName), 
								jScripts_default_user, jScripts_default_group);

					debug(buff);

					sqlite3_open(jScripts_default_dupe_dir_db, &db);
					rc = sqlite3_exec(db, buff, callback, 0, &zErrMsg);
					sqlite3_close(db);

				}
		
			}
			else
			{
				ErrorPrint(DirName);
			}

			free(DirName);

		}

	}

	dwError = GetLastError();

//	debug(".......: dwError (%u) '%s'\n", dwError, var.env.path);

	ErrorPrint("ImportDirNamesToDB");
	
	FindClose(hFind);
/*
	if (dwError == ERROR_NO_MORE_FILES) 
	{
		
		FindClose(hFind);
	}
	else 
	{
		debug(".......: ImportDirNamesToDB ERROR (%u) '%s'\n", dwError, var.env.path);

		FindClose(hFind);

	}
*/
	debug("STOP...: ImportDirNamesToDB <> Level = %i\n", iLevel);
	
}

/*
	Created...: 2006.02.06
	Changed...: 2006.04.30 (added level)
	By........: Jeza
	Desription: Imports DUPE only for FTP.
				jScripts.exe DUPEIMPORT LEVEL
*/
BOOL ImportDupe ( INT argc, _TCHAR* argv[] )
{

	debug("START..: ImportDupe\n");
	
	WIN32_FIND_DATA					FindFileData;
	HANDLE hFind					= INVALID_HANDLE_VALUE;
	_TCHAR							DirSpec[MAX_PATH];
	DWORD							dwError;
	INT iLevel = 1;

	if ( (argc = 3) )
	{
		iLevel = atoi(argv[2]);
	}

	strncpy (DirSpec, var.env.path, strlen(var.env.path)+1);
	strncat (DirSpec, "\\*", 3);

	hFind = FindFirstFile(DirSpec, &FindFileData);

	if (hFind != INVALID_HANDLE_VALUE) 
	{

		//printf("!buffer off\n");
		
		if ( FindFileData.cFileName[0] != '.' )
		{
			
			_TCHAR *DirName	= (_TCHAR *)calloc(MAX_PATH+MAX_FILE, sizeof(_TCHAR));
			sprintf(DirName, "%s\\%s", var.env.path, FindFileData.cFileName);
			
			if ( PathIsDirectory(DirName) )
			{

				PathRemoveBackslash(DirName);

				//PathFindFileName(DirName);

				printf("-> '%s'\n", PathFindFileName(DirName));

				//ImportDirNamesToDB ( DirName, var.env.virtualpath, iLevel );
				ImportDirNamesToDB ( "D:\\movies", "/movies/", 1 );

			}

			free(DirName);
			
		}
				
	}

	while (FindNextFile(hFind, &FindFileData) != 0) 
	{
		if ( FindFileData.cFileName[0] != '.' )
		{

			_TCHAR *DirName	= (_TCHAR *)calloc(MAX_PATH+MAX_FILE+2, sizeof(_TCHAR));
			sprintf(DirName, "%s\\%s\\", var.env.path, FindFileData.cFileName);

			if ( PathIsDirectory(DirName) )
			{

				PathRemoveBackslash(DirName);

				//PathFindFileName(DirName);

				printf("-> '%s'\n", PathFindFileName(DirName));

				//ImportDirNamesToDB ( DirName, var.env.virtualpath, iLevel );
				ImportDirNamesToDB ( "D:\\movies", "/movies/", 1 );

			}

			free(DirName);

		}

	}

	dwError = GetLastError();

	ErrorPrint("ImportDupe");

	FindClose(hFind);

/*
	if (dwError == ERROR_NO_MORE_FILES) 
	{
		
		FindClose(hFind);
	}
	else 
	{
		debug(".......: ImportDupe ERROR (%u) '%s'\n", dwError, var.env.path);

		FindClose(hFind);

	}
*/
	debug("STOP...: ImportDupe\n");

	return TRUE;

}


/*
	Created...: 2006.02.08
	Changed...: 
	By........: Jeza
	Desription: UNDUPE.
				jScripts.exe UNDUPE ReleaseName.
*/
BOOL UnDupe ( _TCHAR* argv[] )
{

	debug("START..: UnDupe\n");
	
	sqlite3 *db;
	CHAR *zErrMsg = 0;
	INT rc;
	CHAR buff[DUPEBUFF] = {0};
	
	sqlite3_open(jScripts_default_dupe_dir_db, &db);

	var.sql.bCountDupes = TRUE;

	debug(".......: SELECT Count(*) FROM DIRDUPE WHERE ReleaseName = '%s';\n", argv[2]);

	sprintf(buff, "SELECT Count(*) FROM DIRDUPE WHERE ReleaseName = '%s';", argv[2]);

	debug(".......: Count = %i\n", var.sql.DupeTotalCount);

	rc = sqlite3_exec(db, buff, callback, 0, &zErrMsg);

	var.sql.bCountDupes = FALSE;

	if ( var.sql.DupeTotalCount > 0 )
	{

		//var.sql.bFindUnDupe = TRUE;

		//var.sql.UnDupeFoundCount = 0;

		debug(".......: DELETE FROM DIRDUPE WHERE ReleaseName = '%s';\n", argv[2]);

		sprintf(buff, "DELETE FROM DIRDUPE WHERE ReleaseName = '%s';", argv[2]);

		rc = sqlite3_exec(db, buff, callback, 0, &zErrMsg);

		//var.sql.bFindUnDupe = FALSE;

	}
	
	sqlite3_close(db);

	debug("STOP...: UnDupe\n");

	if ( var.sql.DupeTotalCount > 0 )
	{
		return TRUE;
	}
	else
	{
		return FALSE;
	}

}

/*
	Created...: 2006.02.25
	Changed...: 
	By........: Jeza
	Desription: Show Help To User.
				jScripts.exe -HELP
*/
BOOL ShowHelp ( )
{

	printf("\n" \
			"jScripts.exe HELP\n" \
			"jScripts.exe FREESPACE\n" \
			"jScripts.exe WHO WHO\n"  \
			"jScripts.exe WHO bw\n"  \
			"jScripts.exe WHO all\n"  \
			"jScripts.exe WHO idle\n"  \
			"jScripts.exe WHO down\n"  \
			"jScripts.exe WHO up\n"  \
			"jScripts.exe WHO speed <login>\n"  \
			"jScripts.exe INVITE <login>\n"  \
			"jScripts.exe USTATS <type> <count> <section>\n"  \
			"jScripts.exe GSTATS <type> <count> <section>\n"  \
			"jScripts.exe BUSTATS <type> <count> <section>\n"  \
			"jScripts.exe BCUSTATS <section>\n"  \
			"jScripts.exe BQUSTATS \"GROUP1 GROUP2\" \"user1 user2\" \"FLAG1 FLAG2\" <section>\n"  \
			"jScripts.exe DAYSTATS \"GROUP1 GROUP2\" \"user1 user2\" \"FLAG1 FLAG2\" <type> <count> <section>\n"  \
			"jScripts.exe GETSTATS <login> <type> <section>\n"  \
			"jScripts.exe SHOWUSERSRANK <login> <type> <section>\n"  \
			"jScripts.exe BAN_ADD <ip>\n"  \
			"jScripts.exe BAN_DEL <ip>\n"  \
			"jScripts.exe BAN_LIST\n"  \
			"jScripts.exe ADDMASTER <login>\n"  \
			"jScripts.exe DELMASTER <login>\n"  \
			"jScripts.exe USER <login>\n"  \
			"jScripts.exe SHOW <login>\n"  \
			"jScripts.exe NFO\n"  \
			"jScripts.exe ADDTRIALTOLOG <login> <group>\n"   \
			"jScripts.exe CHANGEUSERS <group> <number>\n"  \
			"jScripts.exe CHANGEGROUP <login> <group>\n"  \
			"jScripts.exe DELETEUSER <login>\n"  \
			"jScripts.exe ADDFLAG <login> <flag>\n"  \
			"jScripts.exe DELFLAG <login> <flag>\n"  \
			"jScripts.exe DUPE <string>\n"  \
			"jScripts.exe UNDUPE <string>\n"  \
			"jScripts.exe DUPEIMPORT\n"  \
			"jScripts.exe SQLINDEX\n" \
			"jScripts.exe POSANDSTATS <login> <section>\n" \
			"jScripts.exe POSALLSTATS <section>\n" \
			"jScripts.exe POSGALLSTATS <group> <section>\n" \
			"jScripts.exe ALLGPOSANDSTATS <section>\n" \
			"jScripts.exe CREDITSALL\n"
			);
	
	return TRUE;

}

BOOL GetCreditsAll()
{
	
	INT64 iCredits = 0;

	for (int u=0;u<MAXUSERS;u++)
	{
		char TestUserName[USERNAME_LENGTH] = "";

		if ( ResolveUidToUserName(u, TestUserName) )
		{
			
			iCredits += GetUserCredits(0, u, 0);

		}

	}

	printf(jScripts_credits_all, iCredits/(1024*1024));

	return TRUE;

}

