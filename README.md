Za otvaranje i pokretanje projekta su potrebne najnovije verzije sljedećih programa: Visual Studio i SQL Server (Express)

U Solutionu se nalaze tri projekta: 'BackendApp', 'BackendApp.DAL' i 'BackendApp.test'

Prije prvog pokretanja aplikacije potrebno je uraditi sljedeće: 

1. U projektu 'BackendApp.DAL -> Context - -> AppDbContext.cs na liniji 13 podesiti connection string
2. Podesiti projekat 'BackendApp.DAL' kao Start Up Project u Solution Exploreru 
3. Otvoriti 'Package Manager Console' 
4. Podesiti projekat 'BackendApp.DAL' kao Default Project u 'Package Manager Console'  
5. Izvršiti komandu 'Add-Migration InitMigration' 
6. Izvršiti komandu 'Update-Database'
7. Podesiti projekat 'BackendApp' kao Start Up Project   
8. Pokrenuti aplikaciju
