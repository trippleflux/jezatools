using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace jeza.ioFTPD.Framework
{
    public class DriveInformation
    {
        public DriveInformation(DriveInfo driveInfo)
        {
            this.driveInfo = driveInfo;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(CultureInfo.InvariantCulture, "|{0}|{1}", driveInfo.Name, driveInfo.DriveType);
            if (driveInfo.IsReady)
            {
                //Output output = new Output(new Race(new string[] {"asd"}));
                long totalSize = driveInfo.TotalSize;
                long totalFreeSpace = driveInfo.TotalFreeSpace;
                sb.AppendFormat(CultureInfo.InvariantCulture, "|{0}|{1}|{2}|{3}|{4}|{5}|", 
                    driveInfo.VolumeLabel, 
                    driveInfo.DriveFormat, 
                    totalSize, 
                    totalFreeSpace,
                    ((UInt64)totalSize).FormatSize(),
                    ((UInt64)totalFreeSpace).FormatSize());
            }
            else
            {
                sb.Append("|-|-|-|-|-|-|");
            }
            return sb.ToString();
        }

        private readonly DriveInfo driveInfo;
    }
}