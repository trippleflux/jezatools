/*
	Created...: 2005.10.02
	Changed...: 
	By........: 
	Desription: Use for SQL Output.
*/
static int callback(void *NotUsed, int argc, char **argv, char **azColName)
{

/*	
	int i;

	for(i=0; i<argc; i++)
	{
		//printf(".: %s = %s\n", azColName[i], argv[i] ? argv[i] : "NULL");
		debug(".: %s/%s\n", argv[0], argv[1]);
	}
*/

	if ( var.sql.bOnFtpLogin )
	{
		var.sql.bUserExists = TRUE;
	}

	var.sql.bFound = TRUE;

	if ( strcmp(azColName[0], "count(*)") == 0 ||
		strcmp(azColName[0], "LoginCount") == 0 )
		var.sql.iCount = atoi(argv[0]);

	if ( strcmp(azColName[0], "DateAdded") == 0 )
	{
		COleDateTime dt = atol(argv[0]);
		sprintf(var.user.AddedDate, "%s", dt.Format(_T("%m/%d/%Y %H:%M:%S")) );
		//sprintf(var.user.AddedDate, "%d", atol(argv[0]));
	}

	if ( var.sql.bBanList )
		printf(" %-30s %-30s", argv[0], argv[1]);
		//printf(" %-30s ",argv[i] ? argv[i] : "NULL");

	if ( var.sql.bSiteUser )
	{
		
		var.sql.bUserExists = TRUE;

		if ( atol(argv[1]) < 1 )
			printf(" LOGiN COUNT..........: %-15s  LAST LOGiN...........: - \n", argv[0]);
		else
		{
			COleDateTime dt = atol(argv[1]);
			printf(" LOGiN COUNT..........: %-15s  LAST LOGiN...........: %s \n", argv[0], dt.Format(_T("%Y-%m-%d %H:%M:%S")) );
		}
	}

	if ( var.sql.bLastSeen )
	{
		COleDateTime dt = atol(argv[0]);
		sprintf(var.user.LastSeen, "%s", dt.Format(_T("%Y-%m-%d %H:%M:%S")));
		//printf("found '%s' '%s'\n", argv[0], var.user.LastSeen );
	}

	if ( var.sql.bAddedBy )
	{
		
		if ( atol(argv[1]) < 1 )
			printf(" ADDED BY.............: System           DATE ADDED...........: - \n");
		else
		{
			COleDateTime dt = atol(argv[1]);
			printf(" ADDED BY.............: %-15.15s  DATE ADDED...........: %s \n",argv[0], dt.Format(_T("%Y-%m-%d %H:%M:%S")) );
		}
	}

	if ( var.sql.bCheckBan || var.sql.bDelBan )
		var.sql.bIsBanned = TRUE;

	if ( var.sql.bBanList )
		printf("\n");

	if ( var.sql.bCheckDirDupe )
	{
		var.sql.bDupe		= TRUE;
		var.sql.DupeTime	= (INT)atoi(argv[0]);
		COleDateTime dt		= atol(argv[0]);
		StrCpy(var.sql.DupeDate, dt.Format(_T("%Y-%m-%d %H:%M:%S")));
		StrCpy(var.sql.UserName,argv[1]);
	}
	
	if ( var.sql.bFindDupe && (var.sql.DupeFoundCount < jScripts_dupe_max_show) )
	{
		
		COleDateTime dt		= atol(argv[0]);
		StrCpy(var.sql.DupeDate, dt.Format(_T("%Y-%m-%d")));
		StrCpy(var.sql.DupePwd, argv[1]);

		printf(FormatString(jScripts_dupe_show_msg, 0));

		var.sql.DupeFoundCount++;

	}

	if ( var.sql.bCountDupes )
	{
		var.sql.DupeTotalCount = atol(argv[0]);
	}

	/*
	if ( var.sql.bFindUnDupe )
	{
		var.sql.UnDupeFoundCount++;
	}
	*/

	return 0;

}

