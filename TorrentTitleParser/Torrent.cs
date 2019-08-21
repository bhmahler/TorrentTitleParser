using TorrentTitleParser.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace TorrentTitleParser
{
    public class Torrent
    {

        public Torrent(string name)
        {
            ParseInfo(name);
        }

        public string Name { get; set; }

        [Pattern(Regex = @"([Ss]([0-9]{1,2}))[Eex\s]")]
        public int Season { get; set; }

        [Pattern(Regex = @"([Eex]([0-9]{2})(?:[^0-9]|$))")]
        public int Episode { get; set; }

        [Pattern(Regex = @"([\[\(]?((?:19[0-9]|20[01])[0-9])[\]\)]?)")]
        public int Year { get; set; }

        [Pattern(Regex = @"(([0-9]{3,4}p))[^M]")]
        public string Resolution { get; set; }

        [Pattern(Regex = @"(?:PPV\.)?[HP]DTV|(?:HD)?CAM|B[DrR]R[iI][pP][sS]?|TS|(?:PPV )?WEB-?DL(?: DVDRip)?|H[dD]Rip|DVDRip|DVDRiP|DVDRIP|CamRip|W[EB]B[rR]ip|[Bb]lu ?[Rr]ay|DvDScr|hdtv|UHD(?: B[Ll][Uu]R[Aa][Yy])")]
        public string Quality { get; set; }

        [Pattern(Regex = @"HDR(?:\s?10)?")]
        public bool HDR { get; set; }

        [Pattern(Regex = @"xvid|x26[45]|h\.?26[45]|hevc", Options = RegexOptions.IgnoreCase)]
        public string Codec { get; set; }

        [Pattern(Regex = @"MP3|DDP?\+?[57][\.\s]?1|Dual[\- ]Audio|LiNE|D[Tt][Ss](?:-?6[Cc][Hh])?(?:-?HD)?(?: ?MA)?(?:[\.\s]?[567][\.\s]?1)?|AAC(?:\.?2\.0)?|[Aa][Cc]3(?:\s?DD)?(?:[\.\s]?[752][\.\s][10])?|ATMOS TrueHD(?:\s?7\s1)?")]
        public string Audio { get; set; }

        [Pattern(Regex = @"(- ?(?:.+\])?([^-\[]+)(?:\[.+\])?)$", AlternateRegex = @"(([A-Za-z0-9]+))$")]
        public string Group { get; set; }

        [Pattern(Regex = @"\d+\s?bit", Options = RegexOptions.IgnoreCase)]
        public string BitDepth { get; set; }

        [Pattern(Regex = @"R[0-9]")]
        public string Region { get; set; }

        [Pattern(Regex = "REMUX")]
        public bool Remux { get; set; }

        [Pattern(Regex = "EXTENDED")]
        public bool Extended { get;set; }

        [Pattern(Regex = "HC")]
        public bool HardCoded { get; set; }

        [Pattern(Regex = "PROPER")]
        public bool Proper { get; set; }

        [Pattern(Regex = "REPACK")]
        public bool Repack { get; set; }

        [Pattern(Regex = "BLURRED")]
        public bool Blurred { get; set; }

        [Pattern(Regex = "MULT[iI]-?(?:[0-9]+)?")]
        public bool MultipleLanguages { get; set; }

        [Pattern(Regex = "COMPLETE")]
        public bool Complete { get; set; }

        [Pattern(Regex = "REMASTERED")]
        public bool Remastered { get; set; }

        [Pattern(Regex = "DUBBED")]
        public bool Dubbed { get; set; }

        [Pattern(Regex = "AMZN")]
        public bool Amazon { get; set; }

        [Pattern(Regex = "NF")]
        public bool Netflix { get; set; }

        [Pattern(Regex = "([^A-Za-z0-9](3D)[^A-Za-z0-9])")]
        public bool Is3D { get; set; }

        [Pattern(Regex = @"(?:full|half)[-\s](?:sbs|ou)", Options = RegexOptions.IgnoreCase)]
        public string ThreeDFormat { get; set; }

        [Pattern(Regex = @"MKV|AVI|MP4|mkv|avi|mp4")]
        public string Container { get; set; }

        [Pattern(Regex = @"^(\[ ?([^\]]+?) ?\])")]
        public string Website { get; set; }

        [Pattern(Regex = @"1400Mb|3rd Nov| ((Rip))| \[no rar\]|[\[\(]?[Rr][Ee][Qq][\]\)]?[\s\.]?")]
        public string Garbage { get; set; }

        public string Title { get; set; }
        

        public override string ToString()
        {
            return Name;
        }

        public void ParseInfo(string name)
        {
            var end = int.MaxValue;
            var start = 0;
            var clean = "";

            name = HttpUtility.HtmlDecode(name);

            var props = this.GetType().GetProperties().Where(c => c.GetCustomAttributes(false).Any(d => d is PatternAttribute));
            foreach (var prop in props)
            {
                var attribute = (PatternAttribute)prop.GetCustomAttributes(false).First(c => c is PatternAttribute);
                var match = Regex.Match(name, attribute.Regex, attribute.Options);
                if (!match.Success && !string.IsNullOrEmpty(attribute.AlternateRegex))
                {
                    match = Regex.Match(name, attribute.AlternateRegex, attribute.Options);
                }
                if (match.Success)
                {
                    var cleanIndex = match.Groups.Count > 1 ? 2 : 0;
                    clean = match.Groups[cleanIndex].Value;
                    if (prop.PropertyType == typeof(int))
                    {
                        prop.SetValue(this, int.Parse(clean));
                    }
                    else if (prop.PropertyType == typeof(bool))
                    {
                        prop.SetValue(this, true);
                    }
                    else
                    {
                        if (prop.Name == "Group")
                        {
                            clean = Regex.Replace(clean, @" *\([^)]*\) *", "");
                            clean = Regex.Replace(clean, @" *\[[^)]*\] *", "");
                        }
                        prop.SetValue(this, clean);
                    }

                    if (match.Index == 0)
                    {
                        start = match.Groups[0].Length;
                    } else if (match.Index < end)
                    {
                        end = match.Index;
                    }
                }
            }
            var raw = name.Substring(start, end - start).Split('(')[0];
            clean = Regex.Replace(raw, @"^ -", "");
            if (clean.IndexOf(' ') == -1 && clean.IndexOf('.') != -1)
            {
                clean = Regex.Replace(clean, @"\.", " ");
            }
            clean = Regex.Replace(clean, "_", " ");
            clean = Regex.Replace(clean, @"([\(_]|- ?)$", "").Trim();
            Title = clean;
            Name = name;
        }
    }
}
