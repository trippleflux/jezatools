
/*
	Created...: 
	Changed...: 
	By........: Mouton
	Desription: Shared Memory.
*/

LRESULT			lResult;
HWND			Target;
HANDLE			(WINAPI *ShMem_Allocate)(LPVOID, ULONG, DWORD);
LPVOID			(WINAPI *ShMem_Lock)(HANDLE, DWORD);
BOOL			(WINAPI *ShMem_Unlock)(LPVOID);
BOOL			(WINAPI *ShMem_Free)(HANDLE, DWORD);
LPDC_MESSAGE	lpMessage;
LPDC_NAMEID		pNameId;
HMODULE			hShell32;
HANDLE			hSharedMemory, hEvent;
LPVOID			lpContext, hMemory;
DWORD			dwProcessId, dwAllocationSize;
DWORD			dwReturn;
HWND			hIoFTPD;

int InitializeSharedMemory(DWORD dwAllocationAsked=4096);
int CloseSharedMemory();

BOOL InitializeSharedMemory( DWORD dwAllocationAsked )
{
	
	hEvent					= INVALID_HANDLE_VALUE;
	lpMessage				= NULL;
	hSharedMemory			= NULL;
	hShell32				= LoadLibrary("shell32.dll");
	hIoFTPD					= FindWindow(jScripts_default_message_window, NULL);
	dwProcessId				= GetCurrentProcessId();
	
	if ( !hIoFTPD )
	{
		return FALSE;
	}
	
	if (dwAllocationSize < dwAllocationAsked + sizeof(DC_MESSAGE))
	{
		dwAllocationSize = dwAllocationAsked + sizeof(DC_MESSAGE);
	}

	if ( hShell32 )
	{
		/*
		ShMem_Allocate	= (HANDLE (WINAPI *)(LPVOID, ULONG, DWORD))GetProcAddress(hShell32, "SHAllocShared");
		ShMem_Free		= (BOOL (WINAPI *)	(HANDLE, DWORD))GetProcAddress(hShell32, "SHFreeShared");
		ShMem_Unlock	= (BOOL (WINAPI *)	(LPVOID))GetProcAddress(hShell32, "SHUnlockShared");
		ShMem_Lock		= (LPVOID (WINAPI *)(HANDLE, DWORD))GetProcAddress(hShell32, "SHLockShared");
		*/
		ShMem_Allocate	= (HANDLE (WINAPI *)(LPVOID, ULONG, DWORD))GetProcAddress(hShell32, (char *)520);
		ShMem_Free		= (BOOL (WINAPI *)	(HANDLE, DWORD))GetProcAddress(hShell32, (char *)523);
		ShMem_Unlock	= (BOOL (WINAPI *)	(LPVOID))GetProcAddress(hShell32, (char *)522);
		ShMem_Lock		= (LPVOID (WINAPI *)(HANDLE, DWORD))GetProcAddress(hShell32, (char *)521);
		
		if ( ShMem_Allocate && ShMem_Free && ShMem_Lock && ShMem_Unlock )
		{
			// Shared memory exists - allocate memory
			hSharedMemory	= ShMem_Allocate(NULL, dwAllocationSize, dwProcessId);
			
			if ( hSharedMemory == INVALID_HANDLE_VALUE )
			{
				return FALSE;
			}
			
			// Create event
			if ( (hEvent = CreateEvent(NULL, FALSE, FALSE, NULL)) == INVALID_HANDLE_VALUE ) 
			{
				return FALSE;
			}

			lpMessage		= (LPDC_MESSAGE)ShMem_Lock(hSharedMemory, dwProcessId);	// Lock allocation

		}
	}
	
	// Allocation failed
	if (!lpMessage)
	{
		return FALSE;
	}

	//	Copy Message id
	lpMessage->hEvent		= hEvent;
	lpMessage->lpMemoryBase	= lpMessage;
	//lpMessage->lpContext	= (LPVOID)((ULONG)lpMessage + sizeof(DC_MESSAGE));
	lpMessage->lpContext	= (lpMessage + sizeof(DC_MESSAGE));

	//	Send initialization message
//	hMemory	= (LPVOID)SendMessage(hIoFTPD, WM_SHMEM_ALLOC, (WPARAM)dwProcessId, (LPARAM)hSharedMemory);
	hMemory	= (LPVOID)SendMessage(hIoFTPD, WM_DATACOPY_SHELLALLOC, (WPARAM)dwProcessId, (LPARAM)hSharedMemory);
	
	//	Verify handle
	if (!hMemory)
	{
		return FALSE;
	}


	return TRUE;

}

int CloseSharedMemory()
{
	//	Free shared memory
	if (hSharedMemory)
	{
//		if (hMemory) SendMessage(hIoFTPD, WM_SHMEM_FREE, NULL, (LPARAM)hMemory);
		if (hMemory) SendMessage(hIoFTPD, WM_DATACOPY_FREE, NULL, (LPARAM)hMemory);
		if (lpMessage) ShMem_Unlock(lpMessage);
		ShMem_Free(hSharedMemory, dwProcessId);
	}
	if (hEvent != INVALID_HANDLE_VALUE)
	{
		CloseHandle(hEvent);
	}

	if (hShell32)
	{
		FreeLibrary(hShell32);
	}

	return TRUE;
}

/*
	Created...: 2005.09.19
	Changed...: 
	By........: Jeza
	Desription: Resolve GID to GROUPNAME.
*/
BOOL ResolveGidToGroupName (int GroupId, char GroupName[GROUPNAME_LENGTH])
{

	pNameId					= (LPDC_NAMEID)lpMessage->lpContext;
	lpMessage->dwIdentifier	= DC_GID_TO_GROUP;

	pNameId->Id				= GroupId;
	pNameId->tszName[0]		= '\0';

	if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
	{
		//	Wait until processed
		WaitForSingleObject(hEvent, INFINITE);
		//	Copy result
		if (! lpMessage->dwReturn) 
		{
			strcpy(GroupName, pNameId->tszName);
			return TRUE;
		}
		else
			return FALSE;
	}
	
	return FALSE;

}

/*
	Created...: 2005.08.22
	Changed...: 
	By........: Jeza
	Desription: Resolve UID to USERNAME.
*/
BOOL ResolveUidToUserName (int UserId, char UserName[USERNAME_LENGTH])
{

	pNameId					= (LPDC_NAMEID)lpMessage->lpContext;
	lpMessage->dwIdentifier	= DC_UID_TO_USER;

	pNameId->Id				= UserId;
	pNameId->tszName[0]		= '\0';

	if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
	{
		//	Wait until processed
		WaitForSingleObject(hEvent, INFINITE);
		//	Copy result
		if (! lpMessage->dwReturn) 
		{
			strcpy(UserName, pNameId->tszName);
			return TRUE;
		}
		else
			return FALSE;
	}
	
	return FALSE;

}

/*
	Created...: 2005.08.22
	Changed...: 
	By........: Jeza
	Desription: Create User.
*/
BOOL CreateUser (char UserName[USERNAME_LENGTH])
{

	pNameId					= (LPDC_NAMEID)lpMessage->lpContext;
	lpMessage->dwIdentifier	= DC_CREATE_USER;

	pNameId->tszName[0]		= '\0';
	strcpy(pNameId->tszName, UserName);
	debug(".......: UserName = '%s'\n", UserName);

	if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
	{
		//	Wait until processed
		WaitForSingleObject(hEvent, INFINITE);
		//	Copy result
		if (! lpMessage->dwReturn) 
		{
			debug(".......: UserName = '%s' SUCCESS\n", UserName);
			return TRUE;
		}
		else
			debug(".......: UserName = '%s' lpMessage->dwReturn FAiLED\n", UserName);
			return FALSE;
	}

	debug(".......: UserName = '%s' SendMessage FAiLED\n", UserName);
	
	return FALSE;

}

/*
	Created...: 2005.08.22
	Changed...: 
	By........: Jeza
	Desription: Delete User.
*/
BOOL DeleteUser (CHAR UserName[USERNAME_LENGTH])
{

	pNameId					= (LPDC_NAMEID)lpMessage->lpContext;
	lpMessage->dwIdentifier	= DC_DELETE_USER;

	pNameId->tszName[0]		= '\0';
	strcpy(pNameId->tszName, UserName);

	if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
	{
		//	Wait until processed
		WaitForSingleObject(hEvent, INFINITE);
		//	Copy result
		if (! lpMessage->dwReturn) 
		{
			return TRUE;
		}
		else
			return FALSE;
	}
	
	return FALSE;

}

/*
	Created...: 2005.08.22
	Changed...: 
	By........: Jeza
	Desription: Get Users GROUPNAME.
*/
BOOL GetGroupName (int UserId, char GroupName[GROUPNAME_LENGTH])
{

	BOOL bOK				= FALSE;

	PUSERFILE pUserFile		= (PUSERFILE)lpMessage->lpContext;
	lpMessage->dwIdentifier	= DC_USERFILE_OPEN;
	
	pUserFile->Uid			= UserId;

	if ( !SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory) )
	{
		// Wait until processed (5 secs)
		if ( WaitForSingleObject(hEvent, 5000) == WAIT_TIMEOUT ) goto g_DONE;

		//resolve gid to group
		lpMessage->dwIdentifier	= DC_GID_TO_GROUP;
		pNameId->Id			= pUserFile->Gid;
		pNameId->tszName[0]	= '\0';

		if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
		{
			//	Wait until processed
			WaitForSingleObject(hEvent, INFINITE);
			//	Copy result
			if (! lpMessage->dwReturn) 
			{
				strcpy(GroupName, pNameId->tszName);
				bOK = TRUE;
			}

		}

	}
	
	lpMessage->dwIdentifier	= DC_USERFILE_CLOSE;;
	
	if ( !SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory) )
	{
		if ( WaitForSingleObject(hEvent, 5000) == WAIT_TIMEOUT ) goto g_DONE;
	}
	
	g_DONE:

	if ( bOK )
		return TRUE;
	else
		return FALSE;

}

/*
	Created...: 2005.09.19
	Changed...: 
	By........: Jeza
	Desription: Get Users Groups.
				var.user.Groups[]
				var.user.AdminGroups
*/
BOOL GetGroups (int UserId, int iPos)
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
		
		var.usertable[iPos].ACount	= 0;
		var.usertable[iPos].GCount	= 0;

		for (int i = 0;( (i<MAX_GROUPS) && (pUserFile->Groups[i] > -1) );i++)
		{
			var.usertable[iPos].GCount++;
			var.usertable[iPos].Groups[i]			= pUserFile->Groups[i];
			//printf("pUserFile->Groups[%i]=%i\n", i, pUserFile->Groups[i]);
		}
		
		for (int j = 0;( (j<MAX_GROUPS) && (pUserFile->AdminGroups[j] > -1) );j++)
		{
			var.usertable[iPos].ACount++;
			var.usertable[iPos].AdminGroups[j]		= pUserFile->AdminGroups[j];
			//printf("pUserFile->AdminGroups[%i]=%i\n", j, pUserFile->AdminGroups[j]);
		}

		bOK = TRUE;
	}

	lpMessage->dwIdentifier	= DC_USERFILE_CLOSE;;
	
	if ( !SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory) )
	{
		if ( WaitForSingleObject(hEvent, 5000) == WAIT_TIMEOUT ) goto s_DONE;
	}
	
	s_DONE:

	if ( bOK )
		return TRUE;
	else
		return FALSE;

}

/*
	Created...: 2005.09.02
	Changed...: 
	By........: Jeza
	Desription: Get Users Stats in Section.
*/
BOOL GetStats(int iPos, int UserId, int iSection)
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

		var.usertable[iPos].tCredits	= pUserFile->Credits[iSection];

		var.usertable[iPos].tAllUPf		= pUserFile->AllUp[(3*iSection)];
		var.usertable[iPos].tAllDNf		= pUserFile->AllDn[(3*iSection)];
		var.usertable[iPos].tMnUPf		= pUserFile->MonthUp[(3*iSection)];
		var.usertable[iPos].tMnDNf		= pUserFile->MonthDn[(3*iSection)];
		var.usertable[iPos].tWkUPf		= pUserFile->WkUp[(3*iSection)];
		var.usertable[iPos].tWkDNf		= pUserFile->WkDn[(3*iSection)];
		var.usertable[iPos].tDayUPf		= pUserFile->DayUp[(3*iSection)];
		var.usertable[iPos].tDayDNf		= pUserFile->DayDn[(3*iSection)];

		var.usertable[iPos].tAllUP		= pUserFile->AllUp[(3*iSection)+1];
		var.usertable[iPos].tAllDN		= pUserFile->AllDn[(3*iSection)+1];
		var.usertable[iPos].tMnUP		= pUserFile->MonthUp[(3*iSection)+1];
		var.usertable[iPos].tMnDN		= pUserFile->MonthDn[(3*iSection)+1];
		var.usertable[iPos].tWkUP		= pUserFile->WkUp[(3*iSection)+1];
		var.usertable[iPos].tWkDN		= pUserFile->WkDn[(3*iSection)+1];
		var.usertable[iPos].tDayUP		= pUserFile->DayUp[(3*iSection)+1];
		var.usertable[iPos].tDayDN		= pUserFile->DayDn[(3*iSection)+1];
		
		var.usertable[iPos].tAllUPs		= 0;
		var.usertable[iPos].tAllDNs		= 0;
		var.usertable[iPos].tMnUPs		= 0;
		var.usertable[iPos].tMnDNs		= 0;
		var.usertable[iPos].tWkUPs		= 0;
		var.usertable[iPos].tWkDNs		= 0;
		var.usertable[iPos].tDayUPs		= 0;
		var.usertable[iPos].tDayDNs		= 0;

		if ( pUserFile->AllUp[(3*iSection)+2] > 0 )
		{
			var.usertable[iPos].tAllUPs		= 
				pUserFile->AllUp[(3*iSection)+1] / pUserFile->AllUp[(3*iSection)+2];
		}

		if ( pUserFile->AllDn[(3*iSection)+2] > 0 )
		{
			var.usertable[iPos].tAllDNs		= 
				pUserFile->AllDn[(3*iSection)+1] / pUserFile->AllDn[(3*iSection)+2];
		}

		if ( pUserFile->MonthUp[(3*iSection)+2] > 0 )
		{
			var.usertable[iPos].tMnUPs		= 
				pUserFile->MonthUp[(3*iSection)+1] / pUserFile->MonthUp[(3*iSection)+2];
		}

		if ( pUserFile->MonthDn[(3*iSection)+2] > 0 )
		{
			var.usertable[iPos].tMnDNs		= 
				pUserFile->MonthDn[(3*iSection)+1] / pUserFile->MonthDn[(3*iSection)+2];
		}

		if ( pUserFile->WkUp[(3*iSection)+2] > 0 )
		{
			var.usertable[iPos].tWkUPs		= 
				pUserFile->WkUp[(3*iSection)+1] / pUserFile->WkUp[(3*iSection)+2];
		}

		if ( pUserFile->WkDn[(3*iSection)+2] > 0 )
		{
			var.usertable[iPos].tWkDNs		= 
				pUserFile->WkDn[(3*iSection)+1] / pUserFile->WkDn[(3*iSection)+2];
		}

		if ( pUserFile->DayUp[(3*iSection)+2] > 0 )
		{
			var.usertable[iPos].tDayUPs		= 
				pUserFile->DayUp[(3*iSection)+1] / pUserFile->DayUp[(3*iSection)+2];
		}

		if ( pUserFile->DayDn[(3*iSection)+2] > 0 )
		{
			var.usertable[iPos].tDayDNs		= 
				pUserFile->DayDn[(3*iSection)+1] / pUserFile->DayDn[(3*iSection)+2];
		}

		sprintf(var.usertable[iPos].tFlags, pUserFile->Flags);
		var.usertable[iPos].tGid		= pUserFile->Gid;

		GetGroupName(pUserFile->Uid, var.usertable[iPos].tGroupName);
	}

	lpMessage->dwIdentifier	= DC_USERFILE_CLOSE;;
	
	if ( !SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory) )
	{
		if ( WaitForSingleObject(hEvent, 5000) == WAIT_TIMEOUT ) goto s_DONE;
	}
	
	s_DONE:

	if ( bOK )
		return TRUE;
	else
		return FALSE;

}

/*
	Created...: 2005.09.06
	Changed...: 
	By........: Jeza
	Desription: Sort Users Stats by 'iHow'.
*/
BOOL SortUStats(short iHow, int iTotal)
{

	switch ( iHow )
	{

		case SORT_ALLUP:
		{
				
			for (int k=0;k<iTotal;k++)
			{
				for (int t=0;t<iTotal;t++)
				{
        
					if ( (var.usertable[t+1].tAllUP != NULL) && (var.usertable[t].tAllUP < var.usertable[t+1].tAllUP) )
					{
	
						struct _USERTABLE usr[1];

						usr[0]					= var.usertable[t];
						var.usertable[t]		= var.usertable[t+1];
						var.usertable[t+1]		= usr[0];

					}
				}
		    }

			break;
		}

		case SORT_ALLDN:
		{
				
			for (int k=0;k<iTotal;k++)
			{
				for (int t=0;t<iTotal;t++)
				{
        
					if ( (var.usertable[t+1].tAllDN != NULL) && (var.usertable[t].tAllDN < var.usertable[t+1].tAllDN) )
					{
	
						struct _USERTABLE usr[1];

						usr[0]					= var.usertable[t];
						var.usertable[t]		= var.usertable[t+1];
						var.usertable[t+1]		= usr[0];

					}
				}
		    }

			break;
		}

		case SORT_MNUP:
		{
				
			for (int k=0;k<iTotal;k++)
			{
				for (int t=0;t<iTotal;t++)
				{
        
					if ( (var.usertable[t+1].tMnUP != NULL) && (var.usertable[t].tMnUP < var.usertable[t+1].tMnUP) )
					{
	
						struct _USERTABLE usr[1];

						usr[0]					= var.usertable[t];
						var.usertable[t]		= var.usertable[t+1];
						var.usertable[t+1]		= usr[0];

					}
				}
		    }

			break;
		}

		case SORT_MNDN:
		{
				
			for (int k=0;k<iTotal;k++)
			{
				for (int t=0;t<iTotal;t++)
				{
        
					if ( (var.usertable[t+1].tMnDN != NULL) && (var.usertable[t].tMnDN < var.usertable[t+1].tMnDN) )
					{
	
						struct _USERTABLE usr[1];

						usr[0]					= var.usertable[t];
						var.usertable[t]		= var.usertable[t+1];
						var.usertable[t+1]		= usr[0];

					}
				}
		    }

			break;
		}

		case SORT_WKUP:
		{
				
			for (int k=0;k<iTotal;k++)
			{
				for (int t=0;t<iTotal;t++)
				{
        
					if ( (var.usertable[t+1].tWkUP != NULL) && (var.usertable[t].tWkUP < var.usertable[t+1].tWkUP) )
					{
	
						struct _USERTABLE usr[1];

						usr[0]					= var.usertable[t];
						var.usertable[t]		= var.usertable[t+1];
						var.usertable[t+1]		= usr[0];

					}
				}
		    }

			break;
		}

		case SORT_WKDN:
		{
				
			for (int k=0;k<iTotal;k++)
			{
				for (int t=0;t<iTotal;t++)
				{
        
					if ( (var.usertable[t+1].tWkDN != NULL) && (var.usertable[t].tWkDN < var.usertable[t+1].tWkDN) )
					{
	
						struct _USERTABLE usr[1];

						usr[0]					= var.usertable[t];
						var.usertable[t]		= var.usertable[t+1];
						var.usertable[t+1]		= usr[0];

					}
				}
		    }

			break;
		}

		case SORT_DAYUP:
		{
				
			for (int k=0;k<iTotal;k++)
			{
				for (int t=0;t<iTotal;t++)
				{
        
					if ( (var.usertable[t+1].tDayUP != NULL) && (var.usertable[t].tDayUP < var.usertable[t+1].tDayUP) )
					{
	
						struct _USERTABLE usr[1];

						usr[0]					= var.usertable[t];
						var.usertable[t]		= var.usertable[t+1];
						var.usertable[t+1]		= usr[0];

					}
				}
		    }

			break;
		}

		case SORT_DAYDN:
		{
				
			for (int k=0;k<iTotal;k++)
			{
				for (int t=0;t<iTotal;t++)
				{
        
					if ( (var.usertable[t+1].tDayDN != NULL) && (var.usertable[t].tDayDN < var.usertable[t+1].tDayDN) )
					{
	
						struct _USERTABLE usr[1];

						usr[0]					= var.usertable[t];
						var.usertable[t]		= var.usertable[t+1];
						var.usertable[t+1]		= usr[0];

					}
				}
		    }

			break;
		}

		default:
			break;

	}

	for (int i=0;i<iTotal;i++)
	{
		//printf("sortustats %i : '%s'\n", iHow, var.usertable[i].tUserName);
		switch ( iHow )
		{
			case SORT_ALLUP:	{var.usertable[i].tAllUPPos = i+1;break;}
			case SORT_ALLDN:	{var.usertable[i].tAllDNPos = i+1;break;}
			case SORT_MNUP:		{var.usertable[i].tMnUPPos = i+1;break;}
			case SORT_MNDN:		{var.usertable[i].tMnDNPos = i+1;break;}
			case SORT_WKUP:		{var.usertable[i].tWkUPPos = i+1;break;}
			case SORT_WKDN:		{var.usertable[i].tWkDNPos = i+1;break;}
			case SORT_DAYUP:	{var.usertable[i].tDayUPPos = i+1;break;}
			case SORT_DAYDN:	{var.usertable[i].tDayDNPos = i+1;break;}
			default:			{var.usertable[i].tAllUPPos = i+1;break;}
		}
	}

	return TRUE;
}

/*
	Created...: 2006.03.12
	Changed...: 
	By........: Jeza
	Desription: Sort Groups Stats by 'iHow'.
*/
BOOL SortGStats(short iHow, int iTotal)
{

	switch ( iHow )
	{

		case SORT_ALLUP:
		{
				
			for (int k=0;k<iTotal;k++)
			{
				for (int t=0;t<iTotal;t++)
				{
        
					if ( (var.grouptable[t+1].tAllUP != NULL) && (var.grouptable[t].tAllUP < var.grouptable[t+1].tAllUP) )
					{
	
						struct _GROUPTABLE grp[1];

						grp[0]					= var.grouptable[t];
						var.grouptable[t]		= var.grouptable[t+1];
						var.grouptable[t+1]		= grp[0];

					}
				}
		    }

			break;
		}

		case SORT_ALLDN:
		{
				
			for (int k=0;k<iTotal;k++)
			{
				for (int t=0;t<iTotal;t++)
				{
        
					if ( (var.grouptable[t+1].tAllDN != NULL) && (var.grouptable[t].tAllDN < var.grouptable[t+1].tAllDN) )
					{
	
						struct _GROUPTABLE grp[1];

						grp[0]					= var.grouptable[t];
						var.grouptable[t]		= var.grouptable[t+1];
						var.grouptable[t+1]		= grp[0];

					}
				}
		    }

			break;
		}

		case SORT_MNUP:
		{
				
			for (int k=0;k<iTotal;k++)
			{
				for (int t=0;t<iTotal;t++)
				{
        
					if ( (var.grouptable[t+1].tMnUP != NULL) && (var.grouptable[t].tMnUP < var.grouptable[t+1].tMnUP) )
					{
	
						struct _GROUPTABLE grp[1];

						grp[0]					= var.grouptable[t];
						var.grouptable[t]		= var.grouptable[t+1];
						var.grouptable[t+1]		= grp[0];

					}
				}
		    }

			break;
		}

		case SORT_MNDN:
		{
				
			for (int k=0;k<iTotal;k++)
			{
				for (int t=0;t<iTotal;t++)
				{
        
					if ( (var.grouptable[t+1].tMnDN != NULL) && (var.grouptable[t].tMnDN < var.grouptable[t+1].tMnDN) )
					{
	
						struct _GROUPTABLE grp[1];

						grp[0]					= var.grouptable[t];
						var.grouptable[t]		= var.grouptable[t+1];
						var.grouptable[t+1]		= grp[0];

					}
				}
		    }

			break;
		}

		case SORT_WKUP:
		{
				
			for (int k=0;k<iTotal;k++)
			{
				for (int t=0;t<iTotal;t++)
				{
        
					if ( (var.grouptable[t+1].tWkUP != NULL) && (var.grouptable[t].tWkUP < var.grouptable[t+1].tWkUP) )
					{
	
						struct _GROUPTABLE grp[1];

						grp[0]					= var.grouptable[t];
						var.grouptable[t]		= var.grouptable[t+1];
						var.grouptable[t+1]		= grp[0];

					}
				}
		    }

			break;
		}

		case SORT_WKDN:
		{
				
			for (int k=0;k<iTotal;k++)
			{
				for (int t=0;t<iTotal;t++)
				{
        
					if ( (var.grouptable[t+1].tWkDN != NULL) && (var.grouptable[t].tWkDN < var.grouptable[t+1].tWkDN) )
					{
	
						struct _GROUPTABLE grp[1];

						grp[0]					= var.grouptable[t];
						var.grouptable[t]		= var.grouptable[t+1];
						var.grouptable[t+1]		= grp[0];

					}
				}
		    }

			break;
		}

		case SORT_DAYUP:
		{
				
			for (int k=0;k<iTotal;k++)
			{
				for (int t=0;t<iTotal;t++)
				{
        
					if ( (var.grouptable[t+1].tDayUP != NULL) && (var.grouptable[t].tDayUP < var.grouptable[t+1].tDayUP) )
					{
	
						struct _GROUPTABLE grp[1];

						grp[0]					= var.grouptable[t];
						var.grouptable[t]		= var.grouptable[t+1];
						var.grouptable[t+1]		= grp[0];

					}
				}
		    }

			break;
		}

		case SORT_DAYDN:
		{
				
			for (int k=0;k<iTotal;k++)
			{
				for (int t=0;t<iTotal;t++)
				{
        
					if ( (var.grouptable[t+1].tDayDN != NULL) && (var.grouptable[t].tDayDN < var.grouptable[t+1].tDayDN) )
					{
	
						struct _GROUPTABLE grp[1];

						grp[0]					= var.grouptable[t];
						var.grouptable[t]		= var.grouptable[t+1];
						var.grouptable[t+1]		= grp[0];

					}
				}
		    }

			break;
		}

		default:
			break;

	}

	for (int i=0;i<iTotal;i++)
	{
		//printf("sortgstats iTotal=%i %i : '%s'\n", iTotal, iHow, var.grouptable[i].tGroupName);
		switch ( iHow )
		{
			case SORT_ALLUP:	{var.grouptable[i].tAllUPPos = i+1;break;}
			case SORT_ALLDN:	{var.grouptable[i].tAllDNPos = i+1;break;}
			case SORT_MNUP:		{var.grouptable[i].tMnUPPos = i+1;break;}
			case SORT_MNDN:		{var.grouptable[i].tMnDNPos = i+1;break;}
			case SORT_WKUP:		{var.grouptable[i].tWkUPPos = i+1;break;}
			case SORT_WKDN:		{var.grouptable[i].tWkDNPos = i+1;break;}
			case SORT_DAYUP:	{var.grouptable[i].tDayUPPos = i+1;break;}
			case SORT_DAYDN:	{var.grouptable[i].tDayDNPos = i+1;break;}
			default:			{var.grouptable[i].tAllUPPos = i+1;break;}
		}
	}

	return TRUE;
}

/*
	Created...: 2005.09.04
	Changed...: 
	By........: Jeza
	Desription: Sort Users Stats by 'iHow'.
				Returns 'UserName' Position or -1 if Not Found.
*/
INT SortStats(short iHow, int iTotal, char UserName[USERNAME_LENGTH])
{

	switch ( iHow )
	{

		case SORT_ALLUP:
		{
				
			for (int k=0;k<iTotal;k++)
			{
				for (int t=0;t<iTotal;t++)
				{
        
					if ( (var.usertable[t+1].tAllUP != NULL) && (var.usertable[t].tAllUP < var.usertable[t+1].tAllUP) )
					{
	
						struct _USERTABLE usr[1];

						usr[0]					= var.usertable[t];
						var.usertable[t]		= var.usertable[t+1];
						var.usertable[t+1]		= usr[0];

					}
				}
		    }

			break;
		}

		case SORT_ALLDN:
		{
				
			for (int k=0;k<iTotal;k++)
			{
				for (int t=0;t<iTotal;t++)
				{
        
					if ( (var.usertable[t+1].tAllDN != NULL) && (var.usertable[t].tAllDN < var.usertable[t+1].tAllDN) )
					{
	
						struct _USERTABLE usr[1];

						usr[0]					= var.usertable[t];
						var.usertable[t]		= var.usertable[t+1];
						var.usertable[t+1]		= usr[0];

					}
				}
		    }

			break;
		}

		case SORT_MNUP:
		{
				
			for (int k=0;k<iTotal;k++)
			{
				for (int t=0;t<iTotal;t++)
				{
        
					if ( (var.usertable[t+1].tMnUP != NULL) && (var.usertable[t].tMnUP < var.usertable[t+1].tMnUP) )
					{
	
						struct _USERTABLE usr[1];

						usr[0]					= var.usertable[t];
						var.usertable[t]		= var.usertable[t+1];
						var.usertable[t+1]		= usr[0];

					}
				}
		    }

			break;
		}

		case SORT_MNDN:
		{
				
			for (int k=0;k<iTotal;k++)
			{
				for (int t=0;t<iTotal;t++)
				{
        
					if ( (var.usertable[t+1].tMnDN != NULL) && (var.usertable[t].tMnDN < var.usertable[t+1].tMnDN) )
					{
	
						struct _USERTABLE usr[1];

						usr[0]					= var.usertable[t];
						var.usertable[t]		= var.usertable[t+1];
						var.usertable[t+1]		= usr[0];

					}
				}
		    }

			break;
		}

		case SORT_WKUP:
		{
				
			for (int k=0;k<iTotal;k++)
			{
				for (int t=0;t<iTotal;t++)
				{
        
					if ( (var.usertable[t+1].tWkUP != NULL) && (var.usertable[t].tWkUP < var.usertable[t+1].tWkUP) )
					{
	
						struct _USERTABLE usr[1];

						usr[0]					= var.usertable[t];
						var.usertable[t]		= var.usertable[t+1];
						var.usertable[t+1]		= usr[0];

					}
				}
		    }

			break;
		}

		case SORT_WKDN:
		{
				
			for (int k=0;k<iTotal;k++)
			{
				for (int t=0;t<iTotal;t++)
				{
        
					if ( (var.usertable[t+1].tWkDN != NULL) && (var.usertable[t].tWkDN < var.usertable[t+1].tWkDN) )
					{
	
						struct _USERTABLE usr[1];

						usr[0]					= var.usertable[t];
						var.usertable[t]		= var.usertable[t+1];
						var.usertable[t+1]		= usr[0];

					}
				}
		    }

			break;
		}

		case SORT_DAYUP:
		{
				
			for (int k=0;k<iTotal;k++)
			{
				for (int t=0;t<iTotal;t++)
				{
        
					if ( (var.usertable[t+1].tDayUP != NULL) && (var.usertable[t].tDayUP < var.usertable[t+1].tDayUP) )
					{
	
						struct _USERTABLE usr[1];

						usr[0]					= var.usertable[t];
						var.usertable[t]		= var.usertable[t+1];
						var.usertable[t+1]		= usr[0];

					}
				}
		    }

			break;
		}

		case SORT_DAYDN:
		{
				
			for (int k=0;k<iTotal;k++)
			{
				for (int t=0;t<iTotal;t++)
				{
        
					if ( (var.usertable[t+1].tDayDN != NULL) && (var.usertable[t].tDayDN < var.usertable[t+1].tDayDN) )
					{
	
						struct _USERTABLE usr[1];

						usr[0]					= var.usertable[t];
						var.usertable[t]		= var.usertable[t+1];
						var.usertable[t+1]		= usr[0];

					}
				}
		    }

			break;
		}

		default:
			break;

	}

    int iPos = -1;
	
	for (int p=0;p<iTotal;p++)
	{
		if ( strcmp(var.usertable[p].tUserName,UserName) == 0 )
		{
			iPos = p+1;
			break;
		}
	}

	return iPos;
}

/*
	Created...: 2005.08.25
	Changed...: 
	By........: Jeza
	Desription: Changes Users Upload Stats.
*/
BOOL SetStats(int UserId, int iN)
{

	PUSERFILE pUserFile		= (PUSERFILE)lpMessage->lpContext;
		
	//	Open userfile (by user id - not possible by name)
		lpMessage->dwIdentifier	= DC_USERFILE_OPEN;
		pUserFile->Uid	= UserId;

		if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
		{
			//	Wait until done
			WaitForSingleObject(hEvent, INFINITE);
	
			//	Lock userfile (exclusive, required only when writing)
			lpMessage->dwIdentifier	= DC_USERFILE_LOCK;

			if (! lpMessage->dwReturn &&
				! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
			{
				//	Wait until done
				WaitForSingleObject(hEvent, INFINITE);

				if (! lpMessage->dwReturn)
				{
					
					

					pUserFile->DayUp[1]		= iN*123;
					pUserFile->WkUp[1]		= iN*321;
					pUserFile->MonthUp[1]	= iN*213;
					pUserFile->AllUp[1]		= iN*231;
					//	Unlock userfile (if this is not done, io will go crazy..)
					lpMessage->dwIdentifier	= DC_USERFILE_UNLOCK;
					if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
					{
						//	Wait until done
						WaitForSingleObject(hEvent, INFINITE);
					}
				}
			}
			//	Close userfile
			lpMessage->dwIdentifier	= DC_USERFILE_CLOSE;;
			if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
			{
				//	Wait until done
				WaitForSingleObject(hEvent, INFINITE);
			}
		}
	
		return TRUE;

}

/*
	Created...: 2005.08.25
	Changed...: 2005.09.04
	By........: Jeza
	Desription: Fills Struct '_USERTABLE'.
*/
BOOL FillStats( short iSect )
{

	var.user.TotalUsers = 0;
	//short iSect = 0;

	for (int u=0;u<MAXUSERS;u++)
	{
	  
		char TestUserName[USERNAME_LENGTH] = "";

		if ( ResolveUidToUserName(u, TestUserName) )
		{

			sprintf(var.usertable[var.user.TotalUsers].tUserName,TestUserName);
			var.usertable[var.user.TotalUsers].tUid = u;
			
			if ( !var.ustats.bNoDate )
			{
			
				//only when fill USERS TABLE
				if ( var.sql.bFindDate )
				{
					//find date from sysop.log
					FindDate(TestUserName);
					sprintf(var.usertable[var.user.TotalUsers].DateAddedTime, var.user.AddedDate);
				}
				else
				{
					FindDateFromSQL(TestUserName);
					sprintf(var.usertable[var.user.TotalUsers].DateAddedTime, var.user.AddedDate);
				}
			
			}

			GetStats(var.user.TotalUsers, u, iSect);
			var.user.TotalUsers++;
		}
	}

	return TRUE;
}

/*

*/
BOOL AddGStats ( INT k, INT t )
{

	var.grouptable[k].tAllUPf		+= var.usertable[t].tAllUPf;
	var.grouptable[k].tAllDNf 		+= var.usertable[t].tAllDNf;
	var.grouptable[k].tMnUPf 		+= var.usertable[t].tMnUPf;
	var.grouptable[k].tMnDNf 		+= var.usertable[t].tMnDNf;
	var.grouptable[k].tWkUPf 		+= var.usertable[t].tWkUPf;
	var.grouptable[k].tWkDNf 		+= var.usertable[t].tWkDNf;
	var.grouptable[k].tDayUPf 		+= var.usertable[t].tDayUPf;
	var.grouptable[k].tDayDNf 		+= var.usertable[t].tDayDNf;

	var.grouptable[k].tAllUP		+= var.usertable[t].tAllUP;
	var.grouptable[k].tAllDN 		+= var.usertable[t].tAllDN;
	var.grouptable[k].tMnUP 		+= var.usertable[t].tMnUP;
	var.grouptable[k].tMnDN 		+= var.usertable[t].tMnDN;
	var.grouptable[k].tWkUP 		+= var.usertable[t].tWkUP;
	var.grouptable[k].tWkDN 		+= var.usertable[t].tWkDN;
	var.grouptable[k].tDayUP 		+= var.usertable[t].tDayUP;
	var.grouptable[k].tDayDN 		+= var.usertable[t].tDayDN;
	
	var.grouptable[k].tAllUPs		+= var.usertable[t].tAllUPs;
	var.grouptable[k].tAllDNs 		+= var.usertable[t].tAllDNs;
	var.grouptable[k].tMnUPs 		+= var.usertable[t].tMnUPs;
	var.grouptable[k].tMnDNs		+= var.usertable[t].tMnDNs;
	var.grouptable[k].tWkUPs 		+= var.usertable[t].tWkUPs;
	var.grouptable[k].tWkDNs 		+= var.usertable[t].tWkDNs;
	var.grouptable[k].tDayUPs 		+= var.usertable[t].tDayUPs;
	var.grouptable[k].tDayDNs 		+= var.usertable[t].tDayDNs;

	return TRUE;

}

/*
	Created...: 2006.03.12
	Changed...: 
	By........: Jeza
	Desription: Fills Struct '_GROUPTABLE'.
*/
BOOL FillGStats( short iSect )
{

	var.user.TotalUsers = 0;
	var.gstats.iTotalGroups = 0;

	BOOL bFirst = FALSE;

	for (int u=0;u<MAXUSERS;u++)
	{
	  
		char TestUserName[USERNAME_LENGTH] = "";

		if ( ResolveUidToUserName(u, TestUserName) )
		{

			//var.usertable[var.user.TotalUsers].tUid = u;
			
			GetStats(var.user.TotalUsers, u, iSect);

			/*
			 * first one in struct is empty
			 * so fill it with first group stats
			 */
			if (strlen(var.grouptable[0].tGroupName) == 0)
			{

				StrCpy(var.grouptable[0].tGroupName, var.usertable[var.user.TotalUsers].tGroupName);
				
				var.grouptable[0].tCredits		+= var.usertable[var.user.TotalUsers].tCredits;

				AddGStats ( 0, var.user.TotalUsers );

				var.gstats.iTotalGroups++;

				var.grouptable[0].tTotalUsersInGroup++;

				bFirst = TRUE;
				
			}

			BOOL bNEW = FALSE;

			/*
			 * go trough all groups
			 * and fill struct if needed
			 */
			for ( INT k = 0; k < var.gstats.iTotalGroups ; k++)
			{
				
				/*
				 * empty ?
				 */
				if (strlen(var.grouptable[k].tGroupName) == 0)
				{
					break;
				}

				/*
				 * found a GID in table 
				 * so add stats to it
				 */
				//if ( var.usertable[var.user.TotalUsers].tGid == var.grouptable[k].tGid )
				if ( StrCmp(var.usertable[var.user.TotalUsers].tGroupName, var.grouptable[k].tGroupName) == 0 )
				{
					
					var.grouptable[k].tCredits		+= var.usertable[var.user.TotalUsers].tCredits;

					AddGStats( k, var.user.TotalUsers );

					bNEW = FALSE;

					var.grouptable[k].tTotalUsersInGroup++;

					break;

				}

				/*
				 * found new GID in table 
				 */
				//if ( var.usertable[var.user.TotalUsers].tGid != var.grouptable[k].tGid )
				if ( StrCmp(var.usertable[var.user.TotalUsers].tGroupName, var.grouptable[k].tGroupName) != 0 )
				{
					bNEW = TRUE;
				}

				/*
				printf ("k=%i GGID=%i UGID=%i '%s' - '%s' :: ", 
					k, 
					var.grouptable[k].tGid, 
					var.usertable[var.user.TotalUsers].tGid, 
					var.grouptable[k].tGroupName, 
					var.usertable[var.user.TotalUsers].tGroupName);
				*/

			}

			/*
			 * Add new group to struct
			 */
			if ( bNEW )
			{
				
				StrCpy(var.grouptable[var.gstats.iTotalGroups].tGroupName, var.usertable[var.user.TotalUsers].tGroupName);
				
				var.grouptable[var.gstats.iTotalGroups].tCredits		+= var.usertable[var.user.TotalUsers].tCredits;

				AddGStats ( var.gstats.iTotalGroups, var.user.TotalUsers );

				var.grouptable[var.gstats.iTotalGroups].tTotalUsersInGroup++;

				var.gstats.iTotalGroups++;

				bNEW = FALSE;

			}

			var.user.TotalUsers++;
		}
	}

	//printf("var.gstats.iTotalGroups=%i\n", var.gstats.iTotalGroups);

	return TRUE;
}

/*
	Created...: 2005.09.19
	Changed...: 
	By........: Jeza
	Desription: Resolve GROUPNAME to GID.
*/
INT ResolveGroupNameToGid (char GroupName[GROUPNAME_LENGTH])
{

	pNameId					= (LPDC_NAMEID)lpMessage->lpContext;
	lpMessage->dwIdentifier	= DC_GROUP_TO_GID;

	strcpy(pNameId->tszName, GroupName);

	if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
	{
		//	Wait until processed
		WaitForSingleObject(hEvent, INFINITE);

			return (INT)lpMessage->dwReturn;
	}
	
	return -1;

}

/*
	Created...: 2005.09.18
	Changed...: 
	By........: Jeza
	Desription: Resolve USERNAME to UID.
*/
INT ResolveUserNameToUid (char UserName[USERNAME_LENGTH])
{

	pNameId					= (LPDC_NAMEID)lpMessage->lpContext;
	lpMessage->dwIdentifier	= DC_USER_TO_UID;

	strcpy(pNameId->tszName, UserName);

	if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
	{
		//	Wait until processed
		WaitForSingleObject(hEvent, INFINITE);

			return (INT)lpMessage->dwReturn;
	}
	
	return -1;

}

/*
	Created...: 2005.09.18
	Changed...: 
	By........: Jeza
	Desription: Add A Flag To User.
*/
BOOL AddFlag (int UserId, char *Flag)
{

	PUSERFILE pUserFile		= (PUSERFILE)lpMessage->lpContext;
		
	//	Open userfile (by user id - not possible by name)
	lpMessage->dwIdentifier	= DC_USERFILE_OPEN;
	pUserFile->Uid	= UserId;

	if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
	{
		//	Wait until done
		WaitForSingleObject(hEvent, INFINITE);

		//	Lock userfile (exclusive, required only when writing)
		lpMessage->dwIdentifier	= DC_USERFILE_LOCK;

		if (! lpMessage->dwReturn &&
			! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
		{
			//	Wait until done
			WaitForSingleObject(hEvent, INFINITE);

			if (! lpMessage->dwReturn)
			{
				
				strcat(pUserFile->Flags, Flag);

				//	Unlock userfile (if this is not done, io will go crazy..)
				lpMessage->dwIdentifier	= DC_USERFILE_UNLOCK;
				if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
				{
					//	Wait until done
					WaitForSingleObject(hEvent, INFINITE);
				}
			}
		}
		//	Close userfile
		lpMessage->dwIdentifier	= DC_USERFILE_CLOSE;;
		if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
		{
			//	Wait until done
			WaitForSingleObject(hEvent, INFINITE);
		}
	}
	else
	{
		return FALSE;
	}

	return TRUE;
}

/*
	Created...: 2005.09.18
	Changed...: 
	By........: Jeza
	Desription: Remove A Flag From User.
*/
BOOL DelFlag (int UserId, char Flag)
{

	PUSERFILE pUserFile		= (PUSERFILE)lpMessage->lpContext;
		
	//	Open userfile (by user id - not possible by name)
	lpMessage->dwIdentifier	= DC_USERFILE_OPEN;
	pUserFile->Uid	= UserId;

	if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
	{
		//	Wait until done
		WaitForSingleObject(hEvent, INFINITE);

		//	Lock userfile (exclusive, required only when writing)
		lpMessage->dwIdentifier	= DC_USERFILE_LOCK;

		if (! lpMessage->dwReturn &&
			! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
		{
			//	Wait until done
			WaitForSingleObject(hEvent, INFINITE);

			if (! lpMessage->dwReturn)
			{
				
				//char orgFlags[32 + 1];
				char newFlags[32 + 1] = {0};
				short j = 0;

				for (unsigned int i=0;i<strlen(pUserFile->Flags);i++)
				{
					if ( pUserFile->Flags[i] != Flag)
					{
						newFlags[j] = pUserFile->Flags[i];
						j++;
					}
				}

				sprintf(pUserFile->Flags, "%s", newFlags);
				
				//printf("newFlags='%s'\n", newFlags);

				//	Unlock userfile (if this is not done, io will go crazy..)
				lpMessage->dwIdentifier	= DC_USERFILE_UNLOCK;
				if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
				{
					//	Wait until done
					WaitForSingleObject(hEvent, INFINITE);
				}
			}
		}
		//	Close userfile
		lpMessage->dwIdentifier	= DC_USERFILE_CLOSE;;
		if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
		{
			//	Wait until done
			WaitForSingleObject(hEvent, INFINITE);
		}
	}
	else
	{
		return FALSE;
	}

	return TRUE;
}

/*
	Created...: 2005.09.19
	Changed...: 
	By........: Jeza
	Desription: Checks If 'UID' Is Gadmin of 'UserId'.
				'UID'		= GADMIN
				'UserId'	= NormalUser
*/
BOOL CheckGadmin(INT UID, INT UserId)
{
	BOOL bOK = FALSE;

	//var.usertable[x].AdminGroups
	//var.usertable[x].Groups
	//var.usertable[x].ACount
	//var.usertable[x].GCount

	GetGroups(UID, 0);						//gadmin	

	if (var.usertable[0].ACount < 1)		//0 admingroups -> not gadmin
		return FALSE;

	GetGroups(UserId, 1);					//user

	//printf("var.usertable[0].ACount=%i\n", var.usertable[0].ACount);
	//printf("var.usertable[0].GCount=%i\n", var.usertable[0].GCount);
	//printf("var.usertable[1].ACount=%i\n", var.usertable[1].ACount);
	//printf("var.usertable[1].GCount=%i\n", var.usertable[1].GCount);

	for (int j = 0;j<var.usertable[1].GCount;j++)
	{
		for (int i = 0;i<var.usertable[0].ACount;i++)
		{
			//printf(" var.usertable[1].Groups[%i] = %i :: var.usertable[0].AdminGroups[%i] = %i\n", j, var.usertable[1].Groups[j], i, var.usertable[0].AdminGroups[i]);
			if ( var.usertable[1].Groups[j] == var.usertable[0].AdminGroups[i] )
			{
				bOK = TRUE;
				break;
			}
		}
	}

	if ( bOK )
		return TRUE;
	else
		return FALSE;

}

/*
	Created...: 2006.02.01
	Changed...: 
	By........: Jeza
	Desription: Decrease Number Of Users In Group For 1.
*/
BOOL DecreaseGroupUsers(INT GID)
{

	debug("->DecreaseGroupUsers '%i'\n", GID);

	LPGROUPFILE lpGroupFile		= (LPGROUPFILE)lpMessage->lpContext;
		
	debug("--DecreaseGroupUsers 'Open groupfile'\n");
	
	//	Open groupfile (by user id - not possible by name)
	lpMessage->dwIdentifier	= DC_GROUPFILE_OPEN;
	lpGroupFile->Gid	= GID;

	if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
	{
		//	Wait until done
		WaitForSingleObject(hEvent, INFINITE);

		debug("--DecreaseGroupUsers 'Lock groupfile'\n");
		
		//	Lock groupfile (exclusive, required only when writing)
		lpMessage->dwIdentifier	= DC_GROUPFILE_LOCK;

		if (! lpMessage->dwReturn &&
			! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
		{
			//	Wait until done
			WaitForSingleObject(hEvent, INFINITE);

			if (! lpMessage->dwReturn)
			{
				
				debug("--DecreaseGroupUsers 'lpGroupFile->Users	-= 1'\n");
				
				lpGroupFile->Users	-= 1;

				debug("--DecreaseGroupUsers 'Unlock groupfile'\n");

				//	Unlock groupfile (if this is not done, io will go crazy..)
				lpMessage->dwIdentifier	= DC_GROUPFILE_UNLOCK;
				if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
				{
					//	Wait until done
					WaitForSingleObject(hEvent, INFINITE);
				}
			}
		}
		
		debug("--DecreaseGroupUsers 'Close groupfile'\n");

		//	Close groupfile
		lpMessage->dwIdentifier	= DC_GROUPFILE_CLOSE;;
		if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
		{
			//	Wait until done
			WaitForSingleObject(hEvent, INFINITE);
		}
	}
	else
	{
		debug("<-DecreaseGroupUsers '%i' FALSE\n", GID);
		
		return FALSE;
	}

	debug("<-DecreaseGroupUsers '%i'\n", GID);

	return TRUE;
}

/*
	Created...: 2005.10.22
	Changed...: 
	By........: Jeza
	Desription: Change Default GroupID.
*/
BOOL ChangeGroupID (INT UserId, INT GroupId)
{

	debug("->ChangeGroupID '%i' '%i'\n", UserId, GroupId);
	
	PUSERFILE pUserFile		= (PUSERFILE)lpMessage->lpContext;
		
	//	Open userfile (by user id - not possible by name)
	lpMessage->dwIdentifier	= DC_USERFILE_OPEN;
	pUserFile->Uid	= UserId;

	if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
	{
		//	Wait until done
		WaitForSingleObject(hEvent, INFINITE);

		debug("--ChangeGroupID 'Lock userfile'\n");
		
		//	Lock userfile (exclusive, required only when writing)
		lpMessage->dwIdentifier	= DC_USERFILE_LOCK;

		if (! lpMessage->dwReturn &&
			! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
		{
			//	Wait until done
			WaitForSingleObject(hEvent, INFINITE);

			if (! lpMessage->dwReturn)
			{

				debug("--ChangeGroupID 'change userfile'\n");
				
				pUserFile->Groups[0]	= GroupId;
				/*
				if ( DecreaseGroupUsers (pUserFile->Groups[0]) )
				{
					pUserFile->Groups[0]	= GroupId;

					debug("DecreaseGroupUsers '%i' SUCCESS\n", pUserFile->Groups[0]);

				}
				else
				{
					debug("DecreaseGroupUsers '%i' FAiLED\n", pUserFile->Groups[0]);
				}
				*/
				debug("<-ChangeGroupID 'Unlock userfile'\n");
				
				//	Unlock userfile (if this is not done, io will go crazy..)
				lpMessage->dwIdentifier	= DC_USERFILE_UNLOCK;
				if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
				{
					//	Wait until done
					WaitForSingleObject(hEvent, INFINITE);
				}
			}
		}
		
		debug("<-ChangeGroupID 'Close userfile'\n");

		//	Close userfile
		lpMessage->dwIdentifier	= DC_USERFILE_CLOSE;;
		if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
		{
			//	Wait until done
			WaitForSingleObject(hEvent, INFINITE);
		}
	}
	else
	{
		debug("<-ChangeGroupID '%i' '%i' FALSE\n", UserId, GroupId);
		
		return FALSE;
	}

	debug("<-ChangeGroupID '%i' '%i'\n", UserId, GroupId);

	return TRUE;
}

/*
	Created...: 2005.11.06
	Changed...: 
	By........: Jeza
	Desription: Change Credits in Section.
*/
BOOL ChangeCredits (INT UserId, INT CHCredits, INT Section)
{
/*
printf("UserId=%i\n", UserId);
printf("CHCredits=%i\n", CHCredits);
printf("Section=%i\n", Section);
*/
	PUSERFILE pUserFile		= (PUSERFILE)lpMessage->lpContext;
		
	//	Open userfile (by user id - not possible by name)
	lpMessage->dwIdentifier	= DC_USERFILE_OPEN;
	pUserFile->Uid	= UserId;

	if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
	{
		//	Wait until done
		WaitForSingleObject(hEvent, INFINITE);

		//	Lock userfile (exclusive, required only when writing)
		lpMessage->dwIdentifier	= DC_USERFILE_LOCK;

		if (! lpMessage->dwReturn &&
			! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
		{
			//	Wait until done
			WaitForSingleObject(hEvent, INFINITE);

			if (! lpMessage->dwReturn)
			{
				
				pUserFile->Credits[Section]	+= CHCredits;

				//	Unlock userfile (if this is not done, io will go crazy..)
				lpMessage->dwIdentifier	= DC_USERFILE_UNLOCK;
				if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
				{
					//	Wait until done
					WaitForSingleObject(hEvent, INFINITE);
				}
			}
		}
		//	Close userfile
		lpMessage->dwIdentifier	= DC_USERFILE_CLOSE;;
		if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
		{
			//	Wait until done
			WaitForSingleObject(hEvent, INFINITE);
		}
	}
	else
	{
		return FALSE;
	}

	return TRUE;
}

/*
	Created...: 2006.02.01
	Changed...: 
	By........: Jeza
	Desription: Change Number Of Users In Group.
*/
BOOL UpdateGroupUsers(INT GID, INT NR)
{

	LPGROUPFILE lpGroupFile		= (LPGROUPFILE)lpMessage->lpContext;
		
	//	Open groupfile (by user id - not possible by name)
	lpMessage->dwIdentifier	= DC_GROUPFILE_OPEN;
	lpGroupFile->Gid	= GID;

	if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
	{
		//	Wait until done
		WaitForSingleObject(hEvent, INFINITE);

		//	Lock groupfile (exclusive, required only when writing)
		lpMessage->dwIdentifier	= DC_GROUPFILE_LOCK;

		if (! lpMessage->dwReturn &&
			! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
		{
			//	Wait until done
			WaitForSingleObject(hEvent, INFINITE);

			if (! lpMessage->dwReturn)
			{
				
				lpGroupFile->Users	= NR;

				//	Unlock groupfile (if this is not done, io will go crazy..)
				lpMessage->dwIdentifier	= DC_GROUPFILE_UNLOCK;
				if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
				{
					//	Wait until done
					WaitForSingleObject(hEvent, INFINITE);
				}
			}
		}
		//	Close groupfile
		lpMessage->dwIdentifier	= DC_GROUPFILE_CLOSE;;
		if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
		{
			//	Wait until done
			WaitForSingleObject(hEvent, INFINITE);
		}
	}
	else
	{
		return FALSE;
	}

	return TRUE;
}

/*
	Created...: 2006.02.01
	Changed...: 
	By........: Jeza
	Desription: Increase Number Of Users In Group For 1.
*/
BOOL IncreaseGroupUsers(INT GID)
{

	LPGROUPFILE lpGroupFile		= (LPGROUPFILE)lpMessage->lpContext;
		
	//	Open groupfile (by user id - not possible by name)
	lpMessage->dwIdentifier	= DC_GROUPFILE_OPEN;
	lpGroupFile->Gid	= GID;

	if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
	{
		//	Wait until done
		WaitForSingleObject(hEvent, INFINITE);

		//	Lock groupfile (exclusive, required only when writing)
		lpMessage->dwIdentifier	= DC_GROUPFILE_LOCK;

		if (! lpMessage->dwReturn &&
			! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
		{
			//	Wait until done
			WaitForSingleObject(hEvent, INFINITE);

			if (! lpMessage->dwReturn)
			{
				
				lpGroupFile->Users	+= 1;

				//	Unlock groupfile (if this is not done, io will go crazy..)
				lpMessage->dwIdentifier	= DC_GROUPFILE_UNLOCK;
				if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
				{
					//	Wait until done
					WaitForSingleObject(hEvent, INFINITE);
				}
			}
		}
		//	Close groupfile
		lpMessage->dwIdentifier	= DC_GROUPFILE_CLOSE;;
		if (! SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory))
		{
			//	Wait until done
			WaitForSingleObject(hEvent, INFINITE);
		}
	}
	else
	{
		return FALSE;
	}

	return TRUE;
}

/*
	Created...: 2005.09.02
	Changed...: 
	By........: Jeza
	Desription: Get Users Credits in Section.
*/
INT64 GetUserCredits(int iPos, int UserId, int iSection)
{

	INT64 iCredits			= 0;

	PUSERFILE pUserFile		= (PUSERFILE)lpMessage->lpContext;
	lpMessage->dwIdentifier	= DC_USERFILE_OPEN;
	
	pUserFile->Uid			= UserId;

	if ( !SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory) )
	{
		// Wait until processed (5 secs)
		if ( WaitForSingleObject(hEvent, 5000) == WAIT_TIMEOUT ) 
			goto s_DONE;

		iCredits	= pUserFile->Credits[iSection];

	}

	lpMessage->dwIdentifier	= DC_USERFILE_CLOSE;;
	
	if ( !SendMessage(hIoFTPD, WM_SHMEM, NULL, (LPARAM)hMemory) )
	{
		if ( WaitForSingleObject(hEvent, 5000) == WAIT_TIMEOUT ) goto s_DONE;
	}
	
	s_DONE:

	return iCredits;

}

