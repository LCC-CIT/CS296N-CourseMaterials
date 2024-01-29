**CS296N Web Development 2: ASP.NET**                                                        

<h1>Authorization with Identity Part 1</h1>

| Weekly topics                   |                               |
| ------------------------------- | ----------------------------- |
| 1. Intro to Identity            | 6. Complex domain models      |
| 2. Authentication               | 7. More complex domain models |
| <mark>3. Authorization</mark>   | 8. Validation                 |
| 4. Async/Await                  | 9. Web Security               |
| 5. Load testing and performance | 10. Term project              |

<h2>Contents</h2>

[TOC]


## Introduction

### Announcements (Winter 2024)

Lab 1: I didn't get this graded yet, I'll work on it this week!

Lab 2: PRs were due Saturday, code reviews are due tomorrow (Tuesday)

Quiz 3: Take it before class tiime on Wednesday.

### Q and A

- Any questions about anything?

### Review&mdash;Authentication

In the last two classes, we added these features to the Book Review app:

- Registration

- Login

- Logout

- 
  Modified code using the `AppUser` model that now  inherits from `IdentityUser`

  All operations on data in the Identity database tables now goes through one of the Identity classes like `UserManager`.  
  
- Winter 2024 notes: 
  
  - I modified _Layout so that it doesn't need to have the UserManager injected into it. (Thanks Bryce Fisher!)
  - I fixed my unit tests, in particualr the one that uses the UserManager.
  - I added links to Moodle for GitHub and Azure for the All About Pigeons example.
  



## Overview of Authorization

There are two main parts to authorization:

- Establishing user roles and assigning one or more roles to each user. For example:
  - Guest (could be an unregistered user)
  - Member (any registered user, we'll see later that this is a default role)
  - Administrator (a registered user with maximum privileges)
  
- Limiting access to certain parts of the web app to users with particular roles. For example:
  - Administrators have no restrictions. They can access all pages including special administrative pages.
  
  - Members can view all non-administrative pages and make posts.
  
  - Guests can only view non-administrative pages and they can't make posts.
  
    

## Implementing Authorization

We will use Delamater and Murach (2022), Ch. 16, as a guide to adding authorization to our web app. We'll discuss both the "how" and the "why" as we do it.  
We will add ths code:

- A list of user roles to the AppUser
- UserVM
- UserController

In today's session we will not actually restrict any parts of the web site. We'll just set up user roles and role management. We'll add restrictions to parts of our web site based on roles in the next session.

### Managing Users and Roles

In order to work with roles, we need a way to create roles and assign roles to users. We'll make the changes and add the view shown in the textbook starting with the section titled "The user entity and view model".

1. Add `app.UseAuthorization` to Program.cs. This must come <u>after</u> `app.UseAuthentication`!
2. Add a `List` for role names to `AppUser`. This is not needed by Identity. We're just adding it to facilitate our administrative page for managing users and roles.

    ```c#
    [NotMapped]
    public IList<string> RoleNames { get; set; }
    ```

      - The `[NotMapped]` attribute tells Entity Framework that it should not add this property as a field in the AspNetUsers table.
      -  `IList<string>`
        - One reason we're using `IList<string>` rather than `List<string>` is because  the `GetRolesAsync` method of `UserManager` returns this type.
        - Another reason is the "best practice" of using the most general type possible for properties. Here we need arbitrary access to the collection so we need `IList`, not `IEnumerable`.[^1]

3. Create the `UserVM` view-model to hold the lists shown below. This will be used by the Index view below.

    ```c#
    public IEnumerable<AppUser> Users { get; set; }
    public IEnumerable<IdentityRole> Roles { get; set; }
    ```

    -  We're using `IEnumerable<AppUser>` here instead of` IList<AppUser>` because we will only be iterating over the collection and don't need arbitrary access to it.[^1]

4. Add the `UserController` that will be used to manage users and roles. 

   Notes:

   - Leave off the *Authorize attribute* for now. It will block us from testing the controller until we have a user in the "Admin" role. We'll add that next time.  
     Also, the attribute is incorrect as shown in the book. The correct attribute is:  
     `[Authorize(Roles = "Admin")] `
   - We are not using *Areas*, so omit the  `[Area("Admin")]` attribute
   
   This controller implements these action methods:
   
   - User Management
     - `Index()`Renders the admin page for managing users and roles
     
       - Note: **If you are using MySQL**, you need to modify the loop header (on line 22) to prevent the MySQL EF provider from throwing an exception, "MySqlConnection already in use". Modify it by adding `ToList()`, like this: 
     
         ```c#
         foreach (AppUser user in userManager.Users.ToList())
         ```
     
         This is needed because `userManager.Users` returns an `IQueryable`, which defers execution of database queries until all further processing of the query is completed. The EF provider for MySQL doesn't seem to like this. Adding `ToList()` forces the database query to be completed immediately.
     - `Add()`&mdash;Renders the form for adding users
     
       - This code isn't shown in the textbook, but it is the same as the corresponding method in the `AccountController`.
     - `Add(RegisterVM)`&mdash;Adds a user
     
       - This code also isn't shown in the textbook but is the same as in the `AccountController`.
     - `Delete(string)`&mdash;Removes a user

      - Role Management
        - `AddToAdmin(string)`&mdash;Adds a user to the "Admin" role
        - `RemoveFromAdmin(string)`&mdash;Removes a user from the "Admin" role
        - `CreateAdminRole()`&mdash;Creates the "Admin" role
        - `DeleteRole(string)`&mdash;Removes a role

5. Add the `User` / `Index` view

6. Add the `User` / `Add` view

   - This code is not shown in the textbook. It can be copied from the "Ch16Bookstore" source code.


We don't need to add a migration since we have not made any change to our domain model that will affect the database.



## Conclusion

- Look at the lab instructions

  - Reminder to publish to Azure
  - Reminder to keep your unit tests working
  
- Reminder to keep checking your Azure credit balance!

- Review due dates on Moodle

  

## Example Code Repositories

[BookReivews, Authorization branch](https://github.com/LCC-CIT/CS296N-Example-BookReviews-DotNet6/tree/04-Authorization)&mdash;2023 example using .NET 6.0 and MySQL



## References

- *Murach’s ASP.NET Core MVC*, 2nd Ed., Mary Delamater and Joel Murach, 2022  
  Ch. 16, "How to Authenticate and Authorize Users"

- [Introduction to Authorization in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/authorization/introduction?view=aspnetcore-6.0), Microsoft  Tutorial 

- [ASP.NET Core Identity: Authorization Management](https://www.linkedin.com/learning/asp-dot-net-core-identity-authorization-management/securing-asp-dot-net-core-apps-with-authorization?u=88355058), LinkedIn video course by Ervis Trupja, 1 hour 27 minutes, 2019.

  

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
ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev), written winter 2020, revised winter 2024, is licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 