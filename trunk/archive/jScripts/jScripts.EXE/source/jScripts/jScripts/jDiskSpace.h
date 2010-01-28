typedef BOOL (WINAPI *PGETDISKFREESPACEEX)(LPCSTR,
   PULARGE_INTEGER, PULARGE_INTEGER, PULARGE_INTEGER);

BOOL MyGetDiskFreeSpaceEx(LPCSTR pszDrive)
{
	PGETDISKFREESPACEEX pGetDiskFreeSpaceEx;
	__int64 i64FreeBytesToCaller, i64TotalBytes, i64FreeBytes;
	__int64 iDel = 1024*1024*1024;

	   
	DWORD dwSectPerClust, 
			dwBytesPerSect, 
			dwFreeClusters, 
			dwTotalClusters;

	BOOL fResult;

	pGetDiskFreeSpaceEx = (PGETDISKFREESPACEEX) GetProcAddress( 
							GetModuleHandle("kernel32.dll"),
							"GetDiskFreeSpaceExA");

	if (pGetDiskFreeSpaceEx)
	{
		fResult = pGetDiskFreeSpaceEx (pszDrive,
					(PULARGE_INTEGER)&i64FreeBytesToCaller,
					(PULARGE_INTEGER)&i64TotalBytes,
					(PULARGE_INTEGER)&i64FreeBytes);

	// Process GetDiskFreeSpaceEx results.
		if(fResult) 
		{
			printf("%I64d %I64d\n", i64TotalBytes/iDel, i64FreeBytes/iDel);
		}
		else
		{
			printf("0 0\n");
		}

		return fResult;

	}
	else 
	{
		fResult = GetDiskFreeSpaceA (pszDrive, 
					&dwSectPerClust, 
					&dwBytesPerSect,
					&dwFreeClusters, 
					&dwTotalClusters);

	// Process GetDiskFreeSpace results.
		if(fResult) 
		{
			printf("%I64d %I64d\n", (dwTotalClusters*dwSectPerClust*dwBytesPerSect)/iDel, 
				(dwFreeClusters*dwSectPerClust*dwBytesPerSect)/iDel);
		}
		else
		{
			printf("0 0\n");
		}

		return fResult;
	}
}
