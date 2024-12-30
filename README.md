# TorrentTitleParser
> Library for parsing movie and tv show info from torrent names

[![.NET](https://github.com/bhmahler/TorrentTitleParser/actions/workflows/dotnet.yml/badge.svg)](https://github.com/bhmahler/TorrentTitleParser/actions/workflows/dotnet.yml) [![NuGet Badge](https://img.shields.io/nuget/dt/TorrentTitleParser)](https://www.nuget.org/packages/TorrentTitleParser/) [![MIT Licence](https://badges.frapsoft.com/os/mit/mit.png?v=103)](https://opensource.org/licenses/mit-license.php)
#### Possible Properties Parsed 

- Amazon
- Audio
- Audio Channels
- Bit Depth
- Blurred
- Codec
- Complete
- Container
- Dolby Atmos
- Dubbed
- Episode
- Extended
- Group
- Hard Coded
- HDR
- Is3D
- MultipleLanguages
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
- ThreeDFormat
- Title
- TrueHD
- Website
- Year

## Installation
Torrent Title Parser can be installed via nuget package manager

````
PM> Install-Package TorrentTitleParser
````
OR via the .NET CLI
````
> dotnet add package TorrentTitleParser
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





















