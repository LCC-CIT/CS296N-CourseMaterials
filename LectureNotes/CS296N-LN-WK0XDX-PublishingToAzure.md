---
title: Pagination
description: How to paginate data coming from a query done through EF.
keywords: Entity Framework, pagination, query
material: Lecture Notes
generator: Typora
author: Brian Bird
---

**[CS296N Web Development 2: ASP.NET](http://lcc-cit.github.io/CS296N-CourseMaterials/)**

<h1>Pagination</h1>



<h2>Contents</h2>

[TOC]
## Implementation using `Skip` and `Take` statements

See the reference below.



## Implementation using PagedList.MVC 

The PagedList NuGet package installs a PagedList collection type and extension methods for IQueryable and IEnumerable collections. The extension methods create a single page of data in a PagedList collection out of your IQueryable or IEnumerable, and the PagedList collection provides several properties and methods that facilitate paging. The PagedList.Mvc package installs a paging helper that displays the paging buttons.

### The Razor View

In the .cshtml file:

```C#
Page @(Model.PageCount < Model.PageNumber ? 0 : Model.PageNumber) of @Model.PageCount

@Html.PagedListPager(Model, page => Url.Action("Index", 
    new { page, sortOrder = ViewBag.CurrentSort, currentFilter = ViewBag.CurrentFilter }))
```

The @model statement at the top of the page specifies that the view now gets a PagedList object instead of a List object.

The using statement for PagedList.Mvc gives access to the MVC helper for the paging buttons.

## References

Various, [Tutorial: Add sorting, filtering, and paging with the Entity Framework in an ASP.NET MVC application](https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/sorting-filtering-and-paging-with-the-entity-framework-in-an-asp-net-mvc-application), Microsoft, 2022.

- This tutorial uses the PagedList.MVC NuGet package to implement paging.

Various, [Tutorial: Add sorting, filtering, and paging - ASP.NET MVC with EF Core](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/sort-filter-page?view=aspnetcore-5.0), Microsoft, 2022.

- This tutorial uses `Skip` and `Take` statements to implement paging.



------

[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png)](http://creativecommons.org/licenses/by-sa/4.0/) 
​ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev), 2020, revised <time>2022</time>, are licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 

------