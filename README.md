# 1920-b1-be-JordyVanKerkvoorde
## Info
De bedoeling is om de live data van Open Data Portaal Gent<sup>1</sup> aan te spreken en die data op te slaan in een MSSQL database.
Deze data dient dus doorgegeven te worden aan de SQL server. Nadien kan de data uit de database bevraagdworden door de frontend d.m.v. een call naar mijn API.
De reden dat ik ervoor kies om deze data toch op te slaan in een database is om nadien analyses en voorspellingen te kunnen doen naar de bezettingsgraad in een specifieke parking op een bepaald uur.

De reden dat ik de server applicaties direct naar de database laat posten is omdat er anders nog een stap tussen het process zit (de API POST) en dat dit mogelijks de applicatie sterk kan vertragen. 

## Future proof
Door de manier waarop het nu werkt is de app ook altijd up to date, zelfs als stad gent beslist om de data van een andere parking ook vrij te geven zal dit automatisch aan de DB toegevoegd worden en zal dit dus ook d.m.v. de API kunnen aangesproken worden.

Indien ik andere steden aan de applicatie wil toevoegen hoef ik normaal enkel een nieuwe server applicatie aan te maken.

# .NET API

# node.js
De node.js kant zijn server applicaties die op de achtergrond draaien om zo de data van Open Data Portaal Gent<sup>1</sup> te filteren naar nuttige data voor mijn project en dit door te sturen naar de SQL database, dit wordt om de 5 minuten geupdate.

# Swagger
![swagger](https://user-images.githubusercontent.com/44192604/77856215-eddf9300-71f5-11ea-8e77-49558436736d.PNG)

![LatestEntry](https://user-images.githubusercontent.com/44192604/77856222-f89a2800-71f5-11ea-86f0-26ca69195839.PNG)

![AllParkings](https://user-images.githubusercontent.com/44192604/77856225-02239000-71f6-11ea-9776-9449e8b18e66.PNG)

![Parking](https://user-images.githubusercontent.com/44192604/77856229-0a7bcb00-71f6-11ea-9bb6-ff2e936a66f7.PNG)

# Referenties
<sup>1</sup> https://data.stad.gent/explore/?flg=nl&disjunctive.keyword&disjunctive.theme&sort=modified
