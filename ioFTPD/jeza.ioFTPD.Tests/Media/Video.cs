using System;
using MbUnit.Framework;
using TagLib;

namespace jeza.ioFTPD.Tests.Media
{
    [TestFixture]
    public class Video
    {
        [Test]
        public void SampleInfo()
        {
            File file = File.Create(@"..\..\TestFiles\Video\fringe.315.hdtv.sample-lol.avi");
            Properties properties = file.Properties;
            Assert.AreEqual(131, properties.AudioBitrate, "properties.AudioBitrate");
            Assert.AreEqual(2, properties.AudioChannels, "properties.AudioChannels");
            Assert.AreEqual(48000, properties.AudioSampleRate, "properties.AudioSampleRate");
            Assert.AreEqual("XviD Video; ISO/MPEG Layer 3 Audio", properties.Description, "properties.Description");
            Assert.AreEqual(new TimeSpan(0, 0, 1, 2, 729), properties.Duration, "properties.Duration");
            Assert.AreEqual(62, (int) properties.Duration.TotalSeconds, "properties.Duration.TotalSeconds");
        }
    }
}