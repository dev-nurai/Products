# Products

 This is a sample project that demonstrates how to build a web application that displays a list of products and their prices. The data for the products is stored in a MSSQL Server database and retrieved using Dapper.
<br/>
The application consists of the following pages:
 - Home page: displays a list of products and their prices.
 - Add Product page: allows the user to enter a new product and its price. The data is saved to the database using Dapper.
 - Edit Product page: allows the user to update the details of an existing product. The data is saved to the database using Dapper.
 - Delete Product page: allows the user to delete an existing product. The data is removed from the database using Dapper.
 - The layout of the application uses HTML, CSS, and JavaScript/jQuery to provide a responsive user interface.

 ### Technologies Used
 - ASP.NET Core 6.0
 - Dapper
 - MSSQL Server
 - HTML/CSS
 
 ### Getting Started
 To run this project on your machine, follow these steps:
 - Clone the repository to your local machine using Git.
 - Open the project in Visual Studio or another code editor of your choice.
 - Open the appsettings.json file and modify the connection string to match your MSSQL Server database configuration.
 - Open the Package Manager Console and run the following command to create the database tables: Update-Database.
 - Build and run the project.
