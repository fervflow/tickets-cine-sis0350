In Entity Framework (EF), you can execute stored procedures in a similar way to LINQ to SQL, though the approach is slightly different. Here’s how you can use your existing stored procedures with EF, specifically with **Entity Framework Core**.

### Steps to Call Stored Procedures in Entity Framework Core:

1. **Install Entity Framework Core**:
   - In Visual Studio, go to `Tools > NuGet Package Manager > Manage NuGet Packages for Solution...`
   - Search for `Microsoft.EntityFrameworkCore.SqlServer` and install it in your project.

2. **Generate the DbContext**:
   If you want to work with your database, including stored procedures, you need to generate the DbContext and related entity classes.

   You can do this via the **scaffold** command in the **Package Manager Console**:
   ```bash
   Scaffold-DbContext "YourConnectionString" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
   ```

   This command will generate a `DbContext` class for your database.

3. **Use Stored Procedures**:
   Entity Framework provides a few different ways to call stored procedures. Here are the most common methods:

   - **Using `FromSqlRaw()`** for queries that return data:
     If your stored procedure returns data, you can map the result to a model class like this:
     ```csharp
     var result = context.YourEntity
                         .FromSqlRaw("EXEC dbo.YourStoredProcedure @param1, @param2", param1Value, param2Value)
                         .ToList();
     ```

   - **Using `ExecuteSqlRaw()` for non-query commands**:
     If your stored procedure performs actions like inserting, updating, or deleting without returning a result set, you can use:
     ```csharp
     var rowsAffected = context.Database.ExecuteSqlRaw("EXEC dbo.YourStoredProcedure @param1, @param2", param1Value, param2Value);
     ```

4. **Map Stored Procedure Results to Custom Models**:
   If your stored procedure returns a complex result that doesn't map directly to a database table, you can create a custom class to represent the result:
   ```csharp
   public class CustomResult
   {
       public int Column1 { get; set; }
       public string Column2 { get; set; }
   }
   ```

   Then, use `FromSqlRaw()` to map the result:
   ```csharp
   var result = context.CustomResult
                       .FromSqlRaw("EXEC dbo.YourStoredProcedure @param1", param1Value)
                       .ToList();
   ```

5. **Passing Parameters**:
   You can pass parameters safely using `SqlParameter` objects to avoid SQL injection:
   ```csharp
   var param1 = new SqlParameter("@param1", param1Value);
   var result = context.YourEntity
                       .FromSqlRaw("EXEC dbo.YourStoredProcedure @param1", param1)
                       .ToList();
   ```

### Summary of Key Methods:
- **`FromSqlRaw()`**: For executing stored procedures that return a result set.
- **`ExecuteSqlRaw()`**: For executing stored procedures that don't return data (e.g., updates, inserts).
- **SqlParameters**: For safely passing parameters to stored procedures.

Would you like a more detailed example, or do you want to see how to handle something specific with your stored procedures?