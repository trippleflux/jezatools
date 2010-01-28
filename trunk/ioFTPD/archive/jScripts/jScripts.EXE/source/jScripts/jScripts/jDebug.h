int length(char* chaine)
{
 
  int i=0;
  while(chaine[i] != '\0')
   i++;
 
  return i;
}

VOID debug(char *debug_str, ...)
{

	#if ( jScripts_enable_client_debug || jScripts_enable_file_debug )

		va_list		ap;
	    
		time_t now;
		struct tm *l_time;
		char string[20];
		  			 
		time(&now);
		l_time = localtime(&now);
		strftime(string, sizeof string, "%Y-%m-%d %H:%M:%S\n", l_time);

		va_start(ap, debug_str);
	  
	#endif
  
	#if ( jScripts_enable_client_debug )

		va_list arg;
		va_start( arg, debug_str );
		fprintf( stderr, "| DEBUG...: " );
		vfprintf( stderr, debug_str, arg );
		fprintf( stderr, "" );
		va_end( arg );
	    
	#endif

	#if ( jScripts_enable_file_debug )

		HANDLE hMutex = CreateMutex( NULL, TRUE, "MutexDebug" );
	    
		WaitForSingleObject( hMutex, INFINITE );
	    
		char* DebugFile = (char*)calloc(length(jScripts_default_file_name_debug)+1, sizeof(char));
		sprintf(DebugFile, "%s", jScripts_default_file_name_debug);
		    
		FILE		*input;

		if ((input = fopen(DebugFile, "a+")) != NULL )
		{
			fprintf(input, "%.24s -> ", string);
			vfprintf(input, debug_str, ap);
			fclose(input);
		}
		    
		free(DebugFile);

		ReleaseMutex( hMutex );

		CloseHandle( hMutex );

	#endif

}

VOID action(char *action_str, ...)
{

	#if ( jScripts_enable_file_actions_debug )

		va_list		ap;
	    
		time_t now;
		struct tm *l_time;
		char string[20];
		  			 
		time(&now);
		l_time = localtime(&now);
		strftime(string, sizeof string, "%Y-%m-%d %H:%M:%S\n", l_time);

		va_start(ap, action_str);
	  
		HANDLE hMutex = CreateMutex( NULL, TRUE, "MutexAction" );
	    
		WaitForSingleObject( hMutex, INFINITE );
	    
		char* ActionFile = (char*)calloc(length(jScripts_default_file_name_actions)+1, sizeof(char));
		sprintf(ActionFile, "%s", jScripts_default_file_name_actions);
		    
		FILE		*input;

		if ((input = fopen(ActionFile, "a+")) != NULL )
		{
			fprintf(input, "%.24s -> ", string);
			vfprintf(input, action_str, ap);
			fclose(input);
		}
		    
		free(ActionFile);

		ReleaseMutex( hMutex );

		CloseHandle( hMutex );

	#endif

}