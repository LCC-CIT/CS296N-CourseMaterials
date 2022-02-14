# Using the Repository Pattern and Unit Testing in ASP.NET Core MVC Web Apps

[TOC]

## Background Research and Exploration

[Returning IQueryable from Repository Pattern](https://weblogs.asp.net/dotnetstories/repository-iqueryable). Nikolaos Kantzelis ASP.Net Blog. 2016.

Nikolaos makes some good arguments against returning IQueryable from a repository because it violates separation of concerns. But, I still think it's worth it for performance sake.



https://weblogs.asp.net/dotnetstories/repositorypatternEFCore.Nikolaos Kantzelis ASP.Net Blog. 2021.

Nikolaos argues that EF Core is now 100% test friendly and there is no longer any need to use the repository pattern. 

In a nutshell, Entity Framework **already** implements a repository pattern**. DbContext** is the UoW (Unit of Work) and each **DbSet** is the repository. **IDbSet** is the same thing as **IRepository**.



[Test ASP.NET Core MVC apps](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/test-asp-net-core-mvc-apps). Microsoft tutorial. 2022.

Overview of testing: Unit testing,
Integration testing and
Functional testing ASP.NET Core apps.

https://methodpoet.com/unit-testing-with-moq/

Good tutorial on using moq.  

https://dotnetfalcon.com/supporting-async-linq-evaluation-on-iqueryable-mocks/

This author has a great solution for providing a data source that is both async and queryable, but, sadly, it requires a data type, InMemoryQueryable, that is in .NET 4.7 (Old .NET), but not in .NET 6 (.NET Core).

```C#
var inMemoryQueryable = new InMemoryAsyncQueryable<string>(myList);
InMemoryAsyncQueryable<Review> asyncReviews = 
  new InMemoryAsyncQueryable<string>(reviews);
```



## Example of Mocking the Author Index Unit Test in the Book Reviews Project (Unsuccessful)

This didn't work because I couldn't create a data source that implemented both IQueryable and IAsyncEnumerable&mdash;the type returned by the real repository.

```C#
// Create a mock repository instead of using FakeRepository
var repo = new Mock<IReviewRepository>();

// Create a regular old list as a data source
var reviews = new List<Review>();

// Convert the list to use IAsyncEnumerable
var asyncReviews = reviews.ToAsyncEnumerable<Review>();

// Can't convert IAsyncEnumerable to IAsyncQueryable and vice-versa
//var queryableAsyncReviews = asyncReviews.AsQueryable();

// Mock the Reviews property to get an IQueryable for all reviews
repo.SetupGet(x => x.Reviews).Returns(queryableReviews.ToAsyncEnumerable()); 


```



## A Solution that Works Using the Repository Pattern without Moq

I opted for the non-moq version because I was already using the repository pattern, but the solution looks like it's easier if you use Moq.

[Testing with your own test doubles](https://docs.microsoft.com/en-us/ef/ef6/fundamentals/testing/writing-test-doubles). Microsoft tutorial. 2020.

I implemented this here:



