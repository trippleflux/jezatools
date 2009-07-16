/*
	Created...: 2005.09.11
	Changed...: 
	By........: Jeza
	Desription: Load ioFTPD ENV Vars.
				Success return TRUE
				else return FALSE
*/
BOOL GetENV()
{
  
	if ( getenv("USER") != NULL )
		strcpy(var.env.user, getenv("USER"));
	else
		strcpy(var.env.user,jScripts_default_user);

	if ( getenv("GROUP") != NULL )
		strcpy(var.env.group, getenv("GROUP"));
	else  
		strcpy(var.env.group,jScripts_default_group);

	if ( getenv("FLAGS") != NULL )
		strcpy(var.env.flags, getenv("FLAGS"));
	else
		strcpy(var.env.flags,jScripts_default_flags);

	if ( getenv("TAGLINE") != NULL )
		var.env.tagline = getenv("TAGLINE");
	else
		var.env.tagline = jScripts_default_tagline;

	if ( getenv("UID") != NULL )
		var.env.uid = atoi(getenv("UID"));
	else
		var.env.uid = jScripts_default_uid;

	if ( getenv("GID") != NULL )
		var.env.gid = atoi(getenv("GID"));
	else
		var.env.gid = jScripts_default_gid;

	if ( getenv("PATH") != NULL )
		var.env.path = getenv("PATH");
	else
		return FALSE;
	    
	if ( getenv("VIRTUALPATH") != NULL )
		var.env.virtualpath = getenv("VIRTUALPATH");
	else
		return FALSE;

	return TRUE;
  
}

/*
	Created...: 2005.09.11
	Changed...: 
	By........: Jeza
	Desription: List ENVIRONMENT Varialbles.
*/
BOOL ListENV()
{
  
	debug(".......: USER        = %s\n",var.env.user);
	debug(".......: GROUP       = %s\n",var.env.group);
	debug(".......: FLAGS       = %s\n",var.env.flags);
	debug(".......: TAGLINE     = %s\n",var.env.tagline);
	debug(".......: UID         = %i\n",var.env.uid);
	debug(".......: GID         = %i\n",var.env.gid);
	debug(".......: PATH        = %s\n",var.env.path);
	debug(".......: VIRTUALPATH = %s\n",var.env.virtualpath);

	return TRUE;
  
}
