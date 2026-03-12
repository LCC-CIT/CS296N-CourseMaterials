---
title: Working with Scaffolding and Related Data
description: You will learn how to scaffold a domain model entity to create views and controller methods. You will also learn to manage the way Entity Framework handles related data.
---
<h1>How to Use Scaffolding</h1>

**CS296N Web Development 2**

<h2>Contents</h2>

[TOC]

## Review

### Aggregates and Root Entities

An aggregate entity groups together several domain model objects—there is a root entity that is used
to identify the entire aggregate, and it acts as the “boss” for validation and persistence operations.

------



## Scaffolding

Scaffold the Review model. This can be used as an admin page for managing reviews.

These instructions are for Visual Studio 2022.

- Right-click the controllers folder and select *Add*, then select:
  - *New Scaffolded Item...*
  - *MVC Controller with views, using Entity Framework* and click *Add*
    - Select a *Model class* (`Review`&mdash;in my case) and your Data context class.
    - Check all three check boxes.
    - Enter a *Controller name* (ManageController&mdash;in my case, since I already had a ReviewController).
    - Click *Add*.

A new controller and view will be added to your project.

### Shortcomings of a Scaffolded Web Page

- The controller and view do not read related data. They only read data from the model entity selected when setting up the scaffolding.
- The controller uses a DbContext object to access data rather than a repository.
- The page is very generic and most often won't fit the needs of your users or give them a good experience.



## Examples

Book Review site on GitHub: [ComplexDomain branch](https://github.com/LCC-CIT/CS296N-Example-BookReviews/tree/7-ComplexDomain).

Book Review site on GitHub: [MoreComplexDomain branch](https://github.com/LCC-CIT/CS296N-Example-BookReviews/tree/7-MoreComplexDomain).

## References

Anderson, Rick, et al. [MVC Movie Tutorial: Scaffold Movies Pages](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-3.1&tabs=visual-studio#scaffold-movie-pages-2). A Microsoft Tutorial. 2022. 

Delamater, Mary, Murach, Joel. "How to add a controller" 44 &ndash;45 in Ch. 2 of *Murach's ASP.NET Core MVC*. 2nd Ed., Murach, 2022. Shows you how to scaffold an empty controller.

------

 [![Creative Commons License](https://i.creativecommons.org/l/by/4.0/88x31.png)](http://creativecommons.org/licenses/by/4.0/) ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev), 2018 (Revised winter <time>2024</time>), are licensed under a [Creative Commons Attribution 4.0 International License](http://creativecommons.org/licenses/by/4.0/). 

------