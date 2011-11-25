using System;
using System.IO;

namespace jeza.ioFTPD.Framework.ioFTPD
{
    public class UserManager
    {
        public static int UsernameToUid(string username)
        {
            throw new NotImplementedException();
        }

        public static string UidToUsername(int uid)
        {
            throw new NotImplementedException();
        }

        public static UInt64 GetStats(int uid,
                                      UploadStats uploadStats,
                                      int section = 0)
        {
            throw new NotImplementedException();
        }

        public static UserFile GetUser(int uid)
        {
            throw new NotImplementedException();
        }
    }
}