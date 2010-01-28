char* hms(long secs)
{
 
	long	hours = 0,
			mins = 0,
			tmp = 0;
 
	while ( secs >= 3600 )
	{ hours++;secs -= 3600; }
	while ( secs >= 60 )
	{ mins++;secs -= 60;}

 if ( hours )	tmp = sprintf(ttime, "\\002%i\\002h ", hours);
 if ( mins )	tmp += sprintf(ttime + tmp, "\\002%i\\002m ", mins);
 if ( secs || ! tmp ) sprintf(ttime + tmp, "\\002%i\\002s ", secs);
 return ttime;
}

char* hms1(long secs)
{
 
	long	hours = 0,
			mins = 0,
			tmp = 0;
 
	while ( secs >= 3600 )
	{ hours++;secs -= 3600; }
	while ( secs >= 60 )
	{ mins++;secs -= 60;}

 if ( hours )	tmp = sprintf(ttime, "%ih ", hours);
 if ( mins )	tmp += sprintf(ttime + tmp, "%im ", mins);
 if ( secs || ! tmp ) sprintf(ttime + tmp, "%is ", secs);
 return ttime;
}

//zamenja spremenljivke
char *replace_00 (float fSize)
{
  char sSize[5] = " kMGT";
  int i;

  for (i = 0;fSize >= 1024.;i++)
  {
    fSize /= 1024.;
  }
  //printf("%-4.1f%cB\n",fSize,sSize[i]);
  //sprintf(sR,"%-4.1f%cB",fSize,sSize[i]);
  sprintf(sR,"%-4.2f%cB",fSize,sSize[i]);
  
  return sR;
}

//zamenja spremenljivke
char *replace_01 (char *instr, struct VARS *var)
{
  char   *buf_p;
  buf_p = i_buf;
  
  for ( ; *instr ; instr++ )
  {
    if ( *instr == '%' )
    {
      instr++;
      switch ( *instr )
      {  
      	case 'a': buf_p += sprintf( buf_p, "%s", (char *)var->loc.env_path ); break;
      	case 'b': buf_p += sprintf( buf_p, "%s", (char *)var->race.progress_bar ); break;										//progressmeter
      	case 'c': buf_p += sprintf( buf_p, "%s", (char *)var->dir.name ); break;										//cd in multi release
      	case 'd': buf_p += sprintf( buf_p, "%s", (char *)var->dir.p_name ); break;										//release multicd
      	case 'e': buf_p += sprintf( buf_p, "%s", replace_00(var->race.total_bytes) ); break;										//missing files
      	case 'f': buf_p += sprintf( buf_p, "%s", (char *)var->loc.env_pwd ); break;
      	case 'g': buf_p += sprintf( buf_p, "%s", var->race.groupname ); break;											//group
    	case 'h': 
    	{
    	  if ( var->dir.bCD )
    	  {
	    buf_p += sprintf( buf_p, "%s_%s", (char *)var->dir.p_name, (char *)var->dir.name ); 
	    break;
	  }
      	  else
      	  {
      	    buf_p += sprintf( buf_p, "%s", (char *)var->dir.name ); 
      	    break;
      	  }
      	}  
      	case 'i': buf_p += sprintf( buf_p, "%s", (char *)var->loc.arg_path ); break;
      	case 'k': buf_p += sprintf( buf_p, "%i", (int)var->race.total_files-(int)var->race.missing_files ); break;						//upped files
      	case 'm': buf_p += sprintf( buf_p, "%i", (int)var->race.missing_files ); break;										//missing files
      	case 'p': buf_p += sprintf( buf_p, "%i", ((int)var->race.total_files-(int)var->race.missing_files) * 100 / (int)var->race.total_files ); break;		//percent complete
      	case 'r': buf_p += sprintf( buf_p, "%s", (char *)var->dir.name ); break;										//release
      	case 's': buf_p += sprintf( buf_p, "%i", var->file.speed ); break;										//speed in kbps
      	case 'u': buf_p += sprintf( buf_p, "%s", var->race.username ); break;											//user
      	case 'v': buf_p += sprintf( buf_p, "%s", iojZS_version ); break;											//iojZS version
      	case 't': buf_p += sprintf( buf_p, "%i", (int)var->race.total_files ); break;										//total files

        case 'A': buf_p += sprintf( buf_p, "%s", var->mp3.artist ); break;
      	case 'B': buf_p += sprintf( buf_p, "%s", "\\002" ); break;												//bold
      	case 'C': buf_p += sprintf( buf_p, "%s", "\\003" ); break;												//color
        case 'D': buf_p += sprintf( buf_p, "%s", var->mp3.title ); break;
        case 'E': buf_p += sprintf( buf_p, "%i", var->mp3.track ); break;
        case 'Q': buf_p += sprintf( buf_p, "%s", var->mp3.comment ); break;
        case 'S': buf_p += sprintf( buf_p, "%s", var->mp3.album ); break;
      	case 'U': buf_p += sprintf( buf_p, "%s", "\\037" ); break;												//underline
        case 'X': buf_p += sprintf( buf_p, "%s", var->mp3.genre ); break;
        case 'Y': buf_p += sprintf( buf_p, "%s", var->mp3.year ); break;

      	case '%': buf_p += sprintf( buf_p, "%s", "%" ); break;
      }
    } 
    else 
    {
      *buf_p++ = *instr;
    }
  }
  
  *buf_p = 0;  
  return i_buf;
  
}

//zamenja spremenljivke
char *replace_02 (char *instr, struct VARS *var)
{
 int    val1, val2;
 char   *out_p;
 char   *m;
 char   ctrl[10];

 out_p = output2;

 for ( ; *instr ; instr++ ) if ( *instr == '%' ) {
        instr++;
        m = instr;
        if (*instr == '-' && isdigit(*(instr + 1))) instr += 2;
        while (isdigit(*instr)) instr++;
        if ( m != instr ) {
                sprintf(ctrl, "%.*s", instr - m, m);
                val1 = atoi(ctrl);
                } else {
                val1 = 0;
                }
        if ( *instr == '.' ) {
                instr++;
                m = instr;
                if (*instr == '-' && isdigit(*(instr + 1))) instr += 2;
                while (isdigit(*instr)) instr++;
                if ( m != instr ) {
                        sprintf(ctrl, "%.*s", instr - m, m);
                        val2 = atoi(ctrl);
                        } else {
                        val2 = 0;
                        }
                } else {
                val2 = -1;
                }

        switch ( *instr ) {
            	case 'a': out_p += sprintf(out_p, "%*.*s", val1, val2, (char *)var->dir.name ); break;										//cd in multi release
                case 'b': out_p += sprintf(out_p, "%*.*s", val1, val2, var->race.progress_bar ); break;
      		case 'c': out_p += sprintf(out_p, "%*.*s", val1, val2, (char *)var->dir.p_name ); break;										//release multicd
                case 'd': out_p += sprintf(out_p, "%*.*s", val1, val2, (char *)var->loc.env_path ); break;
                case 'e': out_p += sprintf(out_p, "%*.*s", val1, val2, replace_00(var->race.total_bytes) ); break;
                case 'f': out_p += sprintf(out_p, "%*.*s", val1, val2, var->file.name ); break;
      		case 'g': out_p += sprintf(out_p, "%*.*s", val1, val2, var->race.groupname ); break;											//group
                case 'h': out_p += sprintf(out_p, "%*.*s", val1, val2, (char *)var->loc.env_pwd ); break;
         	case 'i': out_p += sprintf(out_p, "%*.*s", val1, val2, (char *)var->race.fastest_user ); break;
         	case 'j': out_p += sprintf(out_p, "%*.*i", val1, val2, (int)var->race.fastest_speed ); break;
         	case 'k': out_p += sprintf(out_p, "%*.*s", val1, val2, (char *)var->race.slowest_user ); break;
         	case 'l': out_p += sprintf(out_p, "%*.*i", val1, val2, (int)var->race.slowest_speed ); break;
                case 'm': out_p += sprintf(out_p, "%*.*i", val1, val2, (int)var->race.missing_files ); break;
         	case 'n': out_p += sprintf(out_p, "%*.*i", val1, val2, (int)var->race.total_users); break;
         	case 'o': out_p += sprintf(out_p, "%*.*i", val1, val2, (int)var->race.total_groups); break;
                case 'p': out_p += sprintf(out_p, "%*.*i", val1, val2, (int)var->race.total_files-(int)var->race.missing_files ); break;
                case 't': out_p += sprintf(out_p, "%*.*i", val1, val2, (int)var->race.total_files ); break;
	      	case 'u': out_p += sprintf(out_p, "%*.*s", val1, val2, var->race.username ); break;											//user
                case 'z': out_p += sprintf(out_p, "%*.*s", val1, val2, replace_00(var->race.total_files*(var->race.total_bytes)) ); break;

                case 'A': out_p += sprintf(out_p, "%*.*s", val1, val2, var->mp3.artist ); break;
         	case 'B': out_p += sprintf(out_p, "%s", "\\002" ); break;												//bold
         	case 'C': out_p += sprintf(out_p, "%s", "\\003" ); break;												//color
                case 'D': out_p += sprintf(out_p, "%*.*s", val1, val2, var->mp3.title ); break;
                case 'E': out_p += sprintf(out_p, "%*.*i", val1, val2, var->mp3.track ); break;
      		case 'H': out_p += sprintf(out_p, "%*.*i", val1, val2, (int)var->file.rescan_fail ); break;										//missing files
                case 'J': out_p += sprintf(out_p, "%*.*i", val1, val2, (int)var->race.total_speed ); break;
                case 'L': out_p += sprintf(out_p, "%*.*d", val1, val2, var->race.total_time ); break;
                case 'M': out_p += sprintf(out_p, "%*.*s", val1, val2, hms(var->race.total_time) ); break;
                case 'N': out_p += sprintf(out_p, "%*.*s", val1, val2, hms1(var->race.total_time) ); break;
	      	case 'O': out_p += sprintf(out_p, "%*.*i", val1, val2, (int)var->file.rescan_ok ); break;										//total files
                case 'Q': out_p += sprintf(out_p, "%*.*s", val1, val2, var->mp3.comment ); break;
                case 'R': out_p += sprintf(out_p, "%*.*s", val1, val2, var->dir.release ); break;
                case 'S': out_p += sprintf(out_p, "%*.*s", val1, val2, var->mp3.album ); break;
         	case 'U': out_p += sprintf(out_p, "%s", "\\037" ); break;												//underline
                case 'X': out_p += sprintf(out_p, "%*.*s", val1, val2, var->mp3.genre ); break;
                case 'Y': out_p += sprintf(out_p, "%*.*s", val1, val2, var->mp3.year ); break;

                case '%': out_p += sprintf(out_p, "%s", "%" ); break;
        }
  } else *out_p++ = *instr;
  *out_p = 0;
  return output2;
}

//zamenja spremenljivke
char *replace_03 (char *instr, int pos, struct VARS *var, struct USER_ *usr, struct GROUP_ *grp )
{
 int    val1, val2;
 char   *out_p;
 char   *m;
 char   ctrl[50];

 out_p = output2;

 for ( ; *instr ; instr++ ) if ( *instr == '%' ) {
        instr++;
        m = instr;
        if (*instr == '-' && isdigit(*(instr + 1))) instr += 2;
        while (isdigit(*instr)) instr++;
        if ( m != instr ) {
                sprintf(ctrl, "%.*s", instr - m, m);
                val1 = atoi(ctrl);
                } else {
                val1 = 0;
                }
        if ( *instr == '.' ) {
                instr++;
                m = instr;
                if (*instr == '-' && isdigit(*(instr + 1))) instr += 2;
                while (isdigit(*instr)) instr++;
                if ( m != instr ) {
                        sprintf(ctrl, "%.*s", instr - m, m);
                        val2 = atoi(ctrl);
                        } else {
                        val2 = 0;
                        }
                } else {
                val2 = -1;
                }

        switch ( *instr ) {
         	case 'b': out_p += sprintf(out_p, "%*.*s", val1, val2, (char *)replace_00(group_[pos].bytes) ); break;
         	case 'c': out_p += sprintf(out_p, "%*.*i", val1, val2, group_[pos].files ); break;
         	case 'd': out_p += sprintf(out_p, "%*.*i", val1, val2, (int)var->race.total_users); break;
         	case 'e': out_p += sprintf(out_p, "%*.*i", val1, val2, (int)var->race.total_groups); break;
         	case 'f': out_p += sprintf(out_p, "%*.*i", val1, val2, user_[pos].files ); break;
                case 'g': out_p += sprintf(out_p, "%*.*s", val1, val2, group_[pos].g_name ); break;
         	case 'i': out_p += sprintf(out_p, "%*.*s", val1, val2, (char *)var->race.fastest_user ); break;
         	case 'j': out_p += sprintf(out_p, "%*.*i", val1, val2, (int)var->race.fastest_speed ); break;
         	case 'k': out_p += sprintf(out_p, "%*.*s", val1, val2, (char *)var->race.slowest_user ); break;
         	case 'l': out_p += sprintf(out_p, "%*.*i", val1, val2, (int)var->race.slowest_speed ); break;
         	case 'm': out_p += sprintf(out_p, "%*.*s", val1, val2, replace_00(user_[pos].bytes) ); break;
         	case 'o': out_p += sprintf(out_p, "%s", var->race.racers ); break;
         	case 'p': out_p += sprintf(out_p, "%*.*i", val1, val2, pos+1 ); break;			
                case 'r': out_p += sprintf(out_p, "%*.*s", val1, val2, user_[pos].g_name ); break;
         	case 'q': out_p += sprintf(out_p, "%*.*i", val1, val2, group_[pos].speed/group_[pos].files ); break;
         	case 's': out_p += sprintf(out_p, "%*.*i", val1, val2, user_[pos].speed/user_[pos].files ); break;
                case 'u': out_p += sprintf(out_p, "%*.*s", val1, val2, user_[pos].u_name ); break;
                case 'w': 
                	sprintf(ctrl, "%s@%s", user_[pos].u_name, user_[pos].g_name);
                	out_p += sprintf(out_p, "%*.*s", val1, val2, ctrl ); break;

         	case 'B': out_p += sprintf(out_p, "%s", "\\002" ); break;												//bold
         	case 'C': out_p += sprintf(out_p, "%s", "\\003" ); break;												//color
         	//stats
	       	case 'D': 
	       		#if ( iojZS_get_user_stats )
                          
                          if ( InitializeSharedMemory() )
                          {
                            FillStats();
                            out_p += sprintf(out_p, "%*.*i", val1, val2, SortStats(SORT_ALLUP, var->user.TotalUsers, user_[pos].u_name) ); 
                            CloseSharedMemory();
                          }
                          else
                          {
                            out_p += sprintf(out_p, "%i", -1 ); 
                          }
         		
	       		#endif
         		break;
         	case 'E': 
	       		#if ( iojZS_get_user_stats )
                          
                          if ( InitializeSharedMemory() )
                          {
                            FillStats();
                            out_p += sprintf(out_p, "%*.*i", val1, val2, SortStats(SORT_ALLDN, var->user.TotalUsers, user_[pos].u_name) ); 
                            CloseSharedMemory();
                          }
                          else
                          {
                            out_p += sprintf(out_p, "%i", -1 ); 
                          }
         		
	       		#endif
         		break;
         	case 'F': 
	       		#if ( iojZS_get_user_stats )
                          
                          if ( InitializeSharedMemory() )
                          {
                            FillStats();
                            out_p += sprintf(out_p, "%*.*i", val1, val2, SortStats(SORT_MNUP, var->user.TotalUsers, user_[pos].u_name) ); 
                            CloseSharedMemory();
                          }
                          else
                          {
                            out_p += sprintf(out_p, "%i", -1 ); 
                          }
         		
	       		#endif
         		break;
         	case 'G': 
	       		#if ( iojZS_get_user_stats )
                          
                          if ( InitializeSharedMemory() )
                          {
                            FillStats();
                 	    out_p += sprintf(out_p, "%*.*i", val1, val2, SortStats(SORT_MNDN, var->user.TotalUsers, user_[pos].u_name) ); 
                            CloseSharedMemory();
                          }
                          else
                          {
                            out_p += sprintf(out_p, "%i", -1 ); 
                          }
         		
	       		#endif
         		break;
         	case 'H': 
	       		#if ( iojZS_get_user_stats )
                          
                          if ( InitializeSharedMemory() )
                          {
                            FillStats();
                 	    out_p += sprintf(out_p, "%*.*i", val1, val2, SortStats(SORT_WKUP, var->user.TotalUsers, user_[pos].u_name) ); 
                            CloseSharedMemory();
                          }
                          else
                          {
                            out_p += sprintf(out_p, "%i", -1 ); 
                          }
         		
	       		#endif
         		break;
         	case 'I': 
	       		#if ( iojZS_get_user_stats )
                          
                          if ( InitializeSharedMemory() )
                          {
                            FillStats();
                 	    out_p += sprintf(out_p, "%*.*i", val1, val2, SortStats(SORT_WKDN, var->user.TotalUsers, user_[pos].u_name) ); 
                            CloseSharedMemory();
                          }
                          else
                          {
                            out_p += sprintf(out_p, "%i", -1 ); 
                          }
         		
	       		#endif
         		break;
         	case 'J': 
	       		#if ( iojZS_get_user_stats )
                          
                          if ( InitializeSharedMemory() )
                          {
                            FillStats();
                 	    out_p += sprintf(out_p, "%*.*i", val1, val2, SortStats(SORT_DAYUP, var->user.TotalUsers, user_[pos].u_name) ); 
                            CloseSharedMemory();
                          }
                          else
                          {
                            out_p += sprintf(out_p, "%i", -1 ); 
                          }
         		
	       		#endif
         		break;
         	case 'K': 
	       		#if ( iojZS_get_user_stats )
                          
                          if ( InitializeSharedMemory() )
                          {
                            FillStats();
                 	    out_p += sprintf(out_p, "%*.*i", val1, val2, SortStats(SORT_DAYDN, var->user.TotalUsers, user_[pos].u_name) ); 
                            CloseSharedMemory();
                          }
                          else
                          {
                            out_p += sprintf(out_p, "%i", -1 ); 
                          }
         		
	       		#endif
         		break;
         	//stats  
                case 'L': out_p += sprintf(out_p, "%*.*d", val1, val2, var->race.total_time ); break;
                case 'M': out_p += sprintf(out_p, "%*.*s", val1, val2, hms(var->race.total_time) ); break;

         	case 'P': out_p += sprintf(out_p, "%*i", val1, user_[pos].files * 100 / var->race.total_files ); break;
         	case 'R': out_p += sprintf(out_p, "%*.*s", val1, val2 , var->dir.release ); break;
         	case 'Q': out_p += sprintf(out_p, "%*i", val1, group_[pos].files * 100 / var->race.total_files ); break;

         	case 'U': out_p += sprintf(out_p, "%s", "\\037" ); break;												//underline

         	case '%': out_p += sprintf(out_p, "%s", "%" ); break;
        }
  } else *out_p++ = *instr;
  *out_p = 0;
  return output2;
}

