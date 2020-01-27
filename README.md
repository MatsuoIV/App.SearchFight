# App.SearchFight


.NET Console App that queries search engines and compares how many results they return, for Example:

```
C:\SearchFight.exe .net java
```

```
.net: Google: 13200000 Bing: 15600000
java: Google: 405000 Bing: 20700000
Google winner: .net
Bing winner: java
Total winner: .net
```
### Notes

This app works using two search engines (Google and Bing). You need the following params for the app to work correctly:

* Google API Key
* Google Custom Engine Key
* Bing Suscription Key
* Bing Configuration Id

Replace these params in the App.Config file located in the interface layer.

```
    <add key="GoogleAPIKey" value="GOOGLE_API_KEY"/>
    <add key="GoogleSearchID" value="GOOGLE_SEARCH_ID"/>
    <add key="BingSuscriptionKey" value="BING_SUSCRIPTION_KEY"/>
    <add key="BingConfigurationId" value="BING_CONFIG_ID"/>
```
