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
	hIoFTPD					= FindWindow(iojZS_window_name, NULL);
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
	lpMessage->lpContext	= (LPVOID)((ULONG)lpMessage + sizeof(DC_MESSAGE));

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
	Desription: Delete User.
BOOL DeleteUser (int UserId, char UserName[USERNAME_LENGTH])
{

	pNameId					= (LPDC_NAMEID)lpMessage->lpContext;
	lpMessage->dwIdentifier	= DC_DELETE_USER;

	pNameId->Id				= UserId;
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
*/

/*
	Created...: 2005.08.22
	Changed...: 
	By........: Jeza
	Desription: Resolve GID to GROUPNAME.
*/
BOOL ResolveGidToGroupName (int UserId, char GroupName[GROUPNAME_LENGTH])
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

		var.usertable[iPos].tAllUP		= pUserFile->AllUp[(3*iSection)+1];
		var.usertable[iPos].tAllDN		= pUserFile->AllDn[(3*iSection)+1];
		var.usertable[iPos].tMnUP		= pUserFile->MonthUp[(3*iSection)+1];
		var.usertable[iPos].tMnDN		= pUserFile->MonthDn[(3*iSection)+1];
		var.usertable[iPos].tWkUP		= pUserFile->WkUp[(3*iSection)+1];
		var.usertable[iPos].tWkDN		= pUserFile->WkDn[(3*iSection)+1];
		var.usertable[iPos].tDayUP		= pUserFile->DayUp[(3*iSection)+1];
		var.usertable[iPos].tDayDN		= pUserFile->DayDn[(3*iSection)+1];
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
	Created...: 2005.08.25
	Changed...: 2005.09.04
	By........: Jeza
	Desription: Fills Struct '_USERTABLE'.
*/
BOOL FillStats()
{

	var.user.TotalUsers = 0;

	short iSect = 0;
	
	if ( getenv("STATSSECTION") != NULL)
	  iSect = atoi(getenv("STATSSECTION"));

	for (int u=0;u<1024;u++)
	{
	  
		char TestUserName[USERNAME_LENGTH] = "";

		if ( ResolveUidToUserName(u, TestUserName) )
		{

			sprintf(var.usertable[var.user.TotalUsers].tUserName,TestUserName);
			var.usertable[var.user.TotalUsers].tUid = u;

			GetStats(var.user.TotalUsers, u, iSect);
			var.user.TotalUsers++;
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
	/*
	printf("DEBUG->%s :: %i :: %i\n",UserName, iPos, iHow);
	printf("var.usertable[0].tUserName=%s :: %I64d\n",var.usertable[0].tUserName,var.usertable[0].tAllUP);
	printf("var.usertable[1].tUserName=%s :: %I64d\n",var.usertable[1].tUserName,var.usertable[0].tAllUP);
	printf("var.usertable[2].tUserName=%s :: %I64d\n",var.usertable[2].tUserName,var.usertable[0].tAllUP);
	*/
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
					
					

					pUserFile->DayUp[1]		= iN+123;
					pUserFile->WkUp[1]		= iN+321;
					pUserFile->MonthUp[1]	= iN+213;
					pUserFile->AllUp[1]		= iN+231;
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

