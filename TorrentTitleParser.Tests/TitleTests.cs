using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TorrentTitleParser.Tests
{
    [TestClass]
    public class TitleTests
    {
        [TestMethod]
        public void TestMovieTitles()
        {
            var torrent = new Torrent("Iron Man 3 2013 REMASTERED 2160p UHD BluRay X265-IAMABLE");
            Assert.AreEqual("Iron Man 3", torrent.Title);
            Assert.AreEqual(2013, torrent.Year);
            Assert.IsTrue(torrent.Remastered);
            Assert.AreEqual("2160p", torrent.Resolution);
            Assert.AreEqual("UHD BluRay", torrent.Quality);
            Assert.AreEqual("X265", torrent.Codec);
            Assert.AreEqual("IAMABLE", torrent.Group);

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

            torrent = new Torrent("Men in Black International 2019 1080p WEB-DL H264 AC3-EVO");
            Assert.AreEqual("Men in Black International", torrent.Title);
            Assert.AreEqual(2019, torrent.Year);
            Assert.AreEqual("1080p", torrent.Resolution);
            Assert.AreEqual("WEB-DL", torrent.Quality);
            Assert.AreEqual("H264", torrent.Codec);
            Assert.AreEqual("AC3", torrent.Audio);
            Assert.AreEqual("EVO", torrent.Group);

            torrent = new Torrent("A Few Good Men 1992 BluRay 1080p Dts-6Ch H264-PiR8");
            Assert.AreEqual("A Few Good Men", torrent.Title);
            Assert.AreEqual(1992, torrent.Year);
            Assert.AreEqual("1080p", torrent.Resolution);
            Assert.AreEqual("BluRay", torrent.Quality);
            Assert.AreEqual("H264", torrent.Codec);
            Assert.AreEqual("Dts-6Ch", torrent.Audio);
            Assert.AreEqual("PiR8", torrent.Group);

            torrent = new Torrent("Avengers Endgame 2019 3D 1080p BluRay x264-GUACAMOLE");
            Assert.AreEqual("Avengers Endgame", torrent.Title);
            Assert.AreEqual(2019, torrent.Year);
            Assert.IsTrue(torrent.Is3D);
            Assert.AreEqual("1080p", torrent.Resolution);
            Assert.AreEqual("BluRay", torrent.Quality);
            Assert.AreEqual("x264", torrent.Codec);
            Assert.AreEqual("GUACAMOLE", torrent.Group);

            torrent = new Torrent("Solo A Star Wars Story 2018 1080p 3D BluRay BluRay Half-SBS x264 DTS-HD MA 7 1-FGT");
            Assert.AreEqual("Solo A Star Wars Story", torrent.Title);
            Assert.AreEqual(2018, torrent.Year);
            Assert.AreEqual("1080p", torrent.Resolution);
            Assert.IsTrue(torrent.Is3D);
            Assert.AreEqual("Half-SBS", torrent.ThreeDFormat);
            Assert.AreEqual("BluRay", torrent.Quality);
            Assert.AreEqual("x264", torrent.Codec);
            Assert.AreEqual("DTS-HD MA 7 1", torrent.Audio);
            Assert.AreEqual("FGT", torrent.Group);

            torrent = new Torrent("Iron Man 2008 MULTi 2160p UHD BluRay x265-SESKAPiLE");
            Assert.AreEqual("Iron Man", torrent.Title);
            Assert.AreEqual(2008, torrent.Year);
            Assert.AreEqual("2160p", torrent.Resolution);
            Assert.IsTrue(torrent.MultipleLanguages);
            Assert.AreEqual("UHD BluRay", torrent.Quality);
            Assert.AreEqual("x265", torrent.Codec);
            Assert.AreEqual("SESKAPiLE", torrent.Group);

            torrent = new Torrent("Pokemon Detective Pikachu 2019 PROPER MULTi 2160p UHD BluRay x265-OohLaLa");
            Assert.AreEqual("Pokemon Detective Pikachu", torrent.Title);
            Assert.AreEqual(2019, torrent.Year);
            Assert.IsTrue(torrent.Proper);
            Assert.IsTrue(torrent.MultipleLanguages);
            Assert.AreEqual("2160p", torrent.Resolution);
            Assert.AreEqual("UHD BluRay", torrent.Quality);
            Assert.AreEqual("x265", torrent.Codec);
            Assert.AreEqual("OohLaLa", torrent.Group);

            torrent = new Torrent("(REQ) Return Of The Living Dead Necropolis 2005 H264 AC3 DD2 0 Will1869");
            Assert.AreEqual("Return Of The Living Dead Necropolis", torrent.Title);
            Assert.AreEqual(2005, torrent.Year);
            Assert.AreEqual("H264", torrent.Codec);
            Assert.AreEqual("AC3 DD2 0", torrent.Audio);
            Assert.AreEqual("Will1869", torrent.Group);

            torrent = new Torrent("[REQ] Three Wishes 1995 DVDRip X264 Ac3 SNAKE");
            Assert.AreEqual("Three Wishes", torrent.Title);
            Assert.AreEqual(1995, torrent.Year);
            Assert.AreEqual("DVDRip", torrent.Quality);
            Assert.AreEqual("X264", torrent.Codec);
            Assert.AreEqual("Ac3", torrent.Audio);
            Assert.AreEqual("SNAKE", torrent.Group);

            torrent = new Torrent("Where The Red Fern Grows-1974-X264-AAC-BigTimeCube");
            Assert.AreEqual("Where The Red Fern Grows", torrent.Title);
            Assert.AreEqual(1974, torrent.Year);
            Assert.AreEqual("X264", torrent.Codec);
            Assert.AreEqual("AAC", torrent.Audio);
            Assert.AreEqual("BigTimeCube", torrent.Group);


        }

        [TestMethod]
        public void TestTVTitles()
        {
            var torrent = new Torrent("Suits S09E05 720p HDTV x264-aAF");
            Assert.AreEqual("Suits", torrent.Title);
            Assert.AreEqual(9, torrent.Season);
            Assert.AreEqual(5, torrent.Episode);
            Assert.AreEqual("720p", torrent.Resolution);
            Assert.AreEqual("HDTV", torrent.Quality);
            Assert.AreEqual("x264", torrent.Codec);
            Assert.AreEqual("aAF", torrent.Group);

            torrent = new Torrent("Bosch S05 2160p AMZN WEBRip DD+5 1 x264-AJP69");
            Assert.AreEqual("Bosch", torrent.Title);
            Assert.AreEqual(5, torrent.Season);
            Assert.AreEqual("2160p", torrent.Resolution);
            Assert.IsTrue(torrent.Amazon);
            Assert.AreEqual("WEBRip", torrent.Quality);
            Assert.AreEqual("DD+5 1", torrent.Audio);
            Assert.AreEqual("x264", torrent.Codec);
            Assert.AreEqual("AJP69", torrent.Group);

            torrent = new Torrent("Stranger Things S03E06 2160p WEBRip x264-STRiFE");
            Assert.AreEqual("Stranger Things", torrent.Title);
            Assert.AreEqual(3, torrent.Season);
            Assert.AreEqual(6, torrent.Episode);
            Assert.AreEqual("2160p", torrent.Resolution);
            Assert.AreEqual("WEBRip", torrent.Quality);
            Assert.AreEqual("x264", torrent.Codec);
            Assert.AreEqual("STRiFE", torrent.Group);

            torrent = new Torrent("The Boys S01 2160p WEB-DL DDP5 1 HDR HEVC-NEOLUTiON");
            Assert.AreEqual("The Boys", torrent.Title);
            Assert.AreEqual(1, torrent.Season);
            Assert.AreEqual("2160p", torrent.Resolution);
            Assert.AreEqual("WEB-DL", torrent.Quality);
            Assert.AreEqual("DDP5 1", torrent.Audio);
            Assert.IsTrue(torrent.HDR);
            Assert.AreEqual("HEVC", torrent.Codec);
            Assert.AreEqual("NEOLUTiON", torrent.Group);
        }
    }
}
