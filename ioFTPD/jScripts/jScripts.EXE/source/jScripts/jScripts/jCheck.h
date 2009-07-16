/*
	Created...: 2005.09.14
	Changed...: 
	By........: Jeza
	Desription: Checks If Allowed COMP Names 
				Checks If Not Expired Date.
*/
BOOL AllowedCheck ()
{
    
	#if ( jScripts_enable_compname_check )

		TCHAR  infoBuf[INFO_BUFFER_SIZE];
		DWORD  bufCharCount = INFO_BUFFER_SIZE;
	    
		// Get and display the name of the computer. 
		bufCharCount = INFO_BUFFER_SIZE;
		if( !GetComputerName( infoBuf, &bufCharCount ) )
			return FALSE;

		//printf("infoBuf='%s'\n",infoBuf);

		if ( !CompareStrings (jScripts_default_allowed_comp_list, infoBuf, " ", TRUE) )
			return FALSE;

	#endif 

	#if ( jScripts_enable_timebomb_check )

		time_t now;

		if ( (DWORD)time(&now) > FormatTime(jScripts_default_timebomb) )
		
			return FALSE;

	#endif

	return TRUE;

}

/*
	Created...: 2005.10.03
	Changed...: 
	By........: Jeza
	Desription: Create SQL TABLES If They Dont Exists.
*/
VOID CheckSQL()
{
	sqlite3 *db;
	CHAR *zErrMsg = 0;
	INT rc;
	CHAR buff[DUPEBUFF] = {0};
	
	if ( !FileExists (jScripts_default_user_db) )
	{
		
		printf("CREATE TABLE USERS\n");

		sqlite3_open(jScripts_default_user_db, &db);

		rc = sqlite3_exec(db, "CREATE TABLE USERS( \
								UserName char(64), \
								GroupName char(64), \
								UID int, \
								GID int, \
								Flags char(20), \
								DateAdded int, \
								AddedBy char(64), \
								LoginCount int, \
								LastLogin int \
								);" \
								, callback, 0, &zErrMsg);

		
		var.sql.bFindDate = TRUE;

		FillStats( 0 );

		var.sql.bFindDate = FALSE;

		rc = sqlite3_exec(db, "begin transaction;", callback, 0, &zErrMsg);

		for (int c = 0 ; c < var.user.TotalUsers ; c++ )
		{
			sprintf(buff, "INSERT INTO \
							USERS (UserName, GroupName, UID, GID, Flags, DateAdded, AddedBy, LoginCount, LastLogin) \
							VALUES ('%s', '%s', %i, %i, '%s', %i, 'System', 0, 0)" \
							, var.usertable[c].tUserName, var.usertable[c].tGroupName, var.usertable[c].tUid, var.usertable[c].tGid, var.usertable[c].tFlags, atoi(var.usertable[c].DateAddedTime));

			rc = sqlite3_exec(db, buff, callback, 0, &zErrMsg);

		}

		rc = sqlite3_exec(db, "commit transaction;", callback, 0, &zErrMsg);

		printf("ADDED %i Users\n", var.user.TotalUsers);

		sqlite3_close(db);

	}

	//sqlite3_open(jScripts_default_user_db, &db);

	//rc = sqlite3_exec(db, "SELECT COUNT(*) FROM USERS;", callback, 0, &zErrMsg);

	//rc = sqlite3_exec(db, "SELECT DateAdded, LoginCount, LastLogin FROM USERS WHERE UserName = 'ssl';", callback, 0, &zErrMsg);

	//sqlite3_close(db);
	
	#if ( jScripts_enable_ban )

		if ( !FileExists (jScripts_default_ban_db) )
		{
			
			printf("CREATE TABLE BANS\n");

			sqlite3_open(jScripts_default_ban_db, &db);

			rc = sqlite3_exec(db, "CREATE TABLE BANS( \
									IP char(64), \
									Reason char(64) \
									);" \
									, callback, 0, &zErrMsg);
			
			rc = sqlite3_exec(db, "CREATE INDEX BanIndex ON BANS (IP);", callback, 0, &zErrMsg);
			
			rc = sqlite3_exec(db, "INSERT INTO BANS (IP, Reason) VALUES ('*@1.2.3.4', 'No Reason');", callback, 0, &zErrMsg);

			sqlite3_close(db);

		}

	#endif

	#if ( jScripts_enable_dupe_dir )
	
		if ( !FileExists (jScripts_default_dupe_dir_db) )
		{
			
			printf("CREATE TABLE DIRDUPE\n");

			sqlite3_open(jScripts_default_dupe_dir_db, &db);

			rc = sqlite3_exec(db, "CREATE TABLE DIRDUPE( \
									ReleaseTime int(10), \
									ReleaseName char(256), \
									Pwd char(256), \
									Section char(32), \
									UserName char(64), \
									GroupName char(64), \
									Wiped int(1), \
									Nuked int(1), \
									NukeReason char(64) \
									);", callback, 0, &zErrMsg);
			
			rc = sqlite3_exec(db, "CREATE INDEX DirDupeIndex ON DIRDUPE (ReleaseName);", callback, 0, &zErrMsg);
			
			rc = sqlite3_exec(db, "INSERT INTO DIRDUPE \
								  (ReleaseTime, ReleaseName, Pwd, Section, UserName, GroupName) \
								  VALUES (0, 'ReleaseName', '/test/ReleaseName', 'test', 'jScripts', 'NoGroup');"
								  , callback, 0, &zErrMsg);

			sqlite3_close(db);

		}

	#endif

}