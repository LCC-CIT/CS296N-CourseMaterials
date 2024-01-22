**CS296N Web Development 2: ASP.NET**

<h1>User Registration with Identity</h1>



| Weekly topics                   |                                |
| ------------------------------- | ------------------------------ |
| 1. Intro to Identity            | 6. Complex domain models       |
| <mark>2. Authentication</mark>  | 7. A more complex domain model |
| 3. Authorization                | 8. Validation                  |
| 4. Async/Await                  | 10. Term project               |
| 5. Load testing and performance | 11. Project presentations      |



<h2>Contents</h2>

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
- App's `DbContext` class inherits from `IdentityDbContext`
- Modify the `SeedData.Seed` method to use an instance of the Identity `UserManager` class to create AppUser objects.
- New migration and database update
- If you have overridden `DbContext.OnModelCreating`, add a call to the base class method

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

- A view-model: `RegisterVM`
- A controller: `AccountController`, with these methods:
  - HttpGet version of `Register`
  - HttpPost version of `Register`
- A view: `Registration`
  - Add code to load JavaScript libraries for validation in the browser

This code is in the textbook in ch. 16 and also in the Ch16Bookstore app.  
(Download [textbook code here](https://www.murach.com/shop-books/web-development-books/murach-s-asp-net-core-mvc-2nd-edition-detail))

## References

### Basic

- *Murach’s ASP.NET Core MVC*, Second Ed., Mary Delamater and Joel Murach, 2022
  - Ch. 16, "How to register a user"
- [Introduction to Identity in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/?view=aspnetcore-6.0)

### Advanced

-  [ HTTP Authentication Mechanisms](https://code-maze.com/http-series-part-4/)
-  [Exploring the  ASP.NET Core Identity Password Hasher](https://andrewlock.net/exploring-the-asp-net-core-identity-passwordhasher/)



------

## Example Code on GitHub

Instructor's Demo Web App using ASP.NET Core 6.0: [BookInfo&mdash;Registration](https://github.com/LCC-CIT/CS296N-Example-BookReviews-DotNet6/tree/02-Registration)

## Upcoming Classes

- We will add pages that use Identity for login (authentication)
- We will restrict different parts of the web app based on user role (authorization)
            

------

[ ![Creative Commons License](https://i.creativecommons.org/l/by/4.0/80x15.png)](http://creativecommons.org/licenses/by/4.0/) [ASP.NET Core MVC Course Materials](http://lcc-cit.github.io/CS296N-CourseMaterials/) by [ Brian Bird](https://profbird.dev), written winter 2017, revised winter 2024 are licensed under a [Creative Commons Attribution 4.0 International License](http://creativecommons.org/licenses/by/4.0/). 
    

------

