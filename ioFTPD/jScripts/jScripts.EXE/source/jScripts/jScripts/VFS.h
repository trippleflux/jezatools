
#define	INVALID_GROUP	(UINT32)-1
#define	INVALID_USER	(UINT32)-1

#define	PRIVATE			0
#define SYMBOLICLINK	1


#define	DATABASE_VERSION			1
#define	DATABASE_HEADER_SIZE		sizeof(BYTE) * 2
#define	DB_UPDATE					0001
#define	DB_NOWRITE					0002
#define DB_OVERWRITE				0004
#define	DB_NOCONTEXT				0100
#define	DB_MAX_CHUNKSIZE			65536
#define	DB_INSERT					1
#define	DB_DELETE					2
#define	DB_PATH						0010
#define DB_NODIRECTORYATTRIBUTES	0020
#define	DB_TYPECHECK				0200


#define _I_READ		0002L
#define _I_WRITE	0004L
#define _I_EXECUTE	0001L
#define _I_OWN		1000L


#define S_IRWXU		0700
#define S_IRUSR		0400
#define S_IWUSR		0200
#define S_IXUSR		0100
#define S_IRWXG		0070
#define S_IRGRP		0040
#define S_IWGRP		0020
#define S_IXGRP		0010
#define S_IRWXO		0007
#define S_IROTH		0004
#define S_IWOTH		0002
#define S_IXOTH		0001



typedef struct _FILE_LIST
{
	LPSTR				Name;
	INT					Length;
	struct _FILE_LIST	*Next;

} FILE_LIST, * LPFILE_LIST;



typedef struct _FILEATTRIBUTES
{
	UINT32	Uid;
	UINT32	Gid;
	UINT32	Mode;
	UINT32	Crc32;

} FILEATTRIBUTES, * LPFILEATTRIBUTES;


typedef struct _DIRECTORYATTRIBUTES
{
	UINT64	Size;
	DWORD	SubDirectories;

} DIRECTORYATTRIBUTES, * LPDIRECTORYATTRIBUTES;


typedef struct _FILECONTEXT
{
	LPVOID	Buffer;
	UINT32	Size;

} FILECONTEXT, * LPFILECONTEXT;



typedef struct _FILEITEM
{
	UINT32			Hash;
	DWORD			dwFileName;
	LPTSTR			FileName;
	FILEATTRIBUTES	Attributes;
	FILECONTEXT		Context;
	UCHAR			Dirty;

} FILEITEM, * LPFILEITEM;


typedef struct _FILE_DATABASE
{
	LPFILEITEM	*Item;
	DWORD		Items;
	DWORD		Size;

} FILE_DATABASE, * LPFILE_DATABASE;


typedef struct _PATHITEM
{
	UINT			Hash;
	DWORD			dwPath;
	LPTSTR			Path;
	DWORD			SubDirectories;
	UINT64			DirectorySize;
	FILETIME		FileTime;
	FILE_DATABASE	FileDatabase;

	struct _PATHITEM	*Prev;
	struct _PATHITEM	*Next;

} PATHITEM, * LPPATHITEM;

typedef struct _PATH_DATABASE
{
	LPPATHITEM	*Item;
	DWORD		Items;
	DWORD		Size;

} PATH_DATABASE, * LPPATH_DATABASE;



typedef struct _VFSPATH
{
	FILEATTRIBUTES		Attributes;
	DIRECTORYATTRIBUTES	DirectoryAttributes;
	FILECONTEXT			Context;

} VFSPATH, * LPVFSPATH;


typedef struct _VFSFILE
{
	FILEATTRIBUTES	Attributes;
	FILECONTEXT		Context;

} VFSFILE, * LPVFSFILE;




typedef struct _VFSCACHE
{
	UINT		Hash;
	LPSTR		Path;
	UINT		Length;

	LPPATHITEM	LastPath;
	LPVFSFILE	VfsFile;

	DWORD		dwSync;
} VFSCACHE, *LPVFSCACHE;



//	VFS entry managment
BOOL VFS_Retrieve(LPSTR szFileName, LPFILETIME lpFileTime, LPVOID lpBuffer, DWORD dwFlags);
BOOL VFS_Insert(LPSTR szFileName, LPFILEATTRIBUTES lpFileAttributes, LPFILECONTEXT lpFileContext, DWORD dwFlags);
BOOL VFS_Access(LPUSERFILE lpUserFile, LPFILEATTRIBUTES lpFileAttributes, LPFILECONTEXT lpFileContext, UINT iMode);

BOOL VFS_RetrieveEx(LPSTR szFileName, LPVFSCACHE lpCache);
LPVFSCACHE VFS_RetrieveExInit(LPSTR szFileName, LPVFSFILE lpBuffer);
VOID VFS_RetrieveExDeInit(LPVFSCACHE lpCache);

VOID VFS_MarkUpdate(LPSTR szUpdatePath);
BOOL VFS_CleanPath(LPSTR szFullPath);
BOOL VFS_Uncache(LPSTR szPath);

//	Context managment
BOOL VFS_AddContext(BYTE bType, LPVOID lpBuffer, DWORD dwBuffer, LPFILECONTEXT lpContext);
BOOL VFS_DeleteContext(BYTE bType, LPFILECONTEXT lpContext);
LPVOID VFS_FindContext(BYTE bType, LPDWORD lpDataSize, LPFILECONTEXT lpContext);
VOID VFS_FreeContext(LPFILECONTEXT lpContext);

//	Initialization routines
VOID VFS_DeInit(VOID);
BOOL VFS_Init(VOID);

//	Variables
extern VFSPATH	DirectoryDefaultFileInformation;
extern VFSFILE	FileDefaultFileInformation;
