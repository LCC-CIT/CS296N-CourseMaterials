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

### This week's objective

This week you will be introduced to ASP.NET Core Identity and learn to use it to manage user accounts. You will learn to write the code to do the following operations on user accounts:        

- Create
- Delete
- Modify
- List user accounts and user information

------



## Adding Identity to a web app

### Adding the infrastructure

Follow the steps in Freeman, Ch. 28 through the end of  "Setting up the User Classes", but skip "Creating a Controller and View".

1. Use the NuGet package manager to add the following packages to your project:

2. - Microsoft.Extensions.Identity.Core
   - Microsoft.AspNetCore.Identity.EntityFrameworkCore
                 

3. Modify your application's DbContext class to inherit from  IdentityDbContext.            

   - This provides a way for Identity to add tables for storing user information to your database.
   - All you need to do is change the inheritance.
   - Don't add a new DbSet for Identity, that will be done by the parent class.
   - Remove the DbSet for your user model. Identity that is also managed in the parent class.

4. Modify your user model so that the class inherits from `IdentityUser`. 

   - If your current user class is named "User", you should change it to something else, like "AppUser" so that you don't have a conflict with a library class named "User".
   - If your  user class has user name or email properties, you should remove them since they are in the new base class (see below).
   - Remove the ID property from your user class. The ID is in the base class.
   - The IdentityUser class has these properties:            
     - Id - This property contains the unique ID for the user. 
     - UserName - This property returns the user’s username.              
     - Claims - This property returns the collection of claims for the user.
     - Email - This property contains the user’s e-mail address. 
     - Logins - This property returns a collection of logins for the user, which can be used for third-party authentication.
     - PasswordHash - This property returns a hashed form of the user password.
     - Roles - This property returns the collection of roles that the user belongs to.
     - PhoneNumber - This property returns the user’s phone number. 
     - SecurityStamp - This property returns a value that is changed when the user identity is altered, such as by a password change. 
                              

5. In Startup.cs, ConfigureServices, add:

   ```C#
   services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>()
                          .AddDefaultTokenProviders();
   ```

   The AddIdentity method has generic type specifiers for the user class and the built-in IdentityRole class for roles.            

   - The AddEntityFrameworkStores method specifies that Identity should use Entity Framework Core to store and retrieve its data, using the application's database  context class. 
   - The AddDefaultTokenProviders method uses the default configuration to support operations that require a token, such as changing a password.
                   

6. In Startup.cs, Configure, add:
    `app.UseAuthentication();`
             

7. Add a migration for the new user model and update the database.

   `dotnet ef migrations add Identity`

   `dotnet ef database update`

After adding Identity to your project, Inspect the database using SQL Server Object Explorer and note the new tables added by Identity. The tables listed below should have been created.

- AspNetRoleClaims

- AspNetRoles

- AspNetUserClaims

- AspNetUserLogins

- AspNetUserRoles

- AspNetUsers&mdash;this is your user table, it contains the fields you added in your own user class.

- AspNetUserTokens

- Using Identity in administrative pages

### Adding an admin controller and views 

We will add the controller and views Freeman describes in Ch. 28 to implement the features shown below.

#### Features

- Creating users
  -   Validating passwords
  -   Validating user names
  -   Validating e-mail addresses
- Editing user information
- Listing user
- Deleting users

#### Files

##### UserViewModels.cs

This file is intended to hold all the view models. I prefer to put each view model in it's own file. I will rename this file and class to *CreateUserViewModel*.

##### AdminController.cs

Note that there is **not** a *DbContext.AppUser* DbSet, we will be accessing the users table via *UserManager*, a class provided by Identity.

##### Create.cshtml



------



## Notes on Freeman Ch. 28

- If you are using .NET Core 2.1 or later, you don't need to add this line to the .csproj file:
               `<DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.0" />`
           
           In fact, according to [ Micrososft's documentation](https://docs.microsoft.com/en-us/dotnet/core/migration/20-21) you should not add this line.
- In Startup.cs, in the Configure method,  **`app.UseAuthentication` must precede app.UseMvc !!!**
- The app doesn't have links to the Admin pages on its home page. Ener the URL: /Admin to get there.
- It's OK to directly delete the IdentityUsers database using SQL Server Object Explorer
- There are special internet domain names defined for testing and examples. These are defined by the Internet Engineering Task Force. These are the reserved domains, they are invalid for actual use:                
  - .test
  - .example
  - .invalid
  - .localhost
  
  Reference: [ Reserved Top Level Doman Names (TLDs)](https://tools.ietf.org/html/rfc2606)
  
- Notes on implementing Identity in my own code:            
  
  - When targeting .NET Core 2.0, I had to add an ID property to my AppUser class in order for EF to generate the identity tables in my application database. In .NET Core 2.2, I don't need to do this.

------



## References

### Basic

- Pro ASP.NET Core 2, Adam Freeman, 2017            

  - Ch. 28 – Getting Started with Identity
  
  - Ch. 12, pg. 321–330, SportsStore: Securing the Administration Features
  
-  [Introduction to Identity in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/)

-  [GitHub Tutorial  Videos](https://www.bing.com/videos/search?q=GitHub Training & Guides&qft=+filterui:userpage-githubguides&FORM=VQCHNL)
  

### Advanced

-  [ HTTP Authentication Mechanisms](https://code-maze.com/http-series-part-4/)
-  [Exploring the  ASP.NET Core Identity Password Hasher](https://andrewlock.net/exploring-the-asp-net-core-identity-passwordhasher/)



------

## Example Code on GitHub

- Pro ASP.NET Core MVC 2, Ch. 28: [Identity example](https://github.com/Apress/pro-asp.net-core-mvc-2/tree/master/28%20-%20Identity/Users)
- Instructor's Demo Web App using ASP.NET Core 2.2: [BookInfo&mdash;AddIdentity branch](https://github.com/LCC-CIT/CS296N-BookInfo-Core-2/tree/AddIdentity)
- Instructor's Demo Web App using ASP.NET Core 3.1: [BookInfo&mdash;Identity branch](Instructor's Demo Web App using ASP.NET Core 2.2: [BookInfo&mdash;AddIdentity branch](https://github.com/LCC-CIT/CS296N-BookInfo-Core-2/tree/AddIdentity))
------



## Next Week

- We will add pages that use Identity for registration and login (authentication)
- We will restrict different parts of the web app based on user role (authorization)
            

------

[ ![Creative Commons License](https://i.creativecommons.org/l/by/4.0/80x15.png)](http://creativecommons.org/licenses/by/4.0/) [ASP.NET Core MVC Course Materials](http://lcc-cit.github.io/CS296N-CourseMaterials/) by [ Brian Bird](https://profbird.online) are licensed under a [Creative Commons Attribution 4.0 International License](http://creativecommons.org/licenses/by/4.0/). 
    

------