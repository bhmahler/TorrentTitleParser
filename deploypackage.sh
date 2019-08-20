cd TorrentTitleParser/bin/Release/
file="$(find -type f -name *.nupkg printf %f\\n)"
echo $file
version=$(echo $file | grep -o -E '[0-9]\.[0-9]\.[0-9]')
echo $version
status=$(curl -o /dev/null -Isw '%{http_code}\n' https://www.nuget.org/api/v2/packages/TorrentTitleParser/$version)
if $status=200; then
	echo "Version $version already found, skipping publish"
	return 0;
else 
	echo "Version $version not found, publishing..."
	dotnet nuget push $file -k $1 -s $2 
fi