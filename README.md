1 NF Hotellapp:

Min tabell innehåller info och värden som behövs och tillämpas i appen. Värdena innehåller namn, efternamn, bokningsdatum, ID osv. 
Raderna är unika då varje rum och gäst har sina namn och typ.

I detta fall när man skapar en ny bokning eller gäst så spelar inte ordningen någon roll, kolumnen för start och slutdatum kan man sortera själv, även för gäst. 
Varje kolumn i min app är unik varje namn innehåller endast string och varje Bed innehåller endast int. Tabellerna i appen innehåller en primary key som är då ID.

2 NF Hotellapp:

Tabellerna för appen är ganska enkla. I varje tabell så är ”ID” primary key och varje ”ID” är unikt. 
Endast bokningstabellen innehåller foreign keys och dessa är då ID för gästerna och rum. 
Tabellerna är beroende av sin primary key som i sin tur har foreing keys för att slå ihop dessa tabeller.

3NF Hotellapp:

När 1 och 2NFs krav är uppfyllda och eftersom mina Y-axlar är primära attributer så räknas detta som 3NF.
Alla "IDs" är unika och det finns ingen datadupicering.
