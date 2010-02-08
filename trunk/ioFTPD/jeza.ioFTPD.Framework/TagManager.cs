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
            Console.WriteLine ("!vfs:chattr 1 \"{0}\" \"{1}\"", symLink, data.UploadVirtualPath);
            Console.WriteLine ("!vfs:add {3} {1}:{2} {0}", data.UploadVirtualPath, data.Uid, data.Gid, Config.TagIncompleteLinkChMod);
            //printf("!vfs:chattr 1 \"%s\" \"%s\"\n", (char*)var->dir.symlink, (char*)var->loc.env_pwd);
            //printf("!vfs:add %i %i:%i %s\n", iojZS_chmod_symlink, atoi(getenv("UID")), atoi(getenv("GID")), (char*)var->dir.symlink);
        }

        private readonly bool tagType;
        private readonly Race race;
    }
}