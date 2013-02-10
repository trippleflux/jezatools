using System.IO;
using jeza.ioFTPD.Framework;
using NUnit.Framework;

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
            string root = Misc.PathCombine(Config.AudioSortByArtistPath, "B");
            string directory = Misc.PathCombine(root, "SwingingSafari");
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
            string root = Misc.PathCombine(Config.AudioSortByGenrePath, "blues");
            string directory = Misc.PathCombine(root, "SwingingSafari");
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
            string root = Misc.PathCombine(Config.AudioSortByYearPath, "2002");
            string directory = Misc.PathCombine(root, "SwingingSafari");
            Assert.IsTrue(Directory.Exists(directory));
        }
    }
}