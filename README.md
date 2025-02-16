# DbTestingExample

## Overview
This repository provides an example of database integration tests in a .NET project using Entity Framework Core and xUnit. It demonstrates how to test database interactions efficiently by ensuring data operations work as expected.

## Features
- Uses **Entity Framework Core** for database interactions.
- Implements **xUnit** for writing and executing tests.
- Utilizes **SQLite** as an in-memory database for testing.
- Ensures **repeatable tests** with a seeding mechanism.

## Structure
- **Database Seeding:** Before each test, the database is reset and populated with predefined data to ensure consistency.
- **Integration Tests:** Verifies key functionalities, such as:
  - Retrieving all items from the database.
  - Adding a new item and ensuring it is stored correctly.
  - Assigning tags to an item and verifying the updates.
- **SQLite Provider:** The tests are executed using SQLite as the database provider, making it lightweight and easy to configure.

## Test Cases
The following test scenarios are included:
1. **Retrieve Items** – Ensures that all pre-seeded items are fetched correctly.
2. **Add Item** – Validates that a new item can be added and later retrieved.
3. **Assign Tags** – Confirms that tags can be associated with an item and stored properly.

## How to Use
1. Clone the repository:
   ```sh
   git clone <repository-url>
   ```
2. Navigate to the project directory and build the solution:
   ```sh
   dotnet build
   ```
3. Run the tests:
   ```sh
   dotnet test
   ```

## Dependencies
- .NET Core
- Entity Framework Core
- SQLite (for testing purposes)
- xUnit (for testing framework)

## License
This project is open-source and available under the [MIT License](LICENSE).

