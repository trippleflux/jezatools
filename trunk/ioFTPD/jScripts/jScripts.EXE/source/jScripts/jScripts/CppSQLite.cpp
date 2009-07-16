#include "stdafx.h"

static int callback(void *NotUsed, int argc, char **argv, char **azColName){
  printf("argv[0]=%s\n", argv[0]);
	int i;
  for(i=0; i<argc; i++){
    printf("%s = %s\n", azColName[i], argv[i] ? argv[i] : "NULL");
  }
  printf("\n");
  return 0;
}

