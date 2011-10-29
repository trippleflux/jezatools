namespace jeza.ioFTPD.Framework
{
    public class Mp3Info
    {
        public Mp3Info()
        {
            Artist = "Artist";
            Album = "Album";
            Title = "Title";
            Genre = "Genre";
            Year = 0;
            TrackNumber = 0;
        }

        public string Artist { get; set; }
        public string Album { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public uint Year { get; set; }
        public uint TrackNumber { get; set; }
    }
}