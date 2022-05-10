# ShopAPI
25Friday exercise - Web API for Starbucks inventory/order management


Used VisualStudio + SQLExpress server
Developed in .NET 5 framework with usage of EFCore.


Available through https://localhost:5001/shopapi/Order  (I left base Category, Product and Extra controllers active since it is easier to do ad-hoc actions) but Order should be the one used. 
It allows for a POST request with JSON structured data.

Example of data:
{
  "productIDs": [
    3, 5, 9
  ],
  "extraIDs": [
    2, 4
  ],
  "valuePaid": 25
}

The API will validate existence of products/extras, stock availability and if customer paid enough and will respond accordingly.


# Notes
Connection string available in appsettings.json .
There is a DB generation script in DBScript.sql file at root folder.
There is a Data Generator/Initializer for populating the database running on startup (if data is not already in DB) (code file Data/DbDataInitializer.cs).


# Issues
Had issues running outside VisualStudio due to computer security policies and was going to dockerize the solution but Docker also had security issues while installing. Will try, regardless, to get hold of a different computer to do it (will make a separate repository for it since it's "out of time" development).


