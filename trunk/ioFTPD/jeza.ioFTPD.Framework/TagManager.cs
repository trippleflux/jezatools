#region
using System;
using System.IO;

#endregion

namespace jeza.ioFTPD.Framework
{
    public class TagManager : ITagManager
    {
        public TagManager ()
        {
            tagType = Config.TagAsFile;
        }

        public void Create
            (string path,
             string tag)
        {
            if (tagType)
            {
                FileInfo.Create0ByteFile(Path.Combine(path, tag));
            }
            else
                throw new NotSupportedException ("Tag as folder");
        }

        public void Delete ()
        {
            throw new NotImplementedException ();
        }

        private readonly bool tagType;
    }
}