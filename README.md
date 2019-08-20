# TorrentTitleParser
> Library for parsing movie and tv show info from torrent names

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
Torrent Title Parser can be installed via nuget package manager or via the console
````
Install-Package TorrentTitleParser
````

## Usage

Simply create a new torrent object and pass the torrent title and all available properties will be parsed

````C#
var torrent = new Torrent("Men in Black International 2019 1080p WEB-DL H264 AC3-EVO");
````


## License
MIT





















