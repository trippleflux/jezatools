/*
	Created...: 2005.09.18
	Changed...: 
	By........: Jeza
	Desription: Return TRUE If File Exists.
*/
BOOL FileExists(char *InputFile)
{

	HANDLE hFile;
	  
	hFile = CreateFile (TEXT(InputFile), GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE | FILE_SHARE_DELETE, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);               
	  
	if(hFile == INVALID_HANDLE_VALUE)
	{
		DWORD dwErr = GetLastError();
		
		if ( ERROR_FILE_NOT_FOUND == dwErr )
		{
			CloseHandle(hFile);
			return FALSE;
		}
	}
	 
	CloseHandle(hFile);

	return TRUE;

}

/*
	Created...: 2005.09.05
	Changed...: 
	By........: Jeza
	Desription: Get File FileName and FileSize.
*/
VOID GetFileInfo(char *InputFile)
{

	if ( -1 ==  stat (InputFile, &stat_p))
	{
		var.jWho.FileSize = 0;
	}
	else
	{
		var.jWho.FileSize = stat_p.st_size;
	}

	char *f			= strrchr(InputFile,'\\');
	if( f == NULL )
		var.jWho.FileName		= InputFile;
	else
		var.jWho.FileName		= ++f;

}


