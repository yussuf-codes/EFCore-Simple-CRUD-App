1. Install Entity Framework Core tools

    ```shell
    dotnet tool install --global dotnet-ef
    ```

2. Make migrations

    ```shell
    dotnet-ef migrations add <Migration Name>
    ```

3. Update the database

    ```shell
    dotnet-ef database update
    ```
