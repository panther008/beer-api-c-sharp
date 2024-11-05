# Beer Collection API
A .NET Core web-based backend service to manage a beer collection.
This API supports creating, listing, updating, and searching for beers.
It is designed to be efficient and suitable for integration with a front-end application.

### Features
- **Add a new beer**: Save a beer with name, type, and optional rating.
- **List all beers:** Retrieve all beers in the collection.
- **Search beers by name**: Search for beers by partial or full name.
- **Update rating:** Add a new rating that updates the beer’s average rating.

### Tech Stack
- **Backend**: .NET Core Web API
- **Database**: SQL Server (can be configured in appsettings.json)
- **Documentation**: Swagger for API documentation

### Setup and Installation
**- 1. Clone the repository:**
```
git clone https://github.com/yourusername/beer-collection-api.git
cd beer-collection-api
```

**- 2. Configure the database connection:**

- Update the DefaultConnection string in appsettings.json to point to your SQL Server instance.


**- 3. Run migrations to set up the database:**
```
dotnet ef database update

```

**- 4.Run the application:**
```
dotnet run
```
**- 5.Access the API documentation:**
- The Swagger UI will be available at http://localhost:<port>/swagger after running the app.

### Project Structure
- **Controllers**: Contains the BeerController which handles API requests.
- **Models**: Defines the Beer model.
- **Services**: Implements the BeerService for managing CRUD operations and rating logic.
- **Data**: Handles database configuration and setup.

### Key Endpoints
- **POST /api/beers:** Add a new beer.
- **GET /api/beers:** Retrieve all beers.
- **GET /api/beers/search?query={name}**: Search for beers by name.
- **PUT /api/beers/{id}/rate:** Update the rating of a beer.

### Sample Requests
**-  Add a Beer**
```
POST /api/beers
Content-Type: application/json
{
  "name": "IPA",
  "type": "Pale Ale",
  "rating": 4
}
```
- **Get All Beers**
```
GET /api/beers
```

- **Search for Beers**
```
GET /api/beers/search?query=ipa

```

- **Update Beer Rating**
```
PUT /api/beers/{id}/rate
Content-Type: application/json
{
  "rating": 5
}
```
