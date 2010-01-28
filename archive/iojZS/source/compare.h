//preveri ce se searchstring nahaja v instr (space)
int compare_01 (char *instr, char *searchstr) 
{
  char *result = NULL;
  result = strtok( instr, " " );
  while( result != NULL ) {
    if ( strstr(searchstr,result) )
    {
      return 1;
    }
    result = strtok( NULL, " " );
  }  
  return 0;
}
/*
//preveri ce se searchstring nahaja v instr (,)
int compare_02 (char *instr, char *searchstr) 
{
  char *result = NULL;
  result = strtok( instr, "," );
  while( result != NULL ) {
    if ( strstr(strlwr(searchstr),result) )
    {
      return 1;
    }
    result = strtok( NULL, "," );
  }  
  return 0;
}
*/

//preveri ce se searchstring nahaja v instr (,)
int compare_02 (char *instr, char *searchstr)
{
  
  char* buffer;
  buffer = (char*) malloc(strlen(searchstr)+1);
  strcpy(buffer,searchstr);

  char *result = NULL;
  result = strtok( instr, "," );
  while( result != NULL )
  {
    if ( strstr(strlwr(buffer),result) )
    {
      free(buffer);
      return 1;
    }
    result = strtok( NULL, "," );
  }

  free(buffer);
  return 0;
  
} 

//preveri ce se searchstring nahaja v zacetku instr (space) /xxx/bla -> /xxx/ primerja 5 znakov (strlen("/xxx/"))
int compare_03 (char *instr, char *searchstr) 
{
  char *result = NULL;
  result = strtok( instr, " " );
  while( result != NULL ) {
    if ( strncmp(searchstr,result,strlen(result)) == 0 )
    {
      return 1;
    }
    result = strtok( NULL, " " );
  }  
  return 0;
}

