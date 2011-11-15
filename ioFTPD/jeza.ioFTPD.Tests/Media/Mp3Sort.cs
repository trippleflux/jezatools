using System.IO;
using jeza.ioFTPD.Framework;
using MbUnit.Framework;

namespace jeza.ioFTPD.Tests.Media
{
    [TestFixture]
    public class Mp3Sort
    {
        [Test]
        public void ByArtist()
        {
            Race race = new Race(new[] {"upload", "", "", ""})
                        {
                            CurrentRaceData = new CurrentRaceData
                                              {
                                                  UploadVirtualPath = "/TestFiles/Mp3/SwingingSafari",
                                                  DirectoryName = "SwingingSafari",
                                              },
                        };
            TagLib.File file = TagLib.File.Create(@"..\..\TestFiles\Mp3\SwingingSafari.mp3");
            Extensions.SortAudio(race, file);
            string root = Path.Combine(Config.AudioSortByArtistPath, "B");
            string directory = Path.Combine(root, "SwingingSafari");
            Assert.IsTrue(Directory.Exists(directory));
        }

        [Test]
        public void ByGenre()
        {
            Race race = new Race(new[] { "upload", "", "", "" })
            {
                CurrentRaceData = new CurrentRaceData
                {
                    UploadVirtualPath = "/TestFiles/Mp3/SwingingSafari",
                    DirectoryName = "SwingingSafari",
                },
            };
            TagLib.File file = TagLib.File.Create(@"..\..\TestFiles\Mp3\SwingingSafari.mp3");
            Extensions.SortAudio(race, file);
            string root = Path.Combine(Config.AudioSortByGenrePath, "blues");
            string directory = Path.Combine(root, "SwingingSafari");
            Assert.IsTrue(Directory.Exists(directory));
        }

        [Test]
        public void ByYear()
        {
            Race race = new Race(new[] { "upload", "", "", "" })
            {
                CurrentRaceData = new CurrentRaceData
                {
                    UploadVirtualPath = "/TestFiles/Mp3/SwingingSafari",
                    DirectoryName = "SwingingSafari",
                },
            };
            TagLib.File file = TagLib.File.Create(@"..\..\TestFiles\Mp3\SwingingSafari.mp3");
            Extensions.SortAudio(race, file);
            string root = Path.Combine(Config.AudioSortByYearPath, "2002");
            string directory = Path.Combine(root, "SwingingSafari");
            Assert.IsTrue(Directory.Exists(directory));
        }
    }
}