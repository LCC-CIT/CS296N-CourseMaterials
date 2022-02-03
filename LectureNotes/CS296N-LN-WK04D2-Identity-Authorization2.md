**CS296N Web Development 2: ASP.NET**                                                                                                         

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

We will use Delamater and Murach (2020) as a guide to continue adding an administrative page for user and role management to our web site.  We will add these items:

- `AdminController` methods for:

  - Delete user
  - Add to Admin
  - Remove from Admin
  - Delete role
- Restrict the admin controller
- Add Admin to our navigation menu, but only for admin users
- Re-publish to Azure


### More Administrative Features

As shown in the section of the textbook titled "Other action methods of the UserController"

We will add these methods to the `AdminController`.



### Restricting Access 

We will use the following C# attributes to restrict access classes or methods:

- `[Authorize]`

  Limits access to logged in users.

- `[Authorize(Roles = "Admin")]`

  Limits access to users in the Admin role

We will add an `AccessDenied` view to the Account views



### Seeding Uses and Roles

Add a method to the `SeedData` class named `SeedUsers`.



## Conclusion

- Look at the lab instructions

  - Reminder to publish to Azure
  - Don't delete your migrations, add to them so your migration will run smoothly on the Azure database.
  - Reminder to keep your unit tests working

- Reminder to keep checking your Azure credit balance!

- Review due dates on Moodle

## Footnotes

Note: seeded users don't have a password--but this isn't necessarily a problem.
We wouldn't normally seed users for production--except an administrator.
The admin can register to give themselves a password; noting that the username is case sensitive when registering.

## Example Code Repositories

[BookReivew, Lab04 branch](https://github.com/LCC-CIT/CS296N-Winter2021LabExample/tree/Lab04)&mdash;2021 example

[BookInfo, Authorization branch](https://github.com/ProfBird/BookInfo-WebApp-Core3/tree/Authorization) &mdash;Admin view and controller methods from 2020.



## References

*Murach’s ASP.NET Core MVC*, Mary Delamater and Joel Murach, 2020

- Ch. 16, "How to Authenticate and Authorize Users"

*Pro ASP.NET Core MVC 2*, Freeman, Apress, 2017

- Ch. 12 - SportsStore: Sections on Identity - [Notes](SportsStoreCh12.html)
- Ch. 29 - Applying ASP.NET Core Identity: Authorizing users with roles 

Microsoft ASP.NET Core MVC Tutorial 

- [Authorization in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/authorization/)&mdash;for ASP.NET Core 3.1 

------

## Conclusion

- Review due dates on Moodle.
- There is reading, but no reading quiz for next week.

------

[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png) ](http://creativecommons.org/licenses/by-sa/4.0/)
ASP.NET Core MVC Lecture Notes, written winter 2021, by [Brian Bird](https://birdsbits.blog) are licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 