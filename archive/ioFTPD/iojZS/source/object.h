//#define MAXFILE			256
//#define MAX_PATH			256
#define MAX_RACE			256
#define LINESIZE			256
#define GRPL				20	//groupname length - for sort by group in mp3
#define SFVS				4096	//velikost ki jo rezervira za buffer ko bere sfv
char    i_buf[MAXFILE];
char	output2[1024];
char	output[2048];
char	sR[10];
char	ttime[40];

#define USERNAME_LENGTH		64
#define GROUPNAME_LENGTH	64

#define SORT_ALLUP	0
#define SORT_ALLDN	1
#define SORT_MNUP	2
#define SORT_MNDN	3
#define SORT_WKUP	4
#define SORT_WKDN	5
#define SORT_DAYUP	6
#define SORT_DAYDN	7

struct stat stat_p;

struct _USER
{
	char			flags[32 + 1];
	BOOL			bFlags;				//flags for WHO
	int				TotalUsers;
};

struct _USERTABLE
{
	int				tUid;
	char			tUserName[USERNAME_LENGTH];
	INT64			tAllUP;
	INT64			tAllDN;
	INT64			tMnUP;
	INT64			tMnDN;
	INT64			tWkUP;
	INT64			tWkDN;
	INT64			tDayUP;
	INT64			tDayDN;
};

struct MP3
{
  char			title[31];
  char 			artist[31];
  char 			album[31];
  char 			year[5];
  char 			comment[31];
  char 			genre[31];
  int 			track;
  unsigned char 	genre_num[1];
} mp3;

struct USER_
{
  char			u_name[30];
  unsigned int		files;
  float			bytes;
  unsigned int		speed;
  char			g_name[30];
} user_[MAX_RACE];

struct GROUP_
{
  char			g_name[30];
  unsigned int		files;
  float			bytes;
  unsigned int		speed;
} group_[MAX_RACE];

struct RACE
{
  unsigned int		total_files;
  float			total_bytes;
  unsigned int		total_speed;
  unsigned long		total_time;
  unsigned int		missing_files;
  char			progress_bar[iojZS_progressmeter_length+1];
  int	 		total_users;
  int			total_groups;
  char			username[30];
  char			groupname[30];
  char			racers[1024];
  int			racer_pos;
  char			slowest_user[30];
  char			fastest_user[30];
  int			slowest_speed;
  int			fastest_speed;
};

struct DIR
{
  boolean		bCD;
  boolean		bAFFIL;
  char			name[MAX_PATH];
  //x:\bla\mp3\1010	= 1010
  //x:\bla\mp3\1010\cd1	= cd1
  char			p_name[MAX_PATH];
  //x:\bla\mp3\1010	= mp3
  //x:\bla\mp3\1010\cd1	= 1010
  char			release[MAX_PATH];
  //x:\bla\mp3\1010	= 1010
  //x:\bla\mp3\1010\cd1	= 1010/cd1
  char			p_symlink[MAX_PATH];
  //x:\bla\mp3\1010	= x:\bla\mp3
  //x:\bla\mp3\1010\cd1	= x:\bla\mp3
  char			symlink[MAX_PATH];
  //x:\bla\mp3\1010	= x:\bla\mp3
  //x:\bla\mp3\1010\cd1	= x:\bla\mp3
  char			groupname[GRPL];
};

struct FILE
{
  boolean		bOK;				//ce so vsi fajli na koncu rejsa 
  boolean		bZIP;				//ce ne najde file_id.diz
  boolean		bIsRAR;
  boolean		bIsZIP;
  char			*name;				//aloha.mp3
  char			*ext;				//mp3
  unsigned long		size;				//file_size_in_bytes
  int			speed;				//getenv("SPEED")
  char			race_file[MAX_PATH];		//race data
  char			race_filetmp[MAX_PATH];		//race datatmp
  char			msg_file[MAX_PATH];		//.ioFTPD.message
  char			sfv_file[MAX_PATH];		//sfv
  int			rescan_ok;			//rescan ok files
  int			rescan_fail;			//rescan failed files
  /*
  char			rescan_file[MAXFILE];		//rescan file
  char			rescan_crc[8];			//rescan file crc
  char			original_crc[8];			//org file crc
  char			rescan_status[16];		//rescan file status ok,missing,fail
  */
};

struct LOC
{
  char			*arg_path;			//argv[2]			x:\bla\mp3\1010\aloha.mp3
  char			*arg_crc;			//argv[3]			CRC
  char			*arg_pwd;			//argv[4]			/mp3/1010/aloha.mp3
  char			*env_path;			//getenv("PATH")		x:\bla\mp3\1010
  //char			env_path1[MAX_PATH];		//getenv("PATH")+\\		x:\bla\mp3\1010\ *
  char			*env_pwd;			//getenv("VIRTUALPATH")		/mp3/1010/
};

static struct VARS
{
  struct LOC		loc;
  struct FILE		file;
  struct DIR		dir;
  struct RACE		race;
  struct MP3		mp3;
	struct _USERTABLE			usertable[1024];
	struct _USER				user;
} var ;

