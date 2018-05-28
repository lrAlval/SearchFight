# SearchFight :mag_right:

Simple Console App that queries search engines and compares how many results they return, for Example:

```
C:\SearchFight.exe .net java
```

```
.net: Google: 13200000 MSN Search: 15600000
java: Google: 405000 MSN Search: 20700000
Google winner: .net
MSN Search winner: java
Total winner: .net
```
### Prerequisites

Because it is using the google search engine and bing , the application needs 3 keys to work :

* Google API Key
* Google Custom Engine Key
* Bing Search Engine Key

Once you have it , Just Update the following keys in the App.Config

```
    <add key="GoogleAPIKey" value="YOUR_GOOGLE_API_KEY_HERE"/>
    <add key="GoogleCEKey" value="YOUR_GOOGLE_CUSTOM_ENGINE_KEY_HERE"/>
    <add key="BingKey" value="YOUR_BING_API_KEY_HERE"/>
```

## Wanna add another search engine ?

Just add another client class and implement ISearchClient , and thats it ! 

## Deployment

Compile the solution with visual studio and the exe will be generated.

## Built With

* [Fody](https://github.com/Fody/Costura) - Embeds dependencies as resources.
* [Fluent Assertions](https://github.com/fluentassertions/fluentassertions) - To Improve readability of the tests

## License

This project is licensed under the MIT License
