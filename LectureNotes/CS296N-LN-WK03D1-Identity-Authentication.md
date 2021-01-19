**CS296N Web Development 2: ASP.NET**                                                        

 Brian Bird

# *Authentication with Identity*

| Weekly topics                           |                                 |
| --------------------------------------- | ------------------------------- |
| 1. Intro to course and input validation | 6. Load testing and performance |
| 2. Identity                             | 7. Creating a web service       |
| **3. Authentication and authorization** | 8. Consuming a web service      |
| 4. Security                             | 9. Docker containers            |
| 5. Publishing to a production server    | 10. Term project                |

## Contents

[TOC]

## Introduction

- Q and A
- Review quiz 3



## Review - Identity

- Adding Identity to a project

  - NuGet package
  - Startup service and configuration
    - Note: we should add `app.UseAuthorization` to the Configure method.
  - User model inherits from IdentityUser
  - App's DbContext class inherits from IdentityDbContext
  - New migration

- Run BookReviews

- Code to register a user

  - View
  - ViewModel
  - Controller methods

  

## Overview

We will use Delamater and Murach (2020) as a guide to adding authentication to our web app. We'll discuss both the "how" and the "why" as we do it.



## Adding Authentication to Our Web Apps

### Authentication: Login and Logout 

#### Modify the navbar

Page 665, "How to add Log In/Out buttons" and links to the layout.
Note: add a register button as well.

##### Using DI with views

Page 568 describes this.

Normally it's not a good practice to inject dependencies into views, but since a layout doesn't have a controller method to pass it a model, this is an acceptable solution.

The @Inject directive does the same thing for a view that adding a parameter to a controller does for a type for which a DI service is defined in startup.

#### Login

Pages 674&ndash;679 describe the process of adding login

- ViewModel
- View
- Controller methods

#### Getting the current user

We will refactor our current code, so that in views that currently require a user to enter their name, we will use the identity of the currently logged in user instead. To get the current user, simply use the `User` property of the controller:

```c#
string userName = User.Identity.Name;
```



## Example Code Repositories

[BookInfo, Core 3.1, Authentication branch](https://github.com/ProfBird/BookInfo-WebApp-Core3/tree/Authentication) &mdash;User login and logout controller methods and views.



## Reading

**Freeman,** ***Pro ASP.NET Core MVC 2***

- Ch. 12 - SportsStore: Sections on Identity - [Notes](SportsStoreCh12.html)
- Ch. 29 - Applying ASP.NET Core Identity: Authorizing users with roles 

**Microsoft ASP.NET Core MVC Tutorial** 

- [Overview of ASP.NET Core Authentication](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/?view=aspnetcore-3.1)&mdash;for ASP.NET Core 3.1 

------



## Conclusion

- Review due dates on Moodle

------



[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png) ](http://creativecommons.org/licenses/by-sa/4.0/)
ASP.NET Core MVC Lecture Notes by [Brian Bird](https://birdsbits.blog) is licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 