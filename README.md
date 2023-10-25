EAN Product Lookup Web Interface
This project provides a web interface to search for product references using an EAN (European Article Number). It fetches product details from a MySQL database and then uses the Barcode Lookup API to get product details from various stores.

Features
Search by EAN: Input the EAN to fetch product details.
MySQL Integration: Fetches product reference, description, price, and other details from a MySQL database.
Barcode Lookup API: Uses the Barcode Lookup API to fetch product details from various stores.
Display Product Info: Displays product reference, description, price, and an image.
Display Store Prices: Lists the product prices from various stores in different currencies (USD, GBP, EUR) with a comparison to a reference price.
Installation
Ensure you have ASP.NET Core installed.

Clone the repository:

bash
Copy code
git clone [repository-link]
Navigate to the repository:

bash
Copy code
cd [repository-name]
Set up your MySQL database and update the connectionString in the SearchEan method.

Update the api_key in the SearchStores method with your Barcode Lookup API key.

Run the application:

arduino
Copy code
dotnet run
Open a web browser and navigate to http://localhost:5000.

Usage
Enter the product's EAN in the provided input field.
Click on the search button.
View the product's details and compare prices across various stores.
Dependencies
ASP.NET Core Razor Pages: For the web interface.
MySql.Data: For MySQL database interaction.
Newtonsoft.Json: For parsing JSON data from the Barcode Lookup API.
Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

License
MIT
