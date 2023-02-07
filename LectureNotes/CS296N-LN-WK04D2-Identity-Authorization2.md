---
title: Authorization with Identity--Part 2
description: Use Delamater and Murach (2022) as a guide to finish adding authorization to a web app: Restrict the admin controller. Add Admin to our navigation menu, but only for admin users. Seed users and an admin role. Re-publish to Azure
keywords: Identity, Authorization, UserManager, Authorize attribute
---
<h1>Authorization with Identity Part 2</h1>

| Weekly topics                              |                                        |
| ------------------------------------------ | -------------------------------------- |
| 1. Intro to course and Input validation    | 6. Async/Await / Complex Domain Models |
| 2. Repositories and Unit Testing           | 7. Creating a Web Service              |
| 3. Publishing to Azure / Intro to Identity | 8. Consuming a Web Service             |
| 4. Authentication                          | 9. Docker containers                   |
| **5. Authorization**                       | 10. Term project                       |

[TOC]

## Introduction

- Q and A

## Review - Last Class' Demo

We added the `AdminController`, some supporting code and two views:

- `Index` for managing users and roles
- `Add` for adding new users



## Overview of Today's Demo

We will use Delamater and Murach (2020) as a guide to finish adding authorization to our web app.

- Seed a user and an admin role.
- Restrict the admin controller.
- Add Admin to our navigation menu, but only for admin users.
- Re-publish to Azure.



## Restricting Access 

We will use the following C# attributes to restrict access classes or methods:

- `[Authorize]`
  - Limits access to logged in users.
  - If a user tries to access a method that requires authorization, they will automatically be redirected to Account/Login[^1]. 

- `[Authorize(Roles = "Admin")]`
  - Limits access to users in the Admin role.
  - If a user not in this role tries to access a method with this restriction, they will be automatically redirected to Account/AccessDenied[^2].




## Demo&mdash;Finishing the Authorization Code

1. Restrict access to authorized users
   - Add the `[Authorize]` attribute to the `Review` methods (for posting a review) in the `ReviewController`.
   - Add `[Authorize(Roles = "Admin")]` to the `AdminController` 

2. Provide notification and redirection to unauthorized users
   - Add an HTTP GET `AccessDenied()` action method to the `AcccountController`. This will notify unauthorized users that they either need to log in or don't have Admin priveleges.
   - Add the `AccessDenied` view to the Views / Account folder

3. Seed an admin user

   We will follow the approach used in the textbook and use the code from the section of ch. 16 titled "How to seed roles and users". 

   - Copy the `ConfigureIdentity` class (I renamed it to `SeedUsers` in my example code) which contains a static method named `CreateAdminUserAsync`. I put the file in  the Data` folder of my project.

   - Add a call to the `CreateAdminUserAsync` method to `Program.cs`. It goes in the `using` statement at the bottom where we are already calling the `SeedData.Seed` method. Here's what the `using` statement looks like after adding the call to `CreateAdminUserAsync`:  
   ```c#
   using (var scope = app.Services.CreateScope())
   {
       await SeedUsers.CreateAdminUserAsync(scope.ServiceProvider);
       var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
       SeedData.Seed(context, scope.ServiceProvider);
   }
   ```

4. Add an *Admin* link to the navbar menu.

   This code isn't in the textbook. Add the code below to the shared _Layout.cshtml file, inside the @if statement that checks to see if a user is logged in.

  ```c#
  @if (User.IsInRole("Admin"))
  {
    <li class="nav-item">
      <a class="nav-link" asp-controller="User" asp-action="Index">
          <span class="fas fa-cog"></span>&nbsp;Admin</a>
    </li>
  }
  ```

  

## Conclusion

- Look at the lab instructions

  - Reminder to publish to Azure
  - Don't delete your migrations, add to them so your migration will run smoothly on the Azure database.
  - Reminder to keep your unit tests working

- Reminder to keep checking your Azure credit balance!

- Review due dates on Moodle



## Examples

[BookReivews, Authorization branch](https://github.com/LCC-CIT/CS296N-Example-BookReviews-DotNet6/tree/04-Authorization)&mdash;2023 example using .NET 6.0 and MySQL

[BookReivews, Authorization branch](https://github.com/LCC-CIT/CS296N-Example-BookReviews/tree/4-Authorization)&mdash;2022 example using .NET 3.1 and SQL Server



## References

*Murach’s ASP.NET Core MVC*, Mary Delamater and Joel Murach, 2022

- Ch. 16, "How to Authenticate and Authorize Users"

Microsoft ASP.NET Core MVC Tutorial 

- [Authorization in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/authorization/)&mdash;for ASP.NET Core

------

## Conclusion

- Review due dates on Moodle.
- There is reading, but no reading quiz for next week.



## Footnotes

[^1]: Account/Login is the default path that unauthorized (not logged in) users will be redirected to when they try to access an action method restricted with the [Authorize] attribute. 
[^2]: Account/AccessDenied is the default path that unauthorized (not in the required role) users will be redirected to when they try to access an action method restricted with the [Authorize(Roles = "SomeRole")] attribute.
[^3]: The users I seeded before adding authentication don't have a password--but this isn't necessarily a problem. They work for the Reviews in the seed data. 





------

[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png) ](http://creativecommons.org/licenses/by-sa/4.0/)
ASP.NET Core MVC Lecture Notes, written winter 2021, revised winter <time>2022</time>, by [Brian Bird](https://profbird.dev) are licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 