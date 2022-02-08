# *Introduction to Async and Await in C#*

| Weekly topics                              |                                 |
| ------------------------------------------ | ------------------------------- |
| 1. Intro to course and Input validation    | **6. Async/Await**              |
| 2. Repositories and Unit Testing           | 7. Load Testing and Performance |
| 3. Publishing to Azure / Intro to Identity | 8. Complex Domain Models        |
| 4. Authentication                          | 9. Docker containers            |
| 5. Authorization                           | 10. Term project                |


[TOC]

## Task Asynchronous Programming Model

Asynchronous methods are non-blocking methods. Execution moves on to the next line  of code after the method call without waiting for the method to return.

Each async method returns a *Task* object. You can start as many Async methods as you want (within  practical limits) without waiting for one to finish before you start  another.

The *await* keyword provides a way to pause execution until an async method  completes or until it returns a Task object. Using await on a Task  rather than a method often improves performance.

Use the *async* keyword when declaring an asynchronous method. Any method declared as  async, must return a Task object. Every async method must be called from within another async method or use the .*Wait()* method when calling the async method.

## Examples

[Async breakfast example](https://github.com/dotnet/docs/tree/main/docs/csharp/programming-guide/concepts/async/snippets/index) (for the Microsoft tutorial).

[Simplified async breakfast and async timer examples](https://github.com/LCC-CIT/AsyncAwaitDemo) (Instructor's examples)

## References

Dumont, Mika and Wagner, Bill. [Introduction To Async, Await, nd Tasks | C# Advanced \(Episodes 5&ndash;8\)](https://channel9.msdn.com/Series/C-Advanced/Introduction-To-Async-Await-And-Tasks--C-Advanced-5-of-8?term=async await&lang-en=true). 2020. Microsoft C# Advanced Video Tutorial. This is the video version of the "async breakfast" tutorial.

Wagner, bill, et al. [Task Asynchronous Programming Model](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/task-asynchronous-programming-model). 2021. Microsoft Tutorial

Wenzel, Maria, et al [Asynchronous programming with async and await](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/). 2019. Microsoft Programming Guide. (This is the written version of the "async breakfast" tutorial.)

 

------

[![Creative Commons License](https://i.creativecommons.org/l/by/4.0/88x31.png)](http://creativecommons.org/licenses/by/4.0/) These ASP.NET Core MVC Lecture Notes, written by [Brian Bird](https://profbird.dev), fall 2019, revised winter 2022, are licensed under a [Creative Commons Attribution 4.0 International License](http://creativecommons.org/licenses/by/4.0/). 

------

 