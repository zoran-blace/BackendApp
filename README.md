Proces prvog pokretanja projekta je malo 'neobičan' iz razloga jer sam naišao na neke probleme sa kompatibilnošću Microsoftovih frameworka koje nisam znao da zaobiđem, za sad :-) 

Za otvaranje i pokretanje projekta su potrebne najnovije verzije sljedećih programa: Visual Studio i SQL Server (Express)

U Solutionu se nalaze tri projekta: 'BackendApp', 'BackendApp.DAL' i 'BackendApp.test'

Prije prvog pokretanja aplikacije potrebno je uraditi sljedeće: 

1. U projektu 'src -> BackendApp.DAL -> Context -> AppDbContext.cs na liniji 13 podesiti connection string
2. Podesiti projekat 'src -> BackendApp.DAL' kao Start Up Project u Solution Exploreru 
3. Otvoriti 'Package Manager Console' 
4. Podesiti projekat 'src -> BackendApp.DAL' kao Default Project u 'Package Manager Console'  
5. Izvršiti komandu 'Add-Migration InitMigration' 
6. Izvršiti komandu 'Update-Database'
7. Podesiti projekat 'src -> BackendApp' kao Start Up Project   
8. Pokrenuti aplikaciju

U slučaju nekih problema sa svim ovim, na mail sam proslijedio sql skriptu koja kreira i popunjava bazu testnim podacima i mijenja sve gore navedene korake
