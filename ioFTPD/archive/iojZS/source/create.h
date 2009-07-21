//poradira fajl
void delete_file ( char *f )
{
  WIN32_FIND_DATA	FindFileData;
  HANDLE hFind		= INVALID_HANDLE_VALUE;
  DWORD dwError;
  
  char _m_file[MAXFILE], _d_file[MAXFILE];
  strcpy(_m_file,var.loc.env_path);
  strncat(_m_file,"\\*",3);

  hFind = FindFirstFile(_m_file, &FindFileData);
  
  if (hFind != INVALID_HANDLE_VALUE) 
  {
    if ( (strncmp(FindFileData.cFileName,".",1) != 0) )
      error ("First file name is %s \n", FindFileData.cFileName);
    while (FindNextFile(hFind, &FindFileData) != 0) 
    {
      if ( (strncmp(FindFileData.cFileName,".",1) == 0) )
      {
        continue;
      }
      else
      {
        strcpy(_d_file,var.loc.env_path);
        strcat(_d_file,"\\");
        strcat(_d_file,FindFileData.cFileName);

        if ( strcmp(strlwr(FindFileData.cFileName),strlwr(f)) == 0 )
        {
          //printf("delete=%s\n",_d_file);
          //char hg[MAXFILE];
          //sprintf(hg,"%s.bad",_d_file);
          //printf("rename=%s\n",hg);
          //rename(_d_file,hg);
          unlink(_d_file);
        }
      }
    }
  
    dwError = GetLastError();
    FindClose(hFind);
    if (dwError != ERROR_NO_MORE_FILES) 
    {
      error(" -[ delete_0_byte_files -> \n -[ ERROR %u\n", dwError);
    }
    /*
    unlink(f);
    error(" -[ delete_missing -> %s\n -[ ERROR %u\n -[ nekaj cudnega?\n", f, GetLastError());
    FindClose(hFind);
    */
  }
}

//poradira 0byte fajl
void delete_missing (struct VARS *var )
{
  WIN32_FIND_DATA	FindFileData;
  HANDLE hFind		= INVALID_HANDLE_VALUE;
  
  char _m_file[MAXFILE] = "";
  sprintf(_m_file,"%s\\%s%s",var->loc.env_path,var->file.name,iojZS_missing_file);

  hFind = FindFirstFile(_m_file, &FindFileData);
  
  if (hFind != INVALID_HANDLE_VALUE) 
  {
    unlink(_m_file);
    //error(" -[ delete_missing -> %s\n -[ ERROR %u\n -[ nekaj cudnega?\n", _m_file, GetLastError());
    FindClose(hFind);
  }
}

//poradira vse 0byte fajle
void delete_0_byte_files (struct VARS *var )
{
  WIN32_FIND_DATA	FindFileData;
  HANDLE hFind		= INVALID_HANDLE_VALUE;
  DWORD dwError;
  
  char _m_file[MAXFILE], _d_file[MAXFILE];
  strcpy(_m_file,var->loc.env_path);
  strncat(_m_file,"\\*",3);

  hFind = FindFirstFile(_m_file, &FindFileData);
  
  if (hFind != INVALID_HANDLE_VALUE) 
  {
    if ( (strncmp(FindFileData.cFileName,".",1) != 0) )
      error ("First file name is %s \n", FindFileData.cFileName);
    while (FindNextFile(hFind, &FindFileData) != 0) 
    {
      if ( (strncmp(FindFileData.cFileName,".",1) == 0) )
      {
        continue;
      }
      else
      {
        strcpy(_d_file,var->loc.env_path);
        strcat(_d_file,"\\");
        strcat(_d_file,FindFileData.cFileName);

        if ( !(-1 ==  stat (_d_file, &stat_p)) )
        {
          if (stat_p.st_size == 0)
            unlink(_d_file);
        }
      }
    }
  
    dwError = GetLastError();
    FindClose(hFind);
    if (dwError != ERROR_NO_MORE_FILES) 
    {
      error(" -[ delete_0_byte_files -> \n -[ ERROR %u\n", dwError);
    }
  }
}
/*
//poradira symlink
void delete_symlink (struct VARS *var )
{
  char temp_s[MAX_PATH] = "";
  sprintf(temp_s,"%s\\.ioFTPD",var->dir.symlink);
  //DeleteFile(temp_s);
  //RemoveDirectory(var->dir.symlink);
  unlink(temp_s);
  RemoveDirectory(var->dir.symlink);
  //printf("symlink=%s\n",var->dir.symlink);
}
*/

//ali fajl obstaja ? ja=1 , ne=0
int file_exists1 ( char *f )
{
  HANDLE hFile;
  
  hFile = CreateFile (TEXT(f), GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE | FILE_SHARE_DELETE, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);               
  
  if(hFile == INVALID_HANDLE_VALUE)
  {
    DWORD dwErr = GetLastError();
    if ( ERROR_FILE_NOT_FOUND == dwErr )
    {
      CloseHandle(hFile);
      return 0;
    }
  }
 
  CloseHandle(hFile);

  return 1;
}

void delete_symlink (struct VARS *var )
{
  char *symlnk	= (char *)calloc(strlen(var->dir.symlink)+1+2+7,sizeof(char));
  sprintf(symlnk,"%s\\.ioFTPD",var->dir.symlink);
  
  //printf(":: Deleting '%s'\n",symlnk);
  unlink(symlnk);
  
  if ( file_exists1(symlnk))
  {
    //printf(":: File Still There!! '%s'\n",symlnk);
    //printf(":: Deleting '%s'\n",symlnk);
    unlink(symlnk);
  }
  
  free(symlnk);
  
  //printf(":: Deleting '%s'\n",var->dir.symlink);
  RemoveDirectory(var->dir.symlink);
  
}

//poradira 0byte stats fajle od userjev kolko so uplovdali
void delete_stats_files (struct VARS *var )
{
  WIN32_FIND_DATA	FindFileData;
  HANDLE hFind		= INVALID_HANDLE_VALUE;
  DWORD 		dwError;
  
  char _m_file[MAXFILE] = "";
  sprintf(_m_file,"%s\\%s",var->loc.env_path,iojZS_delete_users_stats_file);

  hFind = FindFirstFile(_m_file, &FindFileData);
  
  if (hFind != INVALID_HANDLE_VALUE) 
  {
    //char _m_file[MAXFILE] = "";
    sprintf(_m_file,"%s\\%s",var->loc.env_path,FindFileData.cFileName);
    unlink(_m_file);
    while (FindNextFile(hFind, &FindFileData) != 0) 
    {
      char _m_file[MAXFILE] = "";
      sprintf(_m_file,"%s\\%s",var->loc.env_path,FindFileData.cFileName);
      unlink(_m_file);
    }
  
    dwError = GetLastError();
    
    if (dwError != ERROR_NO_MORE_FILES) 
    {
      error(" -[ delete_stats_files -> \n -[ ERROR %u\n", dwError);
    }
    
    FindClose(hFind);
  }
}

//poradira 0byte status fajl
void delete_status (struct VARS *var )
{
  WIN32_FIND_DATA	FindFileData;
  HANDLE hFind		= INVALID_HANDLE_VALUE;
  DWORD 		dwError;
  
  char _m_file[MAXFILE] = "";
  sprintf(_m_file,"%s\\%s",var->loc.env_path,iojZS_delete_bar);

  hFind = FindFirstFile(_m_file, &FindFileData);
  
  if (hFind != INVALID_HANDLE_VALUE) 
  {
    //char _m_file[MAXFILE] = "";
    sprintf(_m_file,"%s\\%s",var->loc.env_path,FindFileData.cFileName);
    unlink(_m_file);
    while (FindNextFile(hFind, &FindFileData) != 0) 
    {
      char _m_file[MAXFILE] = "";
      sprintf(_m_file,"%s\\%s",var->loc.env_path,FindFileData.cFileName);
      unlink(_m_file);
    }
  
    dwError = GetLastError();
    
    if (dwError != ERROR_NO_MORE_FILES) 
    {
      error(" -[ delete_status bar -> \n -[ ERROR %u\n", dwError);
    }
    
    FindClose(hFind);
  }
}

//usvari 0byte fajl
void create_0byte_file (char *o_file)
{
  FILE	*c_miss;
  c_miss = fopen(o_file, "w");
  fclose(c_miss);
  //printf("%s\n",o_file);
}

//naredi progress meter
void create_bar (struct VARS *var)
{
  int	n;
  if(var->race.missing_files == 0 )
  {
    for(n=0; n < iojZS_progressmeter_length; n++)
      var->race.progress_bar[n] = iojZS_progressmeter_filled_char;
  }
  else
  {
    var->race.progress_bar[iojZS_progressmeter_length] = 0;
    for ( n = 0 ; n < (var->race.total_files - var->race.missing_files) * iojZS_progressmeter_length / var->race.total_files ; n++)
      var->race.progress_bar[n] = iojZS_progressmeter_filled_char;
    for ( ; n < iojZS_progressmeter_length ; n++) 
      var->race.progress_bar[n] = iojZS_progressmeter_missing_char;
  }
}

//naredi symlink
void create_symlink (struct VARS *var )
{
  _mkdir((char *)var->dir.symlink);
  printf("!vfs:chattr 1 \"%s\" \"%s\"\n",(char *)var->dir.symlink,(char *)var->loc.env_pwd);
  printf("!vfs:add %i %i:%i %s\n",iojZS_chmod_symlink,atoi(getenv("UID")),atoi(getenv("GID")),(char *)var->dir.symlink);
}

//naredi status file za userje
void create_stats_file (char *user_tag, struct VARS *var )
{
  char s_bar[MAXFILE] = "";
  strcpy(s_bar,var->loc.env_path);
  strcat(s_bar,"\\");
  strcat(s_bar,user_tag);
  create_0byte_file (s_bar);
  printf("!vfs:add %i %i:%i %s\n",iojZS_chmod_status,atoi(getenv("UID")),atoi(getenv("GID")),s_bar);
}

//naredi status bar
void create_status (char *inc_bar, struct VARS *var )
{
  char s_bar[MAXFILE] = "";
  strcpy(s_bar,var->loc.env_path);
  strcat(s_bar,"\\");
  strcat(s_bar,inc_bar);
  create_0byte_file (s_bar);
  printf("!vfs:add %i %i:%i %s\n",iojZS_chmod_status,atoi(getenv("UID")),atoi(getenv("GID")),s_bar);
}
