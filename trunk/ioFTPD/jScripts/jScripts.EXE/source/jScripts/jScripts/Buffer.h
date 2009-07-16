typedef struct _BUFFER
{
	DWORD				len;	// Bytes in buffer
	DWORD				size;	// Size of buffer
	CHAR				*buf;	// Pointer to buffer
	DWORD				dwType;
	DWORD				dwOffset;

} BUFFER, * LPBUFFER;

#define TYPE_CHAR		0
#define TYPE_MULTICHAR	1
#define TYPE_WIDE		2


VOID Put_Buffer_Format(LPBUFFER lpBuffer, LPCSTR szFormat, ...);
VOID Put_Buffer(LPBUFFER lpBuffer, LPVOID lpMemory, DWORD dwSize);
VOID Insert_Buffer(LPBUFFER lpBuffer, LPVOID lpMemory, DWORD dwSize);

BOOL FormatStringWVA(LPBUFFER lpBuffer, LPWSTR wszFormat, va_list Arguments);
BOOL FormatStringW(LPBUFFER lpBuffer, LPWSTR wszFormat, ...);
BOOL FormatStringAVA(LPBUFFER lpBuffer, LPCSTR szFormat, va_list Arguments);
BOOL FormatStringA(LPBUFFER lpBuffer, LPCSTR szFormat, ...);
DWORD aswprintf(LPTSTR *lpBuffer, LPCSTR tszFormat, ...);
#define AppendStringA	Put_Buffer
#define Put_Buffer_Format	FormatStringA

#ifdef _UNICODE
#define FormatString FormatStringW
#else
#define FormatString FormatStringA
#endif