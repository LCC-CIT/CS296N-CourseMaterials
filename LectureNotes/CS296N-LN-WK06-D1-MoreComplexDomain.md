---
title: More on Designing a Domain Model
description: How to use Domain Driven Design and UML to design a more complex domain model. How to write a model so Entity Framework enables cascade deletes of related data in the database.
keywords: Object Oriented Design, UML, Domain Driven Design, domain model, Entity Framework, related data, cascade delete
---
<h1>More on Designing a Domain Model</h1>

**CS296N Web Development 2**

| Weekly topics                   |                                            |
| ------------------------------- | ------------------------------------------ |
| 1. Intro to Identity            | 6. Complex domain models                   |
| 2. Authentication               | 7. <mark>More complex domain models</mark> |
| 3. Authorization                | 8. Validation                              |
| 4. Async/Await                  | 9. Web Security                            |
| 5. Load testing and performance | 10. Term project                           |
| 11. Project Presentations       |                                            |

## Contents

[TOC]

## Intro

### Q & A

- Due dates corrected:
  - Lab 6 beta version due Tuesday, March 5
  - Lab 6 production version due Thursday, March 7

- Next week, week 9, we will cover validation
- Week 10 we will cover Security.

### This Week's Agenda

- How to Code an MVC Web App with a More Complex Domain Model
  - Add a reply to a message
  - Loading related data
  - Managing cascade deletes
  - Many-to-Many relaitonships  
- Scaffolding

### Review

- Domain Driven Design

  - Aggregate: a group of persistent domain model objects that will be loaded together and deleted together.
  - Root entity: The main entity in an aggregate the one that you will perfor load or delete operations on.
  - Design decisions about relationships between domain model classes.

  

## Examples

  - 2023 example, using .NET 6.0, MySQL, and 5 domain model classes:
    -  [CS296N-Example-BookReviews-DotNet6](https://github.com/LCC-CIT/CS296N-Example-BookReviews/tree/7-ComplexDomain/BookReviews/BookReviews/Models), branch 07-ComplexDomain on GitHub.
    - [UML class diagram](https://github.com/LCC-CIT/CS296N-Example-BookReviews-DotNet6/blob/07-ComplexDomain/Docs/BookReviewsDomainModel.pdf) of the domain model.


-----

 [![Creative Commons License](https://i.creativecommons.org/l/by/4.0/88x31.png)](http://creativecommons.org/licenses/by/4.0/)ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev), written in <time>2023</time>, revised in 2024, are licensed under a [Creative Commons Attribution 4.0 International License](http://creativecommons.org/licenses/by/4.0/). 
