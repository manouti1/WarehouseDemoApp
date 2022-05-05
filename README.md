
# Warehouse Demo App

WarehouseDemoApp is a .net core and angular sqlite shopping cart application where user can browse cars and add items to cart

## Tech Stack

**Client:** Angular,bootstrap

**Server:** .net core 3.1, EFCore ,sqlite

## Architecture Used

**Server**

The architecture used on the server is the repository pattern and unit of work as well as dependency injection to utilize usage inside controller.

First time to run the application, you will need to run migrations to sqlite db as it is reading data from file. To run migrations you should use the following command from nugget package manager:
```bash
 dotnet ef migrations add InitialCreate
```
The above command should add your first migrations

```bash
 dotnet ef database update
```
The above command will create your database and create your schema from the migration

**Client**

You will find the code inside the solution in a folder called ClientApp, the following uses library called ngboostrap which is a nice library to use along with angular for styling and have some ready made components. You will notice inside the app folder a shared folder which reperesents all services used in the application. The main components of the angular app are the following:

1. CarComponent (list all cars by date asc)
2. CarDetailsComponent (to get details of specific car)
3. ShoppingCartComponent (for adding items to cart, this uses the localstorage to save data of the items added)

## How to run

**Server**
 From visual studio you only need to run the application.

 **Client**
Open command line and run the following commands:

```bash
 npm install
```
Once done run the following:

```bash
 ng serve
```

