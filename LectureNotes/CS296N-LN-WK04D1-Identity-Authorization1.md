**CS296N Web Development 2: ASP.NET**                                                        

# *Authorization with Identity Part 1*

| Weekly topics                              |                                        |
| ------------------------------------------ | -------------------------------------- |
| 1. Intro to course and Input validation    | 6. Async/Await / Complex Domain Models |
| 2. Repositories and Unit Testing           | 7. Creating a Web Service              |
| 3. Publishing to Azure / Intro to Identity | 8. Consuming a Web Service             |
| 4. Authentication                          | 9. Docker containers                   |
| **5. Authorization**                       | 10. Term project                       |

## Contents

[TOC]



## Introduction

- I still plan to do a video of publishing to DigitalOcean. I'm still catching up after being sick, but I should be able to do that this week. If your Azure account has expired, just put a note in your lab 3 submission saying that and I won't make publishing to a web host part of your grade.

- Q and A

  

## Review&mdash;Authentication

In the last two classes, we added these features to the Book Review app:

- Registration
- Login
- Logout
- 
  Modified code using the `AppUser` model that now  inherits from `IdentityUser`

  All operations on data in the Identity database tables now goes through one of the Identity classes like `UserManager`.
  
- I updated the bootstrap code for the navbar and added [details to the notes](http://lcc-cit.github.io/CS296N-CourseMaterials/LectureNotes/CS296N-LN-WK03D2-Identity-Authentication.html#modify-the-navbar). Let's take a quick look at the code: [BookReviews&mdash;Authentication branch](https://github.com/LCC-CIT/CS296N-Example-BookReviews-DotNet6/blob/03-Authentication/BookReviews/Views/Shared/_Layout.cshtml)
  Discussion:

  - What is the purpose of the SignInManager in this shared layout?
    - Where is this code executed?
    - When a user logs in, how are passwords sent to the controller?
  
  - What do the `<li>` elements correspond to?
  - How are the Font Awesome icons added to the NavBar?



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
  
    

## Implementing Authorization

We will use Delamater and Murach (2020) as a guide to adding authorization to our web app. We'll discuss both the "how" and the "why" as we do it.

In today's session we will not actually restrict any parts of the web site. We'll just set up user roles and role management. We'll add restrictions to parts of our web site based on roles in the next session.

### Managing Users and Roles

In order to work with roles, we need a way to create roles and assign roles to users. We'll make the changes and add the view shown in the textbook starting with the section titled "The user entity and view model".

1. Add `app.UseAuthorization` to the Configure method in the Startup class. This must come <u>after</u> `app.UseAuthentication`!
2. Add a list of role names to `AppUser`. This is not needed by Identity. We're just adding it to facilitate our administrative page for managing users and roles.

    ```c#
    [NotMapped]
    public IList<string> RoleNames { get; set; }
    ```
    
      - The `[NotMapped]` attribute tells Entity Framework that it should not add this property as a field in the AspNetUsers table.
      -  `IList<string>`
        - One reason we're using `IList<string>` rather than `List<string>` is because  the `GetRolesAsync` method of `UserManager` returns this type.
        - Another reason is the "best practice" of using the most general type possible for properties. Here we need arbitrary access to the collection so we need `IList`, not `IEnumerable`.[^1]
    
3. Create the `AdminVM` view-model to hold the lists shown below. This will be used by the Index view below.

    ```c#
    public IEnumerable<AppUser> Users { get; set; }
    public IEnumerable<IdentityRole> Roles { get; set; }
    ```
    
    -  We're using `IEnumerable<AppUser>` here instead of` IList<AppUser>` because we will only be iterating over the collection and don't need arbitrary access to it.[^1]
    
4. Add the `AdminController` (`UserController` in the textbook) that will be used to manage users and roles. The controller implements these action methods:

   - User Management
     - `Index()`&mdash;Renders the admin page for managing users and roles
     - `Add()`&mdash;Renders the form for adding users
     - `Add(RegisterVM)`&mdash;Adds a user
     - `Delete(string)`&mdash;Removes a user
   
   
      - Role Management
        - `AddToAdmin(string)`&mdash;Adds a user to the "Admin" role
        - `RemoveFromAdmin(string)`&mdash;Removes a user from the "Admin" role
        - `CreateAdminRole()`&mdash;Creates the "Admin" role
        - `DeleteRole(string)`&mdash;Removes a role
   
5. Add the `Admin` / `Index` view

6. Add the `Admin` / `Add` view

We don't need to add a migration since we have not made a change to our domain model (just `AppUser`) that will affect the database.



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



## Footnotes

[^1]: Using `IList` instead of `List`

> The principle here is do not ask for more than you need. IEnumerable<T> communicates "I need to get the elements of this sequence from beginning to end". IList<T> communicates "I need to get and set the elements of this sequence in arbitrary order". List<T> communicates "I need to get and set the elements of this sequence in arbitrary order and I only accept lists; I do not accept arrays."
>
> By asking for more than you need, you (1) make the caller do unnecessary work to satisfy your unnecessary demands, and (2) communicate falsehoods to the reader. Ask only for what you're going to use. That way if the caller has a sequence, they don't need to call ToList on it to satisfy your demand.

<cite>Quoted from [Eric Lippert](https://stackoverflow.com/users/88656/eric-lippert) on [Stack Overflow](https://stackoverflow.com/questions/8717582/why-use-ilist-or-list)</cite>

See also When [To Use IEnumerable Or ICollection Or IList Or List](https://www.c-sharpcorner.com/blogs/when-to-use-ienumerable-or-icollection-or-ilist-or-list) by Tanuj Khurana, 2016

[.NET API Documentation for System.Collections](https://docs.microsoft.com/en-us/dotnet/api/system.collections?view=net-6.0) See which classes are derived from which interfaces.

------

[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png) ](http://creativecommons.org/licenses/by-sa/4.0/)
ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev), written winter 2020, revised winter 2022, is licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 