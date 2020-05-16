# 1920-b1-be-JordyVanKerkvoorde
__zie ook aangemaakte wiki op deze github repo__
## Info
De bedoeling is om de live data van Open Data Portaal Gent<sup>1</sup> aan te spreken en die data op te slaan in een MSSQL database.
Deze data dient dus doorgegeven te worden aan de SQL server. Nadien kan de data uit de database bevraagd worden door de frontend d.m.v. een call naar mijn API.
De reden dat ik ervoor kies om deze data toch op te slaan in een database is om nadien analyses en voorspellingen te kunnen doen naar de bezettingsgraad in een specifieke parking op een bepaald uur.

Dat ik de server applicaties direct naar de database laat posten is omdat er anders nog een stap tussen het process zit (de API POST) en dat dit mogelijks de applicatie sterk kan vertragen. 

## Future proof
Door de manier waarop het nu werkt is de app ook altijd up to date, zelfs als Stad Gent beslist om de data van een andere parking ook vrij te geven zal dit automatisch aan de database toegevoegd worden en zal dit dus ook d.m.v. de API kunnen aangesproken worden.

Indien ik andere steden aan de applicatie wil toevoegen, kan dat via een nieuwe server applicatie aan te maken.

# .NET API
## instellingen
~De database draait op een externe server thuis bij een vriend van me, aangezien die liever niet zijn IP en credentials publiek stelt heb ik er dan ook voor gekozen dit te respecteren en deze informatie in de connectionstring te censureren. Echter ben ik op dit moment nog zelf bezig met het opstellen van mijn eigen server dus in de komende week zal (hopelijk) de database en serverapplicaties op mijn server staan. Als dit dan echt nodig is kan ik dan wel de nodige info doorgeven om de applicatie lokaal te kunnen runnen.~

Op dit moment word de API nog niet gehost.

De SQL server database en nodejs app werd op een DigitalOcean server geplaatst om zo de inloggegevens te kunnen meegeven:

- IP: 178.62.218.13
- Poort: 1433
- Gebruikersnaam: SA
- Wachtwoord: Admin20204Parkade763325

# node.js
De node.js kant bestaat uit server applicaties die op de achtergrond draaien om zo de data van Open Data Portaal Gent<sup>1</sup> te filteren naar nuttige data voor mijn project en dit door te sturen naar de SQL database, dit wordt om de 5 minuten geupdate. Op dit moment is enkel de data van de auto parkeergarages up to date en aan de database gelinkt, de fietsenstallingen volgen, maar dit zou geen effect mogen hebben op de API noch de database. (Databasegegevens zie instellingen .NET API)

*__P.S.:__ Sinds een tijdje is er nu Deno (https://deno.land/), een soort node.js 2.0 met built in typescript support, jammer genoeg heb ik geen dedicated sql server library gevonden voor het framework daarmee dus de reden om toch node.js te kiezen voor deze applicatie.*

# Swagger
![swagger](https://user-images.githubusercontent.com/44192604/77856215-eddf9300-71f5-11ea-8e77-49558436736d.PNG)

![LatestEntry](https://user-images.githubusercontent.com/44192604/77856222-f89a2800-71f5-11ea-86f0-26ca69195839.PNG)

![AllParkings](https://user-images.githubusercontent.com/44192604/77856225-02239000-71f6-11ea-9776-9449e8b18e66.PNG)

![Parking](https://user-images.githubusercontent.com/44192604/77856229-0a7bcb00-71f6-11ea-9bb6-ff2e936a66f7.PNG)

![image](https://user-images.githubusercontent.com/44192604/81346437-8f41ea80-90ba-11ea-9515-62a9ade3948f.png)

![image](https://user-images.githubusercontent.com/44192604/81346496-a8e33200-90ba-11ea-83e0-5c53bc32a46f.png)

![image](https://user-images.githubusercontent.com/44192604/81346539-bd272f00-90ba-11ea-9c94-85c0cea68449.png)

# Class Diagram
![class](https://user-images.githubusercontent.com/44192604/77858683-410d1200-7205-11ea-89ea-a27c055c7c1f.PNG)

# Backend document

![Knipsel](https://user-images.githubusercontent.com/44192604/77860533-3146fb00-7210-11ea-8662-1a1b6b8cef26.PNG)


# Vragen
 - Op de manier waarop ik de applicatie maak is er geen nood aan een Initalizer/seeder in de context, de data komt vanuit de serverapplicaties en ik maak dan ook een connectie met een externe zelf gecreëerde database. Is dit een probleem, of mag dit zo behouden worden?

- Door bovenstaande is er ook geen nood aan mappings binnen de API, mag dit ook zo blijven?

- Op dit moment is er geen nood aan POST methodes, is het verplicht POST/PUT methodes te hebben in je API?

- Mijn domeinklassen hebben nog geen gedragsmethodes, is dit van belang?




# Referenties
<sup>1</sup> https://data.stad.gent/explore/?flg=nl&disjunctive.keyword&disjunctive.theme&sort=modified
