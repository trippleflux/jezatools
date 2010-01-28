#define BUFFER				1024
#define READLINE			128
#define SPLITSIZE			16

#define BUFSIZE				65536
#define DUPEBUFF			1024

//#define MAX_PATH			256			//max path length
#define MAX_FILE			256			//max file length

#define USERNAME_LENGTH		64
#define GROUPNAME_LENGTH	64

#define MAXUSERS			1024		//max number of users
#define MAXGROUPS			1024		//max number of groups

#define INFO_BUFFER_SIZE	32767

char	sSplit[USERNAME_LENGTH];
char	sR[10];
char	ttime[10];

char OUTPUT[2048];

/*SORT METHOD*/
#define SORT_ALLUP	0
#define SORT_ALLDN	1
#define SORT_MNUP	2
#define SORT_MNDN	3
#define SORT_WKUP	4
#define SORT_WKDN	5
#define SORT_DAYUP	6
#define SORT_DAYDN	7
/*SORT METHOD*/

/*WHO*/
#define WHO_NORMAL	0
#define WHO_BOT		1
#define WHO_BW		2
#define WHO_IDLE	3
#define WHO_DN		4
#define WHO_UP		5
#define WHO_SPEED	6
/*WHO*/


struct stat stat_p;					//fileinfo

struct _jWHO
{
	int				iIDLE;
	int				iUP;
	int				iDN;
	DWORD			dwUP;
	DWORD			dwDN;
	DWORD			dwSpeed;
	char			UserName[USERNAME_LENGTH];
	char			GroupName[USERNAME_LENGTH];
	char			VirtualPath[MAX_PATH];
	char			VirtualDataPath[MAX_PATH];
	char			RealDataPath[MAX_PATH];
	char			Action[1024];
	char			*FileName;	//[MAXFILE]
	unsigned long	FileSize;
	INT64			totalBytesTransfered;
	DWORD			IdleTime;
	time_t			LoginTime;	
	char			SpeedUser[USERNAME_LENGTH];
};

struct _USER
{
	char			flags[32 + 1];
	char			UserName[USERNAME_LENGTH];
	char			GroupName[USERNAME_LENGTH];
	BOOL			bFlags;				//flags for WHO
	BOOL			bUser;				//power user
	BOOL			bGroup;				//power group
	BOOL			bMEUser;			//own username
	//BOOL			bMEGroup;			//own group
	BOOL			bHUser;				//hide user
	BOOL			bHGroup;			//hide group
	BOOL			bHPath;				//hide path
	int				TotalUsers;
	char			ip[_IP_LINE_LENGTH + 1];
	char			AddedDate[10];
	char			LastSeen[10];
	char			Master[USERNAME_LENGTH];
	char			Show[USERNAME_LENGTH];
	char			User[USERNAME_LENGTH];

};

struct _ENV
{
  char 				*path;
  char 				*virtualpath;
  char 				user[USERNAME_LENGTH];
  char 				group[GROUPNAME_LENGTH];
  char				*tagline;
  char				flags[32 + 1];
  int				uid;
  int				gid;
};

struct _USERTABLE
{
	int				tUid;
	char			tUserName[USERNAME_LENGTH];
	char 			tGroupName[GROUPNAME_LENGTH];
	INT				tGid;
	char			tFlags[32 + 1];
	INT64			tCredits;
	
	INT64			tAllUP;
	INT64			tAllDN;
	INT64			tMnUP;
	INT64			tMnDN;
	INT64			tWkUP;
	INT64			tWkDN;
	INT64			tDayUP;
	INT64			tDayDN;
	
	INT64			tAllUPf;
	INT64			tAllDNf;
	INT64			tMnUPf;
	INT64			tMnDNf;
	INT64			tWkUPf;
	INT64			tWkDNf;
	INT64			tDayUPf;
	INT64			tDayDNf;
	
	INT64			tAllUPs;
	INT64			tAllDNs;
	INT64			tMnUPs;
	INT64			tMnDNs;
	INT64			tWkUPs;
	INT64			tWkDNs;
	INT64			tDayUPs;
	INT64			tDayDNs;
	
	char			DateAddedLine[USERNAME_LENGTH+1+19];
	char			DateAddedTime[20];
	char			LastSeen[20];
	INT				AdminGroups[MAX_GROUPS];			// Admin for these groups
	INT				Groups[MAX_GROUPS];					// List of groups
	INT				ACount;
	INT				GCount;

	INT				tAllUPPos;
	INT				tAllDNPos;
	INT				tMnUPPos;
	INT				tMnDNPos;
	INT				tWkUPPos;
	INT				tWkDNPos;
	INT				tDayUPPos;
	INT				tDayDNPos;

};

struct _GROUPTABLE
{
	char 			tGroupName[GROUPNAME_LENGTH];
	INT				tGid;
	INT64			tCredits;
	INT				tTotalUsersInGroup;
	
	INT64			tAllUP;
	INT64			tAllDN;
	INT64			tMnUP;
	INT64			tMnDN;
	INT64			tWkUP;
	INT64			tWkDN;
	INT64			tDayUP;
	INT64			tDayDN;
	
	INT64			tAllUPf;
	INT64			tAllDNf;
	INT64			tMnUPf;
	INT64			tMnDNf;
	INT64			tWkUPf;
	INT64			tWkDNf;
	INT64			tDayUPf;
	INT64			tDayDNf;
	
	INT64			tAllUPs;
	INT64			tAllDNs;
	INT64			tMnUPs;
	INT64			tMnDNs;
	INT64			tWkUPs;
	INT64			tWkDNs;
	INT64			tDayUPs;
	INT64			tDayDNs;
	
	INT				tAllUPPos;
	INT				tAllDNPos;
	INT				tMnUPPos;
	INT				tMnDNPos;
	INT				tWkUPPos;
	INT				tWkDNPos;
	INT				tDayUPPos;
	INT				tDayDNPos;

};

struct _USTATS
{
	int				iCount;
	char			sWhat[5];
	short			iSection;
	BOOL			bNoDate;							//TRUE if date added is not needed
};

struct _GSTATS
{
	int				iCount;
	char			sWhat[5];
	short			iSection;
	INT				iTotalGroups;
};

struct _SITECOMMANDS
{
	char 			invite_ircnick[USERNAME_LENGTH];
};
/*
struct _USERINFO
{
	INT				Uid;								// User id
	INT				Gid;								// User group id
	CHAR			Tagline[128 + 1];					// Info line
	CHAR			MountFile[_MAX_PATH + 1];			// Root directory
	CHAR			Home[_MAX_PATH + 1];				// Home directory
	CHAR			Flags[32 + 1];						// Flags
	INT				Limits[5];							//	Up max speed, dn max speed, ftp logins, telnet, http
	UCHAR			Password[20];						// Password
	INT				Ratio[MAX_SECTIONS];				// Ratio
	INT64			Credits[MAX_SECTIONS];				// Credits
	INT64			DayUp[MAX_SECTIONS * 3];			// Daily uploads
	INT64			DayDn[MAX_SECTIONS * 3];			// Daily downloads
	INT64			WkUp[MAX_SECTIONS * 3];				// Weekly uploads
	INT64			WkDn[MAX_SECTIONS * 3];				// Weekly downloads
	INT64			MonthUp[MAX_SECTIONS * 3];			// Monthly uploads
	INT64			MonthDn[MAX_SECTIONS * 3];			// Monthly downloads
	INT64			AllUp[MAX_SECTIONS * 3];			// Alltime uploads
	INT64			AllDn[MAX_SECTIONS * 3];			// Alltime downloads
	INT				AdminGroups[MAX_GROUPS];			// Admin for these groups
	INT				Groups[MAX_GROUPS];					// List of groups
	CHAR			Ip[MAX_IPS][_IP_LINE_LENGTH + 1];	// List of ips
};
*/

struct _SQL
{
	BOOL			bFound;							//exec->argc > 0
	INT				iCount;
	BOOL			bFindDate;
	BOOL			bBanList;
	BOOL			bCheckBan;
	BOOL			bIsBanned;
	BOOL			bDelBan;
	BOOL			bSiteUser;
	BOOL			bAddedBy;
	BOOL			bDupe;
	BOOL			bCheckDirDupe;
	char			UserName[USERNAME_LENGTH];
	INT				DupeTime;
	_TCHAR			DupeDate[20];
	BOOL			bFindDupe;
	_TCHAR			DupePwd[256];
	LONG			DupeFoundCount;
	LONG			DupeTotalCount;
	BOOL			bCountDupes;
	//BOOL			bFindUnDupe;
	//INT				UnDupeFoundCount;
	BOOL			bOnFtpLogin;
	BOOL			bUserExists;
	BOOL			bLastSeen;
};

struct _ARGS
{
	_TCHAR			arg00[MAX_FILE];
	_TCHAR			arg01[MAX_FILE];
	_TCHAR			arg02[MAX_FILE];
	_TCHAR			arg03[MAX_FILE];
};

static struct _VARS
{
	struct _jWHO				jWho;
	struct _USER				user;
	struct _ENV					env;
	struct _USERTABLE			usertable[MAXUSERS];
	struct _GROUPTABLE			grouptable[MAXGROUPS];
	struct _USTATS				ustats;
	struct _GSTATS				gstats;
	struct _SITECOMMANDS		site;
	//struct _USERINFO			userinfo;
	struct _SQL					sql;
	struct _ARGS				args;
} var;