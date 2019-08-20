cd TorrentTitleParser/bin/Release/
file="$(find ./ -type f -name *.nupkg -printf "%f")"
echo $file
version=$(echo $file | grep -o -E '[0-9]\.[0-9]\.[0-9]')
echo "Found version $version for publish, checking nuget.org..."
url="https://globalcdn.nuget.org/packages/$file"
status=$(curl -o /dev/null -Isw '%{http_code}\n' $url)
if $status=200; then
	echo "Version $version already found, skipping publish"
	return 0;
else 
	echo "Version $version not found, publishing..."
	dotnet nuget push $file -k $1 -s $2 
fi