# EAN Product Lookup Web Interface 

This project offers a web interface for searching product references using an EAN (European Article Number). It pulls product details from a MySQL database and employs the Barcode Lookup API to obtain product specifics from various retailers.

## Features 

- **Search by EAN:** Users can input the EAN to access product details.
- **MySQL Integration:** Retrieves product reference, description, price, and other relevant data from a MySQL database.
- **Barcode Lookup API:** Leverages the Barcode Lookup API to pull product details from diverse stores.
- **Display Product Info:** Showcases product reference, description, price, and an accompanying image.
- **Display Store Prices:** Enumerates product prices from multiple stores in various currencies (USD, GBP, EUR) juxtaposed with a reference price.

## Installation 

1. Ensure ASP.NET Core is installed on your system.
2. Clone the repository:
    ```bash
    git clone [repository-link]
    ```
3. Navigate to the repository directory:
    ```bash
    cd [repository-name]
    ```
4. Set up your MySQL database and revise the `connectionString` in the `SearchEan` method to match your settings.
5. Replace the `api_key` in the `SearchStores` method with your Barcode Lookup API key.
6. Launch the application:
    ```arduino
    dotnet run
    ```
7. Open your preferred web browser and head to `http://localhost:5000`.

## Usage 

- Input the desired product's EAN in the given field.
- Press the search button.
- Examine the product details and contrast prices across different retailers.

## Dependencies 

- **ASP.NET Core Razor Pages:** Powers the web interface.
- **MySql.Data:** Enables MySQL database interactions.
- **Newtonsoft.Json:** Assists in parsing JSON responses from the Barcode Lookup API.

## Contributing 

Pull requests are wholeheartedly encouraged. For substantial alterations, please initiate an issue first to deliberate on your intended modifications.

## License 

MIT
