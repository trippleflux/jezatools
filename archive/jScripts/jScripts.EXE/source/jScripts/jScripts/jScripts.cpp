// jScripts.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <exception>

#include "ioFTPD.h"

#include "ServerLimits.h"
#include "UserFile.h"
#include "VFS.h"
#include "WinMessages.h"
#include "DataCopy.h"
#include "GroupFile.h"

#include "jConfig.h"
#include "jDefine.h"
#include "jFormat.h"
#include "jDebug.h"
#include "jSQLite.h"
#include "sqlite\\sqlite3.h"
#include "jLog.h"
#include "jEnv.h"
#include "jCompare.h"
#include "jFile.h"
#include "jDateAdded.h"
#include "jioFTPD.h"
#include "jWho.h"
#include "jUserStats.h"
#include "jSiteCommands.h"
#include "jCheck.h"
#include "jDiskSpace.h"


//using namespace std;

//const char* gszFile = jScripts_default_user_db;


int _tmain(int argc, _TCHAR* argv[])
{
	
try	
{
#if ( jScripts_enable_allowed_check )
	
		if ( !AllowedCheck () )
		{
			exit (0);
			return (0);
		}

	#endif 

	debug("\nSTART..: ...........................................................................\n");

	for (int i = 0;i<argc;i++)
	{
	
		debug(".......: argv[%i]=%s\n", i, argv[i]);

	}

	#if ( jScripts_enable_help )

		if ( ( (argc == 2) && (strcmp(strupr(argv[1]), "HELP") == 0) ) 
			|| ( (argc == 2) && (strcmp(strupr(argv[1]), "-H") == 0) ) 
			|| ( (argc == 2) && (strcmp(strupr(argv[1]), "/H") == 0) ) 
			|| ( (argc == 2) && (strcmp(strupr(argv[1]), "/?") == 0) ) 
			|| ( (argc == 2) && (strcmp(strupr(argv[1]), "-?") == 0) ) 
			|| (argc == 1) )
		{
			debug("START..: HELP\n");
			
			ShowHelp ();

			debug("STOP...: HELP\n");
		}

		if ( (argc == 1) )
		{
			
			return 0;

		}

	#endif

	#if ( jScripts_enable_version )

		if ( (strcmp(strupr(argv[1]), "VERSION") == 0) )
		{
			debug("START..: Scripts Version\n");
			
			printf("jScripts Info...: '%s'\n", FormatString(jScripts_default_info, 0));

			if ( (argc > 3) )
			{
				
				TCHAR  infoBuf[INFO_BUFFER_SIZE];
				DWORD  bufCharCount = INFO_BUFFER_SIZE;
			    
				bufCharCount = INFO_BUFFER_SIZE;
				if( GetComputerName( infoBuf, &bufCharCount ) )
				{
					printf("ComputerName....: '%s'\n", infoBuf);
				}

				printf("Time Bomb.......: '%s'\n", jScripts_default_timebomb);

			}

			debug("STOP...: Scripts Version\n");
		}

	#endif

	#if ( jScripts_enable_disk_space )
	
		if ( (strcmp(strupr(argv[1]), "FREESPACE") == 0) )
		{
		
			debug("START..: jScripts_enable_disk_space\n");

			MyGetDiskFreeSpaceEx (argv[2]);

			return 0;

		}

	#endif

	debug("START..: InitializeSharedMemory()\n");
	if ( !InitializeSharedMemory() )
	{
		debug(".......:  -> InitializeSharedMemory() - FAILED\n");
		printf("ERROR.: InitializeSharedMemory - FAILED\n");
		exit(1);
	}
	debug(".......:  -> InitializeSharedMemory() - SUCCESS\n");
	debug("STOP...: InitializeSharedMemory()\n");

	debug("START..: GetENV\n");
	if ( GetENV() )
	{
		debug(".......:  -> GetUENV - SUCCESS\n");
	}
	debug("STOP...: GetUENV\n");

	ListENV();

	if (argc < 2)
		goto END;
	
	if ( (strcmp(strupr(argv[1]), "CHECK") == 0) )
	{
		printf(".......: jScripts Check...\n");
	}

	#if ( jSCripts_enable_sql )

		debug("START..:  CheckSQL()\n");

		CheckSQL();

		debug("STOP...: CheckSQL()\n");

	#endif
	
	#if ( jScripts_enable_change_credits )

		if ( (argc == 5 ) && (strcmp(strupr(argv[1]), "CHANGECREDITS") == 0) )
		{
			debug("START..: CHANGECREDITS\n");

			action(".......:  ..............................................................\n");
			action("START..: CHANGECREDITS\n");

			int UID = ResolveUserNameToUid(argv[2]);

			//printf("UID=%i\n", UID);
			
			if ( UID > -1 ) 
			{
				INT lValue;	// = StrToInt(argv[3]);

				INT iSection = StrToInt(argv[4]);
				
				//StrToIntEx(argv[3], STIF_DEFAULT, &lValue);

				if ( StrToIntEx(argv[3], STIF_DEFAULT, &lValue) )
				{
					
					if ( ChangeCredits( UID, lValue, iSection ) )
					{
						WriteSysOp (jScripts_syslog_change_credits, argv[2], argv[3], iSection);
						printf("CHANGECREDITS '%s' (%s) in Section '%i' SUCCESS\n", argv[2], argv[3], iSection );
						debug(".......: CHANGECREDITS '%s' (%s) in Section '%i' SUCCESS\n", argv[2], argv[3], iSection );
						action(".......: CHANGECREDITS '%s' (%s) in Section '%i' SUCCESS\n", argv[2], argv[3], iSection );
					}
					else
					{
						printf("CHANGECREDITS '%s' (%s) in Section '%i' FAILED\n", argv[2], argv[3], iSection );
						debug(".......: CHANGECREDITS '%s' (%s) in Section '%i' FAILED\n", argv[2], argv[3], iSection );
						action(".......: CHANGECREDITS '%s' (%s) in Section '%i' FAILED\n", argv[2], argv[3], iSection );
					}
				}
				else
				{
					
					debug(".......: StrToIntEx(argv[3], STIF_DEFAULT, &lValue) FAILED\n");
					action(".......: StrToIntEx(argv[3], STIF_DEFAULT, &lValue) FAILED\n");

					printf("CHANGECREDITS '%s' (%s) in Section '%i' FAILED\n", argv[2], argv[3], iSection );
					debug(".......: CHANGECREDITS '%s' (%s) in Section '%i' FAILED\n", argv[2], argv[3], iSection );
					action(".......: CHANGECREDITS '%s' (%s) in Section '%i' FAILED\n", argv[2], argv[3], iSection );
				}

			}
			else
			{
				printf("CHANGECREDITS '%s' (%s) in Section '%s' FAiLED\n", argv[2], argv[3], argv[4] );

				debug(".......: CHANGECREDITS '%s' (%s) in Section '%si' FAiLED\n", argv[2], argv[3], argv[4] );
				debug(".......: UID = %i!\n", UID);

				action(".......: CHANGECREDITS '%s' (%s) in Section '%s' FAiLED\n", argv[2], argv[3], argv[4] );
				action(".......: UID = %i!\n", UID);
			
			}
			
			debug("STOP...: CHANGECREDITS\n");
			action("STOP...: CHANGECREDITS\n");
		}

	#endif
	
	#if ( jScripts_enable_addtrialtolog )

		if ( (argc == 4 ) && (strcmp(strupr(argv[1]), "ADDTRIALTOLOG") == 0) )
		{
			debug("START..: ADDTRIALTOLOG\n");

			action(".......: ..............................................................\n");
			action("START..: ADDTRIALTOLOG\n");
			
			debug("START..: UpdateDateAdded\n");

			UpdateDateAdded( argv );

			debug("STOP...: UpdateDateAdded\n");
			
			WriteSysOp (jScripts_syslog_add_group, argv[2], argv[3]);
			debug (".......: 'jScripts' created user '%s' in group '%s'\n", argv[2], argv[3]);
			action (".......: 'jScripts' created user '%s' in group '%s'\n", argv[2], argv[3]);

			printf("ADDTRIALTOLOG SUCCESS\n");

			debug("STOP...: ADDTRIALTOLOG\n");
			action("STOP...: ADDTRIALTOLOG\n");
		}

	#endif
	
	#if ( jScripts_enable_change_number_of_users )

		if ( (argc == 4 ) && (strcmp(strupr(argv[1]), "CHANGEUSERS") == 0) )
		{
			debug("START..: CHANGEUSERS\n");

			action(".......: ..............................................................\n");
			action("START..: CHANGEUSERS\n");
			
			debug("START..: UpdateUsersInGroup\n");

			if ( UpdateUsersInGroup( argv ) )
			{
				
				WriteSysOp (jScripts_syslog_update_nr_of_users, argv[2], argv[3]);
				debug (".......: 'jScripts' updated number of users in group '%s' to '%s' SUCCESS!\n", argv[2], argv[3]);
				action (".......: 'jScripts' updated number of users in group '%s' to '%s' SUCCESS!\n", argv[2], argv[3]);
				
				printf("CHANGEUSERS SUCCESS\n");

			}
			else
			{

				debug (".......: 'jScripts' updated number of users in group '%s' to '%s' FAiLED!\n", argv[2], argv[3]);
				action (".......: 'jScripts' updated number of users in group '%s' to '%s' FAiLED!\n", argv[2], argv[3]);

				printf("CHANGEUSERS FAiLED\n");

			}

			debug("STOP...: UpdateUsersInGroup\n");
			
			debug("STOP...: CHANGEUSERS\n");
			action("STOP...: CHANGEUSERS\n");
		}

	#endif
	
	#if ( jScripts_enable_changegroup )

		if ( (argc == 4 ) && (strcmp(strupr(argv[1]), "CHANGEGROUP") == 0) )
		{
			debug("START..: CHANGEGROUP\n");

			action(".......: ..............................................................\n");
			action("START..: CHANGEGROUP\n");
			
			int GID = ResolveGroupNameToGid(argv[3]);
			
			if ( GID > -1 )
			{
				if ( ChangeGroup( argv , GID ) )
				{
					WriteSysOp (jScripts_syslog_add_group, argv[2], argv[3]);
					printf("CHANGEGROUP To %s For %s SUCCESS!\n", argv[3], argv[2]);
					debug(".......: CHANGEGROUP To %s For %s SUCCESS!\n", argv[3], argv[2]);
					action(".......: CHANGEGROUP To %s For %s SUCCESS!\n", argv[3], argv[2]);
				}
				else
				{
					printf("CHANGEGROUP To %s For %s FAILED!\n", argv[3], argv[2]);
					debug(".......: CHANGEGROUP To %s For %s FAILED! ChangeGroup( argv , GID )\n", argv[3], argv[2]);
					action(".......: CHANGEGROUP To %s For %s FAILED! ChangeGroup( argv , GID )\n", argv[3], argv[2]);
				}
			}
			else
			{
				
				printf("CHANGEGROUP To %s For %s FAILED!\n", argv[3], argv[2]);

				debug(".......: CHANGEGROUP To %s For %s FAILED!\n", argv[3], argv[2]);
				debug(".......: GID = %i!\n", GID);

				action(".......: CHANGEGROUP To %s For %s FAILED!\n", argv[3], argv[2]);
				action(".......: GID = %i!\n", GID);

			}
			
			debug("STOP...: CHANGEGROUP\n");
			action("STOP...: CHANGEGROUP\n");

		}

	#endif
	
	#if ( jScripts_enable_deleteuser )

		if ( (argc == 3 ) && (strcmp(strupr(argv[1]), "DELETEUSER") == 0) )
		{
			debug("START..: DELETEUSER\n");

			action(".......: ..............................................................\n");
			action("START..: DELETEUSER\n");

			if ( DeleteUser( argv[2] ) )
			{
				WriteSysOp (jScripts_syslog_del_user, argv[2]);
				printf("DELETEUSER '%s' SUCCESS!\n", argv[2]);
				debug(".......: DELETEUSER '%s' SUCCESS!\n", argv[2]);
				action(".......: DELETEUSER '%s' SUCCESS!\n", argv[2]);
			}
			else
			{
				printf("DELETEUSER '%s' FAILED!\n", argv[2]);
				debug(".......: DELETEUSER '%s' FAILED!\n", argv[2]);
				action(".......: DELETEUSER '%s' FAILED!\n", argv[2]);
			}
			debug("STOP...: DELETEUSER\n");
			action("STOP...: DELETEUSER\n");
		}

	#endif
	
	#if ( jScripts_enable_addflag )

		if ( (argc == 4 ) && (strcmp(strupr(argv[1]), "ADDFLAG") == 0) )
		{
			debug("START..: ADDFLAG\n");

			action(".......: ..............................................................\n");
			action("START..: ADDFLAG\n");
			
			int UID = ResolveUserNameToUid(argv[2]);
			if ( UID > -1 ) 
			{
				if ( AddFlag( UID, argv[3] ) )
				{
					WriteSysOp (jScripts_syslog_add_flag, argv[3], argv[2] );
					printf("ADDFLAG '%s' To '%s' SUCCESS\n", argv[3], argv[2] );
					debug(".......: ADDFLAG '%s' To '%s' SUCCESS\n", argv[3], argv[2] );
					action(".......: ADDFLAG '%s' To '%s' SUCCESS\n", argv[3], argv[2] );
				}
				else
				{
					printf("ADDFLAG '%s' To '%s' FAILED! AddFlag( UID, argv[3] )\n", argv[3], argv[2] );
					debug(".......: ADDFLAG '%s' To '%s' FAILED! AddFlag( UID, argv[3] )\n", argv[3], argv[2] );
					action(".......: ADDFLAG '%s' To '%s' FAILED! AddFlag( UID, argv[3] )\n", argv[3], argv[2] );
				}
			}
			else
			{
				printf("ADDFLAG '%s' To '%s' FAiLED\n", argv[3], argv[2] );

				debug(".......: ADDFLAG '%s' To '%s' FAiLED\n", argv[3], argv[2] );
				debug(".......: UID = %i!\n", UID);

				action(".......: ADDFLAG '%s' To '%s' FAiLED\n", argv[3], argv[2] );
				action(".......: UID = %i!\n", UID);

			}
			
			debug("STOP...: ADDFLAG\n");
			action("STOP...: ADDFLAG\n");

		}

	#endif

	#if ( jScripts_enable_delflag )

		if ( (argc == 4 ) && (strcmp(strupr(argv[1]), "DELFLAG") == 0) )
		{
			debug("START..: DELFLAG\n");

			action(".......: ..............................................................\n");
			action("START..: DELFLAG\n");
			
			int UID = ResolveUserNameToUid(argv[2]);
			if ( UID > -1 ) 
			{
				CHAR DF[1] = {0};
				strncpy(DF, argv[3], 1);

				if ( DelFlag( UID, DF[0] ) )
				{
					WriteSysOp (jScripts_syslog_del_flag, argv[3], argv[2] );
					printf("DELFLAG '%s' From '%s' SUCCESS\n", argv[3], argv[2] );
					debug(".......: DELFLAG '%s' From '%s' SUCCESS\n", argv[3], argv[2] );
					action(".......: DELFLAG '%s' From '%s' SUCCESS\n", argv[3], argv[2] );
				}
				else
				{
					printf("DELFLAG '%s' From '%s' FAiLED! DelFlag( UID, DF[0] )\n", argv[3], argv[2] );
					debug(".......: DELFLAG '%s' From '%s' FAiLED! DelFlag( UID, DF[0] )\n", argv[3], argv[2] );
					action(".......: DELFLAG '%s' From '%s' FAiLED! DelFlag( UID, DF[0] )\n", argv[3], argv[2] );
				}
			}
			else
			{
				printf("DELFLAG '%s' To '%s' FAiLED\n", argv[3], argv[2] );

				debug(".......: DELFLAG '%s' To '%s' FAiLED\n", argv[3], argv[2] );
				debug(".......: UID = %i!\n", UID);

				action(".......: DELFLAG '%s' To '%s' FAiLED\n", argv[3], argv[2] );
				action(".......: UID = %i!\n", UID);

			}
			
			
			debug("STOP...: DELFLAG\n");
			action("STOP...: DELFLAG\n");

		}

	#endif

	#if ( jSCripts_enable_adduser )

		if ( (strcmp(strupr(argv[1]), "GADDUSER") == 0) )
		{
			debug("START..: GADDUSER\n");
			GAddUser( argv );
			debug("STOP...: GADDUSER\n");
		}

		if ( (strcmp(strupr(argv[1]), "ADDUSER") == 0) )
		{
			debug("START..: ADDUSER\n");
			AddUser( argv );
			debug("STOP...: ADDUSER\n");
		}

	#endif

	#if ( jScripts_enable_dupe_dir )

/*
2006-02-05 10:01:29 -> argv[0]=jScripts.exe
2006-02-05 10:01:29 -> argv[1]=NEWDIR
2006-02-05 10:01:29 -> argv[2]=F:\test\1211\asd
2006-02-05 10:01:29 -> argv[3]=/test/1211/asd

2006-02-05 10:01:32 -> argv[0]=jScripts.exe
2006-02-05 10:01:32 -> argv[1]=DELDIR
2006-02-05 10:01:32 -> argv[2]=F:\test\1211\asd
2006-02-05 10:01:32 -> argv[3]=/test/1211/asd/
*/

		if ( (argc == 4) && ( strcmp(strupr(argv[1]), "NEWDIR") == 0) )
		{
			
			debug("START..: DUPE NEWDIR\n");

			BOOL bOK = TRUE;
			
			for (int i = 0;i<argc;i++)
				debug(".......: argv[%i]=%s\n", i, argv[i]);
			
			if ( !CheckDupeNEWDIR ( argv ) )
			{
				bOK = FALSE;
			}
			
			debug("STOP...: DUPE NEWDIR\n");

			if ( !bOK )
			{
			
				printf(FormatString(jScripts_dupe_newdir_msg, 0));
				
				debug("START..: CloseSharedMemory()\n");
				CloseSharedMemory();
				debug("STOP...: CloseSharedMemory()\n");

				debug(".......: DIR DUPE RETURN 1\n");

				return 1;

			}

		}
		
		if ( (argc == 4) && ( strcmp(strupr(argv[1]), "DELDIR") == 0) )
		{
			
			debug("START..: DUPE DELDIR\n");

			for (int i = 0;i<argc;i++)
				debug(".......: argv[%i]=%s\n", i, argv[i]);
			
			DupeDELDIR ( argv );
			
			debug("STOP...: DUPE DELDIR\n");

		}
		
		if ( (argc >= 3) && ( strcmp(strupr(argv[1]), "DUPE") == 0) )
		{
			
			debug("START..: SHOW DUPE \n");

			for (int i = 0;i<argc;i++)
				debug(".......: argv[%i]=%s\n", i, argv[i]);
			
			ShowDupe ( argv );
			
			debug("STOP...: SHOW DUPE\n");

		}

		if ( (argc == 3) && ( strcmp(strupr(argv[1]), "UNDUPE") == 0) )
		{
			
			debug("START..: UNDUPE \n");

			for (int i = 0;i<argc;i++)
				debug(".......: argv[%i]=%s\n", i, argv[i]);
			
			StrCpy(var.args.arg02, argv[2]);

			if ( UnDupe ( argv ) )
			{
				printf(FormatString(jScripts_undupe_ok_msg, 0));
			}
			else
			{
				printf(FormatString(jScripts_undupe_fail_msg, 0));
			}
			
			debug("STOP...: UNDUPE\n");

		}

		if ( (argc >= 2) && ( strcmp(strupr(argv[1]), "DUPEIMPORT") == 0) )
		{
			
			debug("START..: DUPEIMPORT \n");

			for (int i = 0;i<argc;i++)
				debug(".......: argv[%i]=%s\n", i, argv[i]);
			
			ImportDupe ( argc, argv );
			
			debug("STOP...: DUPEIMPORT\n");

		}

/*		
		if ( (argc >= 2) && ( strcmp(strupr(argv[1]), "DUPEE") == 0) )
		{

	sqlite3 *db;
	CHAR *zErrMsg = 0;
	INT rc;
	CHAR buff[256] = {0};
	
	sqlite3_open("C:\\ioFTPD\\system\\esmNewdir.db", &db);

	//debug(".......: SELECT ftpPath FROM directories;\n");

	sprintf(buff, "SELECT ftpPath, dirName FROM directories;");

	rc = sqlite3_exec(db, buff, callback, 0, &zErrMsg);

	sqlite3_close(db);

		}
*/			
	#endif

	#if ( jScripts_enable_who )

		if ( (argc >= 3) && ( (strcmp(strlwr(argv[1]), "template=3") == 0) || (strcmp(strupr(argv[1]), "WHO") == 0)) )
		{
			debug("START..: CheckWho\n");
			CheckWho( argv );
			debug("STOP...: CheckWho\n");
		}

	#endif

	#if ( jScripts_enable_ftplogin )

		if ( (strcmp(strupr(argv[1]), "FTPLOGIN") == 0) )
		{
			debug("START..: OnFtpLogIn\n");
			OnFtpLogIn( );
			debug("STOP...: OnFtpLogIn\n");
		}

	#endif

	#if ( jScripts_enable_ustats )

		if ( (argc == 5) && (strncmp(strupr(argv[1]), "USTATS", 6) == 0) )
		{
			debug("START..: GetUStats\n");
			GetUStats( argv );
			debug("STOP...: GetUStats\n");
		}

	#endif

	#if ( jScripts_enable_gstats )

		if ( (argc == 5) && (strncmp(strupr(argv[1]), "GSTATS", 6) == 0) )
		{
			debug("START..: GetGStats\n");
			GetGStats( argv );
			debug("STOP...: GetGStats\n");
		}

	#endif

	#if ( jScripts_enable_bustats )

		if ( (argc == 5) && (strncmp(strupr(argv[1]), "BUSTATS", 7) == 0) )
		{
			debug("START..: GetBUStats\n");
			GetBUStats( argv );
			debug("STOP...: GetBUStats\n");
		}

	#endif

	#if ( jScripts_enable_complete_bustats )

		if ( (argc == 3) && (strncmp(strupr(argv[1]), "BCUSTATS", 8) == 0) )
		{
			debug("START..: GetBCUStats\n");
			GetBUStatsALL( argv );
			debug("STOP...: GetBCUStats\n");
		}

	#endif

	#if ( jScripts_enable_quota_bustats )

		if ( (argc == 6) && (strncmp(strupr(argv[1]), "BQUSTATS", 8) == 0) )
		{
			debug("START..: GetBQUStats\n");
			GetBUStatsQuota( argv );
			debug("STOP...: GetBQUStats\n");
		}

	#endif

	#if ( jScripts_enable_day_stats )

		if ( (argc == 8) && (strncmp(strupr(argv[1]), "DAYSTATS", 8) == 0) )
		{
			debug("START..: GetBQUStats\n");
			GetDAYStats( argv );
			debug("STOP...: GetBQUStats\n");
		}

	#endif

	#if ( jScripts_enable_get_user_stats )

		if ( (argc == 5) && (strncmp(strupr(argv[1]), "GETSTATS", 8) == 0) )
		{
			debug("START..: GetBQUStats\n");
			GetUserStats( argv );
			debug("STOP...: GetBQUStats\n");
		}

	#endif

	#if ( jScripts_enable_get_user_rank )

		if ( (argc == 5) && (strncmp(strupr(argv[1]), "SHOWUSERSRANK", 8) == 0) )
		{
			debug("START..: ShowUsersRank\n");
			ShowUsersRank( argv );
			debug("STOP...: ShowUsersRank\n");
		}

	#endif

	#if ( jScripts_enable_invite )

		if ( (strcmp(strupr(argv[1]), "INVITE") == 0) )
		{
			debug("START..: CheckInvite\n");
			CheckInvite( argv );
			debug("STOP...: CheckInvite\n");
		}

	#endif

	#if ( jScripts_enable_ban )

		if ( (strcmp(strupr(argv[1]), "BAN_LOGIN") == 0) )
		{
			debug("START..: CheckBan\n");
			if ( CheckBan( ) )
			{
				
				printf(FormatString(jScripts_site_ban_msg, 0));
				CloseSharedMemory();
				exit(1);
				return(1);

			}
			debug("STOP...: CheckBan\n");
		}

		if ( (strcmp(strupr(argv[1]), "BAN_ADD") == 0) )
		{
			sprintf(var.user.ip, "%s", argv[2]);

			debug("START..: AddBan\n");
			AddBan( argv );
			debug("STOP...: AddBan\n");
		}

		if ( (strcmp(strupr(argv[1]), "BAN_DEL") == 0) )
		{
			sprintf(var.user.ip, "%s", argv[2]);

			debug("START..: DelBan\n");
			DelBan( );
			debug("STOP...: DelBan\n");
		}
	
		if ( (strcmp(strupr(argv[1]), "BAN_LIST") == 0) )
		{
			debug("START..: ListBan\n");
			BanList();
			debug("STOP...: ListBan\n");
		}
	
	#endif

	#if ( jScripts_enable_master )

		if ( argc == 3)
		{
			sprintf(var.user.Master, "%s", argv[2]);

			if ( (strcmp(strupr(argv[1]), "ADDMASTER") == 0) )
			{
				debug("START..: AddMaster\n");
				AddMaster( argv );
				debug("STOP...: AddMaster\n");
			}

			if ( (strcmp(strupr(argv[1]), "DELMASTER") == 0) )
			{
				debug("START..: DelMaster\n");
				DelMaster( argv );
				debug("STOP...: DelMaster\n");
			}
		}

	#endif
/*
	#if ( jScripts_enable_writedate )

		if ( (strcmp(strupr(argv[1]), "WRITEDATE") == 0) )
		{
			debug("START..: WriteDate\n");
			if ( WriteDate() )
				printf(FormatString(jScripts_site_writedate_success, 0));
			else
				printf(FormatString(jScripts_site_writedate_failed, 0));
			debug("STOP...: WriteDate\n");
		}

	#endif
*/
	#if ( jScripts_enable_site_show )

		if ( (argc == 3) && (strcmp(strupr(argv[1]), "SHOW") == 0) )
		{
			sprintf(var.user.Show, "%s", argv[2]);

			debug("START..: SiteShow\n");
			SiteShow( argv );
			debug("STOP...: SiteShow\n");
		}

	#endif

	#if ( jScripts_enable_site_user )

		if ( (argc == 3) && (strcmp(strupr(argv[1]), "USER") == 0) )
		{
			sprintf(var.user.User, "%s", argv[2]);

			debug("START..: SiteUser\n");
			SiteUser( argv );
			debug("STOP...: SiteUser\n");
		}

	#endif

	#if ( jScripts_enable_site_nfo )

		if ( (argc == 2) && (strcmp(strupr(argv[1]), "NFO") == 0) )
		{
			debug("START..: SiteNFO\n");
			SiteNFO( );
			debug("STOP...: SiteNFO\n");
		}

	#endif

	#if ( jScripts_enable_sql_index )

		if ( (argc == 2) && (strcmp(strupr(argv[1]), "SQLINDEX") == 0) )
		{
			debug("START..: SQLINDEX\n");
			
			sqlite3 *db;
			CHAR *zErrMsg = 0;
			INT rc;

			sqlite3_open(jScripts_default_ban_db, &db);

			rc = sqlite3_exec(db, "CREATE INDEX BanIndex ON BANS (IP);", callback, 0, &zErrMsg);

			debug(".......: CREATE INDEX BanIndex ON BANS (IP);\n");

			sqlite3_close(db);
			
			sqlite3_open(jScripts_default_dupe_dir_db, &db);

			rc = sqlite3_exec(db, "CREATE INDEX DirDupeIndex ON DIRDUPE (ReleaseName);", callback, 0, &zErrMsg);

			debug(".......: CREATE INDEX DirDupeIndex ON DIRDUPE (ReleaseName);\n");

			sqlite3_close(db);

			debug("STOP...: SQLINDEX\n");
		}

	#endif

	#if ( jScripts_enable_credits_all )

		if ( (argc == 2) && (strcmp(strupr(argv[1]), "CREDITSALL") == 0) )
		{
			
			debug("START..: CREDITSALL\n");

			GetCreditsAll();

			debug("STOP...: CREDITSALL\n");

		}

	#endif

	#if ( jscripts_enable_posandstats )

		if ( (argc == 4) && (strcmp(strupr(argv[1]), "POSANDSTATS") == 0) )
		{
			
			debug("START..: POSANDSTATS\n");

			GetUserPosAndStats(argv[2], atoi(argv[3]));

			debug("STOP...: POSANDSTATS\n");

		}

	#endif

	#if ( jscripts_enable_allposandstats )

		if ( (argc == 3) && (strcmp(strupr(argv[1]), "POSALLSTATS") == 0) )
		{
			
			debug("START..: POSALLSTATS\n");

			GetUserPosAndStatsAll(atoi(argv[2]));

			debug("STOP...: POSALLSTATS\n");

		}

	#endif

	#if ( jscripts_enable_gposandstats )

		if ( (argc == 4) && (strcmp(strupr(argv[1]), "POSGALLSTATS") == 0) )
		{
			
			debug("START..: POSGALLSTATS\n");

			GetGroupPosAndStats(argv[2], atoi(argv[3]));

			debug("STOP...: POSGALLSTATS\n");

		}

	#endif

	#if ( jscripts_enable_gallposandstats )

		if ( (argc == 3) && (strcmp(strupr(argv[1]), "ALLGPOSANDSTATS") == 0) )
		{
			
			debug("START..: ALLGPOSANDSTATS\n");

			//GetUserPosAndStats(atoi(argv[2]));

			debug("STOP...: ALLGPOSANDSTATS\n");

		}

	#endif

	#if ( jscripts_enable_addtestuser )

		if ( (argc == 4) && (strcmp(strupr(argv[1]), "ADDUSERS") == 0) )
		{
			
			debug("START..: ADDUSERS\n");

			INT iCount = StrToInt(argv[3]);
			for ( INT i = 0 ; i < iCount ; i++ )
			{
				_TCHAR *UsrName	= (_TCHAR *)calloc(USERNAME_LENGTH, sizeof(_TCHAR));
				sprintf(UsrName, "%s_%i", argv[2], i);
				if ( !CreateUser(UsrName) )
				{
					printf("Created User : '%s' FAiLED\n", UsrName);
				}
				else
				{
					SetStats(ResolveUserNameToUid(UsrName), 2135);
					printf("Created User : '%s'\n", UsrName);
				}
				free(UsrName);
			}

			debug("STOP...: ADDUSERS\n");

		}

	#endif

	#if ( jScripts_enable_reqstats )

		if ( (argc == 3) && (strcmp(strupr(argv[1]), "REQUEST") == 0) )
		{
			
			debug("START..: REQUEST\n");

			debug(".......: Not Ready Yet\n");

			debug("STOP...: REQUEST\n");

		}

		if ( (argc == 3) && (strcmp(strupr(argv[1]), "REQSTATS") == 0) )
		{
			
			debug("START..: REQSTATS\n");

			debug(".......: Not Ready Yet\n");

			debug("STOP...: REQSTATS\n");

		}
	#endif

	#if ( jScripts_enable_bgstats )

		if ( (argc == 6) && (strncmp(strupr(argv[1]), "GDAYSTATS", 9) == 0) )
		{
			debug("START..: GetBGStats\n");
			GetGDAYStats( argv );
			debug("STOP...: GetBGStats\n");
		}

	#endif

	END:
	
	debug("START..: CloseSharedMemory()\n");
	CloseSharedMemory();
	debug("STOP...: CloseSharedMemory()\n");
	return 0;
}
catch (...)
{
	printf("Something Is Wrong\n");
}
}

