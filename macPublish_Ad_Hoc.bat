dotnet build -t:Clean
dotnet clean
dotnet publish ChronoWiz/ChronoWiz.csproj -f net8.0-maccatalyst -c Release -p:MtouchLink=SdkOnly -p:CreatePackage=true -p:EnableCodeSigning=true  -p:CodesignKey="Apple Development: Eigil Krogh (M39X2ZPF3C)" -p:CodesignProvision="ChronoWiz Dvl MacCatalyst" -p:CodesignEntitlements="Platforms/MacCatalyst/Entitlements.Release.plist" -p:UseHardenedRuntime=true -o ".\Packs"

@REM dotnet build -t:Clean
@REM dotnet clean
@REM dotnet publish ChronoWiz\ChronoWiz.csproj -f net8.0-maccatalyst -c Release -p:MtouchLink=SdkOnly -p:CreatePackage=true -p:EnableCodeSigning=true  -p:CodesignKey="Apple Development: Eigil Krogh (M39X2ZPF3C)" -p:CodesignProvision="ChronoWiz Profile Development MAC" -p:CodesignEntitlements="Platforms\MacCatalyst\Entitlements.Release.plist" -p:UseHardenedRuntime=true -o "d:\Users\eigil\Downloads\"