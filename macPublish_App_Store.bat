dotnet publish -f net8.0-maccatalyst -c Release -p:MtouchLink=SdkOnly -p:CreatePackage=true -p:EnableCodeSigning=true -p:EnablePackageSigning=true -p:CodesignKey="Apple Distribution: Eigil Krogh (4657Q2Y6NH)" -p:CodesignProvision="ChronoWiz Profile App Store MAC" -p:CodesignEntitlements="Platforms\MacCatalyst\Entitlements.Release.plist" -p:PackageSigningKey="3rd Party Mac Developer Installer: Eigil Krogh (4657Q2Y6NH)" -p:ServerAddress=skimac -p:ServerUser=eks -p:ServerPassword=sohbdk -p:TcpPort=58181 -p:_DotNetRootRemoteDirectory=/Users/eks/Library/Caches/Xamarin/XMA/SDKs/dotnet/
