dotnet ef database drop
dotnet ef migrations add InitialCreate
dotnet ef database update


docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Apple@123123" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2019-latest
