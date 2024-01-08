**CS296N Web Development 2: ASP.NET**                                                        

<h1>Creating Seed Data with the User Manager</h1>



| Weekly topics                     |                                |
| --------------------------------- | ------------------------------ |
| <mark>1. Intro to Identity</mark> | 6. Complex domain models       |
| 2. Authentication                 | 7. A more complex domain model |
| 3. Authorization                  | 8. Validation                  |
| 4. Async/Await                    | 10. Term project               |
| 5. Load testing and performance   | 11. Project presentations      |

##

<h2>Contents</h2>

[TOC]

## Introduction

- Q and A
- Reminder to check Azure credit balances



## Identity UserManager

When we added Identity to our project, we removed the `DbSet` for our user from our`DbContext` class. This is because the user table in the database is now managed by Identity. Instead of using the DbContext to do CRUD operations with our user model, we will do all of those operations using the Identity `UserManager` service.

### Adding a User in Seed Data with the UserManager

As an example of how to use the UserManager service, we will refactor our SeedData to use the UserManager.



## Example Code on GitHub

- Instructor's Demo Web App using ASP.NET Core 6.0: [BookInfo&mdash;SeedData](https://github.com/LCC-CIT/CS296N-Example-BookReviews-DotNet6/tree/02-SeedData)

## References

*Murach’s ASP.NET Core MVC*, Mary Delamater and Joel Murach, 2020

- Ch. 16, "How to Authenticate and Authorize Users"

------



## Conclusion

- Review due dates on Moodle
- Talk about the lab assignment



## Footnotes



------



[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png) ](http://creativecommons.org/licenses/by-sa/4.0/)
ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev), written winter 2024, is licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 

