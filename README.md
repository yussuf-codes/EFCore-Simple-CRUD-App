## 🚀 Set up:

1. Install Entity Framework Core tools

    ```shell
    dotnet tool install --global dotnet-ef
    ```

2. Add migrations (if there's any)

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

5. Create a console app

    ```shell
    dotnet new console --output Test --use-program-main
    dotnet sln add Test
    ```

6. Add Persistence project reference

    ```shell
    dotnet add Test reference Persistence
    ```

7. Inside the main method, create an `ApplicationDbContext` instance

    ```csharp
    ApplicationDbContext dbContext = new();
    ```

8. Create an `INotesRepository` instance, and inject it with the `ApplicationDbContext` instance

    ```csharp
    INotesRepository repository = new NotesRepository(dbContext);
    ```

9. Create an `NotesService` instance, and inject it with the `INotesRepository` instance

    ```csharp
    NotesService service = new(repository);
    ```
