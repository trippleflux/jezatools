
/*
	Created...: 2005.08.01
	Changed...: 
	By........: Jeza
	Desription: Compare 'InFlag' With 'OutFlag'.
				1LV - ABC = FALSE
				1LV - 1MN = TRUE
*/
BOOL CompareFlags(char InFlag[32 + 1], char OutFlag[32 + 1])
{
	BOOL bFound = false;

	for (unsigned int i=0;i<strlen(InFlag);i++)
	{
		for (unsigned int j=0;j<strlen(OutFlag);j++)
		{
			if ( InFlag[i] == OutFlag[j] )
			{
				bFound = true;
				break;
			}
		}
	}

	if ( bFound )
		return TRUE;
	else
		return FALSE;

}

/*
	Created...: 2005.09.05
	Changed...: 
	By........: Jeza
	Desription: Compare if 'SearchString' is in 'InString'.
				Delimiter	for InString (',' = "jpg,avi")
				bCase		if CaSe SenSiTiVE Search
*/
BOOL CompareStrings(char *InString, char *SearchString, char *Delimiter, BOOL bCaSe)
{
	BOOL bFound = FALSE;

	char *tempIN = (char *)calloc(strlen(InString)+1, sizeof(char));
	char *tempSE = (char *)calloc(strlen(SearchString)+1, sizeof(char));

	sprintf(tempIN, "%s", InString);
	sprintf(tempSE, "%s", SearchString);

	char *result = NULL;
	result = strtok( tempIN, Delimiter );

	while( result != NULL )
	{
		
		if ( bCaSe )
		{
			if ( strncmp(tempSE, result, strlen(result)) == 0 )
			{
				bFound = TRUE;
				break;
			}
		}
		else
		{
			if ( strncmp(strlwr(tempSE), strlwr(result), strlen(result)) == 0 )
			{
				bFound = TRUE;
				break;
			}
		}

		result = strtok( NULL, Delimiter );
	}

	free(tempIN);
	free(tempSE);

	if ( bFound )
		return TRUE;
	else
		return FALSE;

}

/*
	Created...: 2005.09.05
	Changed...: 
	By........: Jeza
	Desription: Compare if 'SearchString' Starts With Any of the 'InString'.
				Delimiter	for InString (',' = "jpg,avi")
				bCase		if CaSe SenSiTiVE Search
				
				CompareStrings Does The Same

BOOL ComparePath(char *InString, char *SearchString, char *Delimiter, BOOL bCaSe)
{
	BOOL bFound = FALSE;

	char *tempIN = (char *)calloc(strlen(InString)+1, sizeof(char));
	char *tempSE = (char *)calloc(strlen(SearchString)+1, sizeof(char));

	sprintf(tempIN, "%s", InString);
	sprintf(tempSE, "%s", SearchString);

	char *result = NULL;
	result = strtok( tempIN, Delimiter );

	while( result != NULL )
	{
		
		if ( bCaSe )
		{
			if ( strncmp(tempSE, result, strlen(result)) == 0 )
			{
				bFound = TRUE;
				break;
			}
		}
		else
		{
			if ( strncmp(strlwr(tempSE), strlwr(result), strlen(result)) == 0 )
			{
				bFound = TRUE;
				break;
			}
		}

		result = strtok( NULL, Delimiter );
	}

	free(tempIN);
	free(tempSE);

	if ( bFound )
		return TRUE;
	else
		return FALSE;

}
*/