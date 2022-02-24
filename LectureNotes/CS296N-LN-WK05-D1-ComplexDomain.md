---
title: Designing a Domain Model
description: Using Domain Driven Development and UML to design a more complex domain model.
keywords: Object Oriented Design, UML, Domain Driven Design, domain model, Entity Framework
---
# Designing a Domain Model

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

### OOP Design and Domain Models

In CS246, System Design, we covered the basics of [Object Oriented Analysis and Design](https://profbird.github.io/CS246-CourseMaterials/LectureNotes/CS246LN-W04-D1-OopDesignReview+UML.html) and how to model the relationships between classes in a UML class diagram like the [Tip of the Day domain model](https://profbird.github.io/CS246-CourseMaterials/LectureNotes/Images/TipOfTheDayDomainModel2022.pdf).  We also looked at how to [implement the relationships in a class diagram in C# code](https://profbird.github.io/CS246-CourseMaterials/LectureNotes/CS246LN-W04-D2-OopDesignReview+Implementation.html). 

### Entity Framework

We learned how to create a DbContext class containing DbSets that are based on our domain models.

------



## Designing Domain Models for ASP.NET Core MVC

### What is a domain model?

- What is the meaning of "[domain](https://www.wolframalpha.com/input/?i=domain)" in general, in math?
- What is meant by the problem "domain" in software development?
- A domain model is a set of classes that reflect the relevant things in our problem domain that we want to persist in a database.

### How do we Apply Domain Driven Design?

[Domain Driven Design](https://martinfowler.com/bliki/DomainDrivenDesign.html)

- Use the terminology of the domain (ubiquitous language) for our classes, fields, etc..
- Keep our focus narrow&mdash;on the problem we are solving. Don't make it too general or abstract.
- Identify aggregates and root entities.
- Separate the domain model from other classes responsible for persistence.

### Example: Book Reviews with a More Complex Domain Model

#### UML diagram

The Book Reviews domain model with Book, Author, and Comments model classes added:

[Domain model UML class diagram](Images/BookReviewsMoreComplexDomainModel.pdf)

#### C# code

Implementing the domain model in C# is straightforward except for implementing composition vs. aggregation. Since we are using Entity Framework to persist our model objects, we need to write our code so that EF will understand which dependent entities will be deleted with the root entity (composition) and which will not.

Aggregation is the the default relationship. If we want to specify composition, we do it in the dependent entity by adding an FK that points to the root entity and is a non-nullable property.

Code based on the UML class diagram:

```c#
public class AppUser : IdentityUser
{
  public string Name { get; set; }  // Real name
}

public class Book
{
	public int BookId { get; set; }
  public string Title { get; set; }
  public DateTime PubDate { get; set; }
  public ICollection<Author> Authors { get; set; }
  public ICollection<Review> Reviews { get; set; }  // Composition--FK in Review
}

public class Author
{
  public int AuthorId { get; set; }
  public string Name { get; set; }
  public DateTime Birthday { get; set; }
}

public class Review
{
  public int ReviewId { get; set; }
  public string ReviewText { get; set; }
  public AppUser Reviewer { get; set; }               
  public ICollection<Comment> Comments { get; set; }  // Compositioin--FK in review
  public int BookId {get; set;}      // Composition (a review is part of a book.)
}

public class Comment
{
   public int CommentId { get; set; }
   public string CommentText { get; set; }
   public AppUser UserName { get; set; }   
   public int ReviewId {get; set;} // Composition (a comment is part of a review.)
}
```



### How Entity Framework Maps a Domain Model to a DB Schema

Each domain model entity is mapped to a table in the database. Additional join tables are created where needed.

- EF creates "shadow properties" for Foreign Keys if the FK properties were not a part of the domain model. Your instructor prefers to leave FK properties out of the model and let EF create them.

- 
  When a root entity is deleted the dependent entities will also be deleted in a *cascade delete* operation in the database. (Look  at a migration with Create Table to see cascade delete specified on a FK).


  In order to signal EF not to do a cascade delete, include the FK property explicitly in the model and make it nullable. (See above).

#### Model Relationships Supported by Entity Framework

EF Core 3.1 supports one-to-one, one-to-many, as well as inheritance. 

- While many-to-many relationships aren't automatically implemented in version 3.1, you can implement this relationship by using a model entity that represents a join table. 

  But, most of the time this relationship isn't needed and just complicates your system. For example: Do we need a many-to-many relationship to manage books that have multiple authors and authors that have written multiple books?
- Inheritance doesn't translate well to a database schema. All the inherited properties end up in one table.

EF 6 automatically implements many-to-many relationships.

#### The database

Look at the database generated by EF. 

- Look for FK columns&mdash;they will be in the tables that represent collections and will be the PK of a table that represents the model holding the collection.
- If the FK is not nullable then it means that records in that table will be cascade deleted. Otherwise, if it's nullable, they will not.



### Demo / Exercise: Modify the BookReview web site

We won't use the full-blown model shown above. We'll just add a comment model

1. Make a UML diagram
   - Identify composition vs. aggregation relationships
   - Identify aggregates and root entities
2. Write the model class
   - Do you need to add non-nullable foreign keys to any models?
3. Write a view and view-model
4. Write controller methods
   - Do we need a new repository method?
   - Will there be issues with related data being returned from a DbSet?



## Examples

Book Review site on GitHub: [ComplexDomain branch](https://github.com/LCC-CIT/CS296N-Example-BookReviews/tree/7-ComplexDomain), and [running on Azure](https://bookreviews.azurewebsites.net/).

Book Review site on GitHub: [MoreComplexDomain branch](https://github.com/LCC-CIT/CS296N-Example-BookReviews/tree/7-MoreComplexDomain)



## References

Freeman, Adam. [Applying Domain-Driven Development](../ArticleAndNotes/ProAspNetMvc4Freeman-DomainDriveDev.pdf) in ch. 3 of *Pro ASP.NET MVC 4*, Apress, 2012.

Vickers, Arthur, et al. [Entity Framework Core: Saving Related Data)](https://docs.microsoft.com/en-us/ef/core/saving/related-data). 2022. 

Vickers, Arthur, et al. [Entity Framework Core: Cascade Delete)](https://docs.microsoft.com/en-us/ef/core/saving/cascade-delete). 2022. 



------

 [![Creative Commons License](https://i.creativecommons.org/l/by/4.0/88x31.png)](http://creativecommons.org/licenses/by/4.0/)ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev), 2018 (Revised winter <time>2022</time>), are licensed under a [Creative Commons Attribution 4.0 International License](http://creativecommons.org/licenses/by/4.0/). 

------