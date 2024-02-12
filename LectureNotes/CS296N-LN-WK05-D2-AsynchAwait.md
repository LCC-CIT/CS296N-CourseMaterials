# *Introduction to Async and Await in C#*

| Weekly topics               |                                 |
| --------------------------- | ------------------------------- |
| 1. Intro to Identity        | 6. Load testing and performance |
| 2. Ice storm                | 7. Complex domain models        |
| 3. Authentication           | 8. Validation                   |
| 4. Authorization            | 9. Security                     |
| 5. <mark>Async/Await</mark> | 10. Term project                |


[TOC]

## Intro

- Q and A



## Task Asynchronous Programming Model

- **Non-blocking methods**  
  Asynchronous methods are *non-blocking* methods. Execution moves on to the next line of code after the method call without waiting for the method to return.

- **Delcare an `async` method**  
  Use the `async` keyword when declaring an asynchronous method. Any method declared as `async`, must return a `Task` object. Every `async` method must be called from within another `async` method or use the `.Wait()` method when calling the `async` method.
- **The `Task` object**  
  Each `async` method returns a `Task` object. You can start as many `Async` methods as you want (within  practical limits) without waiting for one to finish before starting another. 

- **`Await` completion of an async method**  
  The `await` keyword provides a way to pause execution until an async method  completes or until it returns a Task object. Using await on a Task  rather than a method often improves performance.

- **Running synchronous code assynchronously**  
  Synchronous code can be made asynchronous using `Task.Run(()=> SomeSyncronousCode);`

### Viewing Running Threads

If you want to see the threads created by your tasks, you can view processes and threads running on Windows using the free [Process Explorer](https://docs.microsoft.com/en-us/sysinternals/downloads/process-explorer) app.



## Asynchronous Programming for ASP.NET MVC

### Why Use Async Methods?

Since the MVC framework only creates one short-lived instance of each controller objects, in response to HTTP requests, there won't be much need to run tasks concurrently for a single user. But, when we have <u>multiple users</u> on our site, we will need to run tasks concurrently because there are multiple users accessing the site simultaneously.

### Making Your Controller Methods Asynchronous

The only controller methods that need to be async are those that are:

- **I/O bound**: code that does input/output, like accessing a database or web service.
- **CPU bound**: code that takes a long time to execute. For example, code that does many iterations of a loop, or deep recursion.

 In the instructor's example app and most of your lab apps, you only have i/o bound methods--those that access the database either through the DbContext object or Identity (the UserManager, RoleManager, etc.). The methods that use those are the ones that need to be made async.

Making controller methods async will have ripple effects:

- You will need to make methods in the repository async as well—Interface, real repository, and fake repository. 
- You will need to modify any affected unit tests to use `.Wait()` on the async controller methods they call.



## Examples

[Async breakfast example](https://github.com/dotnet/docs/tree/main/docs/csharp/programming-guide/concepts/async/snippets/index) (for the Microsoft tutorial).

[Simplified async breakfast and async timer examples](https://github.com/LCC-CIT/AsyncAwaitDemo) (Instructor's examples)



## Conclusion

- Look at due dates 
- Look at next week's topic



## References

Dumont, Mika and Wagner, Bill. [Introduction To Async, Await, nd Tasks | C# Advanced \(Episodes 5&ndash;8\)](https://channel9.msdn.com/Series/C-Advanced/Introduction-To-Async-Await-And-Tasks--C-Advanced-5-of-8?term=async await&lang-en=true). 2020. Microsoft C# Advanced Video Tutorial. (The video version of the "async breakfast" tutorial.)

Wagner, Bill, et al. [Task Asynchronous Programming Model](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/task-asynchronous-programming-model). 2021. Microsoft Tutorial

Wagner, Bill, et al. [Asynchronous Programming](https://docs.microsoft.com/en-us/dotnet/csharp/async). 2022. Microsoft C# Programming Guide

Wenzel, Maria, et al [Asynchronous programming with async and await](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/). 2019. Microsoft Programming Guide. (This is the written version of the "async breakfast" tutorial.)

[Asynchronous Programming with Entity Framework and Linq](https://learn.microsoft.com/en-us/ef/core/miscellaneous/async). 2022. Microsoft.

------

[![Creative Commons License](https://i.creativecommons.org/l/by/4.0/88x31.png)](http://creativecommons.org/licenses/by/4.0/) These ASP.NET Core MVC Lecture Notes, written by [Brian Bird](https://profbird.dev), fall 2019, revised winter 2024, are licensed under a [Creative Commons Attribution 4.0 International License](http://creativecommons.org/licenses/by/4.0/). 

------

 