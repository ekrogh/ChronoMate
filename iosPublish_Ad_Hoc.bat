dotnet build -t:Clean
dotnet clean
rm -rf /Users/eks/Downloads/ChronoWiz*.*
dotnet publish -f net8.0-ios -c Release -p:ArchiveOnBuild=true -p:RuntimeIdentifier=ios-arm64 -p:CodesignKey="Apple Distribution: Eigil Krogh (4657Q2Y6NH)" -p:CodesignProvision="ChronoWiz Profile Ad Hoc iOS" -p:ServerAddress=skimac -p:ServerUser=eks -p:ServerPassword=sohbdk -p:TcpPort=58181 -p:_DotNetRootRemoteDirectory=/Users/eks/Library/Caches/Xamarin/XMA/SDKs/dotnet/  -o "/Users/eks/Downloads/"
