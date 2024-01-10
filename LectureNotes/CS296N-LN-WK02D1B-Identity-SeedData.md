**CS296N Web Development 2: ASP.NET**                                                        

<h1>Creating Seed Data with the User Manager</h1>



| Weekly topics                     |                                |
| --------------------------------- | ------------------------------ |
| <mark>1. Intro to Identity</mark> | 6. Complex domain models       |
| 2. Authentication                 | 7. A more complex domain model |
| 3. Authorization                  | 8. Validation                  |
| 4. Async/Await                    | 10. Term project               |
| 5. Load testing and performance   | 11. Project presentations      |



<h2>Contents</h2>

[TOC]

## Introduction

- Q and A
- Reminder to check Azure credit balances



## Identity UserManager

When we added Identity to our project, we removed the `DbSet` for our user from our`DbContext` class. This is because the user table in the database is now managed by Identity. Instead of using the DbContext to do CRUD operations with our AppUser model, we will do all of those operations using the Identity `UserManager` service.

### Adding a User in Seed Data with the UserManager

As an example of how to use the UserManager service, we will refactor our SeedData to use the UserManager.

1. Modify the code in Program.cs that calls the `SeedData.Seed method` to pass in an instance of `IServiceProvider` which is needed in order to get an instance of `UserManager`

```c#
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider
      .GetRequiredService<ApplicationDbContext>();
    SeedData.Seed(context, scope.ServiceProvider);
}
```

2. In the SeedData.Seed method, add code to get a UserManager object.

   ```c#
   public static void Seed(ApplicationDbContext context, IServiceProvider provider)
   {
      // code omittted 
      var userManager = provider
        .GetRequiredService<UserManager<AppUser>>();
   ```

3. Create users with the UserManager.

   ```c#
    const string SECRET_PASSWORD = "Secret!123";
    AppUser emmaWatson = new AppUser { UserName = "Emma Watson" };
    var result = userManager.CreateAsync(emmaWatson, SECRET_PASSWORD);
   ```

   

## Example Code on GitHub

- Instructor's Demo Web App using ASP.NET Core 6.0: [BookInfo&mdash;SeedData](https://github.com/LCC-CIT/CS296N-Example-BookReviews-DotNet6/tree/02-SeedData)

## References

*Murach’s ASP.NET Core MVC*, Second Edition, Mary Delamater and Joel Murach, 2022

- Ch. 16, "How to Authenticate and Authorize Users"

------



## Conclusion

- Review due dates on Moodle
- Talk about the lab assignment



## Footnotes

*CreateScope* is a method that creates a new scope for the specified service provider. It is used to create a new scope for resolving dependencies. The IServiceScope instance returned by CreateScope is used to resolve dependencies within the scope of the created scope. The IServiceScope instance is also used to dispose of the scope and any resources that were created within it when it is no longer needed. 

*Scoped services* are registered using the AddScoped method of the IServiceCollection interface. When a scoped service is requested, a new instance of the service is created within the scope of the current request. The same instance is then used for all subsequent requests within that same scope. [Microsoft Learn, Scoped Services](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection#scoped)

------



[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png) ](http://creativecommons.org/licenses/by-sa/4.0/)
ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev), written winter 2022, revised winter 2024, is licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 

