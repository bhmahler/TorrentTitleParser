﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TorrentTitleParser.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PatternAttribute : Attribute
    {
        public string Regex { get; set; }
        public string AlternateRegex { get; set; }
        public RegexOptions Options { get; set; }
        /// <summary>
        /// Pipe separated list of text replacements
        /// e.g .,_|-,_ will replace . with _ and - with _
        /// </summary>
        public string Replacements { get; set; }
    }
}
