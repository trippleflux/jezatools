// calculate the length of a char*
int length(char* chaine)
{
 
 int i=0;
 while(chaine[i] != '\0')
  i++;
 
 return i;
}
 

// update leader info if needed, and tell if we have to log newleader
// 0 => log nothing
// 1 => log actual racer as new leader
int write_newleader ()
{

  // mutex to protect the file in case multiple iojZS are executed
  // at the same time
  HANDLE hMutex = CreateMutex( NULL, TRUE, "MutexLeader" );

  WaitForSingleObject( hMutex, INFINITE );    //wait until it is free

  FILE* file;

  int returnvalue = 0;

  char* buffer;

  buffer = (char*)malloc(strlen(var.loc.env_path)+25);
  sprintf(buffer, "%s\\.ioFTPD.iojZSleader", var.loc.env_path);


   char* racer;
   racer = (char*) malloc 
(strlen(var.race.username)+strlen(var.race.groupname)+5);
   sprintf(racer,"%s@%s", var.race.username, var.race.groupname);


  file=fopen(buffer,"rb");

  if (file != NULL)
  {

   //printf("YES\n");
   // if file exists

   char* leader;
   leader= 
(char*)malloc(strlen(user_[0].u_name)+strlen(group_[0].g_name)+5);
   sprintf(leader, "%s@%s", user_[0].u_name, group_[0].g_name);


  // if current user is the leader
   if( strcmp(racer, leader) == 0)
   {

    long size;


    // get logleader and logsize

    char logleader[20];
	unsigned int logfiles;
	fscanf(file,"%s %d", logleader, &logfiles);

    // check if we already were the leader

     if( strcmp(racer, logleader) != 0 && logfiles < user_[0].files )
    {
     // if not


    // update leaderfile
     fclose(file);

     file=fopen(buffer,"wb");
     fprintf(file,"%s %d\n", racer, user_[0].files);


   // then we should log the new leader here
     returnvalue = 1;


    } // else do nothing


   } // else do nothing


   free(leader);

  }
  else
  {
   //printf("NOT\n");
    // if file doesn't exists, just create the first leader = current user
   file=fopen(buffer,"wb");
   fprintf(file,"%s %d\n",racer,user_[0].files);
  }


  free(buffer);
  free(racer);


  fclose(file);

  ReleaseMutex( hMutex );    //release it so that it will unlock the other app

  // free mem
  CloseHandle( hMutex );

  return returnvalue;

}

//write anounce to iojZS_logfile
void write2log (char* chaine,...)
{

  va_list pa;
  char* buffer;
  char* buff;
  char *s;


  va_start(pa, chaine);

  buffer = (char*)malloc(1024);

  SYSTEMTIME st;
  GetLocalTime(&st);

  sprintf(buffer, "%02d-%02d-%04d %02d:%02d:%02d ", st.wMonth, st.wDay, 
st.wYear, st.wHour, st.wMinute, st.wSecond);


  while ( *chaine != '\0')
  {
    if ( *chaine == '%' )
    {

      switch (*++chaine)
      {

        case 's' :
        {
          s = va_arg(pa, char *);
          strcat(buffer, s );
          break;
        }
        default  :
        {
          break;
        }

      }

    }
    else
    {

      buff = (char *)malloc(2);
      sprintf(buff,"%c",chaine[0]);
      strcat(buffer, buff);
      free(buff);

    }

    chaine++;
  }//end while

  va_end(pa);

  HANDLE hMutex = CreateMutex( NULL, TRUE, "Mutex" );

  WaitForSingleObject( hMutex, INFINITE );

  FILE* file;

  file=fopen(iojZS_logfile,"a");

  fputs(buffer,file);

  fclose(file);

  ReleaseMutex( hMutex );

  CloseHandle( hMutex );
  free(buffer);

  return;

}

//zapise stevilo vseh fajlov ce rejs fajla se ni
void write_total_files ( struct VARS *var )
{
  HANDLE	hFile;
  DWORD		dwBytesRead, dwBytesWritten, dwPtr, dwError;
  
  hFile	= CreateFile(TEXT(var->file.race_file), GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE | FILE_SHARE_DELETE, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);
  
  if ( (hFile != INVALID_HANDLE_VALUE) )
  {
    dwPtr = SetFilePointer (hFile, 0, NULL, FILE_END);
    LockFile(hFile, dwPtr, 0, dwBytesRead, 0);
    char t_f[LINESIZE] = "";
    sprintf(t_f,"%i",var->race.total_files);
    WriteFile(hFile, t_f, LINESIZE, &dwBytesWritten, NULL);
    UnlockFile(hFile, dwPtr, 0, dwBytesRead, 0);
    CloseHandle(hFile);
  }
  else
  {
    dwError = GetLastError();
    error(" -[ write_total_files! \n -[ ERROR %i\n ",dwError);
  }
}

//zapise stevilo vseh fajlov ce iojZSrace ze obstoja
void write_total_files_1 ( struct VARS *var )
{
  HANDLE	hFile;
  DWORD		dwBytesRead, dwBytesWritten, dwPtr, dwError;
  
  hFile	= CreateFile(TEXT(var->file.race_file), GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE | FILE_SHARE_DELETE, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);
  
  if ( (hFile != INVALID_HANDLE_VALUE) )
  {
    dwPtr = SetFilePointer (hFile, 0, NULL, FILE_BEGIN);
    LockFile(hFile, dwPtr, 0, dwBytesRead, 0);
    char t_f[LINESIZE] = "";
    sprintf(t_f,"%i",var->race.total_files);
    WriteFile(hFile, t_f, LINESIZE, &dwBytesWritten, NULL);
    UnlockFile(hFile, dwPtr, 0, dwBytesRead, 0);
    CloseHandle(hFile);
  }
  else
  {
    dwError = GetLastError();
    error(" -[ write_total_files_1! \n -[ ERROR %i\n ",dwError);
  }
}

//zapise .ioFTPD.message
//iM=0 -> write
//iM=1 -> append
void write_io_msg (struct VARS *var, int iM, char *sWhat)
{

  // mutex to protect the file in case multiple iojZS are executed
  // at the same time
  HANDLE hMutex = CreateMutex( NULL, TRUE, "Mutexiomsg" );

  WaitForSingleObject( hMutex, INFINITE );    //wait until it is free

  FILE *ptr;
  
  if ( iM == 0)
    ptr = fopen(var->file.msg_file, "w+");
  if ( iM == 1)
    ptr = fopen(var->file.msg_file, "a+");
  
  if (ptr == 0)
  {
    //error(" -[ write_io_msg -> %s\n -[ ptr == 0 cant open msg file\n", var->file.msg_file);
    //fclose(ptr);
    exit(1);
  }
  fprintf(ptr, "%s", sWhat);
  fclose(ptr);
  
  ReleaseMutex( hMutex );    //release it so that it will unlock the other app

  // free mem
  CloseHandle( hMutex );

}

//write diz to ioftpd.message
void write_msg_diz ()
{

  // mutex to protect the file in case multiple iojZS are executed
  // at the same time
  HANDLE hMutex = CreateMutex( NULL, TRUE, "Mutexmsgdiz" );

  WaitForSingleObject( hMutex, INFINITE );    //wait until it is free

  char 	temp[MAXFILE];
  char	readline[512];
  boolean bO	= true;
  boolean bO1	= true;
  
  sprintf(temp,"%s\\file_id.diz",var.loc.env_path);
  
  FILE *ptr,*ptr1;
  
  ptr = fopen(temp, "r+");
  
  if (ptr == 0)
  { 
    //error(" -[ write_io_msg -> %s\n -[ ptr == 0 cant open msg file\n", temp);
    bO = false;
  }
  
  ptr1 = fopen(var.file.msg_file, "w+");
  
  if (ptr1 == 0)
  { 
    //error(" -[ write_io_msg -> %s\n -[ ptr == 0 cant open msg file\n", var.file.msg_file);
    fclose(ptr);
    bO1 = false;
  }
  
  if ( bO && bO1 )
  {
    while( fgets(readline,512,ptr) != NULL )
    {
      fprintf(ptr1, "%s", readline);
    }
    fclose(ptr);
    fclose(ptr1);
  }
  else
  {
    write_io_msg (&var, 0, "");
  }

  ReleaseMutex( hMutex );    //release it so that it will unlock the other app

  // free mem
  CloseHandle( hMutex );

}

//zapise race data od trenutnega zip fajla
void write_zip_stats ( struct VARS *var )
{
  HANDLE	hFile;
  DWORD		dwBytesRead, dwBytesWritten, dwPtr, dwError;
  
  char		w_buff[LINESIZE] = "", r_buff[LINESIZE] = "";

  boolean	bOpen = false, bNoDiz = false;
  
  short 	o = 0;			//share
  
  /*race vars*/
  float _b;				//bytes
  char _name[30], _group[30], *race_l;	//user, group, ?
  unsigned int _s;			//speed
  boolean bNov = false;			//nov user v stats
  boolean bgNov = false;		//nova grupa v stats
  var->race.total_users = 0;		//userji
  short f;				//za sortiranje
  var->race.total_groups = 0;		//grupe
  var->race.slowest_speed = 10000;
  var->race.fastest_speed = 0;
  /*race vars*/

  int 		to = 0;			//totalfiles if nodiz
  
  hFile		= CreateFile(TEXT(var->file.race_file), GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE | FILE_SHARE_DELETE, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);
  //printf("!buffer off\n");
  do
  {
    if ( (hFile == INVALID_HANDLE_VALUE) )
    {
      dwError = GetLastError();
      if (hFile)
      {
        //CloseHandle(hFile);
        error(" -[ write_zip_stats -> \n -[ ERROR  cant open race file %s\n", var->file.race_file);  
      }
      if ( dwError == ERROR_SHARING_VIOLATION )
      {
        o++;
        Sleep(50);
        //error(" -[ write_zip_stats -> %i\n -[ ERROR  SHARE %s\n", o, var->file.race_file);  
      }
    }
    else
    {
      bOpen = true;
      break;
    }
  }
  while (o < 10);

  int i = 0;
    
  if ( bOpen )
  {
    
    dwPtr = SetFilePointer (hFile, 0, NULL, FILE_END);
    
    LockFile(hFile, dwPtr, 0, dwBytesRead, 0);
    
    char temp_w[LINESIZE] = "";
    sprintf(temp_w,"%s %d %s %s %d",var->file.name, var->file.size, var->race.username, var->race.groupname,var->file.speed);
    WriteFile(hFile, temp_w, LINESIZE, &dwBytesWritten, NULL);
    
    dwPtr = SetFilePointer (hFile, 0, NULL, FILE_BEGIN);
    
    while ( ReadFile(hFile, r_buff, LINESIZE, &dwBytesRead, NULL) != 0)
    {
      if( dwBytesRead == 0 ) 
        break;
      
      if (i == 0)
      {
        var->file.bZIP = true;
        var->race.total_files = var->race.missing_files = (int)atoi(r_buff);
        if ( var->race.total_files == 1000 )
        {
          bNoDiz = true;
          var->file.bZIP = false;
        }
      }
      
      char _t[LINESIZE] = "";
      dwPtr = SetFilePointer (hFile, i*LINESIZE, NULL, FILE_BEGIN);
      ReadFile(hFile, _t, LINESIZE, &dwBytesRead, NULL);
      
      //printf("line : %s\n",_t);
      boolean bYes = false;
      char *line = NULL;
      line = strtok( _t, " " );
      int t = 0;
      /*
      0 - file
      1 - size
      2 - user
      3 - group
      4 - speed
      */
      /*while*/
      while( line != NULL )
      {
        if ( (i > 0) )
        {
    
          if ( (t == 0) )
          {
            if ( bNoDiz )
            {
              to++;
            }
          }
    
          if ( (t == 1) )
          {
            //printf("bytes %i:%i\n",i,atoi(line));
            (var->race.missing_files)--;
            _b = atoi(line);
            var->race.total_bytes += atoi(line);
          }
        
          if ( (t == 2) )
          {
            strcpy(_name,line);
          }
        
          if ( (t == 3) )
          {
            strcpy(_group,line);
          }
        
          if ( (t == 4) )
          {
            _s = atoi(line);
            var->race.total_speed += _s;
            bYes = true;
            
            if ( _s < var->race.slowest_speed )
            {
              var->race.slowest_speed = _s;
              strcpy(var->race.slowest_user,_name);
            }
            
            if ( _s > var->race.fastest_speed )
            {
              var->race.fastest_speed = _s;
              strcpy(var->race.fastest_user,_name);
            }
            
          }
    
        }//i>0
        
        t++;
        line = strtok( NULL , " " );
        
      }
      /*while*/
      
      /*file ma statse*/
      if ( bYes )
      {
        if ( strlen(user_[0].u_name) == 0)
        {
          //printf("prvi : %s\n",_t);
          strcpy(user_[0].u_name,_name);
          strcpy(user_[0].g_name,_group);
          user_[0].files++;
          user_[0].bytes += _b;
          user_[0].speed += _s;
          (var->race.total_users)++;
          //(var->race.total_users)++;
        }
        
        if ( strlen(group_[0].g_name) == 0)
        {
          //printf("prvi : %s\n",_t);
          strcpy(group_[0].g_name,_group);
          group_[0].files++;
          group_[0].bytes += _b;
          group_[0].speed += _s;
          (var->race.total_groups)++;
        }
      
        /*userji*/
        for (f=0; f<var->race.total_users; f++)
        {
          if ( (var->race.total_files - var->race.missing_files) == 1)
          {
            break;	//prvi je ze narejen
          }
          if(strlen(user_[f].u_name) == 0)
          {
            break;	//prazno polje
          }
          if (strcmp(_name,user_[f].u_name) == 0)
          {
            bNov = false;
            user_[f].files++;
            user_[f].bytes += _b;
            user_[f].speed += _s;
            break;
          }
          if (strcmp(_name,user_[f].u_name) != 0)
          {
            bNov = true;
          }
        }
        /*userji*/
      
        /*bNov*/
        if ( bNov )
        {
          strcpy(user_[var->race.total_users].u_name,_name);
          strcpy(user_[var->race.total_users].g_name,_group);
          user_[var->race.total_users].files++;
          user_[var->race.total_users].bytes += _b;
          user_[var->race.total_users].speed += _s;
          (var->race.total_users)++;
          bNov = false;
        }
        /*bNov*/
      
        /*grupe*/
        for (f=0; f<var->race.total_groups; f++)
        {
          if ( (var->race.total_files - var->race.missing_files) == 1)
          {
            break;	//prvi je ze narejen
          }
          if(strlen(group_[f].g_name) == 0)
          {
            break;	//prazno polje
          }
          if (strcmp(_group,group_[f].g_name) == 0)
          {
            bgNov = false;
            group_[f].files++;
            group_[f].bytes += _b;
            group_[f].speed += _s;
            break;
          }
          if (strcmp(_group,group_[f].g_name) != 0)
          {
            bgNov = true;
          }
        }
        /*grupe*/
        
        /*bgNov*/
        if ( bgNov )
        {
          strcpy(group_[var->race.total_groups].g_name,_group);
          group_[var->race.total_groups].files++;
          group_[var->race.total_groups].bytes += _b;
          group_[var->race.total_groups].speed += _s;
          (var->race.total_groups)++;
          bgNov = false;
        }
        /*bgNov*/
      
      }
      /*file ma statse*/
    
      i++;
      char r_buff[LINESIZE] = "";
      
    }
    
    UnlockFile(hFile, dwPtr, 0, dwBytesRead, 0);
    
    CloseHandle(hFile);
    
  }
  
  if ( bNoDiz )
  {
    var->race.total_files = to;
    var->race.missing_files = 0;
  }    
  
  if ( (var->race.total_files - var->race.missing_files) > var->race.total_files )
  {
    var->race.total_files = (var->race.total_files - var->race.missing_files);
    var->race.missing_files = 0;
  }
  
  if ( var->race.total_files == var->race.missing_files )
    var->race.total_speed = 1;
  else
    var->race.total_speed = var->race.total_speed/(var->race.total_files - var->race.missing_files);

  /*sort users*/
  if (var->race.total_users > 1)
  {
    for (int k=0;k<var->race.total_users;k++)
    {
      for (int t=0;t<var->race.total_users;t++)
      {
        struct USER_ usr;
        if ( (user_[t+1].u_name != NULL) && (user_[t].bytes<user_[t+1].bytes) )
        {
          usr		= user_[t];
          user_[t]	= user_[t+1];
          user_[t+1]	= usr;
        }
      }
    }
  }
  /*sort users*/
  
  race_l = var->race.racers;
  
  /*sort groups*/
  if (var->race.total_groups > 1)
  {
    for (int k=0;k<var->race.total_groups;k++)
    {
      for (int t=0;t<var->race.total_groups;t++)
      {
        struct GROUP_ grp;
        if ( (group_[t+1].g_name != NULL) && (group_[t].bytes<group_[t+1].bytes) )
        {
          grp		= group_[t];
          group_[t]	= group_[t+1];
          group_[t+1]	= grp;
        }
      }
    }
  }
  /*sort groups*/
  
  
}

//preveri ce fajl se ni v iojZSrace
boolean check_zip_stats ( struct VARS *var )
{
  HANDLE	hFile;
  DWORD		dwBytesRead, dwPtr, dwError;
  
  char		r_buff[LINESIZE] = "";

  boolean	bOpen = false, bFound = false;
  
  short 	o = 0;			//share
  
  hFile		= CreateFile(TEXT(var->file.race_file), GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE | FILE_SHARE_DELETE, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);
  //printf("!buffer off\n");
  do
  {
    if ( (hFile == INVALID_HANDLE_VALUE) )
    {
      dwError = GetLastError();
      if (hFile)
      {
        //CloseHandle(hFile);
        error(" -[ check_zip_stats -> \n -[ ERROR  cant open race file %s\n", var->file.race_file);  
      }
      if ( dwError == ERROR_SHARING_VIOLATION )
      {
        o++;
        Sleep(50);
        //error(" -[ check_zip_stats -> %i\n -[ ERROR  SHARE %s\n", o, var->file.race_file);  
      }
    }
    else
    {
      bOpen = true;
      break;
    }
  }
  while (o < 10);

  if ( !bOpen )
    return false;
  
  int i = 0;
    
  if ( bOpen )
  {
    
    dwPtr = SetFilePointer (hFile, 0, NULL, FILE_BEGIN);
    
    LockFile(hFile, dwPtr, 0, dwBytesRead, 0);

    while ( ReadFile(hFile, r_buff, LINESIZE, &dwBytesRead, NULL) != 0)
    {
      if( dwBytesRead == 0 ) 
        break;
      
      if (i == 0)
      {
        
      }
      
      char _t[LINESIZE] = "";
      dwPtr = SetFilePointer (hFile, i*LINESIZE, NULL, FILE_BEGIN);
      ReadFile(hFile, _t, LINESIZE, &dwBytesRead, NULL);
      
      if ( strstr(_t,var->file.name) != NULL )
      {
        bFound = true;
        break;
      }
    
      i++;
      char r_buff[LINESIZE] = "";
      
    }
    
    UnlockFile(hFile, dwPtr, 0, dwBytesRead, 0);
    
    CloseHandle(hFile);
    
  }
  
  if ( bFound )
    return false;
  else
    return true;

  
}

