#region
using System;
using System.IO;

#endregion

namespace jeza.ioFTPD.Framework
{
    public class TagManager
    {
        public TagManager (Race race)
        {
            tagType = Config.TagAsFile;
            this.race = race;
        }

        public void Create
            (string path,
             string tag)
        {
            if (tagType)
            {
                FileInfo.Create0ByteFile (Path.Combine (path, tag));
            }
            else
            {
                throw new NotSupportedException ("Tag as folder");
            }
        }

        public void CreateSymLink (string path,
                                   string link)
        {
            string symLink = Path.Combine (path, link);
            FileInfo.CreateFolder (symLink);
            CurrentUploadData data = race.CurrentUploadData;
            Console.Write ("!vfs:chattr 1 \"{0}\" \"{1}\"\n", symLink, data.UploadVirtualPath);
            Console.Write ("!vfs:add {3} {1}:{2} {0}\n", symLink, data.Uid, data.Gid, Config.TagIncompleteLinkChMod);
        }

        private readonly bool tagType;
        private readonly Race race;
    }
}