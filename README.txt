Step 1: Configure the Database Connection
1.	Open the appsettings.json file.
2.	Add your database connection string under the ConnectionStrings section

Step 2: Configure the DbContext
1.	Open the Startup.cs file.
2.	Ensure that the AppDbContext is configured in the ConfigureServices method and verify connection string key name. It should be 
same as appsetting.json file connection string.

Step 3: Add Initial Migration
1.	Open the Package Manager Console in Visual Studio by navigating to Tools > NuGet Package Manager > Package Manager Console.
2.	Run the following command to add an initial migration:
 Add-Migration InitialCreate

Step 4: Update the Database
1.	In the Package Manager Console, run the following command to apply the migration and create the database:
Update-Database

Step 5: Verify the Database
1.	Open SQL Server Management Studio (SSMS) or any other database management tool.
2.	Connect to your SQL Server instance.
3.	Verify that the database PizzaExpressDb has been created and that it contains the necessary tables.

Step 6: Run the Application
1.	Press F5 or click on the Start button in Visual Studio to run the application.
2.	The application should now be connected to the database, and you can interact with the API endpoints.