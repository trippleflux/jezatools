#include <stdio>
#include <stdlib>
#include <string>
#include <sys/stat>
#include <sys/types>			
#include <time>
#include <ctype>
#include <windows>
#include <direct>
#include <math>
#include <tchar.h>
#include "unzip.cpp"

#include "ServerLimits.h"
#include "UserFile.h"
#include "VFS.h"
#include "WinMessages.h"
#include "DataCopy.h"

#include "../config/iojZSconfig.h"
//#include "../config/hqcompiojZSconfig.h"
#include "object.h"
#include "error.h"
#include "stats.h"
#include "id3.h"
#include "crc.h"
#include "write.h"
#include "create.h"
#include "replace.h"
#include "compare.h"
#include "return.h"

#if ( iojZS_use_ntfs_junction_point == true && iojZS_symlink_mp3_sort == true )
    #include "FSLinks/FSLinks.cpp"
    using namespace FSLinks;
#endif

#define iojZS_compnames				"JEZACOMP EPF504024 SETH"
#define iojZS_check_compnames			false

#if ( iojZS_check_compnames )
  #define INFO_BUFFER_SIZE 32767
#endif

int main (int argc, char **argv)
{
  
  time_t zdaj;
  
  /*  
  set time [clock scan "10/20/2005 00:00:00" -gmt true]
  iputs -nobuffer "$time"
  iputs -nobuffer "[clock format $time -format {%m/%d/%Y %H:%M:%S} -gmt false ]"
  */
  if ( time(&zdaj) > 1137715206 )
  {
    exit(0);
    return(0);
  }    

  #if ( iojZS_check_compnames )
  
    TCHAR  infoBuf[INFO_BUFFER_SIZE];
    DWORD  bufCharCount = INFO_BUFFER_SIZE;
    
    // Get and display the name of the computer. 
    bufCharCount = INFO_BUFFER_SIZE;
    if( !GetComputerName( infoBuf, &bufCharCount ) )
    {
      exit(0);
      return(0);
    }

    //printf("infoBuf='%s'\n",infoBuf);

    if ( compare_01 (iojZS_compnames,infoBuf) == 0 )
    {
      exit(0);
      return(0);
    }

  #endif
  
  #if ( iojZS_benchmark == true )
    DWORD Count 			= GetTickCount();
  #endif
  
  //int EXIT_VALUE			= 0;
  //int RETURN_VALUE			= 0;
  boolean bCmpl				= false;

  boolean bExitCode			= true;

  //boolean bIsRAR 			= false;
  //boolean bIsZIP 			= false;
  int iWhat				= 0;
  
  var.loc.env_path			= getenv("PATH");
  var.loc.env_pwd			= getenv("VIRTUALPATH");

  //sprintf(var.loc.env_path1, "%s\\", var.loc.env_path);
  sprintf(var.file.race_file, "%s\\.ioFTPD.iojZSrace", var.loc.env_path);
  //sprintf(var.file.race_filetmp, "%s\\.ioFTPD.iojZSracetmp", var.loc.env_path);
  sprintf(var.file.msg_file, "%s\\.ioFTPD.message", var.loc.env_path);
  
  /*
  if ( sprintf(var.race.username,getenv("USER")) == 0 )
  {
    sprintf(var.race.username,"Nobody");
  }
  
  if ( sprintf(var.race.groupname,getenv("GROUP")) == 0 )
  {
    sprintf(var.race.groupname,getenv("NoGroup"));
  }
  */
  
  strcpy(var.race.username, getenv("USER"));
  if ( strcmp(var.race.username,"") == 0 )
  {
    strcpy(var.race.username,"NoUser");
  }

  strcpy(var.race.groupname,getenv("GROUP"));
  if ( strcmp(var.race.groupname,"") == 0 )
  {
    strcpy(var.race.groupname,"NoGroup");
  }   

  int exts;
  
  /*switch arguments*/
  switch (return_arg(argv[1]))
  {
    
    /*upload*/
    case 0:
    {
      var.loc.arg_path			= argv[2];
      var.loc.arg_crc			= argv[3];
      var.loc.arg_pwd			= argv[4];
      /*
      printf("%s\n",var.loc.arg_path);
      printf("%s\n",var.loc.arg_crc);
      printf("%s\n",var.loc.arg_pwd);
      printf("%s\n",var.loc.env_path);
      printf("%s\n",var.loc.env_pwd);
      */
      printf(replace_01(iojZS_header,&var));

      get_file_info(var.loc.arg_path);

      var.file.speed			= atoi(getenv("SPEED"));

      /*
      printf("file name  = %s\n",var.file.name);
      printf("file ext   = %s\n",var.file.ext);
      printf("file size  = %d\n",var.file.size);
      printf("file speed = %d\n",var.file.speed);
      */
      
      /*skip dir*/
      if ( ( compare_03 (iojZS_no_check_dirs,var.loc.env_pwd) == 1) )
      {
        printf(replace_02(iojZS_skip_file, &var));
        printf(iojZS_footer);
        goto end;
      }
      /*skip dir*/

      /*affil dir*/
      if ( ( compare_03 (iojZS_no_message_dirs,var.loc.env_pwd) == 1) )
      {
        var.dir.bAFFIL = true;
      }
      else
      {
        var.dir.bAFFIL = false;
      }
      /*affil dir*/

      /*no ext*/
      if (strlen(var.file.ext) == 0)
      {
        printf(replace_02(iojZS_bad_file,&var));
        
        #if ( iojZS_delete_no_ext == true )
        
          #if ( iojZS_output_del_reason == true )
            printf(iojZS_delete_reason,iojZS_delete_miss_ext);
          #endif
          
          //EXIT_VALUE			= 1;
          //RETURN_VALUE			= 1;
          
          bExitCode	= false;
          
        #endif
        
        printf(iojZS_footer);
        goto end;
      }
      /*no ext*/
      
      /*speedtest*/
      if ( ( compare_01 (iojZS_speedtest_dir,var.loc.env_pwd) == 1) )
      {
        printf(replace_02(iojZS_skip_file, &var));
        
        #if ( iojZS_anounce_speedtest == true )
          
          #if ( iojZS_log_ioftpd )
            printf("!putlog SPEEDTEST: \"%s\"\n",replace_01(iojZS_irc_speedtest,&var));
          #endif
          
          #if ( iojZS_log_iojzs )
            write2log("SPEEDTEST: \"%s\"\n",replace_01(iojZS_irc_speedtest,&var));
          #endif
          
        #endif

        #if ( iojZS_delete_speedtest == true )
          
          #if ( iojZS_output_del_reason == true )
            printf(iojZS_delete_reason,iojZS_delete_speed_test);
          #endif
          
          //EXIT_VALUE			= 1;
          //RETURN_VALUE			= 1;
          
          bExitCode = false;
        #endif
        
      printf(iojZS_footer);
      goto end;
      }
      /*speedtest*/

      /*skip ext*/
      if ( ( compare_02 (iojZS_skip_ext,var.file.ext) == 1) )
      {
        printf(replace_02(iojZS_skip_file, &var));
        printf(iojZS_footer);
        goto end;
      }
      /*skip ext*/

      get_dir_info(var.loc.env_path);
      /*
      printf("p_name    ->%s\n",var.dir.p_name);
      printf("name      ->%s\n",var.dir.name);
      printf("release   ->%s\n",var.dir.release);
      printf("p_symlink ->%s\n",var.dir.p_symlink);
      printf("symlink   ->%s\n",var.dir.symlink);
      */
      
      /*skip dir*/
      if ( ( compare_02 (iojZS_skip_dir,var.dir.name) == 1) )
      {
        printf(replace_02(iojZS_skip_file, &var));
        printf(iojZS_footer);
        goto end;
      }
      /*skip dir*/

      /*0 byte*/
      if ( var.file.size <= 0 )
      {
        printf(replace_02(iojZS_bad_file,&var));
        
        #if ( iojZS_output_del_reason == true )
          printf(iojZS_delete_reason,iojZS_delete_o_byte);
        #endif
        
        #if ( iojZS_anounce_0byte_file == true )
          
          #if ( iojZS_log_ioftpd )
            printf("!putlog UPDATE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_0_byte,&var));
          #endif
          
          #if ( iojZS_log_iojzs )
            write2log("UPDATE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_0_byte,&var));
          #endif
          
        #endif
        
        //EXIT_VALUE			= 1;
        //RETURN_VALUE			= 1;
        bExitCode = false;
        printf(iojZS_footer);
        goto end;
      }
      /*0 byte*/
      
      /*not allowed ext*/
      if ( ( compare_02 (iojZS_not_ext,var.file.ext) == 1) )
      {
        printf(replace_02(iojZS_bad_file, &var));
        printf(iojZS_delete_reason,iojZS_delete_not_ext);
        //EXIT_VALUE			= 1;
        //RETURN_VALUE			= 1;
        bExitCode = false;
        printf(iojZS_footer);
        goto end;
      }
      /*not allowed ext*/
      
      /*nfo*/
      if ( strcmp(strlwr(var.file.ext),"nfo") == 0 )
      {
        printf(replace_02(iojZS_ok_file, &var));
        printf(iojZS_footer);
        
        #if ( iojZS_anounce_nfo == true )
          
          #if ( iojZS_log_ioftpd )
            printf("!putlog NFO: %s\n",replace_02(iojZS_irc_nfo,&var));
          #endif
          
          #if ( iojZS_log_iojzs )
            write2log("NFO: %s\n",replace_02(iojZS_irc_nfo,&var));
          #endif
          
        #endif

        #if ( iojZS_run_nfo_on_upload)

          STARTUPINFO si;
          PROCESS_INFORMATION pi;
          
          ZeroMemory( &si, sizeof(si) );
          si.cb = sizeof(si);
          ZeroMemory( &pi, sizeof(pi) );
          
          #if ( iojZS_dont_wait_for_script == true )
            printf("!detach 0\n");
            fflush(stdout);
          #endif
          
          if( !CreateProcess( NULL, TEXT(replace_01(iojZS_on_nfo_uploaded,&var)), NULL, NULL, false, 0, NULL, NULL, &si, &pi ) ) 
          {
              error("------[ NFO_FiLE CreateProcess (%s) failed with ERROR (%d)\n",var.loc.env_path, GetLastError());
              exit(0);
              return(0);
          }
          
          WaitForSingleObject( pi.hProcess, INFINITE );
          
          CloseHandle( pi.hProcess );
          CloseHandle( pi.hThread );
          
        #endif
              
        goto end;
      }
      /*nfo*/

      exts				= return_ext(var.file.ext);
        
      if ( exts == 0 )
      {
        iWhat				= 1;
      }

      if ( exts == 4 )
      {
        iWhat				= 2;
      }

      /*switch ext*/
      switch (exts)
      {
        
        /*zip*/
        case 0:
        {
          
          HZIP hz;
          
          if ( (hz = OpenZip(var.loc.arg_path,0)) != 0 )
          {
            
            char diz[MAXFILE] = "";
            sprintf(diz,"%s\\file_id.diz",var.loc.env_path);
            
            /*if not race file*/
            if ( !(file_exists(var.file.race_file)) )
            {
              
              SetUnzipBaseDir(hz,var.loc.env_path);
              
              ZIPENTRY ze; 
              GetZipItem(hz,-1,&ze); 
              int numitems=ze.index;
      
              for (int zi=0; zi<numitems; zi++)
              { 
                
                ZRESULT res = GetZipItem(hz,zi,&ze);
                
                //_tprintf(_T("->%s\n"),ze.name);
                
                if ( res == ZR_CORRUPT )
                  break;
                  
                if ( res != ZR_OK) 
                  break;
                
                if ( strncmp(strlwr(ze.name),"file_id.diz",11) == 0 )
                {
                  UnzipItem(hz,zi,ze.name);
                }
          
                #if ( iojZS_unzip_nfo_from_zip == true )
              
                  if ( return_file_ext (ze.name) == 3 )
                  {
                    UnzipItem(hz,zi,ze.name);
                  }
                  
                #endif
              
          
              }
              
              CloseZip(hz);

              if ( (file_exists(diz)) )
              {
                
                get_diz (diz);
                write_total_files (&var);
                write_zip_stats(&var);
                
              }
              else
              {
                
                var.race.total_files=1000;
                write_total_files (&var);
                write_zip_stats(&var);
                
              }
              
              create_bar(&var);
              create_symlink(&var);
              create_status(replace_01(iojZS_incmpl_bar,&var),&var);
              
              printf(replace_02(iojZS_ok_file, &var));
              
              #if ( iojZS_run_zip_on_upload)

                STARTUPINFO si;
                PROCESS_INFORMATION pi;
                
                ZeroMemory( &si, sizeof(si) );
                si.cb = sizeof(si);
                ZeroMemory( &pi, sizeof(pi) );
                
                #if ( iojZS_dont_wait_for_script == true )
                  printf("!detach 0\n");
                  fflush(stdout);
                #endif
                
                if( !CreateProcess( NULL, TEXT(replace_01(iojZS_on_zip_uploaded,&var)), NULL, NULL, false, 0, NULL, NULL, &si, &pi ) ) 
                {
                    error("------[ ZIP_FiLE CreateProcess (%s) failed with ERROR (%d)\n",var.loc.env_path, GetLastError());
                    exit(0);
                    return(0);
                }
                
                WaitForSingleObject( pi.hProcess, INFINITE );
                
                CloseHandle( pi.hProcess );
                CloseHandle( pi.hThread );
                
              #endif
              
              goto output;
            
            }
            /*if not race file*/
            else
            /*if race file*/
            {
              
              if (!check_zip_stats (&var))
              {
                printf(replace_02(iojZS_bad_file,&var));
                printf(iojZS_footer);
                //EXIT_VALUE	= 1;
                //RETURN_VALUE	= 1;
                bExitCode = false;
                goto end;
              }
              
              if ( !(file_exists(diz)) )
              {
                
                SetUnzipBaseDir(hz,var.loc.env_path);
                
                ZIPENTRY ze; 
                GetZipItem(hz,-1,&ze); 
                int numitems=ze.index;
                
                for (int zi=0; zi<numitems; zi++)
                { 
                  
                  ZRESULT res = GetZipItem(hz,zi,&ze);
                  
                  if ( res == ZR_CORRUPT )
                    break;
                    
                  if ( res != ZR_OK) 
                    break;
                  
                  if ( strncmp(strlwr(ze.name),"file_id.diz",11) == 0 )
                  {
                    UnzipItem(hz,zi,ze.name);
                  }
                  
                  #if ( iojZS_unzip_nfo_from_zip == true )
                
                    if ( return_ext (ze.name) == 3 )
                    {
                      UnzipItem(hz,zi,ze.name);
                    }
                    
                  #endif
                  
                
                }
                
                CloseZip(hz);

                if ( (file_exists(diz)) )
                {
                  get_diz (diz);
                  write_total_files_1 (&var);
                }
                
              }
              
              write_zip_stats(&var);
            
              create_bar(&var);
              create_symlink(&var);
              create_status(replace_01(iojZS_incmpl_bar,&var),&var);
              
              printf(replace_02(iojZS_ok_file, &var));
              
              #if ( iojZS_run_zip_on_upload)

                STARTUPINFO si;
                PROCESS_INFORMATION pi;
                
                ZeroMemory( &si, sizeof(si) );
                si.cb = sizeof(si);
                ZeroMemory( &pi, sizeof(pi) );
                
                #if ( iojZS_dont_wait_for_script == true )
                  printf("!detach 0\n");
                  fflush(stdout);
                #endif
                
                if( !CreateProcess( NULL, TEXT(replace_01(iojZS_on_zip_uploaded,&var)), NULL, NULL, false, 0, NULL, NULL, &si, &pi ) ) 
                {
                    error("------[ ZIP_FiLE CreateProcess (%s) failed with ERROR (%d)\n",var.loc.env_path, GetLastError());
                    exit(0);
                    return(0);
                }
                
                WaitForSingleObject( pi.hProcess, INFINITE );
                
                CloseHandle( pi.hProcess );
                CloseHandle( pi.hThread );
                
              #endif
              
              goto output;
              
            }
            /*if race file*/
            
            goto end;
            
            CloseZip(hz);
            
          }
          else
          {

            CloseZip(hz);
            
            printf(replace_02(iojZS_bad_file,&var));
            printf(iojZS_footer);

            #if ( iojZS_anounce_bad_file == true )
          
              #if ( iojZS_log_ioftpd )
                printf("!putlog UPDATE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_bad_file,&var));
              #endif
          
              #if ( iojZS_log_iojzs )
                write2log("UPDATE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_bad_file,&var));
              #endif
          
            #endif
            
            #if ( iojZS_create_bad_files )
            
              char _b_file[MAXFILE] = "";
              sprintf(_b_file,"%s\\%s%s",var.loc.env_path,var.file.name,iojZS_bad_name_file);
              
              if ( rename ( var.loc.arg_path, _b_file) == 0 )
              {
                goto end;
              }
              else	//rename failed -> delete file
              {
      
                //EXIT_VALUE	= 1;
                //RETURN_VALUE	= 1;
                bExitCode = false;
            
                goto end;
                
              }
              
            #endif
            
            
            #if ( iojZS_create_bad_files == false )
              
              //EXIT_VALUE	= 1;
              //RETURN_VALUE	= 1;
              bExitCode = false;
            
              goto end;
            
            #endif

          }
          
          break;
        }
        /*zip*/

        /*sfv*/
        case 2:
        {
          int sfv_count			= return_sfv_count (var.loc.env_path);
          
          if (sfv_count > 1)
          {
            printf(replace_02(iojZS_bad_file,&var));
            
            #if ( iojZS_output_del_reason == true )
              printf(iojZS_delete_reason,iojZS_delete_sfv_reason);
            #endif
            
            printf(iojZS_footer);
            //EXIT_VALUE			= 1;
            //RETURN_VALUE		= 1;
            bExitCode = false;
            goto end;
          }
          
          if ( !(file_exists(var.file.race_file)) )
          {
           
            get_sfv(var.loc.arg_path);
            
            printf(replace_02(iojZS_ok_file,&var));
            
            create_bar(&var);
            create_symlink(&var);
            create_status(replace_01(iojZS_incmpl_bar,&var),&var);
            
            #if ( iojZS_anounce_sfv == true )
          
              #if ( iojZS_log_ioftpd )
                printf("!putlog SFV: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_sfv,&var));
              #endif
          
              #if ( iojZS_log_iojzs )
                write2log("SFV: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_sfv,&var));
              #endif
          
            #endif
            
            printf(replace_02(iojZS_progressmeter_footer,&var));
          
          }
          else
          {
            
            //compare race file if the same as new sfv
            //if not prepare new race file
            if ( !get_sfv_status (var.loc.arg_path) )
            {
              
              get_sfv(var.loc.arg_path);
            
              printf(replace_02(iojZS_ok_file,&var));
            
              create_bar(&var);
              
              create_symlink(&var);
              create_status(replace_01(iojZS_incmpl_bar,&var),&var);
            
              #if ( iojZS_anounce_sfv == true )
          
                #if ( iojZS_log_ioftpd )
                  printf("!putlog SFV: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_sfv,&var));
                #endif
          
                #if ( iojZS_log_iojzs )
                  write2log("SFV: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_sfv,&var));
                #endif
          
              #endif
            
              printf(replace_02(iojZS_progressmeter_footer,&var));
          
            }
            else	//sfv was deleted and upped again
            {
              
              get_sfv_1 (var.loc.arg_path);
            
              printf(replace_02(iojZS_ok_file,&var));

              create_bar(&var);
              
              if ( var.race.missing_files == 0 )
              {
                
                get_dir_size (&var);
                
                delete_symlink(&var);
                create_status(replace_01(iojZS_cmpl_bar,&var),&var);
                
              }
              else
              {
                
                create_symlink(&var);
                create_status(replace_01(iojZS_incmpl_bar,&var),&var);
                
              }
            
              printf(replace_02(iojZS_progressmeter_footer,&var));
          
            }
            
          }

          #if ( iojZS_run_sfv_on_upload)

            STARTUPINFO si;
            PROCESS_INFORMATION pi;
            
            ZeroMemory( &si, sizeof(si) );
            si.cb = sizeof(si);
            ZeroMemory( &pi, sizeof(pi) );
            
            #if ( iojZS_dont_wait_for_script == true )
              printf("!detach 0\n");
              fflush(stdout);
            #endif
            
            if( !CreateProcess( NULL, TEXT(replace_01(iojZS_on_sfv_uploaded,&var)), NULL, NULL, false, 0, NULL, NULL, &si, &pi ) ) 
            {
                error("------[ SFV_FiLE CreateProcess (%s) failed with ERROR (%d)\n",var.loc.env_path, GetLastError());
                exit(0);
                return(0);
            }
            
            WaitForSingleObject( pi.hProcess, INFINITE );
            
            CloseHandle( pi.hProcess );
            CloseHandle( pi.hThread );
            
          #endif
              
          break;
        }
        /*sfv*/

        /*default*/
        default:
        {

          /*
          if ( !(file_exists(var.file.race_file)) )
          {
            printf(replace_02(iojZS_skip_file, &var));
            printf(iojZS_footer);
            goto end;
          }
          */

          int sfv_count			= return_sfv_count (var.loc.env_path);

          /*sfv < 1*/
          if (sfv_count < 1)
          {
            printf(replace_02(iojZS_bad_file,&var));
            
            #if ( iojZS_output_del_reason == true )
              printf(iojZS_delete_reason,iojZS_delete_no_sfv_reason);
            #endif
            
            printf(iojZS_footer);
            //EXIT_VALUE			= 1;
            //RETURN_VALUE		= 1;
            bExitCode = false;
            goto end;
          }
          /*sfv < 1*/
          
          //get_sfv_name(var.loc.env_path);
          
          int sfv_check			= return_sfv_check(&var);
          
          /*switch sfv check*/
          switch (sfv_check)
          {
            /*crc ok*/
            case 0:
            {
              printf(replace_02(iojZS_ok_file,&var));
              break;
            }
            /*crc ok*/

            /*crc fail*/
            case 1:
            {
              printf(replace_02(iojZS_bad_file,&var));
              
              #if ( iojZS_create_bad_files )
              
                char _b_file[MAXFILE] = "";
                sprintf(_b_file,"%s\\%s%s",var.loc.env_path,var.file.name,iojZS_bad_name_file);
                
                if ( rename ( var.loc.arg_path, _b_file) == 0 )
                {
                  printf(iojZS_footer);
                  goto end;
                }
                else	//rename failed -> delete file
                {
              
                  #if ( iojZS_output_del_reason == true )
                    printf(iojZS_delete_reason,iojZS_delete_crc_reason);
                  #endif
                  
                  printf(iojZS_footer);
                  
                  #if ( iojZS_anounce_bad_file == true )
                  
                    #if ( iojZS_log_ioftpd )
                      printf("!putlog UPDATE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_bad_file,&var));
                    #endif
                  
                    #if ( iojZS_log_iojzs )
                      write2log("UPDATE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_bad_file,&var));
                    #endif
                    
                  #endif
                  
                  //EXIT_VALUE		= 1;
                  //RETURN_VALUE		= 1;
                  bExitCode = false;
                  
                  goto end;
                  
                }
                
              #endif
            
            
              #if ( iojZS_create_bad_files == false )
                
                #if ( iojZS_output_del_reason == true )
                  printf(iojZS_delete_reason,iojZS_delete_crc_reason);
                #endif
                
                printf(iojZS_footer);
                
                #if ( iojZS_anounce_bad_file == true )
                
                  #if ( iojZS_log_ioftpd )
                    printf("!putlog UPDATE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_bad_file,&var));
                  #endif
                
                  #if ( iojZS_log_iojzs )
                    write2log("UPDATE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_bad_file,&var));
                  #endif
                  
                #endif
                
                //EXIT_VALUE		= 1;
                //RETURN_VALUE		= 1;
                bExitCode = false;
                
                goto end;
              
              #endif

              break;
              
            }
            /*crc fail*/

            /*no crc*/
            case 2:
            {
              printf(replace_02(iojZS_bad_file,&var));
              
              #if ( iojZS_create_bad_files )
              
                char _b_file[MAXFILE] = "";
                sprintf(_b_file,"%s\\%s%s",var.loc.env_path,var.file.name,iojZS_bad_name_file);
                
                if ( rename ( var.loc.arg_path, _b_file) == 0 )
                {
                  printf(iojZS_footer);
                  goto end;
                }
                else	//rename failed -> delete file
                {
              
                  #if ( iojZS_output_del_reason == true )
                    printf(iojZS_delete_reason,iojZS_delete_not_in_sfv_reason);
                  #endif
                  
                  printf(iojZS_footer);
                  
                  #if ( iojZS_anounce_bad_file == true )
                  
                    #if ( iojZS_log_ioftpd )
                      printf("!putlog UPDATE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_bad_file,&var));
                    #endif
                  
                    #if ( iojZS_log_iojzs )
                      write2log("UPDATE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_bad_file,&var));
                    #endif
                    
                  #endif
                  
                  //EXIT_VALUE		= 1;
                  //RETURN_VALUE		= 1;
                  bExitCode = false;
                  
                  goto end;
                  
                }
                
              #endif
            
            
              #if ( iojZS_create_bad_files == false )
                
                #if ( iojZS_output_del_reason == true )
                  printf(iojZS_delete_reason,iojZS_delete_not_in_sfv_reason);
                #endif
                
                printf(iojZS_footer);
                
                #if ( iojZS_anounce_bad_file == true )
                
                  #if ( iojZS_log_ioftpd )
                    printf("!putlog UPDATE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_bad_file,&var));
                  #endif
                
                  #if ( iojZS_log_iojzs )
                    write2log("UPDATE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_bad_file,&var));
                  #endif
                  
                #endif
                
                //EXIT_VALUE		= 1;
                //RETURN_VALUE		= 1;
                bExitCode = false;
                
                goto end;
              
              #endif

              break;

            }
            /*no crc*/

            /*default crc*/
            default:
            {
              printf(replace_02(iojZS_bad_file,&var));
              printf(iojZS_footer);
              //EXIT_VALUE		= 1;
              //RETURN_VALUE		= 1;
              bExitCode = false;
              goto end;
              break;
            }
            /*default crc*/
          }
          /*switch sfv check*/
          
          /*mp3*/
          if ( exts == 1 )
          {
            
            get_id3(var.loc.arg_path);

            /*ok genre*/
            #if ( iojZS_check_ok_genre )
              
              if ( compare_02(iojZS_allow_genre, var.mp3.genre) != 1 )
              {

                printf(replace_02(iojZS_stats_bad_genre,&var));

                #if ( iojZS_anounce_mp3_bad_genre )
                  
                  #if ( iojZS_log_ioftpd )
                    printf("!putlog UPDATE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_mp3_bad_genre,&var));
                  #endif
          
                  #if ( iojZS_log_iojzs )
                    write2log("UPDATE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_mp3_bad_genre,&var));
                  #endif
                
                #endif
              
                #if ( iojZS_delete_bad_genre )
                  
                  printf(iojZS_footer);
                  //EXIT_VALUE			= 1;
                  //RETURN_VALUE			= 1;
                  bExitCode = false;
                  goto end;
                
                #endif
              
              }
              
            #endif
            /*ok genre*/

            /*bad genre*/
            #if ( iojZS_check_bad_genre )
              
              if ( compare_02(iojZS_skip_genre, var.mp3.genre) == 1 )
              {

                printf(replace_02(iojZS_stats_bad_genre,&var));

                #if ( iojZS_anounce_mp3_bad_genre )
                  
                  #if ( iojZS_log_ioftpd )
                    printf("!putlog UPDATE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_mp3_bad_genre,&var));
                  #endif
          
                  #if ( iojZS_log_iojzs )
                    write2log("UPDATE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_mp3_bad_genre,&var));
                  #endif
                
                #endif
              
                #if ( iojZS_delete_bad_genre )
                  
                  printf(iojZS_footer);
                  //EXIT_VALUE			= 1;
                  //RETURN_VALUE			= 1;
                  bExitCode = false;
                  goto end;
                
                #endif
              
              }
              
            #endif
            /*bad genre*/

            printf(iojZS_mp3_header);
            printf(replace_02(iojZS_stats_id3,&var));

          }
          /*mp3*/
          
          goto output;
          
          goto end;
          break;
        }
        /*default*/
        
      }
      /*switch ext*/
      
      goto end;

      break;
    }
    /*upload*/

    /*error*/
    case 1:
    {
      //EXIT_VALUE			= 1;
      //RETURN_VALUE			= 1;
      bExitCode = false;
      goto end;
      break;
    }
    /*error*/

    /*delete*/
    case 2:
    {
      if ( !(file_exists(var.file.race_file)) )
      {
        goto end;
      }
        
      char tmp[MAXFILE];
      sprintf(tmp,"%s\\",var.loc.env_path);
      strcat(tmp,argv[3]);

      var.loc.arg_path			= tmp;

      get_file_info(var.loc.arg_path);
      /*
      error("------[ file name  = %s\n",var.file.name);
      error("------[ file ext   = %s\n",var.file.ext);
      error("------[ file size  = %d\n",var.file.size);
      */

      /*no ext*/
      if (strlen(var.file.ext) == 0)
      {
        goto end;
      }
      /*no ext*/
      
      /*skip dir*/
      if ( ( compare_01 (iojZS_no_check_dirs,var.loc.env_pwd) == 1) )
      {
        goto end;
      }
      /*skip dir*/

      /*speedtest*/
      if ( ( compare_01 (iojZS_speedtest_dir,var.loc.env_pwd) == 1) )
      {
        goto end;
      }
      /*speedtest*/

      /*skip ext*/
      if ( ( compare_02 (iojZS_skip_ext,var.file.ext) == 1) )
      {
        goto end;
      }
      /*skip ext*/

      get_dir_info(var.loc.env_path);
      /*
      error("p_name    ->%s\n",var.dir.p_name);
      error("name      ->%s\n",var.dir.name);
      error("release   ->%s\n",var.dir.release);
      error("p_symlink ->%s\n",var.dir.p_symlink);
      error("symlink   ->%s\n",var.dir.symlink);
      */
      
      /*skip dir*/
      if ( ( compare_02 (iojZS_skip_dir,var.dir.name) == 1) )
      {
        goto end;
      }
      /*skip dir*/
      
      /*not allowed ext*/
      if ( ( compare_02 (iojZS_not_ext,var.file.ext) == 1) )
      {
        goto end;
      }
      /*not allowed ext*/

      exts				= return_ext(var.file.ext);
      
      /*switch ext*/
      switch (exts)
      {
        /*zip*/
        case 0:
        {
          delete_status (&var);

          remove_race_file_zip(&var);

          /*poradira vse 0byte*/
          if (var.race.missing_files == 0)
          {
            {
              check_files(&var, exts);
              delete_status (&var);
              delete_0_byte_files(&var);
              delete_symlink(&var);
              unlink(var.file.race_file);
              //create_status(replace_01(iojZS_incmpl_bar,&var),&var);
              goto end;
            }
          }
          /*poradira vse 0byte*/

          /*naredi status bar*/
          if (var.race.missing_files < var.race.total_files)
          {
            {
              create_bar(&var);
              create_symlink(&var);
              create_status(replace_01(iojZS_incmpl_bar,&var),&var);
            }
          }
          /*naredi status bar*/
          
          #if (iojZS_anounce_incomplete)
            
            char* complete;
            
            complete = (char*)malloc(length(var.loc.env_path)+23);
            strcpy(complete, var.loc.env_path);
            strcat(complete, "\\.ioFTPD.iojZScomplete");
            
            if ( (file_exists (complete)) )
            {

              unlink(complete);
              
              #if ( iojZS_log_ioftpd )
                printf("!putlog INCOMPLETE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_incomplete,&var));
              #endif
                
              #if ( iojZS_log_iojzs )
                write2log("INCOMPLETE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_incomplete,&var));
              #endif
      
            }
            
            free(complete);
            
          #endif
          
          goto end;
          break;
        }
        /*zip*/

        /*sfv*/
        case 2:
        {
          delete_0_byte_files(&var);
          delete_symlink(&var);
          goto end;
          break;
        }
        /*sfv*/
        
        /*nfo*/
        case 3:
        {
          goto end;
          break;
        }
        /*nfo*/
        
        /*default*/
        default:
        {
          remove_race_file_sfv(&var);

          delete_status (&var);
          
          int sfv_count			= return_sfv_count (var.loc.env_path);
          
          if (sfv_count == 1)
          {

            create_bar(&var);
            create_symlink(&var);

            if (var.race.missing_files <= var.race.total_files)
            {
              create_status(replace_01(iojZS_incmpl_bar,&var),&var);
            }
            
          }
          else
          {
            delete_status (&var);
            delete_0_byte_files(&var);
            delete_symlink(&var);
          }
          
          #if (iojZS_anounce_incomplete)
            
            char* complete;
            
            complete = (char*)malloc(length(var.loc.env_path)+23);
            strcpy(complete, var.loc.env_path);
            strcat(complete, "\\.ioFTPD.iojZScomplete");
            
            if ( (file_exists (complete)) )
            {

              unlink(complete);
              
              #if ( iojZS_log_ioftpd )
                printf("!putlog INCOMPLETE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_incomplete,&var));
              #endif
                
              #if ( iojZS_log_iojzs )
                write2log("INCOMPLETE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_incomplete,&var));
              #endif
      
            }
            
            free(complete);
            
          #endif
          
          goto end;
          break;
        }
        /*default*/
        
      }
      /*switch ext*/

      goto end;
      break;
    }
    /*delete*/

    /*rescan*/
    case 3:
    {
      
      if ( !file_exists(var.file.race_file) )
      {  
        
        printf(replace_01(iojZS_rescan_head,&var));
        printf(" Files not checked with iojZS\n");
        printf(iojZS_rescan_foot);
        
        break;
        
      }
      
      printf("!buffer off\n");
      
      printf(replace_01(iojZS_rescan_head,&var));

      int sfv_count			= return_sfv_count (var.loc.env_path);
      //printf("%i\n",sfv_count);
      if (sfv_count == 0)
      {
        printf(iojZS_rescan_no_sfv);
        printf(iojZS_rescan_foot);
        goto end;
      }
      
      if (sfv_count > 1)
      {
        printf(iojZS_rescan_more_sfv);
        printf(iojZS_rescan_foot);
        goto end;
      }
      
      get_dir_info(var.loc.env_path);
      
      get_sfv_name(var.loc.env_path);
      
      //printf("argc=%i\nsfv=%s\n",argc,var.file.sfv_file);
      
      /*rescan dir*/
      if (argc == 2)
      {
        
        get_rescan_dir(&var);
        
        if ( file_exists(var.file.race_file) )
        {

          check_files (&var, 1);
          
          get_dir_size(&var);
          
          if ( var.race.total_files > var.file.rescan_ok )
          {
            
            create_symlink(&var);
            
            #if ( iojZS_anounce_rescan )
              
              #if ( iojZS_log_ioftpd )
                printf("!putlog UPDATE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_incomplete_rescan,&var));
              #endif
                
              #if ( iojZS_log_iojzs )
                write2log("UPDATE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_incomplete_rescan,&var));
              #endif
      
            #endif
            
          }
          
          //printf("-->%s<\n",var.file.name);
            
          if ( var.race.total_files == var.file.rescan_ok )
          {
            
            delete_symlink(&var);
            
            delete_0_byte_files(&var);
            
            if ( return_file_ext(var.file.name) == 1 )
            {
              
              char *mp3_file = (char *)calloc(strlen(var.loc.env_path)+strlen(var.file.name)+2,sizeof(char));
              sprintf(mp3_file,"%s\\%s",var.loc.env_path,var.file.name);
              
              if ( file_exists(mp3_file) )
              {
                
                get_id3 (mp3_file);
                
              }
              
              free(mp3_file);
              
              create_status(replace_01(iojZS_mp3_cmpl_bar,&var),&var);
              
              printf(replace_02(iojZS_rescan_id3, &var));
              
            }
            else
            {
              
              create_status(replace_01(iojZS_cmpl_bar,&var),&var);
              
            }

            #if ( iojZS_anounce_rescan )
              
              #if ( iojZS_log_ioftpd )
                printf("!putlog UPDATE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_complete_rescan,&var));
              #endif
                
              #if ( iojZS_log_iojzs )
                write2log("UPDATE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_complete_rescan,&var));
              #endif
        
            #endif
            
          }
          
          printf(replace_02(iojZS_rescan_total, &var));

        }
        
      }

      /*rescan file*/
      if (argc == 3)
      {
        
        char *rescan_file	= (char *)calloc(strlen(var.loc.env_path)+strlen(argv[2])+2,sizeof(char));
        char *sfv_crc		= (char *)calloc(8,sizeof(char));
        char *file_crc		= (char *)calloc(8,sizeof(char));
        char *status		= (char *)calloc(8,sizeof(char));
        
        sprintf(rescan_file,"%s\\%s",var.loc.env_path,argv[2]);
        sprintf(sfv_crc,"00000000");
        sprintf(file_crc,"00000000");
        sprintf(status,iojZS_rescan_missing);
        
        var.file.name = strlwr(argv[2]);
          
        if ( !file_exists (rescan_file) )
        {
          
          if ( get_rescan_file (&var, sfv_crc) == 0 )
          {
            
            printf(" %-56.56s %8.8s %8.8s %8.8s\n",var.file.name,file_crc,sfv_crc,status);
            
            if ( file_exists(var.file.race_file) )
            {
            
              remove_race_file_sfv(&var);

              delete_status (&var);
            
              create_status(replace_01(iojZS_incmpl_bar,&var),&var);
          
              create_symlink(&var);
          
            }

            char *missing_file = (char *)calloc(strlen(rescan_file)+strlen(iojZS_missing_file),sizeof(char));
                
            sprintf(missing_file,"%s%s",rescan_file,iojZS_missing_file);
                
            create_0byte_file (missing_file);
                
            if ( file_exists(missing_file) )
              printf("!vfs:add %i %i:%i %s\n",iojZS_chmod_0byte_file,atoi(getenv("UID")),atoi(getenv("GID")),missing_file);

            free(missing_file);
            
          }
          else
          {

            printf(" %-56.56s %8.8s %8.8s %8.8s\n",var.file.name,file_crc,sfv_crc,status);
          
          }

        }
        else
        {
        
          switch ( get_rescan_file (&var, sfv_crc) )
          {
            
            /*najdo fajl*/
            case 0:
            {
              
              sprintf(file_crc,"%08lx",calc_crc32(rescan_file));
              
              //crc enak
              if ( strncmp(file_crc,sfv_crc,8) == 0 )
              {
                
                sprintf(status,iojZS_rescan_ok);
                printf(" %-56.56s %8.8s %8.8s %8.8s\n",var.file.name,file_crc,sfv_crc,status);
                
                char *missing_file = (char *)calloc(strlen(rescan_file)+strlen(iojZS_missing_file),sizeof(char));
                
                sprintf(missing_file,"%s%s",rescan_file,iojZS_missing_file);
                
                if ( file_exists(missing_file) )
                  unlink(missing_file);
                
                free(missing_file);
                
              }
              //crc ni enak
              else
              {
                
                sprintf(status,iojZS_rescan_fail);
                printf(" %-56.56s %8.8s %8.8s %8.8s\n",var.file.name,file_crc,sfv_crc,status);
                
                if ( file_exists(var.file.race_file) )
                {
                
                  remove_race_file_sfv(&var);

                  delete_status (&var);
                
                  create_status(replace_01(iojZS_incmpl_bar,&var),&var);
          
                  create_symlink(&var);
          
                }

                if ( file_exists(rescan_file) )
                  unlink(rescan_file);

                char *missing_file = (char *)calloc(strlen(rescan_file)+strlen(iojZS_missing_file),sizeof(char));
                
                sprintf(missing_file,"%s%s",rescan_file,iojZS_missing_file);
                
                create_0byte_file (missing_file);
                
                if ( file_exists(missing_file) )
                  printf("!vfs:add %i %i:%i %s\n",iojZS_chmod_0byte_file,atoi(getenv("UID")),atoi(getenv("GID")),missing_file);

                free(missing_file);
                
              }
              
              break;
              
            }
            /*najdo fajl*/
            
            /*fajla ni v sfv???*/
            default:
            {
              
              printf(iojZS_rescan_file_not_in_sfv,var.file.name);
              
              break;
              
            }
            /*fajla ni v sfv???*/
            
          }
          
        }
        
        free(rescan_file);
        free(sfv_crc);
        free(file_crc);
        free(status);

      }
      
      printf(iojZS_rescan_foot);

      //EXIT_VALUE			= 0;
      //RETURN_VALUE			= 0;

      goto end;
      break;
    }
    /*rescan*/
    
    /*newdir*/
    case 4:
    {
      
      #if ( iojZS_log_ioftpd )
        printf("!putlog BLA: \"%s\" \"%s\" \"%s\" \"%s\" \"%s\"\n",getenv("USER"), getenv("GROUP"),argv[2],argv[3],argv[4]);
      #endif
        
      #if ( iojZS_log_iojzs )
        write2log("NEWDIR: \"%s\" \"%s\" \"%s\" \"%s\" \"%s\"\n",getenv("USER"), getenv("GROUP"),argv[2],argv[3],argv[4]);
      #endif
      
      break;

    }
    /*newdir*/

    /*deldir*/
    case 5:
    {
      
      #if ( iojZS_log_ioftpd )
        printf("!putlog BLE: \"%s\" \"%s\" \"%s\" \"%s\" \"%s\"\n",getenv("USER"), getenv("GROUP"),argv[2],argv[3],argv[4]);
      #endif
        
      #if ( iojZS_log_iojzs )
        write2log("DELDIR: \"%s\" \"%s\" \"%s\" \"%s\" \"%s\"\n",getenv("USER"), getenv("GROUP"),argv[2],argv[3],argv[4]);
      #endif
      
      break;

    }
    /*deldir*/

    /*iojzs*/
    case 6:
    {
      
      _tprintf(_T(" iojZS version %s by Jeza\n"),iojZS_version);      
      _tprintf(_T(" \n"));      
      _tprintf(_T(" ACCSPEED............: %s\n"),getenv("ACCSPEED"));      
      _tprintf(_T(" COMSPEC.............: %s\n"),getenv("COMSPEC"));      
      _tprintf(_T(" CREDITS.............: %s\n"),getenv("CREDITS"));      
      _tprintf(_T(" CREDITSECTION.......: %s\n"),getenv("CREDITSECTION"));      
      _tprintf(_T(" FLAGS...............: %s\n"),getenv("FLAGS"));      
      _tprintf(_T(" GID.................: %s\n"),getenv("GID"));      
      _tprintf(_T(" GROUP...............: %s\n"),getenv("GROUP"));      
      _tprintf(_T(" GROUPS..............: %s\n"),getenv("GROUPS"));      
      _tprintf(_T(" IDENT...............: %s\n"),getenv("IDENT"));      
      _tprintf(_T(" IP..................: %s\n"),getenv("IP"));      
      _tprintf(_T(" PATH................: %s\n"),getenv("PATH"));      
      _tprintf(_T(" PWD.................: %s\n"),getenv("PWD"));      
      _tprintf(_T(" REALPATH............: %s\n"),getenv("REALPATH"));      
      _tprintf(_T(" SECTION.............: %s\n"),getenv("SECTION"));      
      _tprintf(_T(" SECTIONNAME.........: %s\n"),getenv("SECTIONNAME"));      
      _tprintf(_T(" SESSIONNAME.........: %s\n"),getenv("SESSIONNAME"));      
      _tprintf(_T(" SPEED...............: %s\n"),getenv("SPEED"));      
      _tprintf(_T(" STATSSECTION........: %s\n"),getenv("STATSSECTION"));      
      _tprintf(_T(" SystemDrive.........: %s\n"),getenv("SystemDrive"));      
      _tprintf(_T(" SYSTEMPATH..........: %s\n"),getenv("SYSTEMPATH"));      
      _tprintf(_T(" SYSTEMROOT..........: %s\n"),getenv("SYSTEMROOT"));      
      _tprintf(_T(" TAGLINE.............: %s\n"),getenv("TAGLINE"));      
      _tprintf(_T(" UID.................: %s\n"),getenv("UID"));      
      _tprintf(_T(" USER................: %s\n"),getenv("USER"));      
      _tprintf(_T(" VIRTUALPATH.........: %s\n"),getenv("VIRTUALPATH"));      
      _tprintf(_T(" WINDIR..............: %s\n"),getenv("WINDIR"));      
      _tprintf(_T(" DAYUP...............: %s\n"),var.race.username);      
      _tprintf(_T(" \n"));      

      break;

    }
    /*iojzs*/

    /*default*/
    default:
    {
      printf("iojZS version_%s by Jeza\n",iojZS_version);
      goto end;
      break;
    }
    /*default*/

  }
  /*switch arguments*/
  
  goto end;
  
  output:

  /*iojZS_create_stats_files*/
  #if ( iojZS_create_stats_files )
    delete_stats_files (&var);
  #endif
  /*iojZS_create_stats_files*/

  delete_status (&var);
  
  if (exts != 0)
    delete_missing(&var);
  
  create_bar(&var);

  /*race time*/
  if ( !(-1 ==  stat (var.loc.env_path, &stat_p)) )
  {
    struct tm *ts;

    var.race.total_time = ceil((time(NULL)-stat_p.st_ctime)*1.);

  }
  else
  {
    var.race.total_time = 1;
  }
  /*race time*/

  /*naredi status bar*/
  if (var.race.missing_files > 0)
  {
    if ( exts == 1 )		//mp3
    {
      create_status(replace_01(iojZS_mp3_incmpl_bar,&var),&var);
    }
    else
    {
      create_status(replace_01(iojZS_incmpl_bar,&var),&var);
    }
  }
  else
  {
    if ( exts == 1 )		//mp3
    {
      create_status(replace_01(iojZS_mp3_cmpl_bar,&var),&var);
    }
    else
    {
      create_status(replace_01(iojZS_cmpl_bar,&var),&var);
    }
    //delete_symlink(&var);
  }
  /*naredi status bar*/
  
  /*.ioFTPD.message*/
  if ( (iojZS_msg_on_the_fly) && (var.race.missing_files > 0) )
  {
    if ( exts == 0 )
    {
      write_msg_diz();
    }
    else 
    {
      write_io_msg (&var, 0, "");
    }
  }

  if ( (iojZS_msg_on_complete) && (var.race.missing_files == 0) )
  {
    if ( exts == 0 )
    {
      write_msg_diz();
    }
    else 
    {
      write_io_msg (&var, 0, "");
    }
  }
  /*.ioFTPD.message*/
  
  /*userhead*/
  printf(iojZS_user_header);
  /*userhead*/
  
  /*.ioFTPD.message*/
  
  if ( (iojZS_msg_on_the_fly) && (var.race.missing_files > 0) )
  {
    write_io_msg (&var, 1, replace_02(iojZS_msg_head_release,&var));

    if ( exts == 1 )
    {
      write_io_msg (&var, 1, replace_02(iojZS_msg_mp3_info,&var));
    }
    
  }
  
  if ( (iojZS_msg_on_complete) && (var.race.missing_files == 0) )
  {
    write_io_msg (&var, 1, replace_02(iojZS_msg_head_release,&var));

    if ( exts == 1 )
    {
      write_io_msg (&var, 1, replace_02(iojZS_msg_mp3_info,&var));
    }

  }
  
  if ( !var.dir.bAFFIL ) 
  {
   
    if ( (iojZS_msg_on_the_fly) && (var.race.missing_files > 0) )
    {
      write_io_msg (&var, 1, iojZS_msg_head_users);
    }
    if ( (iojZS_msg_on_complete) && (var.race.missing_files == 0) )
    {
      write_io_msg (&var, 1, iojZS_msg_head_users);
    }
      
  }
  else
  {
    
    if ( (iojZS_write_affils_stats) && (var.dir.bAFFIL) ) 
    {
     
      if ( (iojZS_msg_on_the_fly) && (var.race.missing_files > 0) )
      {
        write_io_msg (&var, 1, iojZS_msg_head_users);
      }
      if ( (iojZS_msg_on_complete) && (var.race.missing_files == 0) )
      {
        write_io_msg (&var, 1, iojZS_msg_head_users);
      }
        
    }
      
  }
  
  /*.ioFTPD.message*/

  /*usertop*/
  for (int n=0; n<var.race.total_users; n++)
  {

    printf(replace_03(iojZS_stats_users,n,&var,user_,group_));

    /*.ioFTPD.message*/
    if ( !var.dir.bAFFIL ) 
    {
     
      if ( (iojZS_msg_on_the_fly) && (var.race.missing_files > 0) )
      {
        write_io_msg (&var, 1, replace_03(iojZS_msg_users,n,&var,user_,group_));
      }
      if ( (iojZS_msg_on_complete) && (var.race.missing_files == 0) )
      {
        write_io_msg (&var, 1, replace_03(iojZS_msg_users,n,&var,user_,group_));
      }
        
    }
    else
    {
      
      if ( (iojZS_write_affils_stats) && (var.dir.bAFFIL) ) 
      {
       
        if ( (iojZS_msg_on_the_fly) && (var.race.missing_files > 0) )
        {
          write_io_msg (&var, 1, replace_03(iojZS_msg_users,n,&var,user_,group_));
        }
        if ( (iojZS_msg_on_complete) && (var.race.missing_files == 0) )
        {
          write_io_msg (&var, 1, replace_03(iojZS_msg_users,n,&var,user_,group_));
        }
          
      }
        
    }
    /*.ioFTPD.message*/
     
    /*iojZS_create_stats_files*/
    #if ( iojZS_create_stats_files )
      create_stats_file (replace_03(iojZS_users_stats_file,n,&var,user_,group_),&var);
    #endif
    /*iojZS_create_stats_files*/

    /*racelist*/
    #if ( iojZS_anounce_race == true )
    
      if ( (var.race.total_users > 1) && (strcmp(var.race.username,user_[n].u_name) == 0) && (user_[n].files == 1) )
      {
        var.race.racer_pos = n;
      }
      else
      {
        #if ( iojZS_get_racers == true )
          //race_l += sprintf(race_l, " %s", replace_03(iojZS_irc_users_race,n,var,user_,group_));
          //strcat(var.race.racers, " ");
          strcat(var.race.racers, replace_03(iojZS_irc_users_race,n,&var,user_,group_));
        #endif
      }
    
    #endif
    /*racelist*/
  }
  /*usertop*/

  /*grouphead*/
  printf(iojZS_group_header);
  /*grouphead*/
  
  /*.ioFTPD.message*/
  if ( !var.dir.bAFFIL ) 
  {
   
    if ( (iojZS_msg_on_the_fly) && (var.race.missing_files > 0) )
    {
      write_io_msg (&var, 1, iojZS_msg_head_groups);
    }
    if ( (iojZS_msg_on_complete) && (var.race.missing_files == 0) )
    {
      write_io_msg (&var, 1, iojZS_msg_head_groups);
    }
        
  }
  else
  {
    
    if ( (iojZS_write_affils_stats) && (var.dir.bAFFIL) ) 
    {
     
      if ( (iojZS_msg_on_the_fly) && (var.race.missing_files > 0) )
      {
        write_io_msg (&var, 1, iojZS_msg_head_groups);
      }
      if ( (iojZS_msg_on_complete) && (var.race.missing_files == 0) )
      {
        write_io_msg (&var, 1, iojZS_msg_head_groups);
      }
        
    }
      
  }
  
  /*.ioFTPD.message*/

  /*grouptop*/
  for (int n=0; n<var.race.total_groups; n++)
  {
    printf(replace_03(iojZS_stats_groups,n,&var,user_,group_));

    /*.ioFTPD.message*/
    if ( !var.dir.bAFFIL ) 
    {
     
      if ( (iojZS_msg_on_the_fly) && (var.race.missing_files > 0) )
      {
        write_io_msg (&var, 1, replace_03(iojZS_msg_groups,n,&var,user_,group_));
      }
      if ( (iojZS_msg_on_complete) && (var.race.missing_files == 0) )
      {
        write_io_msg (&var, 1, replace_03(iojZS_msg_groups,n,&var,user_,group_));
      }
        
    }
    else
    {
      
      if ( (iojZS_write_affils_stats) && (var.dir.bAFFIL) ) 
      {
       
        if ( (iojZS_msg_on_the_fly) && (var.race.missing_files > 0) )
        {
          write_io_msg (&var, 1, replace_03(iojZS_msg_groups,n,&var,user_,group_));
        }
        if ( (iojZS_msg_on_complete) && (var.race.missing_files == 0) )
        {
          write_io_msg (&var, 1, replace_03(iojZS_msg_groups,n,&var,user_,group_));
        }
          
      }
        
    }
    /*.ioFTPD.message*/
     
  }
  /*grouptop*/

  /*foot + bar*/
  printf(replace_02(iojZS_progressmeter_footer,&var));
  /*foot + bar*/

  /*.ioFTPD.message*/
  if ( !var.dir.bAFFIL ) 
  {
   
    if ( (iojZS_msg_on_the_fly) && (var.race.missing_files > 0) )
    {
      write_io_msg (&var, 1, iojZS_msg_foot);
    }
    if ( (iojZS_msg_on_complete) && (var.race.missing_files == 0) )
    {
      write_io_msg (&var, 1, iojZS_msg_foot);
    }
        
  }
  else
  {
    
    if ( (iojZS_write_affils_stats) && (var.dir.bAFFIL) ) 
    {
     
      if ( (iojZS_msg_on_the_fly) && (var.race.missing_files > 0) )
      {
        write_io_msg (&var, 1, iojZS_msg_foot);
      }
      if ( (iojZS_msg_on_complete) && (var.race.missing_files == 0) )
      {
        write_io_msg (&var, 1, iojZS_msg_foot);
      }
        
    }
      
  }
  /*.ioFTPD.message*/
  
  /*UPDATE:*/
  #if ( iojZS_anounce_update == true )
    if ( (var.race.total_files-var.race.missing_files) == 1)
    {
      if ( exts == 1 )		//mp3
      {
                  
        #if ( iojZS_log_ioftpd )
          printf("!putlog UPDATE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_mp3_update,&var));
        #endif
        
        #if ( iojZS_log_iojzs )
          write2log("UPDATE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_mp3_update,&var));
        #endif
                
      }
      else
      {
                  
        #if ( iojZS_log_ioftpd )
          printf("!putlog UPDATE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_update,&var));
        #endif
        
        #if ( iojZS_log_iojzs )
          write2log("UPDATE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_update,&var));
        #endif
                
      }
    }
  #endif
  /*UPDATE:*/
  
  /*RACE:*/
  #if ( iojZS_anounce_race == true )
    if ( (var.race.total_users > 1) && (strcmp(var.race.username,user_[var.race.racer_pos].u_name) == 0) && (user_[var.race.racer_pos].files == 1) )
    {
                  
      #if ( iojZS_log_ioftpd )
        printf("!putlog RACE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_03(iojZS_irc_race,var.race.racer_pos,&var,user_,group_));
      #endif
        
      #if ( iojZS_log_iojzs )
        write2log("RACE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_03(iojZS_irc_race,var.race.racer_pos,&var,user_,group_));
      #endif
                
    }
  #endif
  /*RACE:*/
 
  /*NEW LEADER:*/
  #if ( iojZS_anounce_newleader == true )
 
    if (write_newleader() == 1)
    {
  
      #if ( iojZS_log_ioftpd )
        printf("!putlog NEWLEADER: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_03(iojZS_irc_newleader,var.race.racer_pos,&var,user_,group_));
      #endif
       
      #if ( iojZS_log_iojzs )
        write2log("NEWLEADER: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_03(iojZS_irc_newleader,var.race.racer_pos,&var,user_,group_));
      #endif
     }
 
  #endif
  /*NEW LEADER:*/
 
  /*HALFWAY:*/
  #if ( iojZS_anounce_halfway == true )
    if ( ((var.race.total_files-var.race.missing_files) == ceil(var.race.total_files/2)) && ((var.race.total_files-var.race.missing_files) > iojZS_minimum_halfway_files) )
    //if ( ((var.race.total_files-var.race.missing_files) == (var.race.total_files/2)) && ((var.race.total_files-var.race.missing_files) > iojZS_minimum_halfway_files) )
    //if ( ((var.race.total_files-var.race.missing_files) == (var.race.total_files/2)) )
    {
                  
      #if ( iojZS_log_ioftpd )
        printf("!putlog HALFWAY: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_03(iojZS_irc_halfway,0,&var,user_,group_));
      #endif
        
      #if ( iojZS_log_iojzs )
        write2log("HALFWAY: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_03(iojZS_irc_halfway,0,&var,user_,group_));
      #endif
                
    }
  #endif
  /*HALFWAY:*/
  
  /*COMPLETE:*/
  
  //boolean bCmpl = false;
    
  if ( var.race.missing_files == 0 )
  {

    /*check files*/
    if ( !check_files (&var, exts) )
    {
      goto end;
    }
    /*check files*/

    bCmpl = true;
    
    delete_symlink(&var);

    /*.ioFTPD.message*/

    /*.ioFTPD.message*/
    
    /*sort mp3*/
    if ( exts == 1 )
    {

      /*use sort shit*/
      #if ( iojZS_symlink_mp3_sort == true )

        /*not pre dir*/
        if ( ( compare_01 (iojZS_no_mp3_symlink_dirs,var.loc.env_pwd) == 0 ) 
)
        {
          /*sort genre*/
          #if ( iojZS_symlink_mp3_genre == true )

            char *temp, *temp_;
            
            temp = (char*) calloc(strlen(iojZS_mp3_genre_dir)+strlen(var.mp3.genre)+2, sizeof(char));
            sprintf(temp,"%s\\%s",iojZS_mp3_genre_dir,var.mp3.genre);
            _mkdir(temp);

            if ( var.dir.bCD )
            {

		temp_ = (char*) calloc(strlen(temp)+strlen(var.dir.p_name)+strlen(var.dir.name)+3, sizeof(char));
                sprintf(temp_,"%s\\%s_%s",temp,var.dir.p_name,var.dir.name);
               _mkdir(temp_);
               
            }
            else
            {
		
		temp_ = (char*) calloc(strlen(temp)+strlen(var.dir.name)+2, sizeof(char));
                sprintf(temp_,"%s\\%s",temp,var.dir.name);
                _mkdir(temp_);
                
            }

	    #if ( iojZS_use_ntfs_junction_point )
	    
              CreateJunctionPoint(temp_, var.loc.env_path);
              
	    #endif
	    
	    #if ( !iojZS_use_ntfs_junction_point )
 
              printf("!vfs:chattr 1 \"%s\" \"%s\"\n",temp_,(char *)var.loc.env_pwd);
              printf("!vfs:add %i %i:%i %s\n",iojZS_chmod_symlink,atoi(getenv("UID")),atoi(getenv("GID")),temp_);
 
            #endif
            
	    free(temp);
	    free(temp_);

          #endif
          /*sort genre*/

          /*sort year*/
          #if ( iojZS_symlink_mp3_year == true )


	    char *tempy, *tempy_;

            tempy = (char*) calloc(strlen(iojZS_mp3_year_dir)+strlen(var.mp3.genre)+2, sizeof(char));
            sprintf(tempy,"%s\\%s",iojZS_mp3_year_dir,var.mp3.year);
            _mkdir(tempy);

            if ( var.dir.bCD )
            {
	      
	      tempy_ = (char*) calloc(strlen(tempy)+strlen(var.dir.p_name)+strlen(var.dir.name)+3, sizeof(char));
	      sprintf(tempy_,"%s\\%s_%s",tempy,var.dir.p_name,var.dir.name);
              _mkdir(tempy_);
              
            }
            else
            {
	      
	      tempy_ = (char*) calloc(strlen(tempy)+strlen(var.dir.name)+2, sizeof(char));
              sprintf(tempy_,"%s\\%s",tempy,var.dir.name);
              _mkdir(tempy_);
              
            }

	    #if ( iojZS_use_ntfs_junction_point )
	    
              CreateJunctionPoint(tempy_, var.loc.env_path);
              
	    #endif
	    
	    #if ( !iojZS_use_ntfs_junction_point )
 
              printf("!vfs:chattr 1 \"%s\" \"%s\"\n",tempy_,(char *)var.loc.env_pwd);
              printf("!vfs:add %i %i:%i %s\n",iojZS_chmod_symlink,atoi(getenv("UID")),atoi(getenv("GID")),tempy_);
 
            #endif
            
	    free(tempy);
	    free(tempy_);

          #endif
          /*sort year*/

          /*sort group*/
          #if ( iojZS_symlink_mp3_group == true )

	    char *tempg, *tempg_;

            tempg = (char*) calloc(strlen(iojZS_mp3_group_dir)+strlen(var.mp3.genre)+2, sizeof(char));
            sprintf(tempg,"%s\\%s",iojZS_mp3_group_dir,var.dir.groupname);
            _mkdir(tempg);

            if ( var.dir.bCD )
            {

	      tempg_ = (char*) calloc(strlen(tempg)+strlen(var.dir.p_name)+strlen(var.dir.name)+3, sizeof(char));
	      sprintf(tempg_,"%s\\%s_%s",tempg,var.dir.p_name,var.dir.name);
              _mkdir(tempg_);

            }
            else
            {

	      tempg_ = (char*) calloc(strlen(tempg)+strlen(var.dir.name)+2, sizeof(char));
              sprintf(tempg_,"%s\\%s",tempg,var.dir.name);
              _mkdir(tempg_);
              
            }

	    #if ( iojZS_use_ntfs_junction_point )
	    
              CreateJunctionPoint(tempg_, var.loc.env_path);
              
	    #endif
	    
	    #if ( !iojZS_use_ntfs_junction_point )
 
              printf("!vfs:chattr 1 \"%s\" \"%s\"\n",tempg_,(char *)var.loc.env_pwd);
              printf("!vfs:add %i %i:%i %s\n",iojZS_chmod_symlink,atoi(getenv("UID")),atoi(getenv("GID")),tempg_);
 
            #endif

	    free(tempg);
	    free(tempg_);

          #endif
          /*sort group*/

          /*sort artist*/
          #if ( iojZS_symlink_mp3_artist == true )

            char *tempa, *tempa_;
            
            if ( var.dir.bCD )
            {
	      
              tempa = (char*) calloc(strlen(iojZS_mp3_group_artist)+3, sizeof(char));
              sprintf(tempa,"%s\\%c",iojZS_mp3_group_artist,var.dir.p_name[0]);
              _mkdir(tempa);

              tempa_ = (char*) calloc(strlen(tempa)+strlen(var.dir.p_name)+strlen(var.dir.name)+3, sizeof(char));
              sprintf(tempa_,"%s\\%s_%s",tempa,var.dir.p_name,var.dir.name);
              _mkdir(tempa_);

            }
            else
            {
	      
              tempa = (char*) calloc(strlen(iojZS_mp3_group_artist)+3, sizeof(char));
              sprintf(tempa,"%s\\%c",iojZS_mp3_group_artist,var.dir.name[0]);
              _mkdir(tempa);

              tempa_ = (char*) calloc(strlen(tempa)+strlen(var.dir.name)+3, sizeof(char));
              sprintf(tempa_,"%s\\%s",tempa,var.dir.name);
              _mkdir(tempa_);

            }

	    #if ( iojZS_use_ntfs_junction_point )
	    
              CreateJunctionPoint(tempa_, var.loc.env_path);
              
	    #endif
	    
	    #if ( !iojZS_use_ntfs_junction_point )
 
              printf("!vfs:chattr 1 \"%s\" \"%s\"\n",tempa_,(char *)var.loc.env_pwd);
              printf("!vfs:add %i %i:%i %s\n",iojZS_chmod_symlink,atoi(getenv("UID")),atoi(getenv("GID")),tempa_);
 
            #endif

	    free(tempa);
	    free(tempa_);

          #endif
          /*sort artist*/

        }
        /*not pre dir*/

      #endif
      /*use sort shit*/
    }
    /*sort mp3*/
    
    char* complete;
    bool bCP = false;
    
    complete = (char*)malloc(length(var.loc.env_path)+23);
    strcpy(complete, var.loc.env_path);
    strcat(complete, "\\.ioFTPD.iojZScomplete");
    
    if ( !(file_exists (complete)) )
    {
      create_0byte_file (complete);
      bCP = true;
    }
    
    free(complete);
    
    if (!bCP)
    {
      goto end;
    }
    
    #if ( iojZS_anounce_complete == true )
    
      /*no_race*/
      if ( (var.race.total_users == 1) )
      {
        /*zip*/
        if ( exts == 0 )
        {
          if ( (iojZS_anounce_zip_norace_complete) && (var.file.bZIP) )
          {
                  
            #if ( iojZS_log_ioftpd )
              printf("!putlog COMPLETE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_03(iojZS_irc_no_race_complete,0,&var,user_,group_));
            #endif
              
            #if ( iojZS_log_iojzs )
              write2log("COMPLETE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_03(iojZS_irc_no_race_complete,0,&var,user_,group_));
            #endif
                
            goto end;
          }
        }
        /*zip*/
        
        /*mp3*/
        if ( exts == 1 )
        {
          if ( (iojZS_anounce_mp3_norace_complete) )
          {
                  
            #if ( iojZS_log_ioftpd )
              printf("!putlog COMPLETE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_03(iojZS_irc_no_race_complete,0,&var,user_,group_));
            #endif
              
            #if ( iojZS_log_iojzs )
              write2log("COMPLETE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_03(iojZS_irc_no_race_complete,0,&var,user_,group_));
            #endif
                
            goto end;
          }
        }
        /*mp3*/
        
        /*rar*/
        else
        {
          if ( (iojZS_anounce_rar_norace_complete) )
          {
                  
            #if ( iojZS_log_ioftpd )
              printf("!putlog COMPLETE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_03(iojZS_irc_no_race_complete,0,&var,user_,group_));
            #endif
              
            #if ( iojZS_log_iojzs )
              write2log("COMPLETE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_03(iojZS_irc_no_race_complete,0,&var,user_,group_));
            #endif
                
            goto end;
          }
        }
        /*rar*/
      
      }
      /*no_race*/
      
      /*race complete*/
      {
        
        if ( (exts == 0) )
        {
          
          if (var.file.bZIP)
          {
            
            #if ( iojZS_log_ioftpd )
              printf("!putlog COMPLETE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_complete,&var));
            #endif
              
            #if ( iojZS_log_iojzs )
              write2log("COMPLETE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_complete,&var));
            #endif
            
            /*UserTop:*/
            #if ( iojZS_anounce_user_head == true )
            
              #if ( iojZS_log_ioftpd )
                printf("!putlog STATS: \"%s\" \"%s\"\n",var.loc.env_pwd,iojZS_irc_user_head);
              #endif
              
              #if ( iojZS_log_iojzs )
                write2log("STATS: \"%s\" \"%s\"\n",var.loc.env_pwd,iojZS_irc_user_head);
              #endif
              
            #endif
            /*UserTop:*/
            
            #if ( iojZS_anounce_user_stats == true )
              for (int n=0; (n<var.race.total_users) && (n<iojZS_total_display_users); n++)
              {
            
                #if ( iojZS_log_ioftpd )
                  printf("!putlog STATS: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_03(iojZS_irc_user_stats,n,&var,user_,group_));
                #endif
              
                #if ( iojZS_log_iojzs )
                  write2log("STATS: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_03(iojZS_irc_user_stats,n,&var,user_,group_));
                #endif
              
              }
            #endif
            
            /*GroupTop:*/
            #if ( iojZS_anounce_group_head == true )
            
              #if ( iojZS_log_ioftpd )
                printf("!putlog STATS: \"%s\" \"%s\"\n",var.loc.env_pwd,iojZS_irc_group_head);
              #endif
              
              #if ( iojZS_log_iojzs )
                write2log("STATS: \"%s\" \"%s\"\n",var.loc.env_pwd,iojZS_irc_group_head);
              #endif
              
            #endif
            /*GroupTop:*/
            
            #if ( iojZS_anounce_group_stats == true )
              for (int n=0; (n<var.race.total_groups) && (n<iojZS_total_display_groups); n++)
              {
            
                #if ( iojZS_log_ioftpd )
                  printf("!putlog STATS: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_03(iojZS_irc_group_stats,n,&var,user_,group_));
                #endif
              
                #if ( iojZS_log_iojzs )
                  write2log("STATS: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_03(iojZS_irc_group_stats,n,&var,user_,group_));
                #endif
              
              }
            #endif
          
          }
        
        }
        else
        {
            
          #if ( iojZS_log_ioftpd )
            printf("!putlog COMPLETE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_complete,&var));
          #endif
              
          #if ( iojZS_log_iojzs )
            write2log("COMPLETE: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_02(iojZS_irc_complete,&var));
          #endif
              
          /*UserTop:*/
          #if ( iojZS_anounce_user_head == true )
            
            #if ( iojZS_log_ioftpd )
              printf("!putlog STATS: \"%s\" \"%s\"\n",var.loc.env_pwd,iojZS_irc_user_head);
            #endif
              
            #if ( iojZS_log_iojzs )
              write2log("STATS: \"%s\" \"%s\"\n",var.loc.env_pwd,iojZS_irc_user_head);
            #endif
              
          #endif
          /*UserTop:*/
          
          #if ( iojZS_anounce_user_stats == true )
            for (int n=0; (n<var.race.total_users) && (n<iojZS_total_display_users); n++)
            {
            
              #if ( iojZS_log_ioftpd )
                printf("!putlog STATS: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_03(iojZS_irc_user_stats,n,&var,user_,group_));
              #endif
              
              #if ( iojZS_log_iojzs )
                write2log("STATS: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_03(iojZS_irc_user_stats,n,&var,user_,group_));
              #endif
              
            }
          #endif
          
          /*GroupTop:*/
          #if ( iojZS_anounce_group_head == true )
            
            #if ( iojZS_log_ioftpd )
              printf("!putlog STATS: \"%s\" \"%s\"\n",var.loc.env_pwd,iojZS_irc_group_head);
            #endif
              
            #if ( iojZS_log_iojzs )
              write2log("STATS: \"%s\" \"%s\"\n",var.loc.env_pwd,iojZS_irc_group_head);
            #endif
              
          #endif
          /*GroupTop:*/
          
          #if ( iojZS_anounce_group_stats == true )
            for (int n=0; (n<var.race.total_groups) && (n<iojZS_total_display_groups); n++)
            {
            
              #if ( iojZS_log_ioftpd )
                printf("!putlog STATS: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_03(iojZS_irc_group_stats,n,&var,user_,group_));
              #endif
              
              #if ( iojZS_log_iojzs )
                write2log("STATS: \"%s\" \"%s\"\n",var.loc.env_pwd,replace_03(iojZS_irc_group_stats,n,&var,user_,group_));
              #endif
              
            }
          #endif
        
        }
        
      }
      /*race complete*/
   
    #endif
    
  }
  
  /*COMPLETE:*/
  
  #if ( iojZS_benchmark == true )
    printf(" Checks completed in %d ms\n",  (GetTickCount() - Count));
  #endif
  
  end:
  /*

  printf("exit=%i\n",EXIT_VALUE);
  printf("return=%i\n",RETURN_VALUE);

  if ( EXIT_VALUE > 1 )
    EXIT_VALUE = 0;
    
  if ( RETURN_VALUE > 1 )
    RETURN_VALUE = 0;
  */
  
  /*run rar on complete*/
  
  #if ( iojZS_run_rar_on_complete == true )
  
    if ( bCmpl )
    {

      if ( iWhat == 2 )
      {

        //printf("Execute RAR: >%s<\n",replace_01(iojZS_rar_on_rls_complete,&var));
        
        STARTUPINFO si;
        PROCESS_INFORMATION pi;
        
        ZeroMemory( &si, sizeof(si) );
        si.cb = sizeof(si);
        ZeroMemory( &pi, sizeof(pi) );
    
        #if ( iojZS_dont_wait_for_script == true )
          printf("!detach 0\n");
          fflush(stdout);
        #endif
        
        if( !CreateProcess( NULL, TEXT(replace_01(iojZS_rar_on_rls_complete,&var)), NULL, NULL, false, 0, NULL, NULL, &si, &pi ) ) 
        {
            error("------[ RAR CreateProcess (%s) failed with ERROR (%d)\n",var.loc.env_path,GetLastError());
            exit(0);
            return(0);
        }
    
        WaitForSingleObject( pi.hProcess, INFINITE );
    
        CloseHandle( pi.hProcess );
        CloseHandle( pi.hThread );
        
      }
      
    }
  
  #endif
  
  /*run rar on complete*/

  /*run zip on complete*/
  
  #if ( iojZS_run_zip_on_complete == true )
    
    if ( bCmpl )
    {
      
      if ( iWhat == 1 )
      {

        //printf("Execute ZIP: >%s<\n",replace_01(iojZS_zip_on_rls_complete,&var));
        
        STARTUPINFO si;
        PROCESS_INFORMATION pi;
        
        ZeroMemory( &si, sizeof(si) );
        si.cb = sizeof(si);
        ZeroMemory( &pi, sizeof(pi) );
    
        #if ( iojZS_dont_wait_for_script == true )
          printf("!detach 0\n");
          fflush(stdout);
        #endif
        
        if( !CreateProcess( NULL, TEXT(replace_01(iojZS_zip_on_rls_complete,&var)), NULL, NULL, false, 0, NULL, NULL, &si, &pi ) ) 
        {
            error("------[ ZIP CreateProcess (%s) failed with ERROR (%d)\n",var.loc.env_path, GetLastError());
            exit(0);
            return(0);
        }
    
        WaitForSingleObject( pi.hProcess, INFINITE );
    
        CloseHandle( pi.hProcess );
        CloseHandle( pi.hThread );
        
      }
      
    }
  
  #endif
  
  /*run zip on complete*/
  
  fflush(stdout);

  if ( bExitCode )
  {
    exit(0);
    return(0);
  }
  else
  {
    exit(1);
    return(1);
  }

}