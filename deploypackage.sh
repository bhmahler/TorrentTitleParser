#!/bin/bash

cd TorrentTitleParser/bin/Release/
file="$(find ./ -type f -name *.nupkg -printf "%f")"
version=$(echo $file | grep -o -E '[0-9]\.[0-9]\.[0-9]')
echo "Found version $version for publish, checking nuget.org..."
lower=$(echo "$file" | tr '[:upper:]' '[:lower:]')
url="https://globalcdn.nuget.org/packages/$lower"
status=$(curl --write-out %{http_code} --silent --output /dev/null $url)
if [ $status == 200 ]; then
	echo "Version $version already found, skipping publish"
else 
	echo "Version $version not found, publishing..."
	dotnet nuget push $file -k $1 -s $2
fi