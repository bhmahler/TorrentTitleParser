using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TorrentTitleParser.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTorrentTitles()
        {
            var torrent = new Torrent("Iron Man 3 2013 REMASTERED 2160p UHD BluRay X265-IAMABLE");
            Assert.AreEqual("Iron Man 3", torrent.Title);
            Assert.AreEqual(2013, torrent.Year);
            Assert.IsTrue(torrent.Remastered);
            Assert.AreEqual("2160p", torrent.Resolution);
            Assert.AreEqual("UHD BluRay", torrent.Quality);
            Assert.AreEqual("X265", torrent.Codec);
            Assert.AreEqual("IAMABLE", torrent.Group);

            torrent = new Torrent("Suits S09E05 720p HDTV x264-aAF");
            Assert.AreEqual("Suits", torrent.Title);
            Assert.AreEqual(9, torrent.Season);
            Assert.AreEqual(5, torrent.Episode);
            Assert.AreEqual("720p", torrent.Resolution);
            Assert.AreEqual("HDTV", torrent.Quality);
            Assert.AreEqual("x264", torrent.Codec);
            Assert.AreEqual("aAF", torrent.Group);

            torrent = new Torrent("John Wick 3 2019 1080p Bluray DTS-HD MA 5 1 x264-EVO");
            Assert.AreEqual("John Wick 3", torrent.Title);
            Assert.AreEqual(2019, torrent.Year);
            Assert.AreEqual("1080p", torrent.Resolution);
            Assert.AreEqual("Bluray", torrent.Quality);
            Assert.AreEqual("x264", torrent.Codec);
            Assert.AreEqual("DTS-HD MA 5 1", torrent.Audio);
            Assert.AreEqual("EVO", torrent.Group);

            torrent = new Torrent("Annabelle Comes Home 2019 1080p HC HDRip X264-EVO");
            Assert.AreEqual("Annabelle Comes Home", torrent.Title);
            Assert.AreEqual(2019, torrent.Year);
            Assert.AreEqual("1080p", torrent.Resolution);
            Assert.IsTrue(torrent.HardCoded);
            Assert.AreEqual("HDRip", torrent.Quality);
            Assert.AreEqual("X264", torrent.Codec);
            Assert.AreEqual("EVO", torrent.Group);
        }
    }
}
