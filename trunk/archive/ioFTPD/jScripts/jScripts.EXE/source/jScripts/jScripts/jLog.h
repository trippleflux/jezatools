VOID WriteLog(char *log_str, ...)
{
	
	#if ( jScripts_enable_log_to_ioFTPD || jScripts_enable_log_to_jScripts )
     
		va_list ap;
		
		char LOG[1024];
		char *buffer;
    
		buffer = LOG;

	    time_t now;
		struct tm *l_time;
		char string[20];
	  			 
		time(&now);
		l_time = localtime(&now);

		strftime(string, sizeof string, "%m-%d-%Y %H:%M:%S", l_time);
    
		int d, i;

		char c, *s;

		va_start(ap, log_str);
    
		for ( ; *log_str ; log_str++ )
		{
			if (*log_str == '%')
			{
			  log_str++;
				
				switch(*log_str)
				{
					case 'c': c = va_arg(ap, char);		buffer += sprintf(buffer, "%c", c ); break;
					case 'd': d = va_arg(ap, int);		buffer += sprintf(buffer, "%d", d ); break;
					case 'i': i = va_arg(ap, int);		buffer += sprintf(buffer, "%i", i ); break;
					case 's': s = va_arg(ap, char *);	buffer += sprintf(buffer, "%s", s ); break;
					case '%': buffer += sprintf(buffer, "%s", "%" ); break;
				}
				
			}
			else
			{
				*buffer++ = *log_str;
			}
		}

		va_end(ap);
		
		*buffer = 0;

		#if ( jScripts_enable_log_to_ioFTPD )
		
			printf("!putlog %s", LOG);

		#endif

		#if ( jScripts_enable_log_to_jScripts )
		
			char *strLog = (char *)calloc(strlen(string)+strlen(LOG)+2,sizeof(char));
		
			sprintf(strLog,"%s %s", string, LOG);
		
			FILE		*input;

			HANDLE hMutex = CreateMutex( NULL, TRUE, "Mutex_jScripts_default_log_file" );
    
			WaitForSingleObject( hMutex, INFINITE );

			if ((input = fopen(jScripts_default_log_file, "a+")) != NULL )
			{
				fprintf(input, "%s", strLog);
				fclose(input);
			}

			ReleaseMutex( hMutex );

			CloseHandle( hMutex );
    
			free(strLog);

		#endif

	#endif

}

/*
	Created...: 2005.10.23
	Changed...: 
	By........: Jeza
	Desription: Writes a line to SysOp.log.
*/
VOID WriteSysOp(char *log_str, ...)
{
	
	va_list ap;
	
	char LOG[1024];
	char *buffer;

	buffer = LOG;

	time_t now;
	struct tm *l_time;
	char string[20];
	  			
	time(&now);
	l_time = localtime(&now);

	strftime(string, sizeof string, "%m-%d-%Y %H:%M:%S", l_time);

	int d, i;

	char c, *s;

	va_start(ap, log_str);

	for ( ; *log_str ; log_str++ )
	{
		if (*log_str == '%')
		{
			log_str++;
			
			switch(*log_str)
			{
				case 'c': c = va_arg(ap, char);		buffer += sprintf(buffer, "%c", c ); break;
				case 'd': d = va_arg(ap, int);		buffer += sprintf(buffer, "%d", d ); break;
				case 'i': i = va_arg(ap, int);		buffer += sprintf(buffer, "%i", i ); break;
				case 's': s = va_arg(ap, char *);	buffer += sprintf(buffer, "%s", s ); break;
				case '%': buffer += sprintf(buffer, "%s", "%" ); break;
			}
			
		}
		else
		{
			*buffer++ = *log_str;
		}
	}

	va_end(ap);
	
	*buffer = 0;

	char *strLog = (char *)calloc(strlen(string)+strlen(LOG)+2,sizeof(char));

	sprintf(strLog,"%s %s", string, LOG);

	FILE		*input;

	HANDLE hMutex = CreateMutex( NULL, TRUE, "Mutex_jScripts_default_sysop_file" );

	WaitForSingleObject( hMutex, INFINITE );

	if ((input = fopen(jScripts_default_sysop_file, "a+")) != NULL )
	{
		fprintf(input, "%s\n", strLog);
		fclose(input);
	}

	ReleaseMutex( hMutex );

	CloseHandle( hMutex );

	free(strLog);

}