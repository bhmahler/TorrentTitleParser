# TorrentTitleParser
> Library for parsing movie and tv show info from torrent names

[![Build Status](https://travis-ci.org/bhmahler/TorrentTitleParser.svg?branch=master)](https://travis-ci.org/bhmahler/TorrentTitleParser) [![NuGet Badge](https://buildstats.info/nuget/TorrentTitleParser)](https://www.nuget.org/packages/TorrentTitleParser/) [![Open Source Love](https://badges.frapsoft.com/os/mit/mit.svg?v=102)](https://github.com/ellerbrock/open-source-badge/)

#### Possible Properties Parsed 

- Amazon
- Audio
- Bit Depth
- Blurred
- Codec
- Complete
- Container
- Episode
- Extended
- Group
- HDR
- Hard Coded
- Name
- Netflix
- Proper
- Quality
- Region
- Remastered
- Remux
- Repack
- Resolution
- Season
- Title
- Website
- Year

## Installation
Torrent Title Parser can be installed via nuget package manager

````
PM> Install-Package TorrentTitleParser -Version 1.0.0
````
OR via the .NET CLI
````
> dotnet add package TorrentTitleParser --version 1.0.0
````

## Usage

Simply create a new torrent object and pass the torrent title and all available properties will be parsed

````C#
var torrent = new Torrent("Men in Black International 2019 1080p WEB-DL H264 AC3-EVO");
/**
torrent = {
 Title = "Men in Black International,
 Year = 2019,
 Resolution = "1080p",
 Quality = "WEB-DL",
 Codec = "H264",
 Audio = "AC3",
 Group = "EVO"		
}
*/
````


## License
MIT





















