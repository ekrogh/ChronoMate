dotnet publish -f net8.0-maccatalyst -c Release -p:MtouchLink=SdkOnly -p:CreatePackage=true -p:EnableCodeSigning=true  -p:CodesignKey="Apple Distribution: Eigil Krogh (4657Q2Y6NH)" -p:CodesignProvision="ChronoWiz Profile Development MAC" -p:CodesignEntitlements="Platforms\MacCatalyst\Entitlements.Release.plist" -p:UseHardenedRuntime=true