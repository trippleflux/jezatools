#region
using System;
using System.IO;

#endregion

namespace jeza.ioFTPD.Framework
{
    public class TagManager
    {
        public TagManager(Race race)
        {
            this.race = race;
        }

        /// <summary>
        /// Creates the specified TAG.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="tag">The tag.</param>
        public void CreateTag
            (string path,
             string tag)
        {
            string tag2Create = Path.Combine(path, tag);
            FileInfo.Create0ByteFile(tag2Create);
        }

        /// <summary>
        /// Creates the symlink with specified CHMOD, UID and GID settings.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="link">The link.</param>
        public void CreateSymLink(string path,
                                  string link)
        {
            string symLink = Path.Combine(path, link);
            Log.Debug("CreateSymLink: {0}", symLink);
            FileInfo.CreateFolder(symLink);
            CurrentRaceData data = race.CurrentRaceData;
            Console.Write("!vfs:chattr 1 \"{0}\" \"{1}\"\n", symLink, data.UploadVirtualPath);
            Console.Write("!vfs:add {3} {1}:{2} {0}\n", symLink, data.Uid, data.Gid, Config.TagIncompleteLinkChMod);
        }

        /// <summary>
        /// Deletes the symlink.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="link">The format.</param>
        public void DeleteSymlink(string path,
                                  string link)
        {
            string symLink = Path.Combine(path, link);
            Log.Debug("DeleteSymlink: {0}", symLink);
            FileInfo fileInfo = new FileInfo();
            fileInfo.DeleteFile(symLink, ".ioFTPD");
            fileInfo.RemoveFolder(symLink);
        }

        private readonly Race race;
    }
}