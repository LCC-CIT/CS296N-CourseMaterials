**CS296N Web Development 2: ASP.NET** 

# Validation of User Input

| Topics by week                       |                                 |
| ------------------------------------ | ------------------------------- |
| 1. Input validation                  | 6. Load Testing and Performance |
| 2. Intro to course and Identity      | 7. Creating a Web Service       |
| 3. Authentication and authorization  | 8. Consuming a Web Service      |
| 4. Publishing to a production server | 9. Docker containers            |
| 5. Security                          | 10. Term project                |

## Contents

[TOC]
------



## Introduction

- Announcements

- We will cover the "left over" topic from fall term, input validation.

  

------



### Review

#### C# Attributes

- Programming Guide: [C# Attributes](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/attributes/)

- Attributes are a means of associating metadata with code

  - Metadata is additional information about types defined in your program (and remember that classes are types).

  - Attributes are declarative.

  - Attributes can be applied to assemblies (think DLLs), classes, methods, and properties. <!--Todo: clarify meaning of BindProperty-->

    ```C#
    [BindProperty]
    public Movie Movie { get; set; }
    ```

  - Attributes can accept arguments.

    ```C#
    [attribute(positional_parameters, name_parameter = value, ...)]
    ```

    - Example using positional parameters:

    <!--Todo: clarify reason for using ObsoleteAttribute-->

    ```C#
    [ObsoleteAttribute("This method is deprecated", false)]
    public void AnOutdatedMethod()
    ```

    - Example using named parameters:

    <!--Todo: Explain the parts of this-->

    ```C#
    [ObsoleteAttribute(Message = "This method is deprecated", IsError = false)]public void AnOutdatedMethod()
    ```

    - API Reference: [ObsoleteAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.obsoleteattribute?view=netcore-2.0)
    
    

------



## Validation 

- Validation is expected in the browser for good UX (user experience), and required on the server for security.
- Good UX design means users are provided with a way to easily fix input entry errors.
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

    <!--Todo: give instructions for this exercise  -->

    - Add a break-point to a request method to test this.
    - Test this again after [disabling JavaScript](https://www.wikihow.com/Disable-JavaScript).

- Validation Example:
  
  ```C#
  [StringLength(60, MinimumLength = 3)]
  [Required]
  public string Title { get; set; }
  ```
  
  

### Validation in the Controller

There are several ways you can perform validation in controller methods:

- Explicit Validation: You add the validation code to a controller method yourself

  - Example: 

    ```C#
    if (string.IsNullOrEmpty(appt.ClientName)) {
      ModelState.AddModelError(nameof(appt.ClientName),
      "Please enter your name");
    }
    ```

  - Model State Dictionary properties and methods:
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

- Make decisions based on Model Validation
  Example:
  ` if (ModelState.IsValid) {   repo.AddBook(book);  }`



### Displaying Validation Errors in the View

- A strongly typed view and model-binding using asp-for tag helpers are required.

- Special Microsoft jQuery functions must be included in the view:
  
```html
  <script src= "https://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.2.0.min.js"></script>
  <script src= "https://ajax.aspnetcdn.com/ajax/jquery.validate/1.16.0/jquery.validate.min.js"></script>
  <script src= "https://ajax.aspnetcdn.com/ajax/jquery.validation.unobtrusive/3.2.6/jquery.validate.unobtrusive.min.js">
  </script>
```

- Tag Helpers that display validation errors

  - Summary
    
  ```html
    <div asp-validation-summary="ModelOnly"></div>
  ```
  
  - Individual field
    
    ```html
    <label asp-for="ClientName">Your name:</label>
    <div><span asp-validation-for="ClientName"></span></div>
    <input asp-for="ClientName" />
    ```
    
    

------



## Notes

#### Nullable and non-nullable model properties

All non-nullable model properties are considered *required* by default. 
Make properties nullable by adding ? to the type&mdash;this will also make them nullable in the database.

#### Display formatting

How to improve the publication date display for books in the BookInfo example:

```C#
[DataType(DataType.Date)]
[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
```

Reference: [DisplayFormatAttribute Class](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.displayformatattribute?view=netcore-2.1)

#### Validation can change the database schema

Add a migration after adding validation annotations that change the database schema:

`dotnet ef migrations add NewMigrationName`



------



## Example

https://github.com/LCC-CIT/CS295N-Bookinfo-Core-21/tree/Validation



------



## References

- Textbook - *Pro ASP.NET Core MVC 2.0*, Adam Freeman, Apress, 2017.
  Ch. 27 "Model Validation"
- [Tutorial: Model validation in ASP.NET Core MVC 
  ](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-2.1)
- [Reference: System.ComponentModel.DataAnnotations Namespace](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=netcore-2.1)



------



[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png)](http://creativecommons.org/licenses/by-sa/4.0/)

ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.online) is licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 
