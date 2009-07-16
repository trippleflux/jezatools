VOID GetUStats()
{

	var.ustats.iSection = jScripts_ustats_default_sections;

	if ( atoi(argv[4]) )
	{
		if ( (atoi(argv[4]) > 0) && (atoi(argv[4]) < 10) )
			var.ustats.iSection = atoi(argv[4]);
	}

	FillStats(var.ustats.iSection);
	
	var.ustats.iCount = jScripts_ustats_default_count;
	sprintf(var.ustats.sWhat, "%s", "ALLUP");

	if ( atoi(argv[3]) )
	{
		
		if ( (atoi(argv[3]) > 0) && (atoi(argv[3]) < var.user.TotalUsers) )
			var.ustats.iCount = atoi(argv[3]);
	}

	
	printf(FormatString(jScripts_ustats_out_head, 0));

	if ( strncmp(argv[2], "DAYDN", 5) == 0)
	{

		SortUStats(SORT_DAYDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "DAYDN");

		for (int i = 0; i < var.ustats.iCount ; i++)
			printf(FormatString(jScripts_ustats_out_body_daydn, i));
	
	}
	else if ( strncmp(argv[2], "DAYUP", 5) == 0)
	{

		SortUStats(SORT_DAYUP, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "DAYUP");

		for (int i = 0; i < var.ustats.iCount ; i++)
			printf(FormatString(jScripts_ustats_out_body_dayup, i));
	
	}
	else if ( strncmp(argv[2], "WKDN", 4) == 0)
	{

		SortUStats(SORT_WKDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "WKDN");

		for (int i = 0; i < var.ustats.iCount ; i++)
			printf(FormatString(jScripts_ustats_out_body_wkdn, i));
	
	}
	else if ( strncmp(argv[2], "WKUP", 4) == 0)
	{

		SortUStats(SORT_WKUP, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "WKUP");

		for (int i = 0; i < var.ustats.iCount ; i++)
			printf(FormatString(jScripts_ustats_out_body_wkup, i));
	
	}
	else if ( strncmp(argv[2], "MNDN", 4) == 0)
	{

		SortUStats(SORT_MNDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "MNDN");

		for (int i = 0; i < var.ustats.iCount ; i++)
			printf(FormatString(jScripts_ustats_out_body_mndn, i));
	
	}
	else if ( strncmp(argv[2], "MNUP", 4) == 0)
	{

		SortUStats(SORT_MNUP, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "MNUP");

		for (int i = 0; i < var.ustats.iCount ; i++)
			printf(FormatString(jScripts_ustats_out_body_mnup, i));
	
	}
	else if ( strncmp(argv[2], "ALLDN", 5) == 0)
	{

		SortUStats(SORT_ALLDN, var.user.TotalUsers);
		sprintf(var.ustats.sWhat, "%s", "ALLDN");

		for (int i = 0; i < var.ustats.iCount ; i++)
			printf(FormatString(jScripts_ustats_out_body_alldn, i));
	
	}
	else
	{

		SortUStats(SORT_ALLUP, var.user.TotalUsers);

		for (int i = 0; i < var.ustats.iCount ; i++)
			printf(FormatString(jScripts_ustats_out_body_allup, i));

	}

	
	printf(FormatString(jScripts_ustats_out_foot, 0));

}