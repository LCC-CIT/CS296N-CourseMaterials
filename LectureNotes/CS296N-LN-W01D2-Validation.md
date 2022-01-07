**CS296N Web Development 2: ASP.NET** 

# Validation of User Input

| Topics by week                                       |                                 |
| ---------------------------------------------------- | ------------------------------- |
| 1. Intro to course and <mark>Input validation</mark> | 6. Load Testing and Performance |
| 2. Identity                                          | 7. Creating a Web Service       |
| 3. Authentication and authorization                  | 8. Consuming a Web Service      |
| 4. Publishing to a production server                 | 9. Docker containers            |
| 5. Security                                          | 10. Term project                |



## Contents

[TOC]
## Introduction

- This week, we will cover the "left over" topic from fall term, input validation.



### Review Concept for This Week's Topic

#### C# Attributes

- Programming Guide: [C# Attributes](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/attributes/)

- Attributes are a means of associating metadata with code

  - Metadata is additional information about types defined in your program (and remember that classes are types).
- Attributes are declarative.
  - Attributes can be applied to assemblies (think DLLs), classes, methods, and properties. 

  

## Validation 

- Validation is expected in the browser for good UX (user experience), and required on the server for security.
- Good UX design means users are provided with an easy way to fix input errors.
- In ASP.NET Core MVC, validation is done on the models.
- Validation is implemented using C# attributes. In .NET Core, attributes that are used on model properties are called *data annotations*.

#### Data Annotations

- API Reference: [System.ComponentModel.DataAnnotations Namespace](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=netcore-2.0)

  - Most of these attributes are for validation.
  
  

### Validation Using Data Annotations

- Validation is specified on the  model properties and is then enforced in multiple places:

  - In the database.

  - In HTML form elements in the browser using jQuery validate.

  - In HTTP Requests processed on the server (in case JavaScript is disabled in the browser).

    - Add a break-point to a request method to test this.
- Test this again after [disabling JavaScript](https://www.wikihow.com/Disable-JavaScript).
  
- Validation Example:
  
  ```C#
  [StringLength(60, MinimumLength = 3)]
  [Required]
  public string Title { get; set; }
  ```
  

#### Common validation annotations

- `[EmailAddress]` validates that a string property is formatted as an email address.

  ```c#
  [EmailAddress]
  public string Email { get; set; }
  ```

- `[Range]` validates that a property value is within a specified range.

  ```C#
  [Range(1, 10)]
  public int Rating { get; set; }
  ```

- `[RegularExpression]` validates that a string matches a specified [regular expression](https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expressions).

  - Date example:

    ```C#
    [RegularExpression(@"^(0[1-9]|1[012])/(0[1-9]|[12][0-9]|3[01])/(20\d\d)$")]
    public DateTime Birthday {get, set;}
    ```

    The regular expression above checks for date in *mm/dd/yyyy* format, for example, 01/19/2020.

  - User name example: 

    ```c#
    [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$")]
    public string UserName {get, set;}
    ```

    The regular expression above checks for the following criteria:

  - UserName can contain the first and last name with a single space. 
  - The last name is optional. If the last name is not present, then there shouldn’t be any space after the first name.
  3. Only upper and lower case alphabets are allowed.
  3. This example is from [Dot Net Tutorials, Regular Expression Attribute in ASP.NET MVC](https://dotnettutorials.net/lesson/regular-expression-attribute-mvc/)

- `[Required]` validates that the property is not null.

  ```C#
  [Required]
  public string Name { get; set; }
  ```

- `[StringLength]`validates that a string property value doesn't exceed a specified length limit.

  ```C#
  [StringLength(1000, MinimumLength = 10)]
  public string ReviewText { get; set; }
  ```

- For a complete list see:  [System.ComponentModel.DataAnnotations Namespace](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=netcore-2.1)

#### Custom error messages

Custom error messages can be added to the validation attribute. For example:

```c#
[Required(ErrorMessage = "Please enter your name")]
```

#### <mark>Exercises</mark>

- Try adding a migration to your project. Has the schema changed?
- Try running the web app. Can you enter invalid data? Are there any error messages?
- Write a unit test for an HttpPost controller method that uses a data model with validation. Will the method accept the data and store it in the repository?

### Validation in the View

A strongly typed view with model-binding using asp-for tag helpers is required.

#### JavaScript Libraries Required

Links to JavaScript libraries for validation are required. Either libraries that are in CDNs, like those shown in the code snippets below, or libraries that are in the ```wwwroot``` folder of your project can be used.

##### jQuery

In *_Layout.cshtml* add a line like this to load jQuery (if it isn't already there):

```html
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
```

##### jQuery validate and unobtrusive validation

Add a script section with links to validation libraries to the bottom of each view that needs to do validation:

```html
@section Scripts {
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.1/jquery.validate.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validation-unobtrusive/3.2.11/jquery.validate.unobtrusive.min.js"></script>
}
```

(Note: Look near the bottom of  *_Layout.cshtml* to see how it processes ```@section Scripts```)

**or**

In *_ValidationScriptsPartial.cshtml* add these lines:

```html
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.1/jquery.validate.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validation-unobtrusive/3.2.11/jquery.validate.unobtrusive.min.js"></script>
```

And in each view that needs to do validation add code to load the libraries listed above:

```javascript
@section Scripts {
    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
}
```



#### Displaying Validation Errors

There are tag helpers for displaying validation errors on individual fields and for displaying a summary of validation errors.

##### Individual field

```html
<label asp-for="ClientName">Your name:</label>
<span asp-validation-for="ClientName"></span>
<input asp-for="ClientName" />
```

##### Summary

```html
<form method="post">
    <div asp-validation-summary="All"></div>
```

  Options for the value are:

  - `All`
  - `ModelOnly`
  - `None`

##### <mark>Exercises</mark>

- Try entering invalid data. Do you get error messages?
- Put a break-point in the controller method that gets called with the data from the view with validation tag helpers. Does the method get called when you enter invalid data?




### Validation in the Controller

There are several ways you can perform validation in controller methods:

- Make decisions based on model validation. 
  
  Example:
  
  ```C#
  if (ModelState.IsValid) {
     repo.AddBook(book);
  }
  ```
  
- Explicit Validation: You add the validation code to a controller method yourself and put values in the Modelstate dictionary.

  - Example: 

    ```C#
    if (string.IsNullOrEmpty(appt.ClientName)) {
      ModelState.AddModelError(nameof(appt.ClientName),
      "Please enter your name");
    }
    ```

  - Modelstate dictionary properties and methods:

    - `AddModelError(property, message)`

      This method is used to record a model validation error for the specified property.

    - `GetValidationState(property)`

      This method is used to determine whether there are model validation errors for a specific property, expressed as a value from the `ModelValidationState` enumeration:

      - *Unvalidated* 

        This value means that no validation has been performed on the model property, usually because there was no value in the request that corresponded to the property name.

      - *Valid* 

        This value means that the request value associated with the property is valid.

      - *Invalid* 

        This value means that the request value associated with the property is invalid and should not be used.

      - *Skipped* 

        This value means that the model property has not been processed, which usually means that there have been so many validation errors that there is no point continuing to perform validation checks.

    - `IsValid`

      This property returns true if all the model properties are valid and returns false otherwise.

#### <mark>Exercises</mark>

- Run the unit test for the controller method which now checks `ModelState.isValid`

## Notes

#### Nullable and non-nullable model properties

- All non-nullable model properties are considered *required* by default.
  - In C#, value types (like int, float, bool) are non-nullable by default. Reference types (like string and other classes) are nullable by default.
- You can make properties nullable by adding ? to the type&mdash;this will also make them nullable in the database and also not required for validation.

#### Validation annotations can change the database schema

Some validation annotations  will cause Entity Framework to change the database schema. Here is a partial list:

- Required
- StringLength

You will need to add a migration and update the database after adding validation annotations that change the database schema.

`dotnet ef migrations add NewMigrationName`

`dotnet ef database update`

------



## Examples

- Instructor's 2020 example, [BookInfo: Validation branch](https://github.com/ProfBird/BookInfo-WebApp-Core3/tree/Validation)

- Instructor's 2021 example, [BookReviews: Lab01 branch](https://github.com/LCC-CIT/CS296N-Winter2021LabExample/tree/Lab01)

- Pro ASP.NET Core MVC 2, Ch. 27: [Model validation example](https://github.com/Apress/pro-asp.net-core-mvc-2/tree/master/27%20-%20Model%20Validation/ModelValidation)

- Microsoft Tutorial, MVC Movies: [Validation example](https://github.com/aspnet/AspNetCore.Docs/tree/master/aspnetcore/mvc/models/validation/samples/2.x/ValidationSample)

  



## References

- Textbook - *Murach's ASP.NET Core MVC*, Delameter and Murach, Murach, 2020.
  - Ch. 2, pg. 70–74, "How to validate user input"
  - Ch. 11, "How to validate data"
- *Pro ASP.NET Core MVC 2.0*, Adam Freeman, Apress, 2017.
  - Ch. 2 "Your First MVC Application", Adding Validation, pp. 38&ndash;45
  - Ch. 27 "Model Validation", 
- Microsoft tutorial, MVC Movies: [Model validation in ASP.NET Core MVC  and Razor Pages](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-3.1)
- Reference: [System.ComponentModel.DataAnnotations Namespace](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=netcore-2.1)&mdash;Contains a complete list of validation attributes.
- Microsoft tutorial, Tag Helpers: [Validation Tag Helpers](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/working-with-forms?view=aspnetcore-3.1#the-validation-tag-helpers)

------



[![ccbysa88x31](ccbysa88x31.png)](http://creativecommons.org/licenses/by-sa/4.0/)ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev), written 2020, revised 2021, are licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 

