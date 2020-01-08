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

#### Display formatting

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

  



