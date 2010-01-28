
typedef struct _IO_STATS
{
	LPUSERFILE		lpUserFile;
	INT				iPosition;
	INT				iSection;

} IO_STATS, * LPIO_STATS;


typedef struct _STATS
{
	LPBUFFER	lpBuffer;

	LPTSTR		tszSearchParameters;
	LPTSTR		tszMessagePrefix;
	LPBYTE		lpMessage;
	DWORD		dwType;
	DWORD		dwSection;
	DWORD		dwUserMax;

} STATS, * LPSTATS;


#define STATS_TYPE_DAYUP	0
#define STATS_TYPE_DAYDN	1
#define STATS_TYPE_WEEKUP	2
#define STATS_TYPE_WEEKDN	3
#define STATS_TYPE_MONTHUP	4
#define STATS_TYPE_MONTHDN	5
#define STATS_TYPE_ALLUP	6
#define STATS_TYPE_ALLDN	7
#define STATS_ORDER_FILES	(0 << 8)
#define STATS_ORDER_BYTES	(1 << 8)
#define STATS_ORDER_TIME	(2 << 8)


BOOL SetStatsType(LPSTATS lpStats, LPTSTR tszType);
BOOL CompileStats(LPSTATS lpStats);