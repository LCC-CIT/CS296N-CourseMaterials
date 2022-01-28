**CS296N Web Development 2: ASP.NET, 2020**

# *User Registration with Identity*

| Weekly topics                                  |                                        |
| ---------------------------------------------- | -------------------------------------- |
| 11. Intro to course and Input validation       | 6. Async/Await / Complex Domain Models |
| 2. Repositories and Unit Testing               | 7. Creating a Web Service              |
| **3. Publishing to Azure / Intro to Identity** | 8. Consuming a Web Service             |
| 4. Authentication                              | 9. Docker containers                   |
| 5. Authorization                               | 10. Term project                       |

**Contents**

[TOC]

------

## Introduction

- Q and A

- Review due dates

- Reminder to check Azure credit balances

  

## Review of last class

### Adding Identity

We Added Identity to a project by adding these things:

- NuGet package
- Startup service and configuration
- User model inherits from `IdentityUser`
- App's DbContext class inherits from `IdentityDbContext`
- New migration and database update
- If you have overridden `OnModelCreating`, add a call to the base class method

When we were done with this, we were able to see Identity tables in our database, but that is all. Nothing changed in our web site behavior.

## Overview of Registration and Authentication

### Registration

Before users can be authenticated, they need to be registered and the registration data needs to be stored in the database.

Passwords are not stored directly. Instead a [hash](https://computersciencewiki.org/index.php/Hashing) of the password is stored.

### Authentication

Authentication is verifying that a user is who they say they are. This can be done using:

- Passwords
- Fingerprints
- Face images (like Windows Hello)
- Other biometrics

We will add authentication to our app in the next class.



## Adding Registration to a web app

We take a bit of a short-cut by copying the registration code from the textbook. We will be adding the following:

- A view-model: RegisterVM
- A controller: AccountController, with these methods:
  - HttpGet version of Register
  - HttpPost version of Register
- A view: Registration
  - Add code to load JavaScript libraries for validation in the browser



## References

### Basic

- *Murach’s ASP.NET Core MVC*, Mary Delamater and Joel Murach, 2020
  - Ch. 16, "How to register a user"
- [Introduction to Identity in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/?view=aspnetcore-3.1)

### Advanced

-  [ HTTP Authentication Mechanisms](https://code-maze.com/http-series-part-4/)
-  [Exploring the  ASP.NET Core Identity Password Hasher](https://andrewlock.net/exploring-the-asp-net-core-identity-passwordhasher/)



------

## Example Code on GitHub

- Instructor's Demo Web App using ASP.NET Core 3.1: [BookInfo&mdash;Identity branch](Instructor's Demo Web App using ASP.NET Core 2.2: [BookInfo&mdash;AddIdentity branch](https://github.com/LCC-CIT/CS296N-BookInfo-Core-2/tree/AddIdentity))

## Upcoming Classes

- We will add pages that use Identity for login (authentication)
- We will restrict different parts of the web app based on user role (authorization)
            

------

[ ![Creative Commons License](https://i.creativecommons.org/l/by/4.0/80x15.png)](http://creativecommons.org/licenses/by/4.0/) [ASP.NET Core MVC Course Materials](http://lcc-cit.github.io/CS296N-CourseMaterials/) by [ Brian Bird](https://profbird.dev), written winter 2017, revised winter 2022 are licensed under a [Creative Commons Attribution 4.0 International License](http://creativecommons.org/licenses/by/4.0/). 
    

------

