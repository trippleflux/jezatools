/*
	Created...: 2005.09.04
	Changed...: 
	By........: Jeza
	Desription: Compare Users Flags For WHO.
				If User Has One of 'jScripts_who_power_flags' He Can See All ONLINE Info
*/
VOID CheckPowerUser()
{

	var.user.bFlags = FALSE;

	if ( CompareFlags(var.env.flags, jScripts_who_power_flags) )
		var.user.bFlags = TRUE;


	var.user.bUser = FALSE;

	if ( CompareStrings(jScripts_who_power_users, var.env.user, " ", TRUE) )
		var.user.bUser = TRUE;

	
	var.user.bGroup = FALSE;

	if ( CompareStrings(jScripts_who_power_groups, var.env.group, " ", TRUE) )
		var.user.bGroup = TRUE;
}

/*
	Created...: 2005.08.01
	Changed...: 2005.09.05
	By........: Jeza
	Desription: ONLINE Info.
				
*/
VOID Who( short iHow )
{

	int iPos = 0, nPos = 0, Users = 0, iSpeed = 0;
	var.jWho.iIDLE = 0, var.jWho.iDN = 0, var.jWho.iUP = 0;
	var.jWho.dwUP = 0, var.jWho.dwDN = 0;
	
	CheckPowerUser();

	if ( iHow == WHO_NORMAL )
		printf(FormatString(jScripts_jwho_head, 0));

	if ( iHow == WHO_BOT )
		printf(FormatString(jScripts_bot_who_head, 0));

	while (nPos != -1 && Users < 1000 )
	{
		lpMessage->dwIdentifier			= DC_GET_ONLINEDATA;
		LPDC_ONLINEDATA pOnlineData		= (LPDC_ONLINEDATA)lpMessage->lpContext;
		pOnlineData->iOffset			= nPos;
		pOnlineData->dwSharedMemorySize = sizeof(DC_MESSAGE) + sizeof(DC_ONLINEDATA) + (_MAX_PATH + 1) * 2;

		SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory);
		if ( WaitForSingleObject(hEvent, 5000) == WAIT_TIMEOUT ) break;

		if (!lpMessage->dwReturn)
		{

			nPos									= pOnlineData->iOffset;
			
			if ( iPos >= nPos || nPos == 1024 )
				break;

			sprintf(var.jWho.UserName, jScripts_default_user);
			sprintf(var.jWho.GroupName, jScripts_default_group);
			sprintf(var.jWho.VirtualPath,"/");
			sprintf(var.jWho.VirtualDataPath,"/");
			sprintf(var.jWho.Action,"");

			DWORD bytesTransfered					= 0;
			var.jWho.totalBytesTransfered			= 0;
			//INT64 totalBytesTransfered			= 0;
			DWORD IntervalLength					= 0;
			var.jWho.dwSpeed						= 0;
			var.jWho.IdleTime						= 0;
			
			
			int UserId								= pOnlineData->OnlineData.Uid;
			int TransferStatus						= (int)pOnlineData->OnlineData.bTransferStatus;

			sprintf(var.jWho.VirtualPath,"%s",pOnlineData->OnlineData.tszVirtualPath);

			var.user.bHPath = FALSE;

			if ( CompareStrings(jScripts_who_hide_path, var.jWho.VirtualPath, " ", TRUE) )
				var.user.bHPath = TRUE;

			sprintf(var.jWho.VirtualDataPath,"%s",pOnlineData->OnlineData.tszVirtualDataPath);
			sprintf(var.jWho.RealDataPath,"%s", pOnlineData->OnlineData.tszRealDataPath);

			sprintf(var.jWho.Action,"%s",pOnlineData->OnlineData.tszAction);
			
			if ( strstr(var.jWho.Action,"PASS ") != NULL )
				sprintf(var.jWho.Action,"PASS *****");

			var.jWho.IdleTime						= (GetTickCount() - pOnlineData->OnlineData.dwIdleTickCount)/1000;
			time_t now;
			var.jWho.LoginTime						= time(&now) - pOnlineData->OnlineData.tLoginTime;
			var.jWho.totalBytesTransfered			= pOnlineData->OnlineData.i64TotalBytesTransfered;
			//totalBytesTransfered					= pOnlineData->OnlineData.i64TotalBytesTransfered;
			IntervalLength							= pOnlineData->OnlineData.dwIntervalLength;
			if ( IntervalLength < 1 )
				IntervalLength						= 1;

			bytesTransfered							= pOnlineData->OnlineData.dwBytesTransfered;
			
			var.jWho.dwSpeed						= bytesTransfered/IntervalLength;

			// -1 occurs when user is login			
			if ( UserId == -1 ) 
				continue;

			//resolve uid to username
			ResolveUidToUserName(UserId, var.jWho.UserName);

			if ( (iHow == WHO_SPEED) && (strcmp(var.jWho.UserName, var.jWho.SpeedUser) != 0) )
				continue;

			var.user.bHUser = FALSE;

			if ( CompareStrings(jScripts_who_hide_users, var.jWho.UserName, " ", TRUE) )
				var.user.bHUser = TRUE;

			
			var.user.bMEUser = FALSE;
			
			if ( CompareStrings(var.user.UserName, var.jWho.UserName, " ", TRUE) )
				var.user.bMEUser = TRUE;

			//get users groupname
			GetGroupName(UserId, var.jWho.GroupName);

			var.user.bHGroup = FALSE;

			if ( CompareStrings(jScripts_who_hide_groups, var.jWho.GroupName, " ", TRUE) )
				var.user.bHGroup = TRUE;
			/*
			if ( CompareStrings(jScripts_who_hide_groups, var.jWho.GroupName, " ", TRUE) &&
				!CompareStrings(var.user.GroupName, var.jWho.GroupName, " ", TRUE) )
				var.user.bHGroup = TRUE;
			*/
			
			// (0 Inactive, 1 Upload, 2 Download, 3 List)
			switch ( TransferStatus )
			{
				case 0:
				{
					
					if ( iHow == WHO_NORMAL )
					{
						if ( var.user.bFlags || var.user.bUser || var.user.bGroup )
							printf(FormatString(jScripts_jwho_body_power_idle, 0));
						else
						{
							if ( (!var.user.bHPath && !var.user.bHUser && !var.user.bHGroup) || var.user.bMEUser )
								printf(FormatString(jScripts_jwho_body_normal_idle, 0));
						}
					}

					if ( iHow == WHO_BOT )
						if ( (!var.user.bHPath && !var.user.bHUser && !var.user.bHGroup) )
							printf(FormatString(jScripts_bot_who_body_normal_idle, 0));

					if ( iHow == WHO_IDLE )
						if ( (!var.user.bHPath && !var.user.bHUser && !var.user.bHGroup) )
							printf(FormatString(jScripts_bot_idle_users, 0));

					if ( (iHow == WHO_SPEED) && (!var.user.bHPath && !var.user.bHUser && !var.user.bHGroup) )
					{
						printf(FormatString(jScripts_bot_speed_idle, 0));
						iSpeed++;
					}


					if ( (!var.user.bHPath && !var.user.bHUser && !var.user.bHGroup) )
						var.jWho.iIDLE++;
					
					break;
				}

				case 1:
				{
					
					GetFileInfo(var.jWho.RealDataPath);

					if ( iHow == WHO_NORMAL )
					{
						if ( var.user.bFlags || var.user.bUser || var.user.bGroup )
							printf(FormatString(jScripts_jwho_body_power_dn, 0));
						else
						{
							if ( (!var.user.bHPath && !var.user.bHUser && !var.user.bHGroup) || var.user.bMEUser )
								printf(FormatString(jScripts_jwho_body_normal_dn, 0));
						}
					}

					if ( iHow == WHO_BOT )
						if ( (!var.user.bHPath && !var.user.bHUser && !var.user.bHGroup) )
							printf(FormatString(jScripts_bot_who_body_normal_dn, 0));

					if ( iHow == WHO_DN )
						if ( (!var.user.bHPath && !var.user.bHUser && !var.user.bHGroup) )
							printf(FormatString(jScripts_bot_dn_users, 0));
					
					if ( (iHow == WHO_SPEED) && (!var.user.bHPath && !var.user.bHUser && !var.user.bHGroup) )
					{
						printf(FormatString(jScripts_bot_speed_dn, 0));
						iSpeed++;
					}

					if ( (!var.user.bHPath && !var.user.bHUser && !var.user.bHGroup) )
					{
						var.jWho.iDN++;
						var.jWho.dwDN += var.jWho.dwSpeed;
					}

					break;
				}

				case 2:
				{
					
					GetFileInfo(var.jWho.RealDataPath);

					if ( iHow == WHO_NORMAL )
					{
						if ( var.user.bFlags || var.user.bUser || var.user.bGroup )
							printf(FormatString(jScripts_jwho_body_power_up, 0));
						else
						{
							if ( (!var.user.bHPath && !var.user.bHUser && !var.user.bHGroup) || var.user.bMEUser )
								printf(FormatString(jScripts_jwho_body_normal_up, 0));
						}
					}

					if ( iHow == WHO_BOT )
						if ( (!var.user.bHPath && !var.user.bHUser && !var.user.bHGroup) )
							printf(FormatString(jScripts_bot_who_body_normal_up, 0));
					
					if ( iHow == WHO_UP )
						if ( (!var.user.bHPath && !var.user.bHUser && !var.user.bHGroup) )
							printf(FormatString(jScripts_bot_up_users, 0));
					
					if ( (iHow == WHO_SPEED) && (!var.user.bHPath && !var.user.bHUser && !var.user.bHGroup) )
					{
						printf(FormatString(jScripts_bot_speed_up, 0));
						iSpeed++;
					}

					if ( (!var.user.bHPath && !var.user.bHUser && !var.user.bHGroup) )
					{
						var.jWho.iUP++;
						var.jWho.dwUP += var.jWho.dwSpeed;
					}

					break;
				}

				case 3:
				{
					
					if ( iHow == WHO_NORMAL )
					{
						if ( var.user.bFlags || var.user.bUser || var.user.bGroup )
							printf(FormatString(jScripts_jwho_body_power_list, 0));
						else
						{
							if ( (!var.user.bHPath && !var.user.bHUser && !var.user.bHGroup) || var.user.bMEUser )
								printf(FormatString(jScripts_jwho_body_normal_list, 0));
						}
					}

					if ( iHow == WHO_BOT )
						if ( (!var.user.bHPath && !var.user.bHUser && !var.user.bHGroup) )
							printf(FormatString(jScripts_bot_who_body_normal_list, 0));
					
					if ( iHow == WHO_IDLE )
						if ( (!var.user.bHPath && !var.user.bHUser && !var.user.bHGroup) )
							printf(FormatString(jScripts_bot_idle_users, 0));

					if ( (iHow == WHO_SPEED) && (!var.user.bHPath && !var.user.bHUser && !var.user.bHGroup) )
					{
						printf(FormatString(jScripts_bot_speed_idle, 0));
						iSpeed++;
					}

					if ( (!var.user.bHPath && !var.user.bHUser && !var.user.bHGroup) )
						var.jWho.iIDLE++;

					break;
				}

				default:
				{
					break;
				}
			}

			Users++;
			iPos = nPos;

		}

		if ( lpMessage->dwReturn == (DWORD)-1 )
			break;

		pOnlineData->iOffset++;

	}
	
	//printf("iHow=%i\n",iHow);

	if ( iHow == WHO_NORMAL )
		printf(FormatString(jScripts_jwho_foot, 0));

	if ( iHow == WHO_BW )
		printf(FormatString(jScripts_bot_bw, 0));

	if ( iHow == WHO_BOT )
		printf(FormatString(jScripts_bot_who_foot, 0));

	if ( (iHow == WHO_IDLE) && (var.jWho.iIDLE < 1) )
		printf(FormatString(jScripts_bot_idle_none, 0));

	if ( (iHow == WHO_UP) && (var.jWho.iUP < 1) )
		printf(FormatString(jScripts_bot_up_none, 0));

	if ( (iHow == WHO_DN) && (var.jWho.iDN < 1) )
		printf(FormatString(jScripts_bot_dn_none, 0));

	if ( (iHow == WHO_SPEED) && (iSpeed < 1) )
		printf(FormatString(jScripts_bot_speed_not_online, 0));
}

/*
	Created...: 2005.09.10
	Changed...: 
	By........: Jeza
	Desription: Choose WHO Type.
				BOT_WHO, SITE WHO,...
*/
VOID CheckWho(_TCHAR* argv[])
{

	if ( (strncmp(strupr(argv[2]),"WHO", 3) == 0) )
		Who(WHO_NORMAL);

	if ( strncmp(strupr(argv[2]),"BW", 2) == 0 )
		Who(WHO_BW);

	if ( (strncmp(strupr(argv[2]),"ALL", 3) == 0) )
		Who(WHO_BOT);

	if ( (strncmp(strupr(argv[2]),"IDLE", 4) == 0) )
		Who(WHO_IDLE);

	if ( (strncmp(strupr(argv[2]),"DOWN", 4) == 0) )
		Who(WHO_DN);

	if ( (strncmp(strupr(argv[2]),"UP", 2) == 0) )
		Who(WHO_UP);

	if ( (strncmp(strupr(argv[2]),"SPEED", 5) == 0) && (argv[3] != NULL) )
	{
		sprintf(var.jWho.SpeedUser, "%s", argv[3]);
		Who(WHO_SPEED);
	}

}


