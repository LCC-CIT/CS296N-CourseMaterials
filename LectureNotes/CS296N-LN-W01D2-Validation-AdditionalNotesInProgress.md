[TOC]

## C# Attribute examples

- <!--Todo: clarify meaning of BindProperty-->

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
  
  

## DateTime Data Annotations

### Validation

Just adding the `[DataType(DataType.Date)]` annotation to a model property will enable a DateTime field in a form to be validated using the `asp-validation-for` tag helper. Validation will look for date to be entered in the m/d/y or mm/dd/yyyy formats (and allows years that go beyond four digits).

Adding the `[DisplayFormat(DataFormatString = "blah blah")]` annotation to the model property will not change the validation criteria, nor will it change what DateTime will accept as a valid date entry.

Adding `[RegularExpression("blah blah")]` annotation will add an additional validation, but won't  change the validation criteria, nor will it change what DateTime will accept as a valid date entry. It just adds an additional validation criteria which could conflict with the one coming from DataType.



### Display formatting

Format the publication date display for books in the BookInfo example app so that only the month, day, and year are displayed&mdash;not the time.

```C#
[DataType(DataType.Date)]
[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
public DateTime PubDate { get; set; }
```

Reference: [DisplayFormatAttribute Class](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.displayformatattribute?view=netcore-2.1)

To make this work, you need to use an HTML helper in the view:

```C#
 @Html.DisplayFor(modelItem => book.PubDate)
```

Reference: [HTML Helper Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.viewfeatures.htmlhelper?view=aspnetcore-3.1)



## Notes from reading Freeman (1/7/20)

### Ch. 2

- Validation based on validation attributes on the models is called *declarative validation*.

- Custom error messages can be added to the validation attribute. For example:

  ```c#
  [Required(ErrorMessage = "Please enter your name")]
  ```

- C# properties that have data types that are non-nullable by default will not automatically be treated as required by the validation tag-helpers in the browser or the Modelstate set in the controller.

- If Modelstate is invalid in the controller, returning the view will provide the user with appropriate error messages.

  ```C#
    public ViewResult RsvpForm(GuestResponse guestResponse) {
              if (ModelState.IsValid) {
                  Repository.AddResponse(guestResponse);
                  return View("Thanks", guestResponse);
              } else {
                  // there is a validation error
                  return View();
              }
  ```

  

- CSS can be used to highlight fields based on the validation status:

  ```css
  .field-validation-error {color: #f00;}
  .field-validation-valid { display: none;}
  .input-validation-error { border: 1px solid #f00; background-color: #fee; }
  .validation-summary-errors { font-weight: bold; color: #f00;}
  .validation-summary-valid { display: none;}
  ```

  

### Ch. 27

Read: Specifying Validation Rules Using Metadata 864—868

Skim 869–870, creating a custom validation attribute

Read: 870—871, performing client side validation



Javascript libraries need to be specified in the following order:

```HTML
@section scripts {
<script asp-src-include="lib/jquery/dist/*.min.js"></script>
<script asp-src-include="lib/jquery-validation/dist/jquery.*.min.js"></script>
<script asp-src-include="lib/jquery-validation-unobtrusive/*.min.js"></script>
}
```



## HTML data-* attribute

The data-* attributes is used to store custom data. [w3Schools](https://www.w3schools.com/tags/att_global_data.asp)