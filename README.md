# WebApi
WebApi and WebApplication develop with .Net Core 

### Used Librarys

. Bootstrap

. DataTables

. Font Awesome

. JQuery

. Ionicons

. Inputmask

. SweetAlert

## Technologies

- .Net Core

- Code First Migrations.

- EF

### Installation:

1. Download or clone the project and open it with Visual Studio (2017 and higher).

2. Go to appsettings.json file on BCWebApi project.

3. Changes the server value on the ConnectionString value (you can follor the comment example), change the user and password if you need it,
  if your server works with Windows Authentication set the value "Trusted_Connection" to True.
  
4. If you are in Windows, open the Package Manager Console (menu View-> Other windows-> Package Manager Console) and run the command Update-Database
   at this point we are usin EF Code First Migrations to create all the data base from our code.
   
   If you are in Mac OS, open the terminal window and go to the root folder of this project and run the following command (In Mac you´ll need
   to have Docker and Sql Server image from Docker if you dont have this requirements you can follow this link https://database.guide/how-to-install-sql-server-on-a-mac/)
   dotnet ef database update. 
   
   This command (Windows or Mac OS) will create the data base with all the tables that is need it for this projec using the values that we do on step 3.
   
5. Now just need to run the project and for an easier debug we can config our solutions to debug both Projects (WebApi and WebApplication)
   
   To do that: make a right click on the Solution name on Visual Studio and then click on "Set StartUp Projects..." and select "Multiple startup project"
   , in the Action Column select Start in both projects.
   
6. Now just click on run and thats it.
