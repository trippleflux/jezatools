/*
	Created...: 2005.09.17
	Changed...: 2005.09.18
	By........: Jeza
	Desription: Split The Input String.
*/
char *SplitUserName(char *readline)
{

	int	i = 0;
	char *_split[SPLITSIZE];

	_split[0] = readline;
	
	while ( 1 )
	{
		if ( (*readline == '\'') ) 
		{
			*readline = 0;
			i++;
			_split[i] = readline + 1;
		} 
		else if ( *readline == 0 )
		{
			i++;
			_split[i] = NULL;
			break;
		}
		readline++;
	}

	sprintf(sSplit, "%s",_split[3]);
	return sSplit;

}

/*
	Created...: 2005.10.03
	Changed...: 
	By........: Jeza
	Desription: Search SysOp.log For Date Added 
				Returns DateAdded of User If Found
*/
BOOL FindDate(char *UserName)
{
    if (!FileExists(jScripts_default_sysop_file))
	{
        printf(FormatString(jScripts_error_msg_sysoplog_not_open, 0));
		return FALSE;
    }

	BOOL bFOund = FALSE;
	FILE *input;
	char readline[READLINE];
	int i = 0;

	if ((input = fopen(jScripts_default_sysop_file, "r+")) != NULL )
	{
	
		while (TRUE)
		{
			fgets(readline, READLINE, input);

			if (feof(input) != 0)
				break;

			if ( strstr(readline, " created user ") != 0 )
			{
				//08-30-2005 22:32:40 'Jeza' created user 'test_user_00' in group 'FRiENDS'.
				
				char *line = (char *)calloc(strlen(readline)+1, sizeof(char));
				strncpy(line, readline, strlen(readline)-1);
				
				char *da = (char *)calloc(19+1, sizeof(char));
				strncpy(da, readline, 19);
				
				if ( strncmp(UserName, SplitUserName(line), strlen(UserName)) == 0 )
				{
					sprintf(var.user.AddedDate, "%.10d", FormatTime(da));
					bFOund = TRUE;
					break;
				}
				//sprintf(var.usertable[i].DateAddedLine, "%d %s", FormatTime(da), SplitUserName(line));
				//printf(">%s< ,%d, :%s: .%s", SplitUserName(line), FormatTime(da), da, readline);

				free(line);
				free(da);

				i++;
				
			}
		}
		
		fclose(input);

		if ( bFOund )
			return TRUE;
		else
			return FALSE;

	}
	else
	{
		return FALSE;
	}
	
}

/*
	Created...: 2005.10.03
	Changed...: 
	By........: Jeza
	Desription: Search USERS TABLE For Date Added 
				Returns DateAdded of User If Found
*/
BOOL FindDateFromSQL(char *UserName)
{
	sqlite3 *db;
	CHAR *zErrMsg = 0;
	INT rc;
	CHAR buff[256];
		
	sqlite3_open(jScripts_default_user_db, &db);

	sprintf(buff, "SELECT DateAdded FROM USERS WHERE UserName = '%s';", UserName);

	rc = sqlite3_exec(db, buff, callback, 0, &zErrMsg);

	sqlite3_close(db);

	return TRUE;
}

/*
	Created...: 2005.09.18
	Changed...: 2005.10.03	- SQLite.dll now
	By........: Jeza
	Desription: Search SysOp.log For Date Added 
				Writes All Dates To Another File.

BOOL oldWriteDate()
{

    if (!FileExists(jScripts_default_sysop_file))
	{
        printf(FormatString(jScripts_error_msg_sysoplog_not_open, 0));
		return FALSE;
    }

	FILE *input;
	char readline[READLINE];
	int i = 0;

	if ((input = fopen(jScripts_default_sysop_file, "r+")) != NULL )
	{
	
		while (TRUE)
		{
			fgets(readline, READLINE, input);

			if (feof(input) != 0)
				break;

			if ( strstr(readline, " created user ") != 0 )
			{
				//08-30-2005 22:32:40 'Jeza' created user 'test_user_00' in group 'FRiENDS'.
				
				char *line = (char *)calloc(strlen(readline)+1, sizeof(char));
				strncpy(line, readline, strlen(readline)-1);
				
				char *da = (char *)calloc(19+1, sizeof(char));
				strncpy(da, readline, 19);
				
				sprintf(var.usertable[i].DateAddedLine, "%d %s", FormatTime(da), SplitUserName(line));
				//printf(">%s< ,%d, :%s: .%s", SplitUserName(line), FormatTime(da), da, readline);

				free(line);
				free(da);

				i++;
				
			}
		}
		
		fclose(input);
	}
	else
	{
		return FALSE;
	}

    if (FileExists(jScripts_default_dateadded_file))
	{
        unlink(jScripts_default_dateadded_file);
    }

	FILE *output;	
	
	if ((output = fopen(jScripts_default_dateadded_file, "w+")) != NULL )
	{
		for (int j=0;j<i;j++)
		{
			//printf("->%s\n",var.usertable[j].DateAddedLine);
			fprintf(output, "%s\n", var.usertable[j].DateAddedLine);
		}

		fclose(input);
	}
	else
	{
		return FALSE;
	}

	return TRUE;

}
*/
/*
	Created...: 2005.09.17
	Changed...: 2005.10.03	- SQLite.dll now
	By........: Jeza
	Desription: Search jScripts_default_dateadded_file For Date Added 
				Returns DateAdded of User If Found

BOOL oldFindDate(char *UserName)
{
    if ( !FileExists(jScripts_default_dateadded_file) )
	{
        if ( !WriteDate() )
		{
			return FALSE;
		}
    }

	BOOL bFOund = FALSE;
	DWORD UTime	= 0;
	sprintf(var.user.AddedDate, "%i", 0);

	FILE *input;
	char readline[READLINE];

    if ( FileExists(jScripts_default_dateadded_file) )
	{
		
		// Open the stream and read it back.
		if ((input = fopen(jScripts_default_dateadded_file, "r+")) != NULL )
		{
			while (TRUE)
			{

				fgets(readline, READLINE, input);

				if (feof(input) != 0)
					break;

				//1121471307 test_user_00
				char *User = strrchr(readline, 0x20);
				User++;
					
				if ( strncmp(UserName, User, strlen(UserName)) == 0 )
				{
					sprintf(var.user.AddedDate, "%.10s", readline);
					bFOund = TRUE;
					break;
				}
				
			}

		}

		if ( bFOund )
			return TRUE;
		else
			return FALSE;

	}
	else
	{
		return FALSE;
	}
	
}
*/

