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