//prebere diz
void get_diz (char *file)
{
  FILE *ptr;
  char	readline[512],disks[3]={0};
  int j=0,i,k;
  bool bF=false;
  
  if ((ptr = fopen(file, "r")) != NULL )
  {

    while( fgets(readline,512,ptr) != NULL )
    {
      if (bF)
        break;
      //printf("\norgline=%c",readline[strlen(readline)-1]);
      if ( !(isdigit(readline[strlen(readline)-1])) )
        readline[strlen(readline)-1]='\0';
      else
        readline[strlen(readline)]='\0';
      //printf("\nline=%s",readline);

      for (i=0;i<(int)strlen(readline);i++)
      {
        switch(tolower(readline[i]))
        {
          case '\0':
          {
            printf("\n0--->%s<",readline);
            break;
          }
          case ' ':
          {
            readline[j++]='-';
            break;
          }
          case 'o':
          {
            readline[j++]='0';
            break;
          }
          case 'x':
          {
            readline[j++]='0';
            break;
          }
          default:
          {
            readline[j++]=readline[i];
            break;
          }
        }
      }
      readline[j]=0;
      j=0;

      //printf("\nstisjena=>%s<",readline);

      for (k=0;k<(int)strlen(readline);k++)
      {
        switch(tolower(readline[k]))
        {
          case '/':
          {

            if ( (k>1) )
            {
              //if ( (k==2) && !(isalnum(readline[k-3])) )
                //break;
              if ( (readline[k-1] == '-') && (readline[k+1] == '-') && (isdigit(readline[k-2])) && (isdigit(readline[k+2])) )
              {  
                disks[0]='0';
                disks[1]=readline[k+2];
                if (isdigit(readline[k+3]))
                  disks[2]=readline[k+3];
                bF = true;
                break;
              }
              if ( !(isdigit(readline[k+1])) )
                break;
              if (readline[k-1] == '/')
                break;
              if (readline[k+3] == '/')
                break;
              if (readline[k-3] == '/')
                break;
              if ( (readline[k+4] < (int)strlen(readline)) && (isdigit(readline[k+4])) )
                break;
              //printf("%s\n%i->%c%c\n",readline,k,readline[k+1],readline[k+2]);
              disks[0]=readline[k+1];
              disks[1]=readline[k+2];
              if (isdigit(readline[k+3]))
                disks[2]=readline[k+3];
              bF = true;
              break;
            }
            break;
          }
          
          default:
          {
            break;
          }
        }
        //printf("%i->\n",k);
        if (bF)
          break;
      }
      
    }
  }
  fclose(ptr);
  //printf("\n\nend disks=%i\n%s\n",atoi(disks),file);
  //fflush(stdout);
  if ( atoi(disks) < 1 )
  {
    var.race.total_files=1000;
  }
  else
  {
    var.race.total_files=atoi(disks);
  }
    
  //write_total_files (&var);
  
}

//ali fajl obstaja ? ja=1 , ne=0
int file_exists ( char *f )
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

//vrne velikost dira
void get_dir_size (struct VARS *var)
{
  WIN32_FIND_DATA	FindFileData;
  HANDLE hFind		= INVALID_HANDLE_VALUE;
  DWORD dwError;
  
  char _m_file[MAXFILE], _d_file[MAXFILE];
  strcpy(_m_file,var->loc.env_path);
  strncat(_m_file,"\\*",3);

  hFind = FindFirstFile(_m_file, &FindFileData);
  
  if (hFind == INVALID_HANDLE_VALUE) 
  {
     FindClose(hFind);
     var->race.total_bytes = 0;
  } 
  else 
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
          if (stat_p.st_size > 0)
            var->race.total_bytes += stat_p.st_size;
          //printf("::%i\n",var->race.total_bytes);
        }
      }
    }
  
    dwError = GetLastError();
    FindClose(hFind);
    if (dwError != ERROR_NO_MORE_FILES) 
    {
      error(" -[ get_dir_size -> \n -[ ERROR %u\n", dwError);
    }
  }
  //printf("final=%i\n",var->race.total_bytes);
}

//vrne ext od fajla
int return_file_ext (char *input)
{
  char *ex;
  ex = strrchr(input,'.');
  
  if(ex != NULL)
  {
    
    ex++;
    if ( strcmp(strlwr(ex),"zip") == 0 )
      return 0;
    if ( strcmp(strlwr(ex),"mp3") == 0 )
      return 1;
    if ( strcmp(strlwr(ex),"sfv") == 0 )
      return 2;
    if ( strcmp(strlwr(ex),"nfo") == 0 )
      return 3;
    else
      return 255;
    
  }
  else
    return 255;
}


//vrne ext
int return_ext (char *input)
{
  if ( strcmp(strlwr(input),"zip") == 0 )
    return 0;
  if ( strcmp(strlwr(input),"mp3") == 0 )
    return 1;
  if ( strcmp(strlwr(input),"sfv") == 0 )
    return 2;
  if ( strcmp(strlwr(input),"nfo") == 0 )
    return 3;
  if ( strcmp(strlwr(input),"rar") == 0 )
    return 4;
  if ( strncmp(strlwr(input),"r",1) == 0 )
  {
    if ( isdigit(input[1]) && isdigit(input[2]) )
    return 4;
  }
  else
    return 255;
}

//file name,ext,size
void get_file_info (char *input)
{
  if ( -1 ==  stat (input, &stat_p))
  {
    var.file.size = 0;
  }
  else
  {
    var.file.size = stat_p.st_size;
  }

  char *f			= strrchr(input,'\\');
  if(f==NULL)
    var.file.name		= input;
  else
    var.file.name		= ++f;
  
  char *e			= strrchr(f,'.');
  if(e==NULL)
    var.file.ext		= "";
  else
    var.file.ext		= ++e;
  
}

//vrne 0 ce najde file in crc, drugace 1
int get_rescan_file( struct VARS *var, char *rescan_crc )
{
  
  HANDLE	hFile;
  DWORD		dwBytesRead, dwBytesWritten, dwPtr, dwError;

  hFile		= CreateFile(TEXT(var->file.sfv_file), GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE | FILE_SHARE_DELETE, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);
  
  if ( hFile != INVALID_HANDLE_VALUE )
  {
    
    if ( -1 ==  stat (var->file.sfv_file, &stat_p))
    {
      CloseHandle(hFile);
      return 1;
    }
    else
    {
      var->file.size = stat_p.st_size;
    }
    
    char *buff = (char *) malloc(var->file.size);
    
    ReadFile(hFile, buff, var->file.size, &dwBytesRead, NULL);
    
    if ( dwBytesRead == 0 )
    {
      CloseHandle(hFile);
      return 1;
    }
    
    CharLowerBuff(buff, dwBytesRead);
    
    boolean bFound = false;
    
    char *result = NULL;
    result = strtok( buff, "\r\n" );
    
    while( result != NULL )
    {
      if ( (result[0] != ';') && (strlen(result) > 9) )
      {

        char w_buff[LINESIZE] = "";
        
        sprintf(w_buff,"%s",result);
      	
        int len = strcspn(w_buff," ");
        char _name[128] = "";
        strncpy(_name,w_buff,len);
        
        if ( strcmp(_name, var->file.name) == 0 )
        {
          char *t = strrchr(w_buff,0x20);

          //sprintf(var->file.rescan_crc,"%08.8s",++t);
          sprintf(rescan_crc,"%08s",++t);

          //printf("result=%s\nname='%s'\ncrc='%s'\n",result,_name,rescan_crc);

      	  bFound = true;
      	  break;
      	  
      	}
      }
      result = strtok( NULL, "\r\n" );
    }
    
    free(buff);
    
    CloseHandle(hFile);

    if (bFound)
      return 0;
  }
  
  return 1;
  
}

//poradira race data za var->file.name
void remove_race_file_zip ( struct VARS *var)
{
  HANDLE	hFile;
  DWORD		dwBytesRead, dwBytesWritten, dwPtr, dwError;
  
  char		w_buff[LINESIZE] = "", r_buff[LINESIZE] = "";

  boolean	bOpen = false, bNoDiz = false;
  
  short 	o = 0;			//share
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
        error(" -[ remove_race_file_zip -> \n -[ ERROR  cant open race file %s\n", var->file.race_file);  
      }
      if ( dwError == ERROR_SHARING_VIOLATION )
      {
        o++;
        Sleep(50);
        //error(" -[ remove_race_file_zip -> %i\n -[ ERROR  SHARE %s\n", o, var->file.race_file);  
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
    dwPtr = SetFilePointer (hFile, 0, NULL, FILE_BEGIN);
    
    LockFile(hFile, dwPtr, 0, dwBytesRead, 0);
    
    while ( ReadFile(hFile, r_buff, LINESIZE, &dwBytesRead, NULL) != 0)
    {
      if( dwBytesRead == 0 ) 
        break;
      
      if (i == 0)
      {
        var->race.total_files = var->race.missing_files = (int)atoi(r_buff);
        if ( var->race.total_files == 1000 )
        {
          bNoDiz = true;
        }
      }
      
      if (strncmp(strlwr(var->file.name),strlwr(r_buff),strlen(var->file.name)) == 0)
      {
        //error("remove entry: %i,%s->%s\n",i,r_buff,var->file.name);
        dwPtr = SetFilePointer (hFile, i*LINESIZE, NULL, FILE_BEGIN);
        char w_buff[LINESIZE] = "";
        WriteFile(hFile, w_buff, LINESIZE, &dwBytesWritten, NULL);
      }

      char _t[LINESIZE] = "";
      dwPtr = SetFilePointer (hFile, i*LINESIZE, NULL, FILE_BEGIN);
      ReadFile(hFile, _t, LINESIZE, &dwBytesRead, NULL);

      //printf("line : %s\n",_t);
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
            else
            {
              (var->race.missing_files)--;
            }
            break;
          }

        }//i>0
        
        t++;
        line = strtok( NULL , " " );
        
      }
      /*while*/
      
      i++;
      char r_buff[LINESIZE] = "";
      
    }
    
    UnlockFile(hFile, dwPtr, 0, dwBytesRead, 0);
    
    CloseHandle(hFile);
    //error("i=%i\n",i);
  }
  
  if ( bNoDiz )
  {
    var->race.total_files = to;
    var->race.missing_files = 0;
/*
    char diz[MAXFILE] = "";
    sprintf(diz,"%s\\file_id.diz",var->loc.env_path);
          
    if ( (file_exists(diz)) )
    {
      get_diz (diz);
    }
*/            
  }

  if ( (var->race.total_files - var->race.missing_files) > var->race.total_files )
  {
    var->race.total_files = (var->race.total_files - var->race.missing_files);
    var->race.missing_files = 0;
  }
  
}

//poradira race data za var->file.name
void remove_race_file_sfv ( struct VARS *var)
{
  HANDLE	hFile;
  DWORD		dwBytesRead, dwBytesWritten, dwPtr, dwError;
  
  char		w_buff[LINESIZE] = "", r_buff[LINESIZE] = "";
  boolean	bOpen = false;
  
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
        error(" -[ return_sfv_check -> \n -[ ERROR  cant open race file %s\n", var->file.race_file);  
      }
      if ( dwError == ERROR_SHARING_VIOLATION )
      {
        o++;
        Sleep(50);
        //error(" -[ return_sfv_check -> %i\n -[ ERROR  SHARE %s\n", o, var->file.race_file);  
      }
    }
    else
    {
      bOpen = true;
      break;
    }
  }
  while (o < 10);

  if ( bOpen )
  {
    LockFile(hFile, dwPtr, 0, dwBytesRead, 0);
    
    int i = 0;
    
    while ( ReadFile(hFile, r_buff, LINESIZE, &dwBytesRead, NULL) != 0)
    {
      if( dwBytesRead == 0 ) 
        break;
      
      if (i == 0)
      {
        var->race.total_files = var->race.missing_files = (int)atoi(r_buff);
      }
      
      char *temp_f = (char *)malloc(LINESIZE);
      
      sprintf(temp_f,"%s",var->file.name);
      
      /*file found*/
      if (strncmp(strlwr(temp_f),strlwr(r_buff),strlen(temp_f)) == 0)
      {
        
        char temp_c[LINESIZE] = "";
        sprintf(temp_c,"%s ",var->file.name);

        char _t[LINESIZE] = "";
        dwPtr = SetFilePointer (hFile, i*LINESIZE, NULL, FILE_BEGIN);
        ReadFile(hFile, _t, LINESIZE, &dwBytesRead, NULL);

        char *line = NULL;
        line = strtok( _t, " " );
        int t = 0;

        while( line != NULL )
        {
          if ( (i > 0) )
          {

            if ( (t == 1) )
            {
              strcat(temp_c,line);
              //error("%s -- %s\n",temp_c,line);
              break;
            }
          
          }//i>0
          
          t++;
          line = strtok( NULL , " " );
          
        }

        dwPtr = SetFilePointer (hFile, i*LINESIZE, NULL, FILE_BEGIN);

        WriteFile(hFile, temp_c, LINESIZE, &dwBytesWritten, NULL); 

        char _m_file[MAXFILE];
        sprintf(_m_file,"%s\\%s%s",var->loc.env_path,var->file.name,iojZS_missing_file);
        create_0byte_file (_m_file);
        printf("!vfs:add %i %i:%i %s\n",iojZS_chmod_0byte_file,atoi(getenv("UID")),atoi(getenv("GID")),_m_file);

      }
      /*file found*/
      
      /*bFound && bOK*/
      {
        
        char _t[LINESIZE] = "";
        dwPtr = SetFilePointer (hFile, i*LINESIZE, NULL, FILE_BEGIN);
        ReadFile(hFile, _t, LINESIZE, &dwBytesRead, NULL);
        
        char *line = NULL;
        line = strtok( _t, " " );
        int t = 0;
        /*
        0 - file
        1 - crc
        2 - size
        3 - user
        4 - group
        5 - speed
        */
        /*while*/
        while( line != NULL )
        {
          if ( (i > 0) )
          {

            if ( (t == 2) )
            {
              (var->race.missing_files)--;
              break;
            }
          
          }//i>0
          
          t++;
          line = strtok( NULL , " " );
          
        }
        /*while*/
        

      }
      /*bFound && bOK*/
      
      free(temp_f);
      i++;
      char r_buff[LINESIZE] = "";
      
    }
    
    UnlockFile(hFile, dwPtr, 0, dwBytesRead, 0);
    
    CloseHandle(hFile);
    
    if ( (var->race.total_files - var->race.missing_files) > var->race.total_files )
    {
      var->race.total_files = (var->race.total_files - var->race.missing_files);
      var->race.missing_files = 0;
    }
  
  }//bOpen

}


//vrne 0=file ok, 1=crc fail, 2= ni v sfv
int return_sfv_check ( struct VARS *var)
{
  HANDLE	hFile;
  DWORD		dwBytesRead, dwBytesWritten, dwPtr, dwError;
  
  char		w_buff[LINESIZE] = "", r_buff[LINESIZE] = "";
  boolean	bOK = false, bFound = false, bOpen = false;
  
  short 	o = 0;			//share
  /*race vars*/
  float _b;				//bytes
  char _name[30], _group[30];		//user, group, ?  , *race_l
  unsigned int _s;			//speed
  boolean bNov = false;			//nov user v stats
  boolean bgNov = false;		//nova grupa v stats
  var->race.total_users = 0;		//userji
  short f;				//za sortiranje
  var->race.total_groups = 0;		//grupe
  var->race.slowest_speed = 10000;
  var->race.fastest_speed = 0;
  /*race vars*/
  hFile		= CreateFile(TEXT(var->file.race_file), GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE | FILE_SHARE_DELETE, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);
  //printf("!buffer off\n");
  do
  {
    if ( (hFile == INVALID_HANDLE_VALUE) )
    {
      dwError = GetLastError();
      /*
      if (hFile)
      {
        CloseHandle(hFile);
        error(" -[ return_sfv_check -> \n -[ ERROR  cant open race file %s\n", var->file.race_file);  
      }
      */
      if ( dwError == ERROR_SHARING_VIOLATION )
      {
        o++;
        Sleep(50);
        //error(" -[ return_sfv_check -> %i\n -[ ERROR  SHARE %s\n", o, var->file.race_file);  
      }
    }
    else
    {
      bOpen = true;
      break;
    }
  }
  while (o < 10);

  if ( bOpen )
  {
    dwPtr = SetFilePointer (hFile, 0, NULL, FILE_BEGIN);
    
    LockFile(hFile, dwPtr, 0, dwBytesRead, 0);
    
    int i = 0;
    
    while ( ReadFile(hFile, r_buff, LINESIZE, &dwBytesRead, NULL) != 0)
    {
      if( dwBytesRead == 0 ) 
        break;
      
      if (i == 0)
      {
        var->race.total_files = var->race.missing_files = (int)atoi(r_buff);
      }
      
      //int len = strlen(r_buff)+9;
      
      char *temp_f = (char *)malloc(LINESIZE);
      
      sprintf(temp_f,"%s",var->file.name);
      
      /*file found*/
      if (strncmp(strlwr(temp_f),strlwr(r_buff),strlen(temp_f)) == 0)
      {
        
        bFound = true;
        
        char *temp_c = (char *)malloc(LINESIZE);
        sprintf(temp_c,"%s %s",var->file.name,var->loc.arg_crc);
        
        /*crc ok*/
        if (strncmp(strlwr(temp_c),r_buff,strlen(temp_c)) == 0)
        {
          bOK = true;
    
         dwPtr = SetFilePointer (hFile, i*LINESIZE, NULL, FILE_BEGIN);
         /*
         if (dwPtr == INVALID_SET_FILE_POINTER)
         { 
           dwError = GetLastError() ;
           printf("error %i\n",dwError);
         }
         else
         */
         {
           ReadFile(hFile, w_buff, LINESIZE, &dwBytesRead, NULL);
           //printf("pointer1\t>%s<\n",w_buff);
           char *temp_w = (char *)malloc(LINESIZE);
           sprintf(temp_w,"%s %d %s %s %d",w_buff,var->file.size, var->race.username, var->race.groupname,var->file.speed);
           
           dwPtr = SetFilePointer (hFile, i*LINESIZE, NULL, FILE_BEGIN);
           
           //LockFile(hFile, dwPtr, 0, dwBytesRead, 0);
           WriteFile(hFile, temp_w, LINESIZE, &dwBytesWritten, NULL);
           //UnlockFile(hFile, dwPtr, 0, dwBytesRead, 0);
           
           //printf("race -> %s\n",temp_f);
           //(var->race.missing_files)--;
           
           free(temp_w);
         }
    
        }
        /*crc ok*/
        
        free(temp_c);
        
      }
      /*file found*/
      
      /*bFound && bOK*/
      //if ( bFound && bOK )
      {
        
        char _t[LINESIZE] = "";
        dwPtr = SetFilePointer (hFile, i*LINESIZE, NULL, FILE_BEGIN);
        ReadFile(hFile, _t, LINESIZE, &dwBytesRead, NULL);
        
        //printf("line : %s\n",_t);
        boolean bYes = false;		//ce so statsi za ta fajl
        char *line = NULL;		//vrstica
        char file_a[LINESIZE] = "";	//ime fajla
        char file_b[8] = "";		//crc fajla
        int t = 0;			//steje kaj vse je v vrstici
          
        line = strtok( _t, " " );
        /*
        0 - file
        1 - crc
        2 - size
        3 - user
        4 - group
        5 - speed
        */
        /*while*/
        while( line != NULL )
        {
          
          if ( (i > 0) )
          {
             
            if ( (t == 0) )
            {
              strcpy(file_a,line);
            }
          
            if ( (t == 1) )
            {
              strcpy(file_b,line);
            }
            
            if ( (t == 2) )
            {
              //printf("bytes %i:%i\n",i,atoi(line));
              (var->race.missing_files)--;
              _b = atoi(line);
              var->race.total_bytes += atoi(line);
            }
          
            if ( (t == 3) )
            {
              strcpy(_name,line);
            }
          
            if ( (t == 4) )
            {
              strcpy(_group,line);
            }
            /*
            if ( (t == 5) )
            {
              _s = atoi(line);
              var->race.total_speed += _s;
              bYes = true;
            }
            */
            if ( (t == 5) )
            {
              _s = atoi(line);
              var->race.total_speed += _s;
              
            
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
              
              #if (!iojZS_check_files_when_race)
                
                bYes = true;
                 
              #endif
              
              #if (iojZS_check_files_when_race)
              
                char cf[MAXFILE] = "";	//za fajl ki ga bo isko
                sprintf(cf,"%s\\%s",var->loc.env_path, file_a);
                
                if ( file_exists (cf) )
                {
                  bYes = true;
                }
                else
                {
                  char bula[LINESIZE] = "";
                  sprintf(bula,"%s %s",file_a, file_b);
                  //printf("bula=%s\n",bula);
                  
                  bYes = false;
                  
                  dwPtr = SetFilePointer (hFile, i*LINESIZE, NULL, FILE_BEGIN);
                  WriteFile(hFile, bula, LINESIZE, &dwBytesWritten, NULL); 
                
                  char _m_file[MAXFILE];
                  sprintf(_m_file,"%s\\%s%s",var->loc.env_path,file_a,iojZS_missing_file);
                  create_0byte_file (_m_file);
                  printf("!vfs:add %i %i:%i %s\n",iojZS_chmod_0byte_file,atoi(getenv("UID")),atoi(getenv("GID")),_m_file);
                
                }
              
              #endif
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

      }
      /*bFound && bOK*/
      
      free(temp_f);
      i++;
      char r_buff[LINESIZE] = "";
      
    }
    
    UnlockFile(hFile, dwPtr, 0, dwBytesRead, 0);
    
    CloseHandle(hFile);
    
  }//bOpen

  if ( bFound )
  {
    if ( bOK )
    {

      //var->race.total_users = j;
      //var->race.total_groups = g;
      //printf("users=%i\ngroups=%i\n",var->race.total_users,var->race.total_groups);

      if ( (var->race.total_files - var->race.missing_files) > var->race.total_files )
      {
        var->race.total_files = (var->race.total_files - var->race.missing_files);
        var->race.missing_files = 0;
      }
      
      /*total speed*/
      if ( var->race.total_files == var->race.missing_files )
        var->race.total_speed = 1;
      else
        var->race.total_speed = var->race.total_speed/(var->race.total_files - var->race.missing_files);
      /*total speed*/
      
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
              user_[t]		= user_[t+1];
              user_[t+1]	= usr;
            }
          }
        }
      }
      /*sort users*/
      
      //race_l = var->race.racers;
      
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
              group_[t]		= group_[t+1];
              group_[t+1]	= grp;
            }
          }
        }
      }
      /*sort groups*/
  
      return 0;
    }
    else 
      return 1;
  }
  else
    return 2;
}

//poisce sfv fajl
void get_sfv_name (char *input)
{
  WIN32_FIND_DATA	FindFileData;
  HANDLE hFind		= INVALID_HANDLE_VALUE;
  char			DirSpec[MAX_PATH];
  DWORD			dwError;
  
  strncpy (DirSpec, input, strlen(input)+1);
  strncat (DirSpec, "\\*.sfv", 7);
  
  hFind = FindFirstFile(DirSpec, &FindFileData);

  if (hFind != INVALID_HANDLE_VALUE) 
  {
    dwError = GetLastError();
    if (dwError == ERROR_NO_MORE_FILES) 
    {
      FindClose(hFind);
    }
    else 
    {
      error(" -[ get_sfv_name -> %s\n -[ ERROR %u\n -[ nekaj cudnega?\n", input, dwError);
      FindClose(hFind);
    }
    sprintf(var.file.sfv_file,"%s\\%s",input,FindFileData.cFileName);
  }
}

//vrne st sfv fajlov
int return_sfv_count (char *input)
{
  WIN32_FIND_DATA	FindFileData;
  HANDLE hFind		= INVALID_HANDLE_VALUE;
  char			DirSpec[MAX_PATH];
  DWORD			dwError;
  short int i		= 0;
  
  strncpy (DirSpec, input, strlen(input)+1);
  strncat (DirSpec, "\\*.sfv", 7);
  
  hFind = FindFirstFile(DirSpec, &FindFileData);

  if (hFind != INVALID_HANDLE_VALUE) 
  {
    if ( FindFileData.cFileName[0] != '.' )
    {
      //printf("1 %s\n",FindFileData.cFileName);
      i++;
    }
    
    while (FindNextFile(hFind, &FindFileData) != 0) 
    {
      if ( FindFileData.cFileName[0] != '.' )
      {
        //printf("2 %s\n",FindFileData.cFileName);
        i++;
      }
    }
    
    dwError = GetLastError();
    if (dwError == ERROR_NO_MORE_FILES) 
    {
      FindClose(hFind);
    }
    else 
    {
      error(" -[ return_sfv_count -> %s\n -[ ERROR %u\n -[ nekaj cudnega?\n", input, dwError);
      return(-1);
    }
  }

  return i;
  
}

//prebere sfv
void get_sfv (char *_sfv)
{
  //printf("sfv = %s\n",_sfv);
  int		total_files = 0;	//total fiels
  
  HANDLE	hFile;
  HANDLE	hTempFile; 
  DWORD		dwBytesRead, dwBytesWritten, dwPtr, dwError;
  
  boolean	bOK = true;
  
  hFile		= CreateFile(TEXT(_sfv), GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE | FILE_SHARE_DELETE, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);
  
  if ( (hFile == INVALID_HANDLE_VALUE) )
  {
    if (hFile)
    {
      CloseHandle(hFile);
      error(" -[ get_sfv -> \n -[ ERROR  cant open sfv %s\n", _sfv);  
    }
    bOK = false;
  }

  hTempFile	= CreateFile(TEXT(var.file.race_file), GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE | FILE_SHARE_DELETE, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);

  if ( (hTempFile == INVALID_HANDLE_VALUE) )
  {
    if (hFile)
    {
      CloseHandle(hFile);
    }
    if (hTempFile)
    {
      CloseHandle(hTempFile);
    }
    error(" -[ get_sfv -> \n -[ ERROR  cant open race %s\n", var.file.race_file);  
    total_files = 1;
    bOK = false;
  }

  if (bOK)
  {
    char *buff = (char *) malloc(var.file.size);
    
    ReadFile(hFile, buff, var.file.size, &dwBytesRead, NULL);
    
    CloseHandle(hFile);

    if ( dwBytesRead == 0 )
    {
      error(" -[ get_sfv -> %s\n -[ ERROR  cant read sfv\n", var.file.race_file);
    }
    
    CharLowerBuff(buff, dwBytesRead);
    
    char w_buff[LINESIZE] = "";

    dwPtr = SetFilePointer (hTempFile, 0, NULL, FILE_BEGIN);
    
    LockFile(hTempFile, dwPtr, 0, dwBytesRead, 0);

    sprintf(w_buff,"%i",total_files);
    WriteFile(hTempFile, w_buff, LINESIZE, &dwBytesWritten, NULL);
    
    char *result = NULL;
    result = strtok( buff, "\r\n" );
    while( result != NULL )
    {
      if ( (result[0] != ';') && (strlen(result) > 9) )
      {

        char w_buff[LINESIZE] = "";
        
        sprintf(w_buff,"%s",result);
        WriteFile(hTempFile, w_buff, LINESIZE, &dwBytesWritten, NULL);
        
        char _m_file[MAXFILE] = "";
        
        int len = strcspn(w_buff," ");
        char _name[128] = "";
        strncpy(_name,w_buff,len);

        sprintf(_m_file,"%s\\%s",var.loc.env_path,_name);
        
        if ( !file_exists(_m_file) )
        {
          strcat(_m_file,iojZS_missing_file);
          create_0byte_file (_m_file);
          printf("!vfs:add %i %i:%i %s\n",iojZS_chmod_0byte_file,atoi(getenv("UID")),atoi(getenv("GID")),_m_file);
          //printf("vfs:add %i %s:%s %s\n",iojZS_chmod_0byte_file,getenv("UID"),getenv("GID"),_m_file);
        }
        
        total_files++;

      }

      result = strtok( NULL, "\r\n" );

    }
    
    char w1_buff[LINESIZE] = "";
    sprintf(w1_buff,"%i",total_files);

    dwPtr = SetFilePointer (hTempFile, 0, NULL, FILE_BEGIN);

    WriteFile(hTempFile, w1_buff, LINESIZE, &dwBytesWritten, NULL);

    UnlockFile(hTempFile, dwPtr, 0, dwBytesRead, 0);
  
    CloseHandle(hTempFile);
    
    free(buff);

  }
  
  var.race.total_files			= total_files;
  var.race.missing_files		= total_files;
  
}

//prebere sfv
void get_sfv_1 (char *_sfv)
{
  //printf("sfv = %s\n",_sfv);
  int		total_files = 0;	//total files
  int		missing_files = 0;	//missing files
  
  HANDLE	hFile;
  DWORD		dwBytesRead, dwBytesWritten, dwPtr, dwError;
  
  boolean	bOK = true;
  
  hFile		= CreateFile(TEXT(_sfv), GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE | FILE_SHARE_DELETE, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);
  
  if ( (hFile == INVALID_HANDLE_VALUE) )
  {
    if (hFile)
    {
      CloseHandle(hFile);
      error(" -[ get_sfv_1 -> \n -[ ERROR  cant open sfv %s\n", _sfv);  
    }
    bOK = false;
  }

  if (bOK)
  {
    char *buff = (char *) malloc(var.file.size);
    
    ReadFile(hFile, buff, var.file.size, &dwBytesRead, NULL);
    
    CloseHandle(hFile);

    if ( dwBytesRead == 0 )
    {
      error(" -[ get_sfv_1 -> %s\n -[ ERROR  cant read sfv\n", var.file.race_file);
    }
    
    CharLowerBuff(buff, dwBytesRead);
    
    char w_buff[LINESIZE] = "";

    char *result = NULL;
    result = strtok( buff, "\r\n" );
    while( result != NULL )
    {
      if ( (result[0] != ';') && (strlen(result) > 9) )
      {

        char w_buff[LINESIZE] = "";
        sprintf(w_buff,"%s\\",var.loc.env_path);
        //printf("result=%s\n",result);
        strncat(w_buff,result,strlen(result)-9);
        //printf("file=%s<\n",w_buff);

        
        if ( !file_exists(w_buff) )
        {
          strcat(w_buff,iojZS_missing_file);
          create_0byte_file (w_buff);
          printf("!vfs:add %i %i:%i %s\n",iojZS_chmod_0byte_file,atoi(getenv("UID")),atoi(getenv("GID")),w_buff);
          //printf("vfs:add %i %s:%s %s\n",iojZS_chmod_0byte_file,getenv("UID"),getenv("GID"),_m_file);
          missing_files++;
        }

        total_files++;

      }

      result = strtok( NULL, "\r\n" );

    }
    
    //char w1_buff[LINESIZE] = "";
    //sprintf(w1_buff,"%i",total_files);

    free(buff);

  }
  
  var.race.total_files			= total_files;
  var.race.missing_files		= missing_files;
  
}

//preveri ce so fajli v race isti kot v sfv
boolean get_sfv_status ( char *_sfv)
{

  HANDLE	hFile;
  HANDLE	hTempFile; 
  DWORD		dwBytesRead, dwBytesWritten, dwPtr, dwError;
  
  boolean	bOpen = false, bOR = false;
  short 	o = 0;			//share
  
  hFile		= CreateFile(TEXT(_sfv), GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE | FILE_SHARE_DELETE, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);
  
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
    
    int iTotal, iFound, iRace;
    iTotal = iFound = iRace = 0;
    
    //iTotal=skup fajlov v sfv
    //iFound=kolko je najdo v race
    //iRace =kolko je vseh v race
    
    char *buff = (char *) malloc(var.file.size);
    
    ReadFile(hFile, buff, var.file.size, &dwBytesRead, NULL);
    
    CloseHandle(hFile);

    if ( dwBytesRead == 0 )
    {
      error(" -[ get_sfv_status -> %s\n -[ ERROR  cant read sfv\n", _sfv);
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
        
        iTotal++;
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
          
            //printf("i=%i\t->>%s<<->>%s<<\n",i,result,r_buff);
            //printf("->>%s<<-\n",r_buff);
          
            if (strncmp(strlwr(r_buff),strlwr(result),strlen(result)) == 0)
            {
              //printf("najdoi=%i\n->>%s<<\n>>%s<<-\n",i,result,r_buff);
              iFound++;
              break;
            }
          
          }
          
          char r_buff[LINESIZE] = "";
          i++;	
          
        }//while
        
      }//if ( (result[0] != ';') && (strlen(result) > 9) )

      result = strtok( NULL, "\r\n" );

    }//while( result != NULL )
    
    free(buff);
    
    char r_buff[LINESIZE] = "";
        
    dwPtr = SetFilePointer (hTempFile, 0, NULL, FILE_BEGIN);
    
    while ( ReadFile(hTempFile, r_buff, LINESIZE, &dwBytesRead, NULL) != 0)
    {
          
      if( dwBytesRead == 0 ) 
      {
        break;
      }
      
      iRace++;
      
    } 
        
    UnlockFile(hTempFile, dwPtr, 0, dwBytesRead, 0);
  
    CloseHandle(hTempFile);
    /*
    printf("iTotal = %i\n",iTotal);
    printf("iFound = %i\n",iFound);
    printf("iRace  = %i\n",iRace);
    printf("iRace  = %i\n",iRace-1);
    */
    
    if ( iFound = iTotal = (iRace-1))
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

//vrne 1 ce je cd,dvd,... drugace 0
int is_cd (char *instr)
{
  if ( 
       ( (strncmp(strlwr(instr), "cd",  2) == 0) && (strlen(instr) < 5) ) ||
       ( (strncmp(strlwr(instr), "dvd",  3) == 0) && (strlen(instr) < 6) ) ||
       ( (strncmp(strlwr(instr), "dis",  3) == 0) && (strlen(instr) < 7) ) ||
       ( (strncmp(strlwr(instr), "czsub",  5) == 0) && (strlen(instr) < 6) ) ||
       ( (strncmp(strlwr(instr), "sub",  3) == 0) && (strlen(instr) < 5) ) ||
       ( (strncmp(strlwr(instr), "vobsub",  6) == 0) && (strlen(instr) < 8) ) )
  {
    return 1;
  }
  else
  {
    return 0;
  }
}

// ime dira, ime parent dira, lokacija symlink, ime relisa
void get_dir_info (char *d_input)
{
  char d_temp[MAX_PATH]	= "";
  char sml[MAX_PATH]	= "";
  char rls[MAX_PATH]	= "";
  //char grp[GRPL]	= "";

  char *temp		= strrchr(d_input,'\\');
  strcpy(var.dir.name,++temp);
  
  strncpy(d_temp,d_input,strlen(d_input)-strlen(var.dir.name)-1);
  char *p_temp		= strrchr(d_temp,'\\');
  strcpy(var.dir.p_name,++p_temp);
  
  strcpy(var.dir.release,rls);

  if ( is_cd(temp) )
  {
    var.dir.bCD = true;
    
    #if ( iojZS_symlink_mp3_group )
      
      char *grp	= strrchr(var.dir.p_name,'-');
      if ( (grp == NULL) || (strlen(grp) >= GRPL ) )
        grp = "iND";
      strcpy(var.dir.groupname, ++grp);

    #endif

    sprintf(var.dir.release, "%s/%s", var.dir.p_name, var.dir.name);
    strncpy(sml,d_input,strlen(d_input)-strlen(var.dir.name)-1-strlen(var.dir.p_name));
    strncpy(var.dir.p_symlink,d_input,strlen(d_input)-strlen(var.dir.name)-1-strlen(var.dir.p_name));
    strcat(sml,replace_01(iojZS_incomplete_link_cd,&var));
    strcpy(var.dir.symlink,sml);
  }
  else
  {
    var.dir.bCD = false;
    
    #if ( iojZS_symlink_mp3_group )
      
      char *grp	= strrchr(var.dir.name,'-');
      if ( (grp == NULL) || (strlen(grp) >= GRPL ) )
        grp = "iND";
      strcpy(var.dir.groupname, ++grp);

    #endif

    sprintf(var.dir.release, "%s", var.dir.name);
    strncpy(sml,d_input,(strlen(d_input)-strlen(var.dir.name)));
    strncpy(var.dir.p_symlink,d_input,(strlen(d_input)-strlen(var.dir.name)));
    strcat(sml,replace_01(iojZS_incomplete_link,&var));
    strcpy(var.dir.symlink,sml);
  }
}

//vrne prvi argument
int return_arg (char *input)
{
  if ( strcmp(input,"upload") == 0 )
    return 0;
  if ( strcmp(input,"error") == 0 )
    return 1;
  if ( strcmp(input,"delete") == 0 )
    return 2;
  if ( strcmp(input,"rescan") == 0 )
    return 3;
  if ( strcmp(input,"newdir") == 0 )
    return 4;
  if ( strcmp(input,"deldir") == 0 )
    return 5;
  if ( strcmp(input,"iojzs") == 0 )
    return 6;
  else
    return 255;
}

//preveri ce so vsi fajli zapisani v race za sfv race prisotni 
void check_race_file_sfv ( struct VARS *var)
{
  HANDLE	hFile;
  DWORD		dwBytesRead, dwBytesWritten, dwPtr, dwError;
  
  char		w_buff[LINESIZE] = "", r_buff[LINESIZE] = "";
  boolean	bOpen = false;
  
  var->file.bOK = true;
  
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
        error(" -[ check_race_file_sfv -> \n -[ ERROR  cant open race file %s\n", var->file.race_file);  
      }
      if ( dwError == ERROR_SHARING_VIOLATION )
      {
        o++;
        Sleep(50);
        error(" -[ check_race_file_sfv -> %i\n -[ ERROR  SHARE %s\n", o, var->file.race_file);  
      }
    }
    else
    {
      bOpen = true;
      break;
    }
  }
  while (o < 10);

  if ( bOpen )
  {
    LockFile(hFile, dwPtr, 0, dwBytesRead, 0);
    
    int i = 0;
    
    while ( ReadFile(hFile, r_buff, LINESIZE, &dwBytesRead, NULL) != 0)
    {
      if( dwBytesRead == 0 ) 
        break;
      
      if (i == 0)
      {
        var->race.total_files = var->race.missing_files = (int)atoi(r_buff);
      }
      
      if ( i > 0 )
      
      {
      	
      	char *temp_f = (char *)malloc(MAXFILE);
        
        char *f = NULL;
        f = strtok(r_buff, " ");
        
        if( f != NULL )
        {
          //if ( file_exists)
          sprintf(temp_f,"%s\\%s",var->loc.env_path,f);
          
          //printf("line=%s\n",temp_f);
          
          if ( !file_exists ( temp_f ) )
          {
            var->file.name = f;
            //printf("file=%s\n",f);
            //printf("line=%s\n",temp_f);
            remove_race_file_sfv(var);
          
            char _m_file[MAXFILE];
            sprintf(_m_file,"%s\\%s%s",var->loc.env_path,var->file.name,iojZS_missing_file);
            
            if (!file_exists(_m_file))
            {
              create_0byte_file (_m_file);
              printf("!vfs:add %i %i:%i %s\n",iojZS_chmod_0byte_file,atoi(getenv("UID")),atoi(getenv("GID")),_m_file);
            }
                        
            delete_status (var);
            
            create_status(replace_01(iojZS_incmpl_bar,var),var);
            
            var->file.bOK = false;
            
          }
          
        }
      
        free(temp_f);
        
      }
      
      i++;
      
      char r_buff[LINESIZE] = "";
      
    }
    
    UnlockFile(hFile, dwPtr, 0, dwBytesRead, 0);
    
    CloseHandle(hFile);
    
  }//bOpen

}

//preveri ce so vsi fajli zapisani v race za zip race prisotni 
void check_race_file_zip ( struct VARS *var)
{
  HANDLE	hFile;
  DWORD		dwBytesRead, dwBytesWritten, dwPtr, dwError;
  
  char		w_buff[LINESIZE] = "", r_buff[LINESIZE] = "";
  boolean	bOpen = false;
  
  var->file.bOK = true;
  
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
        error(" -[ check_race_file_sfv -> \n -[ ERROR  cant open race file %s\n", var->file.race_file);  
      }
      if ( dwError == ERROR_SHARING_VIOLATION )
      {
        o++;
        Sleep(50);
        error(" -[ check_race_file_sfv -> %i\n -[ ERROR  SHARE %s\n", o, var->file.race_file);  
      }
    }
    else
    {
      bOpen = true;
      break;
    }
  }
  while (o < 10);

  if ( bOpen )
  {
    LockFile(hFile, dwPtr, 0, dwBytesRead, 0);
    
    int i = 0;
    
    while ( ReadFile(hFile, r_buff, LINESIZE, &dwBytesRead, NULL) != 0)
    {
      if( dwBytesRead == 0 ) 
        break;
      
      if (i == 0)
      {
        var->race.total_files = var->race.missing_files = (int)atoi(r_buff);
      }
      
      if ( i > 0 )
      
      {
      	
      	char *temp_f = (char *)malloc(MAXFILE);
        
        char *f = NULL;
        f = strtok(r_buff, " ");
        
        if( f != NULL )
        {
          //if ( file_exists)
          sprintf(temp_f,"%s\\%s",var->loc.env_path,f);
          
          //printf("line=%s\n",temp_f);
          
          if ( !file_exists ( temp_f ) )
          {
            var->file.name = f;
            //printf("file=%s\n",f);
            //printf("line=%s\n",temp_f);
            remove_race_file_zip(var);
            /*
            char _m_file[MAXFILE];
            sprintf(_m_file,"%s\\%s%s",var->loc.env_path,var->file.name,iojZS_missing_file);
            create_0byte_file (_m_file);
            printf("!vfs:add %i %i:%i %s\n",iojZS_chmod_0byte_file,atoi(getenv("UID")),atoi(getenv("GID")),_m_file);
            */            
            delete_status (var);
            
            create_status(replace_01(iojZS_incmpl_bar,var),var);
            
            var->file.bOK = false;
            
          }
          
        }
      
        free(temp_f);
              
      }
      
      i++;
      
      char r_buff[LINESIZE] = "";
      
    }
    
    UnlockFile(hFile, dwPtr, 0, dwBytesRead, 0);
    
    CloseHandle(hFile);
    
  }//bOpen

}

//preveri ce so vsi fajli ki so v iojZSrace prisotni in prisebni
boolean check_files(struct VARS *var, int e)
{
  //printf("e=%i\n",e);
  //return true;
  /*zip*/
  if ( e == 0 )
  {
    
    check_race_file_zip (var);
    
    if ( !var->file.bOK )
      return false;

  }
  /*zip*/
  else
  /*mp3 rar*/
  {
    
    check_race_file_sfv (var);
    
    if ( !var->file.bOK )
      return false;

  }
  /*mp3 rar*/
  
  return true;
  
}

boolean read_sfv (char *_sfv, char *buff, int size)
{

  HANDLE	hFile;
  DWORD		dwBytesRead, dwError;
  
  boolean	bOpen = false;
  short 	o = 0;			//share

  hFile		= CreateFile(TEXT(_sfv), GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE | FILE_SHARE_DELETE, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);
  
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

  if (bOpen)
  {
    
    //char *buff = (char *) malloc(SFVS*2);
    
    ReadFile(hFile, buff, size, &dwBytesRead, NULL);
    
    CloseHandle(hFile);

    if ( dwBytesRead == 0 )
    {
      error(" -[ read_sfv -> %s\n -[ ERROR  cant read sfv\n", _sfv);
      //free(buff);
      return false;
    }
    
    CharLowerBuff(buff, dwBytesRead);
    
    //printf("buff:\n%s\n",buff);
    
    return true;
    
  }
  
  return false;
  
}

boolean get_rescan_dir (struct VARS *var)
{
  
  HANDLE	hFile;
  DWORD		dwBytesRead, dwBytesWritten, dwPtr, dwError;
  
  boolean	bOpen = false, bFound = false;
  short 	o = 0;			//share
  
  var->file.rescan_ok = 0;
  var->file.rescan_fail = 0;
  
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

  if (bOpen)
  {
    
    char *buff = (char *) malloc(SFVS*2);
    
    ReadFile(hFile, buff, SFVS*2, &dwBytesRead, NULL);
    
    CloseHandle(hFile);

    if ( dwBytesRead == 0 )
    {
      error(" -[ get_rescan_dir -> %s\n -[ ERROR  cant read sfv\n", var->file.sfv_file);
      free(buff);
      return false;
    }
    
    CharLowerBuff(buff, dwBytesRead);
    
    //printf("%s<...buff\n",buff);
    
    char *result = NULL;
    result = strtok( buff, "\r\n" );
    
    while( result != NULL )
    {
      
      if ( (result[0] != ';') && (strlen(result) > 9) )
      {

        //printf(">%s<\n",result);

        char *rescan_file	= (char *)calloc(strlen(var->loc.env_path)+strlen(result)-9+2,sizeof(char));
        char *sfv_crc		= (char *)calloc(8,sizeof(char));
        char *file_crc		= (char *)calloc(8,sizeof(char));
        char *status		= (char *)calloc(8,sizeof(char));
        char *temp		= (char *)calloc(strlen(result)-9,sizeof(char));
        char *crc		= strrchr(result,0x20);
        
        sprintf(temp,"%*.*s",(strlen(result)-9),(strlen(result)-9),result);
        var->file.name = temp;
        //sprintf(rescan_file,"%s\\%s",var->loc.env_path,temp);
        sprintf(sfv_crc,"%8.8s",++crc);
        sprintf(file_crc,"00000000");
        sprintf(status,iojZS_rescan_missing);
        
        //printf("-->%s\\%s<\n",var->loc.env_path,var->file.name);
        sprintf(rescan_file,"%s\\%s",var->loc.env_path,var->file.name);
        //printf("-->%s<\n",rescan_file);
        
        if ( file_exists (rescan_file) )
        {
          
          //sprintf(file_crc,"%08lx",calc_crc32(rescan_file));
          
          DWORD dwCrc32, dwErrorCode = NO_ERROR;
          dwErrorCode = CCrc32Static::FileCrc32Win32(rescan_file, dwCrc32);
          
          if(dwErrorCode == NO_ERROR)
	    sprintf(file_crc, "%08x", dwCrc32);
	  else
	    sprintf(file_crc, "%08x", dwErrorCode);
	    
          
          if ( strncmp(strlwr(sfv_crc),strlwr(file_crc),8) == 0 )
          {
            
            sprintf(status,iojZS_rescan_ok);
            printf(" %-56.56s %8.8s %8.8s %8.8s\n",var->file.name,file_crc,sfv_crc,status);
            
            char *missing_file = (char *)calloc(strlen(rescan_file)+strlen(iojZS_missing_file)+2,sizeof(char));
                
            sprintf(missing_file,"%s%s",rescan_file,iojZS_missing_file);
                
            if ( file_exists(missing_file) )
              unlink(missing_file);
                
            free(missing_file);

            var->file.rescan_ok++;

          }
          else
          {
            
            sprintf(status,iojZS_rescan_fail);
            printf(" %-56.56s %8.8s %8.8s %8.8s\n",temp,file_crc,sfv_crc,status);
            
            var->file.rescan_fail++;
            
            char *missing_file = (char *)calloc(strlen(rescan_file)+strlen(iojZS_missing_file),sizeof(char));
                
            sprintf(missing_file,"%s%s",rescan_file,iojZS_missing_file);
                
            create_0byte_file (missing_file);
                
            if ( file_exists(missing_file) )
              printf("!vfs:add %i %i:%i %s\n",iojZS_chmod_0byte_file,atoi(getenv("UID")),atoi(getenv("GID")),missing_file);
  
            free(missing_file);
          
          }
          
        }
        else
        {
          
          printf(" %-56.56s %8.8s %8.8s %8.8s\n",var->file.name,file_crc,sfv_crc,status);

          char *missing_file = (char *)calloc(strlen(rescan_file)+strlen(iojZS_missing_file),sizeof(char));
              
          sprintf(missing_file,"%s%s",rescan_file,iojZS_missing_file);
              
          create_0byte_file (missing_file);
              
          if ( file_exists(missing_file) )
            printf("!vfs:add %i %i:%i %s\n",iojZS_chmod_0byte_file,atoi(getenv("UID")),atoi(getenv("GID")),missing_file);

          free(missing_file);
          
        }
        
        free(rescan_file);
        free(sfv_crc);
        free(file_crc);
        free(status);
        free(temp);
        free(crc);
        
      }//if ( (result[0] != ';') && (strlen(result) > 9) )

      result = strtok( NULL, "\r\n" );

    }//while( result != NULL )
    
    free(buff);
    
    return true;
    
  }
  else
  {
    
    return false;
    
  }
  
}



