---
title: Working with Scaffolding and Related Data
description: You will learn how to scaffold a domain model entity to create views and controller methods. You will also learn to manage the way Entity Framework handles related data.
---
# Working with Scaffolding and Related Data

**CS296N Web Development 2**

| Weekly topics                              |                                 |
| ------------------------------------------ | ------------------------------- |
| 1. Intro to course and Input validation    | 6. Async/Await                  |
| 2. Repositories and Unit Testing           | 7. Performance and Load Testing |
| 3. Publishing to Azure / Intro to Identity | **8. Complex Domain Models**    |
| 4. Authentication                          | 9. Docker containers            |
| 5. Authorization                           | 10. Term project                |

## Contents

[TOC]

## Review

### Aggregates and Root Entities

An aggregate entity groups together several domain model objects—there is a root entity that is used
to identify the entire aggregate, and it acts as the “boss” for validation and persistence operations.

### Entity Framework

We learned how to include related data when retrieving an entity from a DbSet.

------



## Scaffolding

Scaffold the Review model. This will be an admin page for editing reviews.



## Working with Related Data

- Lazy loading
- Eager loading
- Cascade deletes



### Exercise: Modify the BookReview web site

- Add scaffolding
- Test cascade deletes
- Experiment with eager and lazy loading



## References

Anderson, Rick, et al. [MVC Movie Tutorial: Scaffold Movies Pages)](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-3.1&tabs=visual-studio#scaffold-movie-pages-2). 2022. 



------

 [![Creative Commons License](https://i.creativecommons.org/l/by/4.0/88x31.png)](http://creativecommons.org/licenses/by/4.0/) ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev), 2018 (Revised winter <time>2022</time>), are licensed under a [Creative Commons Attribution 4.0 International License](http://creativecommons.org/licenses/by/4.0/). 

------