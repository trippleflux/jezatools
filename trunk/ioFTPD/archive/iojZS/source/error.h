#define iojZS_error " -[ Wrong arguments posted to script! Check ioFTPD.ini \n" \
		    " -[ [Events]                                           \n" \
		    " -[ OnUploadComplete       = EXEC iojZS.exe upload     \n" \
		    " -[ [FTP_Post-Command_Events]                          \n" \
		    " -[ dele                   = EXEC iojZS.exe delete     \n"

int error(char *error_str, ...)
{
  FILE		*input;
  va_list	ap;
  time_t 	timenow = time(NULL);
  
  va_start(ap, error_str);
  
  if ((input = fopen("iojZS_ERROR.log", "a+")) != NULL )
  {
    fprintf(input, "%.24s \n", ctime(&timenow));
    vfprintf(input, error_str, ap);
    fclose(input);
  }
  else
  {
    printf("ERROR Writing ERROR.LOG : %s\n",error_str);
  }
}
