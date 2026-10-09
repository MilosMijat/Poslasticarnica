# Poslastičarnica

Desktop aplikacija za evidenciju mušterija, poslastica i porudžbina u poslastičarnici. Razvijena je u jeziku C#, uz Windows Forms korisnički interfejs, klijent–server arhitekturu i SQL Server bazu podataka.

## Funkcionalnosti

- Prijava prodavca pomoću korisničkog imena i šifre.
- Unos, pretraga, izmena i brisanje mušterija, uz podršku za fizička i pravna lica.
- Unos poslastica sa nazivom, vrstom, cenom i opisom.
- Kreiranje, pretraga, izmena i brisanje porudžbina i njihovih stavki.
- Evidencija količina i iznosa stavki, kao i ukupnog iznosa porudžbine.
- Pregled porudžbina za izabranu mušteriju.
- Unos stručnih sprema i povezivanje sa prodavcima, uz stepen i datum sticanja.
- Pokretanje i zaustavljanje servera kroz zasebnu formu.

## Tehnologije

- C# i .NET 8
- Windows Forms
- Microsoft SQL Server
- ADO.NET i `Microsoft.Data.SqlClient`
- TCP soketi za komunikaciju klijenta i servera
- JSON serijalizacija pomoću `System.Text.Json`

## Organizacija projekta

| Projekat / folder | Namena |
| --- | --- |
| `Client` | Klijentske forme i slanje zahteva serveru. |
| `PoslasticarnicaNova` (`Server1.csproj`) | Serverska aplikacija, obrada zahteva i sistemske operacije. |
| `Common` | Domenski modeli, zahtevi, odgovori i JSON mrežni serijalizator. |
| `DBBroker` | Pristup bazi, izvršavanje SQL naredbi i upravljanje transakcijama. |

Klijent šalje zahtev serveru preko TCP veze. Server poziva odgovarajuću sistemsku operaciju, pristupa bazi preko brokera i vraća odgovor klijentu. Sistemske operacije koriste zajednički obrazac za otvaranje konekcije, početak transakcije, potvrdu ili poništavanje promena i zatvaranje konekcije.

## Preduslovi

- Windows, zbog Windows Forms aplikacija.
- .NET 8 SDK.
- SQL Server instanca kojoj aplikacija može da pristupi.
- Za rad kroz Visual Studio: instalirana podrška za .NET desktop razvoj i .NET 8.

## Podešavanje baze

**SQL skripta za kreiranje baze i rezervna kopija baze trenutno nisu priložene projektu.** Pre korišćenja aplikacije potrebno je obezbediti bazu sa odgovarajućom šemom i početnim podacima. Aplikacija ne kreira bazu automatski.

Konekcija je definisana u fajlu [`DBBroker/DbConnection.cs`](DBBroker/DbConnection.cs). Prilagodi `Data Source` svojoj SQL Server instanci i `Initial Catalog` nazivu baze. Primer za lokalni SQL Server Express:

```csharp
connection = new SqlConnection(
    @"Data Source=.\SQLEXPRESS;Initial Catalog=PS_Poslasticarnica2;Integrated Security=True;Encrypt=False");
```

Ovaj primer koristi Windows autentifikaciju. Windows nalog pod kojim se pokreće server mora imati pristup bazi.

Domenski model obuhvata tabele `Prodavac`, `Musterija`, `Fizicko_Lice`, `Pravno_Lice`, `Grad`, `Poslastica`, `Porudzbina`, `Stavka_Porudzbine`, `Strucna_Sprema` i `PrSS`. Opis atributa i ograničenja nalazi se u [dokumentaciji entiteta](dokumentacija_tabela_entiteta.md); ona nije zamena za SQL skriptu sa tačnom šemom.

Za prijavu je potreban postojeći zapis prodavca u bazi. Unapred popunjena polja na formi za prijavu ne kreiraju korisnički nalog. Za izbor grada pri unosu mušterije potrebno je popuniti i tabelu `Grad`.

## Pokretanje

### Iz terminala

U folderu koji sadrži `PoslasticarnicaNova.sln` obnovi pakete i izgradi rešenje:

```powershell
dotnet restore PoslasticarnicaNova.sln
dotnet build PoslasticarnicaNova.sln
```

Pokreni serversku aplikaciju:

```powershell
dotnet run --project PoslasticarnicaNova/Server1.csproj
```

U serverskoj formi klikni na **POKRENI**. Zatim u drugom terminalu, iz istog foldera, pokreni klijenta:

```powershell
dotnet run --project Client/Client.csproj
```

Prijavi se podacima prodavca koji postoji u bazi.

### Iz Visual Studio-a

1. Otvori `PoslasticarnicaNova.sln`.
2. Obnovi NuGet pakete i izgradi rešenje.
3. Pokreni projekat `Server1` i u njegovoj formi klikni na **POKRENI**.
4. Dok server radi, pokreni projekat `Client`.
5. Prijavi se i iz glavnog menija izaberi željenu funkcionalnost.

### Mrežna podešavanja

Klijent i server trenutno koriste adresu `127.0.0.1` i port `9999`, pa su podešeni za rad na istom računaru. Vrednosti su definisane u fajlovima [`Client/Communication.cs`](Client/Communication.cs) i [`PoslasticarnicaNova/Server.cs`](PoslasticarnicaNova/Server.cs).

Klijent pokušava povezivanje prilikom otvaranja forme za prijavu, zato server treba pokrenuti prvi.

## Česti problemi

| Problem | Šta proveriti |
| --- | --- |
| Klijent ne može da se poveže sa serverom | Da li je u serverskoj formi pritisnuto **POKRENI** i da li oba projekta koriste istu adresu i port. Posle pokretanja servera ponovo pokreni klijenta. |
| Greška pri pristupu bazi | Naziv SQL Server instance, naziv baze, dostupnost servisa i prava Windows naloga. |
| Prijava nije uspešna | Da li u bazi postoji prodavac sa unetim korisničkim imenom i šifrom. |
| Lista gradova je prazna | Da li tabela `Grad` sadrži podatke. |
| Server ne može da zauzme port | Da li druga instanca aplikacije ili drugi proces već koristi port `9999`. |
