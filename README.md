# 1920-b1-be-JordyVanKerkvoorde
## Info
De bedoeling is om de live data van Open Data Portaal Gent<sup>1</sup> aan te spreken en die data op te slaan in een MSSQL database.
Deze data dient dus doorgegeven te worden aan mijn .NET API d.m.v. een POST methode. Nadien kan de data uit de database bevraagdworden door de frontend d.m.v. een call naar mijn API.
De reden dat ik ervoor kies om deze data toch op te slaan in een database is om nadien analyses en voorspellingen te kunnen doen naar de bezettingsgraad in een specifieke parking op een bepaald uur.

# .NET API

# node.js
De node.js kant zijn server applicaties die op de achtergrond draaien om zo de data van Open Data Portaal Gent<sup>1</sup> te filteren naar nuttige data voor mijn project en dit door te sturen naar mijn .NET API, dit wordt om de 5 minuten geupdate.

# Referenties
<sup>1</sup> https://data.stad.gent/explore/?flg=nl&disjunctive.keyword&disjunctive.theme&sort=modified
