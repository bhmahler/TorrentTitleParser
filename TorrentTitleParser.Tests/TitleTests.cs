using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace TorrentTitleParser.Tests
{
    [TestClass]
    public class TitleTests
    {
        [TestMethod]
        public void ManualTest()
        {
            var settings = new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            };
            var torrent = new Torrent("Futurama Complete [jlw][plexO]");
            Trace.WriteLine(JsonConvert.SerializeObject(torrent, Formatting.Indented, settings));
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestTS ()
        {
            var torrent = new Torrent("Inside Out 2 2024 1080p TELESYNC x264 COLLECTiVE");
            Assert.AreEqual("TELESYNC", torrent.Quality);
            torrent = new Torrent("Inside Out 2 2024 V2 HDTS c1nem4 x264-SUNSCREEN");
            Assert.AreEqual("TS", torrent.Quality);
            torrent = new Torrent("Sinners 2025 1080p TeleSync X264 COLLECTiVE");
            Assert.AreEqual("TeleSync", torrent.Quality);

        }

        [TestMethod]
        public void TestNumericalTitle ()
        {
            var torrent = new Torrent("1923 S01E01 2022 1080p x264 meGusta");
            Assert.AreEqual("1923", torrent.Title);
            Assert.AreEqual(2022, torrent.Year);
        }

        [TestMethod]
        public void TestMovieTitles()
        {
            var settings = new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            };

            var torrent = new Torrent("The Flash 2023 1080p V2 Cam X264 Will1869");
            Assert.AreEqual("The Flash", torrent.Title);
            Assert.AreEqual(2023, torrent.Year);
            Assert.AreEqual("1080p", torrent.Resolution);
            Assert.AreEqual("Cam", torrent.Quality);
            Assert.AreEqual("X264", torrent.Codec);
            Assert.AreEqual("Will1869", torrent.Group);


            torrent = new Torrent("Iron Man 3 2013 REMASTERED 2160p UHD BluRay X265-IAMABLE");
            Assert.AreEqual("Iron Man 3", torrent.Title);
            Assert.AreEqual(2013, torrent.Year);
            Assert.IsTrue(torrent.Remastered);
            Assert.AreEqual("2160p", torrent.Resolution);
            Assert.AreEqual("UHD BluRay", torrent.Quality);
            Assert.AreEqual("X265", torrent.Codec);
            Assert.AreEqual("IAMABLE", torrent.Group);

            Trace.WriteLine(JsonConvert.SerializeObject(torrent, Formatting.Indented, settings));

            torrent= new Torrent("John Wick 3 2019 1080p Bluray DTS-HD MA 5 1 x264-EVO");
            Assert.AreEqual("John Wick 3", torrent.Title);
            Assert.AreEqual(2019, torrent.Year);
            Assert.AreEqual("1080p", torrent.Resolution);
            Assert.AreEqual("Bluray", torrent.Quality);
            Assert.AreEqual("x264", torrent.Codec);
            Assert.AreEqual("DTS-HD MA", torrent.Audio);
            Assert.AreEqual("5.1", torrent.AudioChannels);
            Assert.AreEqual("EVO", torrent.Group);

            Trace.WriteLine(JsonConvert.SerializeObject(torrent, Formatting.Indented, settings));

            torrent = new Torrent("Annabelle Comes Home 2019 1080p HC HDRip X264-EVO");
            Assert.AreEqual("Annabelle Comes Home", torrent.Title);
            Assert.AreEqual(2019, torrent.Year);
            Assert.AreEqual("1080p", torrent.Resolution);
            Assert.IsTrue(torrent.HardCoded);
            Assert.IsFalse(torrent.HDR);
            Assert.AreEqual("HDRip", torrent.Quality);
            Assert.AreEqual("X264", torrent.Codec);
            Assert.AreEqual("EVO", torrent.Group);

            Trace.WriteLine(JsonConvert.SerializeObject(torrent, Formatting.Indented, settings));

            torrent = new Torrent("Men in Black International 2019 1080p WEB-DL H264 AC3-EVO");
            Assert.AreEqual("Men in Black International", torrent.Title);
            Assert.AreEqual(2019, torrent.Year);
            Assert.AreEqual("1080p", torrent.Resolution);
            Assert.AreEqual("WEB-DL", torrent.Quality);
            Assert.AreEqual("H264", torrent.Codec);
            Assert.AreEqual("AC3", torrent.Audio);
            Assert.AreEqual("EVO", torrent.Group);

            Trace.WriteLine(JsonConvert.SerializeObject(torrent, Formatting.Indented, settings));

            torrent = new Torrent("A Few Good Men 1992 BluRay 1080p Dts-6Ch H264-PiR8");
            Assert.AreEqual("A Few Good Men", torrent.Title);
            Assert.AreEqual(1992, torrent.Year);
            Assert.AreEqual("1080p", torrent.Resolution);
            Assert.AreEqual("BluRay", torrent.Quality);
            Assert.AreEqual("H264", torrent.Codec);
            Assert.AreEqual("Dts-6Ch", torrent.Audio);
            Assert.AreEqual("PiR8", torrent.Group);

            Trace.WriteLine(JsonConvert.SerializeObject(torrent, Formatting.Indented, settings));

            torrent = new Torrent("Avengers Endgame 2019 3D 1080p BluRay x264-GUACAMOLE");
            Assert.AreEqual("Avengers Endgame", torrent.Title);
            Assert.AreEqual(2019, torrent.Year);
            Assert.IsTrue(torrent.Is3D);
            Assert.AreEqual("1080p", torrent.Resolution);
            Assert.AreEqual("BluRay", torrent.Quality);
            Assert.AreEqual("x264", torrent.Codec);
            Assert.AreEqual("GUACAMOLE", torrent.Group);

            Trace.WriteLine(JsonConvert.SerializeObject(torrent, Formatting.Indented, settings));

            torrent = new Torrent("Solo A Star Wars Story 2018 1080p 3D BluRay BluRay Half-SBS x264 DTS-HD MA 7 1-FGT");
            Assert.AreEqual("Solo A Star Wars Story", torrent.Title);
            Assert.AreEqual(2018, torrent.Year);
            Assert.AreEqual("1080p", torrent.Resolution);
            Assert.IsTrue(torrent.Is3D);
            Assert.AreEqual("Half-SBS", torrent.ThreeDFormat);
            Assert.AreEqual("BluRay", torrent.Quality);
            Assert.AreEqual("x264", torrent.Codec);
            Assert.AreEqual("DTS-HD MA", torrent.Audio);
            Assert.AreEqual("7.1", torrent.AudioChannels);
            Assert.AreEqual("FGT", torrent.Group);

            Trace.WriteLine(JsonConvert.SerializeObject(torrent, Formatting.Indented, settings));

            torrent = new Torrent("Iron Man 2008 MULTi 2160p UHD BluRay x265-SESKAPiLE");
            Assert.AreEqual("Iron Man", torrent.Title);
            Assert.AreEqual(2008, torrent.Year);
            Assert.AreEqual("2160p", torrent.Resolution);
            Assert.IsTrue(torrent.MultipleLanguages);
            Assert.AreEqual("UHD BluRay", torrent.Quality);
            Assert.AreEqual("x265", torrent.Codec);
            Assert.AreEqual("SESKAPiLE", torrent.Group);

            Trace.WriteLine(JsonConvert.SerializeObject(torrent, Formatting.Indented, settings));

            torrent = new Torrent("Pokemon Detective Pikachu 2019 PROPER MULTi 2160p UHD BluRay x265-OohLaLa");
            Assert.AreEqual("Pokemon Detective Pikachu", torrent.Title);
            Assert.AreEqual(2019, torrent.Year);
            Assert.IsTrue(torrent.Proper);
            Assert.IsTrue(torrent.MultipleLanguages);
            Assert.AreEqual("2160p", torrent.Resolution);
            Assert.AreEqual("UHD BluRay", torrent.Quality);
            Assert.AreEqual("x265", torrent.Codec);
            Assert.AreEqual("OohLaLa", torrent.Group);

            Trace.WriteLine(JsonConvert.SerializeObject(torrent, Formatting.Indented, settings));

            torrent = new Torrent("(REQ) Return Of The Living Dead Necropolis 2005 H264 AC3 DD2 0 Will1869");
            Assert.AreEqual("Return Of The Living Dead Necropolis", torrent.Title);
            Assert.AreEqual(2005, torrent.Year);
            Assert.AreEqual("H264", torrent.Codec);
            Assert.AreEqual("AC3 DD", torrent.Audio);
            Assert.AreEqual("2.0", torrent.AudioChannels);
            Assert.AreEqual("Will1869", torrent.Group);

            Trace.WriteLine(JsonConvert.SerializeObject(torrent, Formatting.Indented, settings));

            torrent = new Torrent("[REQ] Three Wishes 1995 DVDRip X264 Ac3 SNAKE");
            Assert.AreEqual("Three Wishes", torrent.Title);
            Assert.AreEqual(1995, torrent.Year);
            Assert.AreEqual("DVDRip", torrent.Quality);
            Assert.AreEqual("X264", torrent.Codec);
            Assert.AreEqual("Ac3", torrent.Audio);
            Assert.AreEqual("SNAKE", torrent.Group);

            Trace.WriteLine(JsonConvert.SerializeObject(torrent, Formatting.Indented, settings));

            torrent = new Torrent("Where The Red Fern Grows-1974-X264-AAC-BigTimeCube");
            Assert.AreEqual("Where The Red Fern Grows", torrent.Title);
            Assert.AreEqual(1974, torrent.Year);
            Assert.AreEqual("X264", torrent.Codec);
            Assert.AreEqual("AAC", torrent.Audio);
            Assert.AreEqual("BigTimeCube", torrent.Group);

            Trace.WriteLine(JsonConvert.SerializeObject(torrent, Formatting.Indented, settings));

            torrent = new Torrent("Alita Battle Angel 2019 BluRay 10Bit 1080p DD+5 1 H265-d3g");
            Assert.AreEqual("Alita Battle Angel", torrent.Title);
            Assert.AreEqual(2019, torrent.Year);
            Assert.AreEqual(10, torrent.BitDepth);
            Assert.AreEqual("1080p", torrent.Resolution);
            Assert.AreEqual("BluRay", torrent.Quality);
            Assert.AreEqual("H265", torrent.Codec);
            Assert.AreEqual("DD+", torrent.Audio);
            Assert.AreEqual("5.1", torrent.AudioChannels);
            Assert.AreEqual("d3g", torrent.Group);

            Trace.WriteLine(JsonConvert.SerializeObject(torrent, Formatting.Indented, settings));

            torrent = new Torrent("Avengers.Endgame.2019.2160p.BluRay.REMUX.HEVC.DTS-HD.MA.TrueHD.7.1.Atmos-FGT");
            Assert.AreEqual("Avengers Endgame", torrent.Title);
            Assert.AreEqual(2019, torrent.Year);
            Assert.AreEqual("2160p", torrent.Resolution);
            Assert.IsTrue(torrent.Remux);
            Assert.AreEqual("BluRay", torrent.Quality);
            Assert.AreEqual("HEVC", torrent.Codec);
            Assert.AreEqual("DTS-HD MA", torrent.Audio);
            Assert.IsTrue(torrent.TrueHD);
            Assert.AreEqual("7.1", torrent.AudioChannels);
            Assert.IsTrue(torrent.DolbyAtmos);
            Assert.AreEqual("FGT", torrent.Group);

            Trace.WriteLine(JsonConvert.SerializeObject(torrent, Formatting.Indented, settings));


            torrent = new Torrent("John Wick 2014 BluRay 1080p AC-3 TrueHD 7 1 HEVC-d3g");
            Assert.AreEqual("John Wick", torrent.Title);
            Assert.AreEqual(2014, torrent.Year);
            Assert.AreEqual("1080p", torrent.Resolution);
            Assert.AreEqual("BluRay", torrent.Quality);
            Assert.AreEqual("HEVC", torrent.Codec);
            Assert.AreEqual("AC-3", torrent.Audio);
            Assert.IsTrue(torrent.TrueHD);
            Assert.AreEqual("7.1", torrent.AudioChannels);
            Assert.AreEqual("d3g", torrent.Group);

            Trace.WriteLine(JsonConvert.SerializeObject(torrent, Formatting.Indented, settings));
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
            Assert.AreEqual("DD+", torrent.Audio);
            Assert.AreEqual("5.1", torrent.AudioChannels);
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
            Assert.AreEqual("DDP", torrent.Audio);
            Assert.AreEqual("5.1", torrent.AudioChannels);
            Assert.IsTrue(torrent.HDR);
            Assert.AreEqual("HEVC", torrent.Codec);
            Assert.AreEqual("NEOLUTiON", torrent.Group);
        }

        [TestMethod]
        public void TestOddTitle()
        {
            var torrent = new Torrent("Saving Private Ryan 1998 720p BDRip DD5 1 x264-ITSat");
            Assert.AreEqual("Saving Private Ryan", torrent.Title);
        }
    }
}
