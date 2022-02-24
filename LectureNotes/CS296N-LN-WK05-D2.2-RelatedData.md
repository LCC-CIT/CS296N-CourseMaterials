---
title: Working with Scaffolding and Related Data
description: You will learn how to scaffold a domain model entity to create views and controller methods. You will also learn to manage the way Entity Framework handles related data.
---
# Working with Related Data

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

### Entity Framework

You have already learned how to include related data when retrieving an entity from a DbSet. We did this using `Include` and `ThenInclude` which is the way to do *eager loading*. Today, you will learn about other ways to load related data.



## Loading Related Data

When a model class has composition or aggregation relationships to other classes, the data in those other classes is referred to as *related data*. With EF, when you get data from a DbSet, the default is that you only get the data from the entity represented by that DbSet. You don't get related data with it. There are three ways to get related data:

- Eager loading
- Lazy loading
- Explicit loading

### Eager Loading


This is the way we loaded related data in BookReviews, `ReviewRepoistory.Reviews` using `Include` and `ThenInclude`:

```C#
using (var context = new BookReviewContext())
{
    var reviews = context.Reviews
              .Include(r => r.Reviewer)
              .Include(r => r.Comments)
              .ThenInclude(r => r.Commenter);
}
```

- `Include` is used to include the related data from the entity specified in the lambda expression. Subsequent Include statements are used for other entities at the same level (properties on the same entity as the previous Include).
- `ThenInclude` is used to include related data from the next level down (properties on the entity in the include statement's lambda).

#### When to Use Eager Loading

Use eager loading when you know that you will need all of the related data. If you know you will only need some of the related data, then use explicit loading instead.



### Lazy Loading

When an entity is first read, the related data isn't included. But, the first time you read data from the property for a composed or aggregated entity, the data will be automatically retrieved. 

#### How to Use Lazy Loading

In order to use lazy loading you need to do the following:

- Install the [Microsoft.EntityFrameworkCore.Proxies](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Proxies/) NuGet package.

- 
  In Startup, Configuration, modify the code for adding a DbContext by adding the method`UseLazyLoadingProxies()` call.

  ```C#
  services.AddDbContext<BookReviewContext>( options => options
                            .UseLazyLoadingProxies()
            								.UseSqlServerConfiguration["ConnectionStrings:MyCon"]));
  ```

- 
  Make any property with which you wish to use lazy loading `virtual` so that it can be overridden by the lazy loading proxy. 

  You don't need to add a new migration after making these properties virtual.

  ```C#
  public class Review
  {
    // properties omitted...
    public virtual AppUser Reviewer { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }  
  }
  
  public class Comment
      {
  				// properties omitted...
          public virtual AppUser Commenter { get; set; }
          public int ReviewId { get; set; }  // FK to cause cascade delete
      }
  ```

- Just query your data as if you had used `Include` . The related data will only  be loaded if it is needed.

#### When to Use Lazy Loading

Because not all the data is retrieved at once, lazy loading can cause extra database roundtrips that would be avoided if you used eager or explicit loading. Use lazy loading when it is unpredictable what data you will need, but you are more likely not use related data.



### Explicit Loading

This is similar to lazy loading in that when the entity is first read, related data isn't loaded. The difference is that the related data won't be automatically loaded. You need to write code to explicitly load the related data you want. For example:

```C#
using (var context = new BookReviewContext())
{
    // Get a Review IQueryable object. This loads no data.
    var review = context.Reviews.First();
    // Load the Comments collection
    context.Entry(review).Collection(r => r.Comments).Load();
		// Load the Reviewer object
    context.Entry(review).Reference(r => r.Reviewer).Load();
}
```

In the above example, querying Context.Reviews will return an IQueryable. When you call Load() on a query, it has the same effect as ToList(), except it doesn't build the list. It just stores the data locally in EF's memory space.

If you want to load more than one related entity, you should do it in one query expression so that there is only one round-trip to the database. For example:

```C#
context.Entry(review).Collection(r => r.Comments).Reference(r => r.Reviewer).Load();
```



#### When to Use Explicit Loading

Use explicit loading when you know you will need some, but not all of the related data. If you know you will need all of the related data, use eager loading instead.



### Exercise / Demo: BookReview web site

Experiment with eager and lazy loading



## Examples

Book Review site on GitHub: [ComplexDomain branch](https://github.com/LCC-CIT/CS296N-Example-BookReviews/tree/7-ComplexDomain), and [running on Azure](https://bookreviews.azurewebsites.net/).

Book Review site on GitHub: [MoreComplexDomain branch](https://github.com/LCC-CIT/CS296N-Example-BookReviews/tree/7-MoreComplexDomain)



## References

Anderson, Rick. [Tutorial: Read related data - ASP.NET MVC with EF Core](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/read-related-data?view=aspnetcore-3.1). A Microsoft tutorial. 2022.

Delamater, Mary, Murach, Joel. "How to work with related data" 156 &ndash;165 in Ch. 4 of *Murach's ASP.NET Core MVC*. Murach, 2020. Presents a somewhat different approach to working with related data.

Rojansky, Shay, et al. [Loading Related Data](https://docs.microsoft.com/en-us/ef/core/querying/related-data/). A Microsoft tutorial. 2021.



------

 [![Creative Commons License](https://i.creativecommons.org/l/by/4.0/88x31.png)](http://creativecommons.org/licenses/by/4.0/) ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev), 2018 (Revised winter <time>2022</time>), are licensed under a [Creative Commons Attribution 4.0 International License](http://creativecommons.org/licenses/by/4.0/). 

------