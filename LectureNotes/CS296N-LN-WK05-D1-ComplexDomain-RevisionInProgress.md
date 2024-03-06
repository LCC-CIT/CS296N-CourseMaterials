---
title: Designing a Domain Model
description: How to use Domain Driven Design and UML to design a more complex domain model. How to write a model so Entity Framework enables cascade deletes of related data in the database.
keywords: Object Oriented Design, UML, Domain Driven Design, domain model, Entity Framework, related data, cascade delete
---
# Designing a Domain Model

**CS296N Web Development 2**

| Weekly topics                   |                                       |
| ------------------------------- | ------------------------------------- |
| 1. Intro to Identity            | <mark>6. Complex domain models</mark> |
| 2. Authentication               | 7. More complex domain models         |
| 3. Authorization                | 8. Validation                         |
| 4. Async/Await                  | 9. Web Security                       |
| 5. Load testing and performance | 10. Term project                      |
| 11. Project Presentations       |                                       |

## Contents

[TOC]

## Q & A

- This week's quiz is closing at 11:59pm. (2024)
- JMeter load testing: I fixed the test plan step for logging into my web site thanks Juliet. (2024)

## Review

### OOP Design and Domain Models

In CS246, System Design, we covered the basics of [Object Oriented Analysis and Design](https://profbird.github.io/CS246-CourseMaterials/LectureNotes/CS246LN-W04-D1-OopDesignReview+UML.html) and how to model the relationships between classes in a UML class diagram like the [Tip of the Day domain model](https://profbird.github.io/CS246-CourseMaterials/LectureNotes/Images/TipOfTheDayDomainModel2022.pdf).  We also looked at how to [implement the relationships in a class diagram in C# code](https://profbird.github.io/CS246-CourseMaterials/LectureNotes/CS246LN-W04-D2-OopDesignReview+Implementation.html). 

### Entity Framework

We learned how to create a DbContext class containing DbSets that are based on our domain models.

------



## Designing Domain Models for ASP.NET Core MVC

### What is a domain model?

- What is the meaning of "[domain](https://www.wolframalpha.com/input/?i=domain)" in general, in math?
- What is meant by the *problem domain* in software development?
- A *domain model* is a set of classes that reflect the relevant things in our problem domain.

### How do we Apply Domain Driven Design?

[Domain Driven Design](https://martinfowler.com/bliki/DomainDrivenDesign.html)

- Use the terminology of the domain (ubiquitous language) for our classes, fields, etc.
- Keep our focus narrow&mdash;on the problem we are solving. Don't make it too general or abstract.
- Identify *aggregates* and *root entities.*
- In the *domain model*, identify the *persistent objects* (those that will be stored in a database) and the *transient objects* (those that will not be stored).  
  Note, ViewModels are *trainsient objects*, but are not part of the *domain model*.

### Example: Book Reviews with a More Complex Domain Model

#### UML diagram

The Book Reviews domain model with Book, Author, and Comments model classes added:

[Domain model UML class diagram](Images/BookReviewsMoreComplexDomainModel.pdf)

##### Questions

Will this more complex domain model:

- facilitate any additional functionality in the web site?[^1]
- make querying more efficient, or queries easier to write?[^2]
- make storage of data in the database more efficient?[^3]

#### C# code

Implementing the domain model in C# is straightforward except for implementing *composition* vs. *aggregation*. Since we are using Entity Framework to persist our model objects, we need to write our code so that EF will understand which dependent entities will be deleted with the root entity (*composition*) and which will not (*aggregation*).

- **Aggregation** is the the default relationship. 
- **Composition** is implemented in the dependent entity by adding an FK that points to the root entity and is a non-nullable int property. This will enable a cascade delete.

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
  public ICollection<Author> Authors { get; set; }  // Association--no FK in Author
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
  public ICollection<Comment> Comments { get; set; }  // Composition--FK in Comment
  public int BookId {get; set;}      // Composition (a Review is part of a Book.)
}

public class Comment
{
   public int CommentId { get; set; }
   public string CommentText { get; set; }
   public AppUser UserName { get; set; }   
   public int ReviewId {get; set;} // Composition (a Comment is part of a Review.)
}
```



### How Entity Framework Maps a Domain Model to a DB Schema

Each persistent domain model entity is mapped to a table in the database. Additional join tables are created where needed. EF creates s*hadow properties* for Foreign Keys if the FK properties were not a part of the domain model. Your instructor prefers to leave FK properties out of the model and let EF create them.

Model classes are identified as persistent by being part of a `DbSet` property of a `DbContext` derived class.

#### Cascade Delete

*Cascade delete* is EF's way of implementing a *composition* relationship. When a root entity is deleted the dependent entities will also be deleted in a *cascade delete* operation in the database. (Look at a migration that includes the SQL command `Create Table` to see cascade delete specified on a FK).

You can control cascade deletes several ways:

- By means of a FK property in the dependent model class:

   - The default is to not do cascade delete when there is no explicit FK property in the dependent model. (See the `Author` model above).  

   - A nullable FK property in the dependent model indicates an optional property in the parent model and will not be cascade deleted.
   - A non-nullable FK property in the dependent model will cause the dependent entities in the database to be cascade deleted.

   -- OR --

- Add a `ModelBuilder` rule in `DbContext.OnModelBuilding`. See [Configuring Cascade Behaviors](https://docs.microsoft.com/en-us/ef/core/saving/cascade-delete#configuring-cascading-behaviors) (Vickers 2022) for descriptions of the options for the `DeleteBehavior` enum.

  Example:

  - 
    In Delamater (2022), this will prevent Genre records from being deleted with a Book record.

    ```C#
    modelBuilder.Entity<Book>()
      .HasOne(b => b.Genre)
      .WithMany(g => g.Books)
    	.OnDelete(DeleteBehavior.Restrict); // don't delete dependent rows
    
    ```

    

#### The database

Look at the database generated by EF. 

- Look for FK columns&mdash;they will be in the tables that represent a collection of objects (like `Reviews`) and will be the PK of a table that represents the model holding the collection (like `BookId` and `ReviewerId`).

  **Reviews Table**

  | ReviewId | BookId | ReviewText                                                | ReviewDate | ReviewerId                           |
  | -------- | ------ | --------------------------------------------------------- | ---------- | ------------------------------------ |
  | PK       | FK     |                                                           |            | FK                                   |
  | 1        | 1      | Great book, a must read!                                  | 2020-11-01 | 7fa122e5-00be-415a-b683-39b2fca90e4c |
  | 2        | 1      | I love the clever, witty dialog                           | 2020-11-15 | b09e9fcd-9cba-4e8f-8a9f-83895baf1d2b |
  | 3        | 2      | Wonderful book, written by a distant cousin of mine.      | 2020-11-30 | 2254a440-0d71-4b10-aaf9-e382595ab62b |
  | 4        | 3      | It was a little hard going at first, but then I loved it! | 2020-11-01 | 2254a440-0d71-4b10-aaf9-e382595ab62b |
  | 5        | 4      | This is a classic that lives up to its reputation!        | 2020-09-22 | 2254a440-0d71-4b10-aaf9-e382595ab62b |




- If an FK is not nullable (`BookId` and `ReviewerId` are not nullable) that means rows in this table will be cascade deleted with rows in the parent tables. If they were nullable, they would not.


  - Look at the constraints in the migration code for the Reviews table. For both FKs, the `onDelete` constraint is set to `ReferentialAction.Cascade`. 
    ```sql
    table.ForeignKey(
        name: "FK_Reviews_AspNetUsers_ReviewerId",
        column: x => x.ReviewerId,
        principalTable: "AspNetUsers",
        principalColumn: "Id",
        onDelete: ReferentialAction.Cascade);
    table.ForeignKey(
        name: "FK_Reviews_Books_BookId",
        column: x => x.BookId,
        principalTable: "Books",
        principalColumn: "BookId",
        onDelete: ReferentialAction.Cascade);
    ```

    


### Demo / Exercise: Modify the BookReview web site

We won't use the full-blown model shown above. We'll just add a Comment class to our existing domain model.

1. Make a UML diagram
   - Identify composition vs. aggregation relationships
   - Identify aggregates and root entities
2. Write the model class
   - Do you need to add foreign keys to any models to enable cascade deletes?[^5]
3. Add Comment objects to the seed data.
4. Modify the exiting view that displays reviews so that users can read and write comments.
   - Modify the repository Reviews property: Add `.Include(r => r.Comments).ThenInclude(c => c.Commenter)` to the code that gets reviews from the DbContext object.
5. **Test what we've done so far**. You should be able to view comments that come from the seed data.
   - Add a new migration (since we changed the domain model)
   - Update the database
6. Write a view and view-model
7. Write new controller methods
   - Comment HttpGet method to display the form for entering comments
   - Comment HttpPost method to store the new comments. 
8. Modify the repository
   - Do we need a new repository method?[^6]
   - Will there be issues with related data being returned from a DbSet?[^7]
9. **Test it again**. You should be able to post comments now.



#### Model Relationships Supported by Entity Framework

- EF Core 3.1 only supported one-to-one, one-to-many, as well as inheritance. 

- EF 6.0 and above automatically implements all of the above as well as many-to-many relationships.



## Examples

2023 Book Review site on GitHub: [MoreComplexDomain branch](https://github.com/LCC-CIT/CS296N-Example-BookReviews-DotNet6)

UML class diagrams of the domain models are in the Doc folder of this repository.



## References

Delamater, Mary, Murach, Joel. "How to work with relationships", pg. 450&ndash;459 in Ch. 12 of *Murach's ASP.NET Core MVC*. 2nd Ed. Murach, 2022. Presents a different approach to defining relationships in a domain model and managing cascade deletes.

Freeman, Adam. [Applying Domain-Driven Development](../ArticleAndNotes/ProAspNetMvc4Freeman-DomainDriveDev.pdf) in ch. 3 of *Pro ASP.NET MVC 4*, Apress, 2012.

Svyryd, Andriy, et al. [Entity Framework Core, Modeling Relationships](https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key#required-and-optional-relationships). 2023

Vickers, Arthur, et al. [Entity Framework Core: Saving Related Data)](https://docs.microsoft.com/en-us/ef/core/saving/related-data). 2022. 

Vickers, Arthur, et al. [Entity Framework Core: Cascade Delete)](https://docs.microsoft.com/en-us/ef/core/saving/cascade-delete). 2022. 



-----

 [![Creative Commons License](https://i.creativecommons.org/l/by/4.0/88x31.png)](http://creativecommons.org/licenses/by/4.0/)ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev), 2018 (Revised winter <time>2023</time>), are licensed under a [Creative Commons Attribution 4.0 International License](http://creativecommons.org/licenses/by/4.0/). 

[^1]: Yes, now users can add comments to reviews, but that's all.
[^2]: Yes, Books and Authors can be directly retrieved from the database. Other queries are simplified.
[^3]: Yes, EF will now create a database that is in 2nd(?) normal form.
[^4]: No, if we model Book as having a collection of Authors, that's all we need. If we want to know all the books written by a given author, we can write a query for that. 
[^5]: Yes, we need to add a FK of `CommentId` to the `Review` class.
[^6]: Yes, we need a method to update Review objects that have had Comments added to them. But, no new method is needed for saving Comments since Review is the root entity of an aggregate with Comment, we will do all operations on Comment through Review.
[^7]: Yes, we will need to modify the Reviews property of the ReviewRepository by adding a `ThenInclude` method for the Comment collection.