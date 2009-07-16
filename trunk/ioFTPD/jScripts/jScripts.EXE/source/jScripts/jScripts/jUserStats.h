/*
	Created...: 2005.09.05
	Changed...: 
	By........: Jeza
	Desription: Sort Users STATS.
				jScripts.exe USTATS ALLUP 10 0
				=> TOP 10 ALLUP Users in Section 0
*/
VOID GetUStats(_TCHAR* argv[])
{

	var.ustats.iSection = jScripts_ustats_default_sections;

	if ( atoi(argv[4]) )
	{
		if ( (atoi(argv[4]) > 0) && (atoi(argv[4]) < 10) )
			var.ustats.iSection = atoi(argv[4]);
	}

	var.ustats.bNoDate = TRUE;

	FillStats(var.ustats.iSection);
	
	var.ustats.bNoDate = FALSE;

	if ( atoi(argv[3]) )
	{
		
		if ( (atoi(argv[3]) > 0) && (atoi(argv[3]) < var.user.TotalUsers) )
			var.ustats.iCount = atoi(argv[3]);
		else if ( (atoi(argv[3]) > var.user.TotalUsers) )
			var.ustats.iCount = var.user.TotalUsers;
		else
			var.ustats.iCount = jScripts_ustats_default_count;

	}

	
	if ( strncmp(strupr(argv[2]), "DAYDN", 5) == 0)
	{

		SortUStats(SORT_DAYDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "DAYDN");

		printf(FormatStr1ng(jScripts_ustats_out_head, 0));

		for (int i = 0; i < var.ustats.iCount ; i++)
			printf(FormatStr1ng(jScripts_ustats_out_body_daydn, i));
	
	}
	else if ( strncmp(strupr(argv[2]), "DAYUP", 5) == 0)
	{

		SortUStats(SORT_DAYUP, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "DAYUP");

		printf(FormatStr1ng(jScripts_ustats_out_head, 0));

		for (int i = 0; i < var.ustats.iCount ; i++)
			printf(FormatStr1ng(jScripts_ustats_out_body_dayup, i));
	
	}
	else if ( strncmp(strupr(argv[2]), "WKDN", 4) == 0)
	{

		SortUStats(SORT_WKDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "WKDN");

		printf(FormatStr1ng(jScripts_ustats_out_head, 0));

		for (int i = 0; i < var.ustats.iCount ; i++)
			printf(FormatStr1ng(jScripts_ustats_out_body_wkdn, i));
	
	}
	else if ( strncmp(strupr(argv[2]), "WKUP", 4) == 0)
	{

		SortUStats(SORT_WKUP, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "WKUP");

		printf(FormatStr1ng(jScripts_ustats_out_head, 0));

		for (int i = 0; i < var.ustats.iCount ; i++)
			printf(FormatStr1ng(jScripts_ustats_out_body_wkup, i));
	
	}
	else if ( strncmp(strupr(argv[2]), "MNDN", 4) == 0)
	{

		SortUStats(SORT_MNDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "MNDN");

		printf(FormatStr1ng(jScripts_ustats_out_head, 0));

		for (int i = 0; i < var.ustats.iCount ; i++)
			printf(FormatStr1ng(jScripts_ustats_out_body_mndn, i));
	
	}
	else if ( strncmp(strupr(argv[2]), "MNUP", 4) == 0)
	{

		SortUStats(SORT_MNUP, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "MNUP");

		printf(FormatStr1ng(jScripts_ustats_out_head, 0));

		for (int i = 0; i < var.ustats.iCount ; i++)
			printf(FormatStr1ng(jScripts_ustats_out_body_mnup, i));
	
	}
	else if ( strncmp(strupr(argv[2]), "ALLDN", 5) == 0)
	{

		sprintf(var.ustats.sWhat, "%s", "ALLDN");
		SortUStats(SORT_ALLDN, var.user.TotalUsers);

		printf(FormatStr1ng(jScripts_ustats_out_head, 0));

		for (int i = 0; i < var.ustats.iCount ; i++)
			printf(FormatStr1ng(jScripts_ustats_out_body_alldn, i));
	
	}
	else
	{

		SortUStats(SORT_ALLUP, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "ALLUP");

		printf(FormatStr1ng(jScripts_ustats_out_head, 0));

		for (int i = 0; i < var.ustats.iCount ; i++)
			printf(FormatStr1ng(jScripts_ustats_out_body_allup, i));

	}

	
	printf(FormatStr1ng(jScripts_ustats_out_foot, 0));

}



/*
	Created...: 2006.03.11
	Changed...: 
	By........: Jeza
	Desription: Sort Groups STATS.
				jScripts.exe GSTATS ALLUP 10 0
				=> TOP 10 ALLUP Groups in Section 0
*/
VOID GetGStats(_TCHAR* argv[])
{

	var.gstats.iSection = jScripts_gstats_default_sections;

	if ( atoi(argv[4]) )
	{
		if ( (atoi(argv[4]) > 0) && (atoi(argv[4]) < 10) )
			var.gstats.iSection = atoi(argv[4]);
	}

	FillGStats(var.gstats.iSection);
	
	if ( atoi(argv[3]) )
	{
		
		if ( (atoi(argv[3]) > 0) && (atoi(argv[3]) < var.gstats.iTotalGroups) )
			var.gstats.iCount = atoi(argv[3]);
		else if ( (atoi(argv[3]) > var.gstats.iTotalGroups) )
			var.gstats.iCount = var.gstats.iTotalGroups;
		else
			var.gstats.iCount = jScripts_gstats_default_count;

	}

	
	if ( strncmp(strupr(argv[2]), "DAYDN", 5) == 0)
	{

		SortGStats(SORT_DAYDN, var.gstats.iTotalGroups);
		sprintf(var.gstats.sWhat, "%s", "DAYDN");

		printf(FormatStr1ng(jScripts_gstats_out_head, 0));

		for (int i = 0; i < var.gstats.iCount ; i++)
			printf(FormatStr1ng(jScripts_gstats_out_body_daydn, i));
	
	}
	else if ( strncmp(strupr(argv[2]), "DAYUP", 5) == 0)
	{

		SortGStats(SORT_DAYUP, var.gstats.iTotalGroups);
		sprintf(var.gstats.sWhat, "%s", "DAYUP");

		printf(FormatStr1ng(jScripts_gstats_out_head, 0));

		for (int i = 0; i < var.gstats.iCount ; i++)
			printf(FormatStr1ng(jScripts_gstats_out_body_dayup, i));
	
	}
	else if ( strncmp(strupr(argv[2]), "WKDN", 4) == 0)
	{

		SortGStats(SORT_WKDN, var.gstats.iTotalGroups);
		sprintf(var.gstats.sWhat, "%s", "WKDN");

		printf(FormatStr1ng(jScripts_gstats_out_head, 0));

		for (int i = 0; i < var.gstats.iCount ; i++)
			printf(FormatStr1ng(jScripts_gstats_out_body_wkdn, i));
	
	}
	else if ( strncmp(strupr(argv[2]), "WKUP", 4) == 0)
	{

		SortGStats(SORT_WKUP, var.gstats.iTotalGroups);
		sprintf(var.gstats.sWhat, "%s", "WKUP");

		printf(FormatStr1ng(jScripts_gstats_out_head, 0));

		for (int i = 0; i < var.gstats.iCount ; i++)
			printf(FormatStr1ng(jScripts_gstats_out_body_wkup, i));
	
	}
	else if ( strncmp(strupr(argv[2]), "MNDN", 4) == 0)
	{

		SortGStats(SORT_MNDN, var.gstats.iTotalGroups);
		sprintf(var.gstats.sWhat, "%s", "MNDN");

		printf(FormatStr1ng(jScripts_gstats_out_head, 0));

		for (int i = 0; i < var.gstats.iCount ; i++)
			printf(FormatStr1ng(jScripts_gstats_out_body_mndn, i));
	
	}
	else if ( strncmp(strupr(argv[2]), "MNUP", 4) == 0)
	{

		SortGStats(SORT_MNUP, var.gstats.iTotalGroups);
		sprintf(var.gstats.sWhat, "%s", "MNUP");

		printf(FormatStr1ng(jScripts_gstats_out_head, 0));

		for (int i = 0; i < var.gstats.iCount ; i++)
			printf(FormatStr1ng(jScripts_gstats_out_body_mnup, i));
	
	}
	else if ( strncmp(strupr(argv[2]), "ALLDN", 5) == 0)
	{

		sprintf(var.gstats.sWhat, "%s", "ALLDN");
		SortGStats(SORT_ALLDN, var.gstats.iTotalGroups);

		printf(FormatStr1ng(jScripts_gstats_out_head, 0));

		for (int i = 0; i < var.gstats.iCount ; i++)
			printf(FormatStr1ng(jScripts_gstats_out_body_alldn, i));
	
	}
	else
	{

		SortGStats(SORT_ALLUP, var.gstats.iTotalGroups);
		sprintf(var.gstats.sWhat, "%s", "ALLUP");

		printf(FormatStr1ng(jScripts_gstats_out_head, 0));

		for (int i = 0; i < var.gstats.iCount ; i++)
			printf(FormatStr1ng(jScripts_gstats_out_body_allup, i));

	}

	printf(FormatStr1ng(jScripts_gstats_out_foot, 0));

}

/*
	Created...: 2005.09.14
	Changed...: 
	By........: Jeza
	Desription: Sort Users STATS.
				jScripts.exe BUSTATS ALLUP 10 0
				=> TOP 10 ALLUP Users in Section 0
				For TRiAL/QUOTA Only
*/
VOID GetBUStats(_TCHAR* argv[])
{

	var.ustats.iSection = jScripts_bustats_default_sections;

	if ( atoi(argv[4]) )
	{
		if ( (atoi(argv[4]) > 0) && (atoi(argv[4]) < 10) )
			var.ustats.iSection = atoi(argv[4]);
	}

	var.ustats.bNoDate = TRUE;

	FillStats(var.ustats.iSection);
	
	var.ustats.bNoDate = FALSE;

	sprintf(var.ustats.sWhat, "%s", "ALLUP");

	if ( atoi(argv[3]) )
	{
		
		if ( (atoi(argv[3]) > 0) && (atoi(argv[3]) < var.user.TotalUsers) )
			var.ustats.iCount = atoi(argv[3]);
		else if ( (atoi(argv[3]) > var.user.TotalUsers) )
			var.ustats.iCount = var.user.TotalUsers;
		else
			var.ustats.iCount = jScripts_bustats_default_count;

	}

	
	if ( strncmp(strupr(argv[2]), "DAYDN", 5) == 0)
	{

		SortUStats(SORT_DAYDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "DAYDN");

		for (int i = 0; i < var.ustats.iCount ; i++)
			printf(FormatStr1ng(jScripts_bustats_out_body_daydn, i));
	
	}
	else if ( strncmp(strupr(argv[2]), "DAYUP", 5) == 0)
	{

		SortUStats(SORT_DAYUP, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "DAYUP");

		for (int i = 0; i < var.ustats.iCount ; i++)
			printf(FormatStr1ng(jScripts_bustats_out_body_dayup, i));
	
	}
	else if ( strncmp(strupr(argv[2]), "WKDN", 4) == 0)
	{

		SortUStats(SORT_WKDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "WKDN");

		for (int i = 0; i < var.ustats.iCount ; i++)
			printf(FormatStr1ng(jScripts_bustats_out_body_wkdn, i));
	
	}
	else if ( strncmp(strupr(argv[2]), "WKUP", 4) == 0)
	{

		SortUStats(SORT_WKUP, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "WKUP");

		for (int i = 0; i < var.ustats.iCount ; i++)
			printf(FormatStr1ng(jScripts_bustats_out_body_wkup, i));
	
	}
	else if ( strncmp(strupr(argv[2]), "MNDN", 4) == 0)
	{

		SortUStats(SORT_MNDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "MNDN");

		for (int i = 0; i < var.ustats.iCount ; i++)
			printf(FormatStr1ng(jScripts_bustats_out_body_mndn, i));
	
	}
	else if ( strncmp(strupr(argv[2]), "MNUP", 4) == 0)
	{

		SortUStats(SORT_MNUP, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "MNUP");

		for (int i = 0; i < var.ustats.iCount ; i++)
			printf(FormatStr1ng(jScripts_bustats_out_body_mnup, i));
	
	}
	else if ( strncmp(strupr(argv[2]), "ALLDN", 5) == 0)
	{

		SortUStats(SORT_ALLDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "ALLDN");

		for (int i = 0; i < var.ustats.iCount ; i++)
			printf(FormatStr1ng(jScripts_bustats_out_body_alldn, i));
	
	}
	else
	{

		SortUStats(SORT_ALLUP, var.user.TotalUsers);

		for (int i = 0; i < var.ustats.iCount ; i++)
			printf(FormatStr1ng(jScripts_bustats_out_body_allup, i));

	}

}

/*
	Created...: 2005.09.05
	Changed...: 
	By........: Jeza
	Desription: Shows Users STATS.
*/
VOID GetBUStatsALL( _TCHAR* argv[] )
{

	var.ustats.iSection = jScripts_ustats_default_sections;

	if ( atoi(argv[2]) )
	{
		if ( (atoi(argv[2]) > 0) && (atoi(argv[2]) < 10) )
			var.ustats.iSection = atoi(argv[2]);
	}

	FillStats(var.ustats.iSection);

	for (int i = 0; i < var.user.TotalUsers ; i++)
		printf(FormatStr1ng(jScripts_bustats_out_body_complete, i));

}

/*
	Created...: 2005.09.20
	Changed...: 
	By........: Jeza
	Desription: Shows Users STATS.
				Shows Only QUOTA USERS.
				jScripts.exe BQUSTATS "GROUP1 GROUP2" "user1 user2" "FLAG1 FLAG2" SECTiON.
				GROUP1, ..., user1, ... , FLAG1, ... Are Not Included
*/
VOID GetBUStatsQuota( _TCHAR* argv[] )
{

	var.ustats.iSection = jScripts_ustats_default_sections;

	if ( atoi(argv[5]) )
	{
		if ( (atoi(argv[5]) > 0) && (atoi(argv[5]) < 10) )
			var.ustats.iSection = atoi(argv[5]);
	}

	//printf("argv[2]=%s\n", argv[2]);
	//printf("argv[3]=%s\n", argv[3]);

	FillStats(var.ustats.iSection);
	
	int j = 1;

	for (int i = 0; i < var.user.TotalUsers ; i++)
	{
		if ( !(CompareStrings(argv[2], var.usertable[i].tGroupName, " ", TRUE)) && 
			 !(CompareStrings(argv[3], var.usertable[i].tUserName, " ", TRUE)) &&
			 !(CompareFlags(argv[4], var.usertable[i].tFlags)) )
		{
			printf("{%i} ", j);
			printf(FormatStr1ng(jScripts_bustats_out_body_quota, i));
			j++;
		}
	}

}


/*
	Created...: 2006.01.15
	Changed...: 
	By........: Jeza
	Desription: Sort Users STATS.
				jScripts.exe DAYTATS "SITEOPS" "Jeza pimpek" "1 M" ALLUP 10 0
				=> TOP 10 ALLUP Users in Section 0
				=> But NOT SITEOP GROUP, Jeza,pimpek or FLAGS 1 OR M
*/
VOID GetDAYStats(_TCHAR* argv[])
{

	var.ustats.iSection = jScripts_bustats_default_sections;

	if ( atoi(argv[7]) )
	{
		if ( (atoi(argv[7]) > 0) && (atoi(argv[7]) < 10) )
			var.ustats.iSection = atoi(argv[7]);
	}

	var.ustats.bNoDate = TRUE;

	FillStats(var.ustats.iSection);
	
	var.ustats.bNoDate = FALSE;

	sprintf(var.ustats.sWhat, "%s", "ALLUP");

	if ( atoi(argv[6]) )
	{
		
		if ( (atoi(argv[6]) > 0) && (atoi(argv[6]) < var.user.TotalUsers) )
			var.ustats.iCount = atoi(argv[6]);
		else if ( (atoi(argv[6]) > var.user.TotalUsers) )
			var.ustats.iCount = var.user.TotalUsers;
		else
			var.ustats.iCount = jScripts_bustats_default_count;

	}
	
	if ( strncmp(strupr(argv[5]), "DAYDN", 5) == 0)
	{

		SortUStats(SORT_DAYDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "DAYDN");

		int j = 0;

		for (int i = 0; ( (i < var.user.TotalUsers) && (j < var.ustats.iCount)) ; i++)
		{
			if ( !(CompareStrings(argv[2], var.usertable[i].tGroupName, " ", TRUE)) && 
 				 !(CompareStrings(argv[3], var.usertable[i].tUserName, " ", TRUE)) &&
				 !(CompareFlags(argv[4], var.usertable[i].tFlags)) )
			{

				printf(FormatStr1ng(jScripts_bustats_out_body_daydn, i));

				j++;

			}
		}
	
	}
	else if ( strncmp(strupr(argv[5]), "DAYUP", 5) == 0)
	{

		SortUStats(SORT_DAYUP, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "DAYUP");

		int j = 0;

		for (int i = 0; ( (i < var.user.TotalUsers) && (j < var.ustats.iCount)) ; i++)
		{
			if ( !(CompareStrings(argv[2], var.usertable[i].tGroupName, " ", TRUE)) && 
 				 !(CompareStrings(argv[3], var.usertable[i].tUserName, " ", TRUE)) &&
				 !(CompareFlags(argv[4], var.usertable[i].tFlags)) )
			{

				printf(FormatStr1ng(jScripts_bustats_out_body_dayup, i));

				j++;

			}
		}
	
	}
	else if ( strncmp(strupr(argv[5]), "WKDN", 4) == 0)
	{

		SortUStats(SORT_WKDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "WKDN");

		int j = 0;

		for (int i = 0; ( (i < var.user.TotalUsers) && (j < var.ustats.iCount)) ; i++)
		{
			if ( !(CompareStrings(argv[2], var.usertable[i].tGroupName, " ", TRUE)) && 
 				 !(CompareStrings(argv[3], var.usertable[i].tUserName, " ", TRUE)) &&
				 !(CompareFlags(argv[4], var.usertable[i].tFlags)) )
			{

				printf(FormatStr1ng(jScripts_bustats_out_body_wkdn, i));

				j++;

			}
		}
	
	}
	else if ( strncmp(strupr(argv[5]), "WKUP", 4) == 0)
	{

		SortUStats(SORT_WKUP, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "WKUP");

		int j = 0;

		for (int i = 0; ( (i < var.user.TotalUsers) && (j < var.ustats.iCount)) ; i++)
		{
			if ( !(CompareStrings(argv[2], var.usertable[i].tGroupName, " ", TRUE)) && 
 				 !(CompareStrings(argv[3], var.usertable[i].tUserName, " ", TRUE)) &&
				 !(CompareFlags(argv[4], var.usertable[i].tFlags)) )
			{

				printf(FormatStr1ng(jScripts_bustats_out_body_wkup, i));

				j++;

			}
		}
	
	}
	else if ( strncmp(strupr(argv[5]), "MNDN", 4) == 0)
	{

		SortUStats(SORT_MNDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "MNDN");

		int j = 0;

		for (int i = 0; ( (i < var.user.TotalUsers) && (j < var.ustats.iCount)) ; i++)
		{
			if ( !(CompareStrings(argv[2], var.usertable[i].tGroupName, " ", TRUE)) && 
 				 !(CompareStrings(argv[3], var.usertable[i].tUserName, " ", TRUE)) &&
				 !(CompareFlags(argv[4], var.usertable[i].tFlags)) )
			{

				printf(FormatStr1ng(jScripts_bustats_out_body_mndn, i));

				j++;

			}
		}
	
	}
	else if ( strncmp(strupr(argv[5]), "MNUP", 4) == 0)
	{

		SortUStats(SORT_MNUP, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "MNUP");

		int j = 0;

		for (int i = 0; ( (i < var.user.TotalUsers) && (j < var.ustats.iCount)) ; i++)
		{
			if ( !(CompareStrings(argv[2], var.usertable[i].tGroupName, " ", TRUE)) && 
 				 !(CompareStrings(argv[3], var.usertable[i].tUserName, " ", TRUE)) &&
				 !(CompareFlags(argv[4], var.usertable[i].tFlags)) )
			{

				printf(FormatStr1ng(jScripts_bustats_out_body_mnup, i));

				j++;

			}
		}
	
	}
	else if ( strncmp(strupr(argv[5]), "ALLDN", 5) == 0)
	{

		SortUStats(SORT_ALLDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "ALLDN");

		int j = 0;

		for (int i = 0; ( (i < var.user.TotalUsers) && (j < var.ustats.iCount)) ; i++)
		{
			if ( !(CompareStrings(argv[2], var.usertable[i].tGroupName, " ", TRUE)) && 
 				 !(CompareStrings(argv[3], var.usertable[i].tUserName, " ", TRUE)) &&
				 !(CompareFlags(argv[4], var.usertable[i].tFlags)) )
			{

				printf(FormatStr1ng(jScripts_bustats_out_body_alldn, i));

				j++;

			}
		}
	
	}
	else
	{

		SortUStats(SORT_ALLUP, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "ALLUP");

		int j = 0;

		for (int i = 0; ( (i < var.user.TotalUsers) && (j < var.ustats.iCount)) ; i++)
		{
			if ( !(CompareStrings(argv[2], var.usertable[i].tGroupName, " ", TRUE)) && 
 				 !(CompareStrings(argv[3], var.usertable[i].tUserName, " ", TRUE)) &&
				 !(CompareFlags(argv[4], var.usertable[i].tFlags)) )
			{

				printf(FormatStr1ng(jScripts_bustats_out_body_allup, i));

				j++;

			}
		}
	
	}

}


/*
	Created...: 2006.01.19
	Changed...: 
	By........: Jeza
	Desription: Get Users STATS POS And MBs.
				jScripts.exe GETSTATS Jeza ALLUP 0
				-> 5 Jeza iND 87545

*/
VOID GetUserStats(_TCHAR* argv[])
{

	var.ustats.iSection = jScripts_bustats_default_sections;

	if ( atoi(argv[4]) )
	{
		if ( (atoi(argv[4]) > 0) && (atoi(argv[4]) < 10) )
			var.ustats.iSection = atoi(argv[4]);
	}

	var.ustats.bNoDate = TRUE;

	FillStats(var.ustats.iSection);
	
	var.ustats.bNoDate = FALSE;

	BOOL bFound = FALSE;

	sprintf(var.ustats.sWhat, "%s", "ALLUP");

	if ( strncmp(strupr(argv[3]), "DAYDN", 5) == 0)
	{

		SortUStats(SORT_DAYDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "DAYDN");

		for (int i = 0; i < var.user.TotalUsers ; i++)
		{
			if ( CompareStrings(argv[2], var.usertable[i].tUserName, " ", TRUE) )
			{

				printf(FormatStr1ng(jScripts_bustats_out_body_daydn, i));
				
				bFound = TRUE;

				break;

			}
		}
	
	}
	else if ( strncmp(strupr(argv[3]), "DAYUP", 5) == 0)
	{

		SortUStats(SORT_DAYUP, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "DAYUP");

		for (int i = 0; i < var.user.TotalUsers ; i++)
		{
			if ( CompareStrings(argv[2], var.usertable[i].tUserName, " ", TRUE) )
			{

				printf(FormatStr1ng(jScripts_bustats_out_body_dayup, i));

				bFound = TRUE;

				break;

			}
		}
	
	}
	else if ( strncmp(strupr(argv[3]), "WKDN", 4) == 0)
	{

		SortUStats(SORT_WKDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "WKDN");

		for (int i = 0; i < var.user.TotalUsers ; i++)
		{
			if ( CompareStrings(argv[2], var.usertable[i].tUserName, " ", TRUE) )
			{

				printf(FormatStr1ng(jScripts_bustats_out_body_wkdn, i));

				bFound = TRUE;

				break;

			}
		}
	
	}
	else if ( strncmp(strupr(argv[3]), "WKUP", 4) == 0)
	{

		SortUStats(SORT_WKUP, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "WKUP");

		for (int i = 0; i < var.user.TotalUsers ; i++)
		{
			if ( CompareStrings(argv[2], var.usertable[i].tUserName, " ", TRUE) )
			{

				printf(FormatStr1ng(jScripts_bustats_out_body_wkup, i));

				bFound = TRUE;

				break;

			}
		}
	
	}
	else if ( strncmp(strupr(argv[3]), "MNDN", 4) == 0)
	{

		SortUStats(SORT_MNDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "MNDN");

		for (int i = 0; i < var.user.TotalUsers ; i++)
		{
			if ( CompareStrings(argv[2], var.usertable[i].tUserName, " ", TRUE) )
			{

				printf(FormatStr1ng(jScripts_bustats_out_body_mndn, i));

				bFound = TRUE;

				break;

			}
		}
	
	}
	else if ( strncmp(strupr(argv[3]), "MNUP", 4) == 0)
	{

		SortUStats(SORT_MNUP, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "MNUP");

		for (int i = 0; i < var.user.TotalUsers ; i++)
		{
			if ( CompareStrings(argv[2], var.usertable[i].tUserName, " ", TRUE) )
			{

				printf(FormatStr1ng(jScripts_bustats_out_body_mnup, i));

				bFound = TRUE;

				break;

			}
		}
	
	}
	else if ( strncmp(strupr(argv[3]), "ALLDN", 5) == 0)
	{

		SortUStats(SORT_ALLDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "ALLDN");

		for (int i = 0; i < var.user.TotalUsers ; i++)
		{
			if ( CompareStrings(argv[2], var.usertable[i].tUserName, " ", TRUE) )
			{

				printf(FormatStr1ng(jScripts_bustats_out_body_alldn, i));

				bFound = TRUE;

				break;

			}
		}
	
	}
	else
	{

		SortUStats(SORT_ALLUP, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "ALLUP");

		for (int i = 0; i < var.user.TotalUsers ; i++)
		{
			if ( CompareStrings(argv[2], var.usertable[i].tUserName, " ", TRUE) )
			{

				printf(FormatStr1ng(jScripts_bustats_out_body_allup, i));

				bFound = TRUE;

				break;

			}
		}
	
	}
}

/*
	Created...: 2006.02.25
	Changed...: 
	By........: Jeza
	Desription: Get Users RANK POS UserName GroupName MBs Files Speed.
				jScripts.exe SHOWUSERSRANK Jeza ALLUP 0

				-> 1 Jeza1 iND1 87545 123 2
				-> 2 Jeza2 iND2 87545 123 2
				-> 3 Jeza3 iND3 87545 123 2

*/
VOID ShowUsersRank( _TCHAR* argv[] )
{

	var.ustats.iSection = jScripts_bustats_default_sections;

	if ( atoi(argv[4]) )
	{
		if ( (atoi(argv[4]) > 0) && (atoi(argv[4]) < 10) )
			var.ustats.iSection = atoi(argv[4]);
	}

	var.ustats.bNoDate = TRUE;

	FillStats(var.ustats.iSection);
	
	var.ustats.bNoDate = FALSE;

	BOOL bFound = FALSE;

	sprintf(var.ustats.sWhat, "%s", "ALLUP");

	if ( strncmp(strupr(argv[3]), "DAYDN", 5) == 0)
	{

		SortUStats(SORT_DAYDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "DAYDN");

		for (int i = 0; i < var.user.TotalUsers ; i++)
		{
			if ( CompareStrings(argv[2], var.usertable[i].tUserName, " ", TRUE) )
			{

				if ( i == 0 )
				{

					printf(FormatStr1ng(jScripts_bustats_out_body_daydn, i));
					printf(FormatStr1ng(jScripts_bustats_out_body_daydn, (i+1)));
					printf(FormatStr1ng(jScripts_bustats_out_body_daydn, (i+2)));

				}
				else if ( var.user.TotalUsers - i == 1 )
				{
					
					printf(FormatStr1ng(jScripts_bustats_out_body_daydn, (i-2)));
					printf(FormatStr1ng(jScripts_bustats_out_body_daydn, (i-1)));
					printf(FormatStr1ng(jScripts_bustats_out_body_daydn, i));

				}
				else
				{

					printf(FormatStr1ng(jScripts_bustats_out_body_daydn, (i-1)));
					printf(FormatStr1ng(jScripts_bustats_out_body_daydn, i));
					printf(FormatStr1ng(jScripts_bustats_out_body_daydn, (i+1)));
					
				}
				
				bFound = TRUE;

				break;

			}
		}
	
	}
	else if ( strncmp(strupr(argv[3]), "DAYUP", 5) == 0)
	{

		SortUStats(SORT_DAYUP, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "DAYUP");

		for (int i = 0; i < var.user.TotalUsers ; i++)
		{
			if ( CompareStrings(argv[2], var.usertable[i].tUserName, " ", TRUE) )
			{

				if ( i == 0 )
				{

					printf(FormatStr1ng(jScripts_bustats_out_body_dayup, i));
					printf(FormatStr1ng(jScripts_bustats_out_body_dayup, (i+1)));
					printf(FormatStr1ng(jScripts_bustats_out_body_dayup, (i+2)));

				}
				else if ( var.user.TotalUsers - i == 1 )
				{
					
					printf(FormatStr1ng(jScripts_bustats_out_body_dayup, (i-2)));
					printf(FormatStr1ng(jScripts_bustats_out_body_dayup, (i-1)));
					printf(FormatStr1ng(jScripts_bustats_out_body_dayup, i));

				}
				else
				{

					printf(FormatStr1ng(jScripts_bustats_out_body_dayup, (i-1)));
					printf(FormatStr1ng(jScripts_bustats_out_body_dayup, i));
					printf(FormatStr1ng(jScripts_bustats_out_body_dayup, (i+1)));
					
				}
				

				bFound = TRUE;

				break;

			}
		}
	
	}
	else if ( strncmp(strupr(argv[3]), "WKDN", 4) == 0)
	{

		SortUStats(SORT_WKDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "WKDN");

		for (int i = 0; i < var.user.TotalUsers ; i++)
		{
			if ( CompareStrings(argv[2], var.usertable[i].tUserName, " ", TRUE) )
			{

				if ( i == 0 )
				{

					printf(FormatStr1ng(jScripts_bustats_out_body_wkdn, i));
					printf(FormatStr1ng(jScripts_bustats_out_body_wkdn, (i+1)));
					printf(FormatStr1ng(jScripts_bustats_out_body_wkdn, (i+2)));

				}
				else if ( var.user.TotalUsers - i == 1 )
				{
					
					printf(FormatStr1ng(jScripts_bustats_out_body_wkdn, (i-2)));
					printf(FormatStr1ng(jScripts_bustats_out_body_wkdn, (i-1)));
					printf(FormatStr1ng(jScripts_bustats_out_body_wkdn, i));

				}
				else
				{

					printf(FormatStr1ng(jScripts_bustats_out_body_wkdn, (i-1)));
					printf(FormatStr1ng(jScripts_bustats_out_body_wkdn, i));
					printf(FormatStr1ng(jScripts_bustats_out_body_wkdn, (i+1)));
					
				}
				
				bFound = TRUE;

				break;

			}
		}
	
	}
	else if ( strncmp(strupr(argv[3]), "WKUP", 4) == 0)
	{

		SortUStats(SORT_WKUP, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "WKUP");

		for (int i = 0; i < var.user.TotalUsers ; i++)
		{
			if ( CompareStrings(argv[2], var.usertable[i].tUserName, " ", TRUE) )
			{

				if ( i == 0 )
				{

					printf(FormatStr1ng(jScripts_bustats_out_body_wkup, i));
					printf(FormatStr1ng(jScripts_bustats_out_body_wkup, (i+1)));
					printf(FormatStr1ng(jScripts_bustats_out_body_wkup, (i+2)));

				}
				else if ( var.user.TotalUsers - i == 1 )
				{
					
					printf(FormatStr1ng(jScripts_bustats_out_body_wkup, (i-2)));
					printf(FormatStr1ng(jScripts_bustats_out_body_wkup, (i-1)));
					printf(FormatStr1ng(jScripts_bustats_out_body_wkup, i));

				}
				else
				{

					printf(FormatStr1ng(jScripts_bustats_out_body_wkup, (i-1)));
					printf(FormatStr1ng(jScripts_bustats_out_body_wkup, i));
					printf(FormatStr1ng(jScripts_bustats_out_body_wkup, (i+1)));
					
				}
				
				bFound = TRUE;

				break;

			}
		}
	
	}
	else if ( strncmp(strupr(argv[3]), "MNDN", 4) == 0)
	{

		SortUStats(SORT_MNDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "MNDN");

		for (int i = 0; i < var.user.TotalUsers ; i++)
		{
			if ( CompareStrings(argv[2], var.usertable[i].tUserName, " ", TRUE) )
			{

				if ( i == 0 )
				{

					printf(FormatStr1ng(jScripts_bustats_out_body_mndn, i));
					printf(FormatStr1ng(jScripts_bustats_out_body_mndn, (i+1)));
					printf(FormatStr1ng(jScripts_bustats_out_body_mndn, (i+2)));

				}
				else if ( var.user.TotalUsers - i == 1 )
				{
					
					printf(FormatStr1ng(jScripts_bustats_out_body_mndn, (i-2)));
					printf(FormatStr1ng(jScripts_bustats_out_body_mndn, (i-1)));
					printf(FormatStr1ng(jScripts_bustats_out_body_mndn, i));

				}
				else
				{

					printf(FormatStr1ng(jScripts_bustats_out_body_mndn, (i-1)));
					printf(FormatStr1ng(jScripts_bustats_out_body_mndn, i));
					printf(FormatStr1ng(jScripts_bustats_out_body_mndn, (i+1)));
					
				}
				
				bFound = TRUE;

				break;

			}
		}
	
	}
	else if ( strncmp(strupr(argv[3]), "MNUP", 4) == 0)
	{

		SortUStats(SORT_MNUP, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "MNUP");

		for (int i = 0; i < var.user.TotalUsers ; i++)
		{
			if ( CompareStrings(argv[2], var.usertable[i].tUserName, " ", TRUE) )
			{

				if ( i == 0 )
				{

					printf(FormatStr1ng(jScripts_bustats_out_body_mnup, i));
					printf(FormatStr1ng(jScripts_bustats_out_body_mnup, (i+1)));
					printf(FormatStr1ng(jScripts_bustats_out_body_mnup, (i+2)));

				}
				else if ( var.user.TotalUsers - i == 1 )
				{
					
					printf(FormatStr1ng(jScripts_bustats_out_body_mnup, (i-2)));
					printf(FormatStr1ng(jScripts_bustats_out_body_mnup, (i-1)));
					printf(FormatStr1ng(jScripts_bustats_out_body_mnup, i));

				}
				else
				{

					printf(FormatStr1ng(jScripts_bustats_out_body_mnup, (i-1)));
					printf(FormatStr1ng(jScripts_bustats_out_body_mnup, i));
					printf(FormatStr1ng(jScripts_bustats_out_body_mnup, (i+1)));
					
				}
				
				bFound = TRUE;

				break;

			}
		}
	
	}
	else if ( strncmp(strupr(argv[3]), "ALLDN", 5) == 0)
	{

		SortUStats(SORT_ALLDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "ALLDN");

		for (int i = 0; i < var.user.TotalUsers ; i++)
		{
			if ( CompareStrings(argv[2], var.usertable[i].tUserName, " ", TRUE) )
			{

				if ( i == 0 )
				{

					printf(FormatStr1ng(jScripts_bustats_out_body_alldn, i));
					printf(FormatStr1ng(jScripts_bustats_out_body_alldn, (i+1)));
					printf(FormatStr1ng(jScripts_bustats_out_body_alldn, (i+2)));

				}
				else if ( var.user.TotalUsers - i == 1 )
				{
					
					printf(FormatStr1ng(jScripts_bustats_out_body_alldn, (i-2)));
					printf(FormatStr1ng(jScripts_bustats_out_body_alldn, (i-1)));
					printf(FormatStr1ng(jScripts_bustats_out_body_alldn, i));

				}
				else
				{

					printf(FormatStr1ng(jScripts_bustats_out_body_alldn, (i-1)));
					printf(FormatStr1ng(jScripts_bustats_out_body_alldn, i));
					printf(FormatStr1ng(jScripts_bustats_out_body_alldn, (i+1)));
					
				}
				
				bFound = TRUE;

				break;

			}
		}
	
	}
	else
	{

		SortUStats(SORT_ALLUP, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "ALLUP");

		for (int i = 0; i < var.user.TotalUsers ; i++)
		{
			if ( CompareStrings(argv[2], var.usertable[i].tUserName, " ", TRUE) )
			{

				if ( i == 0 )
				{

					printf(FormatStr1ng(jScripts_bustats_out_body_allup, i));
					printf(FormatStr1ng(jScripts_bustats_out_body_allup, (i+1)));
					printf(FormatStr1ng(jScripts_bustats_out_body_allup, (i+2)));

				}
				else if ( var.user.TotalUsers - i == 1 )
				{
					
					printf(FormatStr1ng(jScripts_bustats_out_body_allup, (i-2)));
					printf(FormatStr1ng(jScripts_bustats_out_body_allup, (i-1)));
					printf(FormatStr1ng(jScripts_bustats_out_body_allup, i));

				}
				else
				{

					printf(FormatStr1ng(jScripts_bustats_out_body_allup, (i-1)));
					printf(FormatStr1ng(jScripts_bustats_out_body_allup, i));
					printf(FormatStr1ng(jScripts_bustats_out_body_allup, (i+1)));
					
				}
				
				bFound = TRUE;

				break;

			}
		}
	
	}

}

/*
	Created...: 2006.06.03
	Changed...: 
	By........: Jeza
	Desription: Get Users RANK(all/mn/wk/day) MBs GROUPNAME FLAGS CREDiTS in SECTiON.
				jScripts.exe GETUSERPOSANDSTATS Jeza 0
				alluprank allupmb alldnrank alldnmb... 
				-> 5 Jeza iND 87545

*/
VOID GetUserPosAndStats(_TCHAR UserName[USERNAME_LENGTH], INT iSection)
{

	var.ustats.iSection = jScripts_uposstats_default_section;

	if ( (iSection > 0) && (iSection < 10) )
		var.ustats.iSection = iSection;

	if ( ResolveUserNameToUid(UserName) > -1 )
	{
		FillStats(var.ustats.iSection);

		SortUStats(SORT_ALLUP, var.user.TotalUsers);
		SortUStats(SORT_ALLDN, var.user.TotalUsers);
		SortUStats(SORT_MNUP, var.user.TotalUsers);
		SortUStats(SORT_MNDN, var.user.TotalUsers);
		SortUStats(SORT_WKUP, var.user.TotalUsers);
		SortUStats(SORT_WKDN, var.user.TotalUsers);
		SortUStats(SORT_DAYUP, var.user.TotalUsers);
		SortUStats(SORT_DAYDN, var.user.TotalUsers);

		for (int i = 0; i < var.user.TotalUsers ; i++)
		{
			if ( CompareStrings(UserName, var.usertable[i].tUserName, " ", TRUE) )
			{
				sqlite3 *db;
				CHAR *zErrMsg = 0;
				INT rc;
				CHAR buff[256];
					
				sqlite3_open(jScripts_default_user_db, &db);
				sprintf(buff, "SELECT LastLogin FROM USERS WHERE UserName = '%s'", UserName);
				debug(".......: %s\n", buff);
				var.sql.bLastSeen = TRUE;
				rc = sqlite3_exec(db, buff, callback, 0, &zErrMsg);
				var.sql.bLastSeen = FALSE;
				sqlite3_close(db);

				printf(FormatStr1ng(jScripts_uposstats_out_body_complete, i));
				break;
			}
		}
	}
	else
	{
		printf("-");
	}
}

/*
	Created...: 2006.06.03
	Changed...: 
	By........: Jeza
	Desription: Get Users RANK(all/mn/wk/day) MBs GROUPNAME FLAGS CREDiTS in SECTiON.
				jScripts.exe GETUSERPOSANDSTATS Jeza 0
				alluprank allupmb alldnrank alldnmb... 

*/
VOID GetUserPosAndStatsAll(INT iSection)
{

	var.ustats.iSection = jScripts_uposstats_default_section;

	if ( (iSection > 0) && (iSection < 10) )
		var.ustats.iSection = iSection;

	FillStats(var.ustats.iSection);

	SortUStats(SORT_ALLUP, var.user.TotalUsers);
	SortUStats(SORT_ALLDN, var.user.TotalUsers);
	SortUStats(SORT_MNDN, var.user.TotalUsers);
	SortUStats(SORT_WKUP, var.user.TotalUsers);
	SortUStats(SORT_WKDN, var.user.TotalUsers);
	SortUStats(SORT_DAYUP, var.user.TotalUsers);
	SortUStats(SORT_DAYDN, var.user.TotalUsers);
	SortUStats(SORT_MNUP, var.user.TotalUsers);

	for (int i = 0; i < var.user.TotalUsers ; i++)
	{
		printf(FormatStr1ng(jScripts_uposstats_all_complete, i));
	}
}

/*
	Created...: 2006.06.04
	Changed...: 
	By........: Jeza
	Desription: Get Groups STATS POS and MBs.
				jScripts.exe POSGALLSTATS GroupName 0
*/
VOID GetGroupPosAndStats(_TCHAR GroupName[GROUPNAME_LENGTH], INT iSection)
{

	var.gstats.iSection = jScripts_gposstats_default_section;

	if ( (iSection > 0) && (iSection < 10) )
		var.gstats.iSection = iSection;

	if ( ResolveGroupNameToGid(GroupName) > -1 )
	{
		FillGStats(var.gstats.iSection);

		SortGStats(SORT_ALLUP, var.gstats.iTotalGroups);
		SortGStats(SORT_ALLDN, var.gstats.iTotalGroups);
		SortGStats(SORT_MNUP, var.gstats.iTotalGroups);
		SortGStats(SORT_MNDN, var.gstats.iTotalGroups);
		SortGStats(SORT_WKUP, var.gstats.iTotalGroups);
		SortGStats(SORT_WKDN, var.gstats.iTotalGroups);
		SortGStats(SORT_DAYUP, var.gstats.iTotalGroups);
		SortGStats(SORT_DAYDN, var.gstats.iTotalGroups);

		for (int i = 0; i < var.gstats.iTotalGroups ; i++)
		{
			if ( CompareStrings(GroupName, var.grouptable[i].tGroupName, " ", TRUE) )
			{
				printf(FormatStr1ng(jScripts_gposstats_out_body_complete, i));
				break;
			}
		}
	}
	else
	{
		printf("-");
	}

}


/*
	Created...: 2006.07.06
	Changed...: 
	By........: Jeza
	Desription: Shows TOP x Groups.
				jScripts.exe GDAYTATS "SITEOPS" ALLUP 10 0
				=> TOP 10 ALLUP Groups in Section 0
				=> But NOT SITEOP GROUP
*/
VOID GetGDAYStats(_TCHAR* argv[])
{

	var.ustats.iSection = jScripts_bustats_default_sections;

	if ( atoi(argv[7]) )
	{
		if ( (atoi(argv[7]) > 0) && (atoi(argv[7]) < 10) )
			var.ustats.iSection = atoi(argv[7]);
	}

	var.ustats.bNoDate = TRUE;

	FillStats(var.ustats.iSection);
	
	var.ustats.bNoDate = FALSE;

	sprintf(var.ustats.sWhat, "%s", "ALLUP");

	if ( atoi(argv[6]) )
	{
		
		if ( (atoi(argv[6]) > 0) && (atoi(argv[6]) < var.user.TotalUsers) )
			var.ustats.iCount = atoi(argv[6]);
		else if ( (atoi(argv[6]) > var.user.TotalUsers) )
			var.ustats.iCount = var.user.TotalUsers;
		else
			var.ustats.iCount = jScripts_bustats_default_count;

	}
	
	if ( strncmp(strupr(argv[5]), "DAYDN", 5) == 0)
	{

		SortUStats(SORT_DAYDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "DAYDN");

		int j = 0;

		for (int i = 0; ( (i < var.user.TotalUsers) && (j < var.ustats.iCount)) ; i++)
		{
			if ( !(CompareStrings(argv[2], var.usertable[i].tGroupName, " ", TRUE)) && 
 				 !(CompareStrings(argv[3], var.usertable[i].tUserName, " ", TRUE)) &&
				 !(CompareFlags(argv[4], var.usertable[i].tFlags)) )
			{

				printf(FormatStr1ng(jScripts_bustats_out_body_daydn, i));

				j++;

			}
		}
	
	}
	else if ( strncmp(strupr(argv[5]), "DAYUP", 5) == 0)
	{

		SortUStats(SORT_DAYUP, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "DAYUP");

		int j = 0;

		for (int i = 0; ( (i < var.user.TotalUsers) && (j < var.ustats.iCount)) ; i++)
		{
			if ( !(CompareStrings(argv[2], var.usertable[i].tGroupName, " ", TRUE)) && 
 				 !(CompareStrings(argv[3], var.usertable[i].tUserName, " ", TRUE)) &&
				 !(CompareFlags(argv[4], var.usertable[i].tFlags)) )
			{

				printf(FormatStr1ng(jScripts_bustats_out_body_dayup, i));

				j++;

			}
		}
	
	}
	else if ( strncmp(strupr(argv[5]), "WKDN", 4) == 0)
	{

		SortUStats(SORT_WKDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "WKDN");

		int j = 0;

		for (int i = 0; ( (i < var.user.TotalUsers) && (j < var.ustats.iCount)) ; i++)
		{
			if ( !(CompareStrings(argv[2], var.usertable[i].tGroupName, " ", TRUE)) && 
 				 !(CompareStrings(argv[3], var.usertable[i].tUserName, " ", TRUE)) &&
				 !(CompareFlags(argv[4], var.usertable[i].tFlags)) )
			{

				printf(FormatStr1ng(jScripts_bustats_out_body_wkdn, i));

				j++;

			}
		}
	
	}
	else if ( strncmp(strupr(argv[5]), "WKUP", 4) == 0)
	{

		SortUStats(SORT_WKUP, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "WKUP");

		int j = 0;

		for (int i = 0; ( (i < var.user.TotalUsers) && (j < var.ustats.iCount)) ; i++)
		{
			if ( !(CompareStrings(argv[2], var.usertable[i].tGroupName, " ", TRUE)) && 
 				 !(CompareStrings(argv[3], var.usertable[i].tUserName, " ", TRUE)) &&
				 !(CompareFlags(argv[4], var.usertable[i].tFlags)) )
			{

				printf(FormatStr1ng(jScripts_bustats_out_body_wkup, i));

				j++;

			}
		}
	
	}
	else if ( strncmp(strupr(argv[5]), "MNDN", 4) == 0)
	{

		SortUStats(SORT_MNDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "MNDN");

		int j = 0;

		for (int i = 0; ( (i < var.user.TotalUsers) && (j < var.ustats.iCount)) ; i++)
		{
			if ( !(CompareStrings(argv[2], var.usertable[i].tGroupName, " ", TRUE)) && 
 				 !(CompareStrings(argv[3], var.usertable[i].tUserName, " ", TRUE)) &&
				 !(CompareFlags(argv[4], var.usertable[i].tFlags)) )
			{

				printf(FormatStr1ng(jScripts_bustats_out_body_mndn, i));

				j++;

			}
		}
	
	}
	else if ( strncmp(strupr(argv[5]), "MNUP", 4) == 0)
	{

		SortUStats(SORT_MNUP, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "MNUP");

		int j = 0;

		for (int i = 0; ( (i < var.user.TotalUsers) && (j < var.ustats.iCount)) ; i++)
		{
			if ( !(CompareStrings(argv[2], var.usertable[i].tGroupName, " ", TRUE)) && 
 				 !(CompareStrings(argv[3], var.usertable[i].tUserName, " ", TRUE)) &&
				 !(CompareFlags(argv[4], var.usertable[i].tFlags)) )
			{

				printf(FormatStr1ng(jScripts_bustats_out_body_mnup, i));

				j++;

			}
		}
	
	}
	else if ( strncmp(strupr(argv[5]), "ALLDN", 5) == 0)
	{

		SortUStats(SORT_ALLDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "ALLDN");

		int j = 0;

		for (int i = 0; ( (i < var.user.TotalUsers) && (j < var.ustats.iCount)) ; i++)
		{
			if ( !(CompareStrings(argv[2], var.usertable[i].tGroupName, " ", TRUE)) && 
 				 !(CompareStrings(argv[3], var.usertable[i].tUserName, " ", TRUE)) &&
				 !(CompareFlags(argv[4], var.usertable[i].tFlags)) )
			{

				printf(FormatStr1ng(jScripts_bustats_out_body_alldn, i));

				j++;

			}
		}
	
	}
	else
	{

		SortUStats(SORT_ALLUP, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "ALLUP");

		int j = 0;

		for (int i = 0; ( (i < var.user.TotalUsers) && (j < var.ustats.iCount)) ; i++)
		{
			if ( !(CompareStrings(argv[2], var.usertable[i].tGroupName, " ", TRUE)) && 
 				 !(CompareStrings(argv[3], var.usertable[i].tUserName, " ", TRUE)) &&
				 !(CompareFlags(argv[4], var.usertable[i].tFlags)) )
			{

				printf(FormatStr1ng(jScripts_bustats_out_body_allup, i));

				j++;

			}
		}
	
	}

}
