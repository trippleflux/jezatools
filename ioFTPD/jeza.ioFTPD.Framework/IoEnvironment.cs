using System;

namespace jeza.ioFTPD.Framework
{
    public class IoEnvironment
    {
        public static int GetUid()
        {
            return Misc.String2Number(Environment.GetEnvironmentVariable("UID") ?? "0");
        }

        public static int GetGid()
        {
            return Misc.String2Number(Environment.GetEnvironmentVariable("GID") ?? "0");
        }

        public static string GetVirtualPath()
        {
            return Environment.GetEnvironmentVariable("VIRTUALPATH") ?? "/NoPath";
        }

        public static string GetRealPath()
        {
            return Environment.GetEnvironmentVariable("PATH") ?? "c:\\NoPath";
        }

        public static string GetGroupName()
        {
            return Environment.GetEnvironmentVariable("GROUP") ?? "NoGroup";
        }

        public static string GetUserName()
        {
            return Environment.GetEnvironmentVariable("USER") ?? "NoUser";
        }

        public static int GetSpeed()
        {
            string speed = Environment.GetEnvironmentVariable("SPEED");
            return speed == null ? 1 : Misc.String2Number(speed);
        }
    }
}