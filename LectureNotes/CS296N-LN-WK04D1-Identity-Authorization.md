**CS296N Web Development 2: ASP.NET**                                                        

# *Authorization with Identity*

| Weekly topics                                  |                                        |
| ---------------------------------------------- | -------------------------------------- |
| 1. Intro to course and Input validation        | 6. Async/Await / Complex Domain Models |
| 2. Repositories and Unit Testing               | 7. Creating a Web Service              |
| **3. Publishing to Azure / Intro to Identity** | 8. Consuming a Web Service             |
| 4. Authentication                              | 9. Docker containers                   |
| 5. Authorization                               | 10. Term project                       |

## Contents

[TOC]



## Introduction

- Q and A

## Review - Authentication

In the last two classes, we added these features to the BookReivew app:

- Login
- Logout
- 
  Modified code using the AppUser model that now  inherits from IdentityUser

  All operations on data in the Identity database tables now goes through one of the Identity classes like UserManager.



## Overview of Authorization

There are two main parts to authorization:

- Establishing user roles and assigning one or more roles to each user. For example:
  - Guest (could be an unregistered user)
  - Member (any registered user, we'll see later that this is a default role)
  - Administrator (a registered user with maximum privileges)
- Limiting access to certain parts of the web app to users with particular roles. For example:
  - Administrators have no restrictions. They can access all pages including special administrative pages.
  - Members can view all non-administrative pages and make posts.
  - Guests can only view non-administrative pages. They can't make posts.

##Implementing Authorization

We will use Delamater and Murach (2020) as a guide to adding authentication to our web app. We'll discuss both the "how" and the "why" as we do it.

### Managing Users and Roles

In order to work with roles, we need a way to create roles and assign roles to users. We'll make the changes and add the view shown in the textbook starting with the section titled "The user entity and view model".

- Add `app.UseAuthorization` to the Configure method in the Startup class. This must come <u>after</u> `app.UseAuthentication`!
- Add a list of role names to AppUser.
- Create a view-model to hold lists of AppUser and IdentityUser objects. This will be used by the view that manages users and roles (below).
- Add an AdminController (UserController in the textbook) that will be used to manage users and roles.
- Add the Admin / Index view

### More Administrative Features

As shown in the section of the textbook titled "Other action mentors of the UserController"

We will add these methods to the AdminController.

### Restricting Access 

We will use the following C# attributes to restrict access classes or methods:

- `[Authorize]`

  Limits access to logged in users.

- `[Authorize(Roles = "Admin")]`

  Limits access to users in the Admin role

We will add an AccessDenied view to the Account views



### Seeding Uses and Roles

Add a method to the SeedData class named SeedUsers.

## Conclusion

- Look at the lab instructions

  - Reminder to publish to Azure
  - Don't delete your migrations, add to them so your migration will run smoothly on the Azure database.
  - Reminder to keep your unit tests working

- Reminder to keep checking your Azure credit balance!

- Review due dates on Moodle

  

## Example Code Repositories

[BookReivew, Lab04 branch](https://github.com/LCC-CIT/CS296N-Winter2021LabExample/tree/Lab04)&mdash;2021 example



## References

*Murach’s ASP.NET Core MVC*, Mary Delamater and Joel Murach, 2020

- Ch. 16, "How to Authenticate and Authorize Users"

*Pro ASP.NET Core MVC 2*, Freeman, Apress, 2017

- Ch. 12 - SportsStore: Sections on Identity - [Notes](SportsStoreCh12.html)
- Ch. 29 - Applying ASP.NET Core Identity: Authorizing users with roles 

Microsoft ASP.NET Core MVC Tutorial 

- [Authorization in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/authorization/)

------

[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png) ](http://creativecommons.org/licenses/by-sa/4.0/)
ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev), written winter 2020, revised winter 2022, is licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 