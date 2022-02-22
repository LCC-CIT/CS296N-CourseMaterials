---
title: Authorization with Identity--Part 2
description: Use Delamater and Murach (2020) as a guide to finish adding authorization to a web app: Restrict the admin controller. Add Admin to our navigation menu, but only for admin users. Seed users and an admin role. Re-publish to Azure
keywords: Identity, Authorization, UserManager, Authorize attribute
---
# *Authorization with Identity Part 2*

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

- Restrict the admin controller
- Add Admin to our navigation menu, but only for admin users
- Seed users and an admin role
- Re-publish to Azure



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
   - Write a new method, `SeedAdminUser(IServiceProvider serviceProvider)` in the `SeedData` class. 
     - Notes:
       -  I've changed the name and class of this method from those used by the `CreateAdminUser` method in the textbook.)
       - This method needs to return an `async Task` because it calls `UserManager` async methods  using `await`.
     - In `Startup`, in the `Cofnigure` method, after all the other configuration statements, add a call to the `CreateAdminUser` method.

        ```c#
        SeedData.SeedAdminUser(app.ApplicationServices).Wait();
        ```

4. Turn off scope validation for the default service provider. In `Program.cs`, add this code that modifies the expression `webBuilder.UserStartup<Startup>;`
   We will add code to seed an Admin user[^3].

   ```c#
   webBuilder.UserStartup<Startup>
     .UseDefaultServiceProvider(
         options => options.ValidateScopes = false); }
   ```

   - Scope validation is turned on by default. It's purpose is a bit complicated, but it has to do with ensuring objects that are injected with a scoped lifetime are managed correctly. Scope validation will not properly handle the `ServiceProvider` object we are injecting a  into our `SeedAdminUser` method, so we need to turn it off. Read more about scope validation [here](https://bartwullems.blogspot.com/2019/02/aspnet-core-scope-validation.html).
   
     

## Conclusion

- Look at the lab instructions

  - Reminder to publish to Azure
  - Don't delete your migrations, add to them so your migration will run smoothly on the Azure database.
  - Reminder to keep your unit tests working

- Reminder to keep checking your Azure credit balance!

- Review due dates on Moodle



## Examples

[BookReivew, Lab04 branch](https://github.com/LCC-CIT/CS296N-Winter2021LabExample/tree/Lab04)&mdash;2021 example





## References

*Murach’s ASP.NET Core MVC*, Mary Delamater and Joel Murach, 2020

- Ch. 16, "How to Authenticate and Authorize Users"

*Pro ASP.NET Core MVC 2*, Freeman, Apress, 2017

- Ch. 12 - SportsStore: Sections on Identity - [Notes](SportsStoreCh12.html)
- Ch. 29 - Applying ASP.NET Core Identity: Authorizing users with roles 

Microsoft ASP.NET Core MVC Tutorial 

- [Authorization in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/authorization/)&mdash;for ASP.NET Core 3.1 

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