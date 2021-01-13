**CS296N Web Development 2: ASP.NET**                                                        

 Brian Bird

# *User Management with Identity*

| Weekly topics                           |                                 |
| --------------------------------------- | ------------------------------- |
| 1. Intro to course and Input validation | 6. Load Testing and Performance |
| **2. Identity**                         | 7. Creating a Web Service       |
| 3. Authentication and authorization     | 8. Consuming a Web Service      |
| 4. Publishing to a production server    | 9. Docker containers            |
| 5. Security                             | 10. Term project                |

**Contents**

[TOC]

------

## Introduction

### What is ASP.NET Core Identity?

It is a class library (an API) for:          

- Authentication
- Authorization
- Role management
- User account management



------



## Adding Identity to a web app

### Adding the infrastructure

1. Use the NuGet package manager to add the following packages to your project:

   - Microsoft.AspNetCore.Identity.EntityFrameworkCore
                 

3. Modify your application's DbContext class to inherit from  IdentityDbContext.            

   - This provides a way for Identity to add tables for storing user information to your database.
   - All you need to do is change the inheritance.
   - Don't add a new DbSet for Identity, that will be done by the parent class.
   - Remove the DbSet for your user model, that is also managed in the parent class.

4. Modify your *user* model so that the class inherits from `IdentityUser`. 

   - If your current user class is named "User", you should change it to something else, like "AppUser" so that you don't have a conflict with a library class named "User".
   - If your user class has user name or email properties, you should remove them since they are in the new base class (see below).
   - Remove the ID property from your user class. The ID is in the base class.
   - The `IdentityUser` class has these properties:            
     - Id - This property contains the unique ID for the user. 
     - UserName - This property returns the user’s username.              
     - Claims - This property returns the collection of claims for the user.
     - Email - This property contains the user’s e-mail address. 
     - Logins - This property returns a collection of logins for the user, which can be used for third-party authentication.
     - PasswordHash - This property returns a hashed form of the user password.
     - Roles - This property returns the collection of roles that the user belongs to.
     - PhoneNumber - This property returns the user’s phone number. 
     - SecurityStamp - This property returns a value that is changed when the user identity is altered, such as by a password change. 
                              

4. In Startup.cs, `ConfigureServices`, add:

   ```C#
   services.AddIdentity<AppUser, IdentityRole>()
       .AddEntityFrameworkStores<AppDbContext>()
       .AddDefaultTokenProviders();
   ```

   The `AddIdentity` method has generic type specifiers for the user class and the built-in `IdentityRole` class for roles.            

   - The `AddEntityFrameworkStores` method specifies that Identity should use Entity Framework Core to store and retrieve its data, using the application's database context class. 
   - The `AddDefaultTokenProviders` method uses the default configuration to support operations that require a token, such as changing a password.
                   

6. In Startup.cs, `Configure`, add:
    `app.UseAuthentication();`
             

7. Add a migration for the new user model and update the database using these CLI commands:

   ```powershell
dotnet ef migrations add Identity
   dotnet ef database update
   ```

After adding Identity to your project, Inspect the database using SQL Server Object Explorer and note the new tables added by Identity. The tables listed below should have been created.

- AspNetRoleClaims

- AspNetRoles

- AspNetUserClaims

- AspNetUserLogins

- AspNetUserRoles

- AspNetUsers&mdash;this is your user table, it contains the fields you added in your own user class.

- AspNetUserTokens

- Using Identity in administrative pages

##### 



------





## References

### Basic

- *Murach’s ASP.NET Core MVC*, Mary Delamater and Joel Murach, 2020
  - Ch. 16, "How to Authenticate and Authorize Users"
- *Pro ASP.NET Core 2*, Adam Freeman, 2017            
- Ch. 28 – Getting Started with Identity
  
  - Ch. 12, pg. 321–330, SportsStore: Securing the Administration Features
- [Introduction to Identity in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/?view=aspnetcore-3.1)

### Advanced

-  [ HTTP Authentication Mechanisms](https://code-maze.com/http-series-part-4/)
-  [Exploring the  ASP.NET Core Identity Password Hasher](https://andrewlock.net/exploring-the-asp-net-core-identity-passwordhasher/)



------

## Example Code on GitHub

- Pro ASP.NET Core MVC 2, Ch. 28: [Identity example](https://github.com/Apress/pro-asp.net-core-mvc-2/tree/master/28%20-%20Identity/Users)
- Instructor's Demo Web App using ASP.NET Core 3.1: [BookInfo&mdash;Identity branch](Instructor's Demo Web App using ASP.NET Core 2.2: [BookInfo&mdash;AddIdentity branch](https://github.com/LCC-CIT/CS296N-BookInfo-Core-2/tree/AddIdentity))
------



## Next Class

- We will add pages that use Identity for registration and login (authentication)
- We will restrict different parts of the web app based on user role (authorization)
            

------

[ ![Creative Commons License](https://i.creativecommons.org/l/by/4.0/80x15.png)](http://creativecommons.org/licenses/by/4.0/) [ASP.NET Core MVC Course Materials](http://lcc-cit.github.io/CS296N-CourseMaterials/) by [ Brian Bird](https://profbird.dev), written winter 2017, revised winter 2021 are licensed under a [Creative Commons Attribution 4.0 International License](http://creativecommons.org/licenses/by/4.0/). 
    

------

