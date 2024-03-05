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

- Are there any questions about anything?

- 

### Review

- Domain Driven Design

  - Aggregate: a group of persistent domain model objects that will be loaded together and deleted together.
  - Root entity: The main entity in an aggregate the one that you will perfor load or delete operations on.
  - Design decisions about relationships between domain model classes.

- Cascade delete&mdash;this is how we implement a composition relationship when using Entity Framework.
  - Add an FK (non-nullable) in the dependent model class to enable cascade delete.
    - Example: Review has a collection of comment objects, Comment has a FK for Review.

  - The default relationship is aggregation (no cascade delete). This is what you get if there is no FK in the dependent model class. A nullable FK in the dependent model class will have the same effect.

- Multiple examples (see links below) of persistent domain models with both composition (cascade delete) and aggregation relationships:

  - 2022 BookReview example, branch 7-ComplexDomain, has 3 persistent model classes: `Review`, `Comment` and `AppUser` .
  - 2023 BookReview example ([previous notes](CS296N-LN-WK05-D1-ComplexDomain.html) show code from this) with 5 persistent model classes: `Book`, `Author`, `Review`, `Comment` and `AppUser`. Includes a many-to-many relationship between `Author` and `Book`.
  - 2024 AllAboutPigeons example with 2 persistent model classes: `Message`, with a self-referential composition relationship for replies, and `AppUser`.

## Examples

- 2022 example, using .NET 3.2, SQL Server, and 3 domain model classes:
    - [CS296N-Example-BookReviews](https://github.com/LCC-CIT/CS296N-Example-BookReviews/tree/7-ComplexDomain/BookReviews/BookReviews/Models), branch 7-ComplexDomain on GitHub.
    - [UML class diagram](https://github.com/LCC-CIT/CS296N-Example-BookReviews/blob/7-ComplexDomain/BookReviews/Docs/BookReviewsComplexDomainModel.pdf) of the domain model.

- 2023 example, using .NET 6.0, MySQL, and 5 domain model classes:
    -  [CS296N-Example-BookReviews-DotNet6](https://github.com/LCC-CIT/CS296N-Example-BookReviews/tree/7-ComplexDomain/BookReviews/BookReviews/Models), branch 07-ComplexDomain on GitHub.
    - [UML class diagram](https://github.com/LCC-CIT/CS296N-Example-BookReviews-DotNet6/blob/07-ComplexDomain/Docs/BookReviewsDomainModel.pdf) of the domain model.
- 2024 example using .NET 6.0, MySQL and a domain model with self-referential composition (Message class):
  - [CS296_AllAboutPigeons](https://github.com/ProfBird/CS296_AllAboutPigeons/tree/Lab06), Lab06 branch.



-----

 [![Creative Commons License](https://i.creativecommons.org/l/by/4.0/88x31.png)](http://creativecommons.org/licenses/by/4.0/)ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev), written winter 2023, revised <time>2024</time>, are licensed under a [Creative Commons Attribution 4.0 International License](http://creativecommons.org/licenses/by/4.0/). 
