---
title: More on Designing a Domain Model
description: How to use Domain Driven Design and UML to design a more complex domain model. How to write a model so Entity Framework enables cascade deletes of related data in the database.
keywords: Object Oriented Design, UML, Domain Driven Design, domain model, Entity Framework, related data, cascade delete
---
<h1>More on Designing a Domain Model</h1>

**CS296N Web Development 2**

| Weekly topics                             |                                               |
| ----------------------------------------- | --------------------------------------------- |
| 1. 1. Publishing a site to a Linux server | 6. Load testing and performance               |
| 2. Intro to Identity                      | 7. Complex domain models                      |
| 3. Authentication                         | 8. <mark>More on complex domain models</mark> |
| 4. Authorization                          | 9.  Validation                                |
| 5. Async/Await                            | 10. Term project / Docker containers          |

## Contents

[TOC]

## Intro

### Q & A

- Lab 7 due date extended by one week to Thursday, March 9
- Next week, week 9, we will cover validation
- The Docker lab, lab 9, is now optional extra credit. You can watch videos of the lectures and do the reading on your own.

### This Week's Agenda

- Coding and Refactoring Faster
  - Scaffolding
  - Unit Testing with an In-Memory Database
  - Hot Reload
- How to Code an MVC Web App with a More Complex Domain Model
  - Getting user input for domain property model collections
  - Managing cascade deletes
  - Many-to-Many relaitonships

### Review

- Domain Driven Design

  - Aggregates
  - Root entities
  - Design decisions about relationships between domain model classes.

- Multiple Versions of the BookReview Domain Model

  - Last year's BookReview, branch 7-ComplexDomain, has just 3: Review, AppUser, Comment.
  - The notes show an example with 5: Book, Author, Review, AppUser, Comment.
    - We started coding this version in this year's BookReview example on branch 07-ComplexDomain.
    - We had to do a lot of refactoring of the repository, controllers, and unit tests because I changed the root entity from Review to Book.

## Examples

  - Last year's example, using .NET 3.2, with 3 domain model classes: [CS296N-Example-BookReviews, branch 7-ComplexDomain](https://github.com/LCC-CIT/CS296N-Example-BookReviews/tree/7-ComplexDomain/BookReviews/BookReviews/Models).
  - This year's example, using .NET 6.0, with 5 domain model classes: [CS296N-Example-BookReviews-DotNet6, branch 07-ComplexDomain](https://github.com/LCC-CIT/CS296N-Example-BookReviews/tree/7-ComplexDomain/BookReviews/BookReviews/Models).

-----

 [![Creative Commons License](https://i.creativecommons.org/l/by/4.0/88x31.png)](http://creativecommons.org/licenses/by/4.0/)ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev), written winter <time>2023</time>, are licensed under a [Creative Commons Attribution 4.0 International License](http://creativecommons.org/licenses/by/4.0/). 
