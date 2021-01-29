**CS296N Web Development 2: ASP.NET**                                                        

# *Authorization with Identity*

| Weekly topics                           |                            |
| --------------------------------------- | -------------------------- |
| 1. Intro to course and Input validation | 6. Security                |
| 2. Identity                             | 7. Creating a Web Service  |
| 3. Authentication                       | 8. Consuming a Web Service |
| **4. Authorization**                    | 9. Docker containers       |
| 5. Async/Await & Complex Domain Model   | 10. Term project           |

## Contents

[TOC]

## Introduction

- Q and A
- Areas&mdash;answer to a question from the last class:
  - Microsoft Tutorial: [Areas in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/areas?view=aspnetcore-3.1)
  - Delamater and Murach (2020), pg. 218&ndash;221, "How to work with areas"

## Review - Last Class' Demo

In the last  class, we made these changes to the BookReview app: 

- Fixed the login redirect problem

  - Order of these lines in the `Startup.Configure` method

    ```c#
     app.UseAuthentication();
     app.UseAuthorization();
    ```

- Fixed the seed code so it doesn't create bogus users

  - Note: seeded users don't have a password--but this isn't necessarily a problem.
    We wouldn't normally seed users for production--except an administrator.
    The admin can register to give themselves a password; noting that the username is case sensitive when registering.

- Added the Admin Index view and supporting code

  - `AdminVM`
  - `AdminController` and Index method

  

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