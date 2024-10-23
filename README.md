# Pizzeria

This project is a pizza ordering system that allows users to create, update, and list their pizza orders.

## Installation
### Clone the repository
```bash
git clone https://github.com/EmmanuelGreene/pizzeria.git
```
### Restore dependencies and set up the database
```bash
dotnet restore
dotnet ef database update
```

### Running the Project
```bash
dotnet run
```
you can access it via http://localhost:5000.

## Testing
To run the automated tests
```bash
dotnet test
```

## Design Decisions
 - Used Entity Framework Core for database interactions.
 - Chose an In-Memory database for unit testing to ensure tests run quickly and do not require external dependencies.

## You can access below url and test the GraphQL apis.
```bash
http://3.16.187.201:5000/graphql/
```
