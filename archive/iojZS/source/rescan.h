
//rescan dira
boolean get_rescan_dir ( STRUCT VARS *var)
{

  HANDLE	hFile;
  HANDLE	hTempFile; 
  DWORD		dwBytesRead, dwBytesWritten, dwPtr, dwError;
  
  boolean	bOpen = false, bOR = false, bFound = false;
  short 	o = 0;			//share

  hFile		= CreateFile(TEXT(var->file.sfv_file), GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE | FILE_SHARE_DELETE, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);
  
  do
  {
    if ( (hFile == INVALID_HANDLE_VALUE) )
    {
      dwError = GetLastError();

      if ( dwError == ERROR_SHARING_VIOLATION )
      {
        o++;
        Sleep(50);
      }
    }
    else
    {
      bOpen = true;
      break;
    }
  }
  while (o < 10);

  hTempFile	= CreateFile(TEXT(var.file.race_file), GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE | FILE_SHARE_DELETE, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);

  o = 0;
  
  do
  {
    if ( (hTempFile == INVALID_HANDLE_VALUE) )
    {
      dwError = GetLastError();

      if ( dwError == ERROR_SHARING_VIOLATION )
      {
        o++;
        Sleep(50);
      }
    }
    else
    {
      bOR = true;
      break;
    }
  }
  while (o < 10);

  if (bOR && bOpen)
  {
    
    char *buff = (char *) malloc(SFVS*2);
    
    ReadFile(hFile, buff, SFVS*2, &dwBytesRead, NULL);
    
    CloseHandle(hFile);

    if ( dwBytesRead == 0 )
    {
      error(" -[ get_rescan_dir -> %s\n -[ ERROR  cant read sfv\n", _sfv);
      free(buff);
      return false;
    }
    
    CharLowerBuff(buff, dwBytesRead);
    
    dwPtr = SetFilePointer (hTempFile, 0, NULL, FILE_BEGIN);
    
    LockFile(hTempFile, dwPtr, 0, dwBytesRead, 0);

    char *result = NULL;
    result = strtok( buff, "\r\n" );
    
    while( result != NULL )
    {
      
      if ( (result[0] != ';') && (strlen(result) > 9) )
      {
        
        char *rescan_file	= (char *)calloc(strlen(var.loc.env_path)+strlen(result)-9+2,sizeof(char));
        char *sfv_crc		= (char *)calloc(8,sizeof(char));
        char *file_crc		= (char *)calloc(8,sizeof(char));
        char *status		= (char *)calloc(8,sizeof(char));
        char *temp		= (char *)calloc(strlen(result)-9,sizeof(char));
        char *t			= strrchr(result,0x20);
        
        strncpy(temp,result,strlen(result)-9);
        var.file.name = temp;
        sprintf(rescan_file,"%s\\%s",var.loc.env_path,temp);
        sprintf(sfv_crc,"%08s",++t);
        sprintf(file_crc,"00000000");
        sprintf(status,iojZS_rescan_missing);

        int i = 0;
        
        char r_buff[LINESIZE] = "";
        
        dwPtr = SetFilePointer (hTempFile, 0, NULL, FILE_BEGIN);
        
        while ( ReadFile(hTempFile, r_buff, LINESIZE, &dwBytesRead, NULL) != 0)
        {
          
          if( dwBytesRead == 0 ) 
          {
            break;
          }
          
          if ( i > 0 )
          {
          
            if (strncmp(strlwr(r_buff),strlwr(result),strlen(result)) == 0)
            {
              
              if (file_exists (rescan_file))
              {

                sprintf(status,iojZS_rescan_ok);
                printf(" %-56.56s %8.8s %8.8s %8.8s\n",var.file.name,file_crc,sfv_crc,status);

                bFound = true;

                break;

              }
              else
              {

                printf(" %-56.56s %8.8s %8.8s %8.8s\n",var.file.name,file_crc,sfv_crc,status);

              }
              
            }
          
          }
          
          char r_buff[LINESIZE] = "";
          i++;	
          
        }//while
        
        if (!bFound)
        {
          
          printf(" %-56.56s %8.8s %8.8s %8.8s\n",var.file.name,file_crc,sfv_crc,status);
          
        }
        else
        {
          
          bFound = false;
          
        }
        
        free(rescan_file);
        free(sfv_crc);
        free(file_crc);
        free(status);
        free(temp);
        
      }//if ( (result[0] != ';') && (strlen(result) > 9) )

      result = strtok( NULL, "\r\n" );

    }//while( result != NULL )
    
    free(buff);
    
    UnlockFile(hTempFile, dwPtr, 0, dwBytesRead, 0);
  
    CloseHandle(hTempFile);
    
    if ( true )
    {
      return true;
    }
    else
    {
      return false;
    }
    
  }
  else
  {
    
    return false;
    
  }
  
}
