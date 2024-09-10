## 🚀 Set up:

1. Install Entity Framework Core tools

    ```shell
    dotnet tool install --global dotnet-ef
    ```

2. Make migrations

    ```shell
    dotnet-ef migrations --project Persistence add <Migration Name>
    ```

3. Add SQL Server connection string to user secrets

    ```shell
    dotnet user-secrets --project Persistence set "ConnectionStrings:DefaultConnection" "<SQL Server Connection String>"
    ```

4. Update the database

    ```shell
    dotnet-ef database --project Persistence update
    ```
