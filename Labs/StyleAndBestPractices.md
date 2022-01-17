# C# Style and Best Practices Guide

[TOC]

## Style

### Layout

- White Space
  - Put blank lines between methods
  - Put each class in a separate file
- Indentation

- Subordinate blocks of code are indented.

- Opening curly braces are placed below their associated line of code.

- Conditional statements are always inside curly braces. (A style requirement, not a language requirement.)

  ```
  if (gallons < 1)
  {
      isLowFuel = true;
  }
  ```

### Naming of variables, methods, classes, etc.

- Names should be descriptive.

- Boolean variables are prefixed with *is*, like `isValid`.

- UI elements have the element type as a suffix, like `valueInput`.

- Casing:
  - camelCase for variables.
  - CAPS_WITH_UNDERBARS should be used for constants.
    - Any repeated numbers should be represented by named constants.
  - TitleCase for everything else: properties, methods, classes, namespaces, etc.

- 
  Plurality

  Variable, object, or property names should be singular unless they are for a collection (Array, List, Dictionary, etc.). For example:

  ```C#
  string name = "Forrest Gump";
  List<string> = names = new List<string>();
  ```

  

### Dead Code

Unused code should be removed (no commented-out code, unreachable methods, or obsolete files).

### Comments

- Explanatory comments should be used to explain the purpose of blocks of code, variables, and constants or literal numbers.
- Explain why instead of what.
- XML comments should be used on classes and methods.

```
/// <summary>
/// A sub-ViewModel of the CustomerInfoViewModel
/// </summary>
/// <typeparam name="T">The type of the Model class used by the VM</typeparam>
public class ViewModel<T> : IObservable<ViewDictionary>
```



### Reference

[C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/) - Microsoft C# Programming Guide

-----



 ## Best Practices

### Exception Handling

Use try-catch and send a user notification and/or log message where ever exceptions could potentially occur.

```c#
try
{
    answer = 10 / value;
}
catch (System.DivideByZeroException e)
{
    string message = "Tried to divide by zero: " + e.Message;
    Debug.LogError(message);
    Notifications.DisplayNotification(message);
}

```

### General

- Code is DRY (no duplicated blocks of code).
- Good separation of concerns, for example, code that does computation or logical operations is separated into its own class.
- All class instance variables are private.
- Local variables are used wherever possible instead of declaring a member variable.
- Named constants are used instead of repeated literal constants.
- Each method does just one thing (no “Swiss Army” methods).
- Classes are “loosely coupled” and “highly coherent”.
- Design patterns are being followed appropriately (MVC, Observer, Adapter, Class Factory, etc.).




-----

[![ccbysa88x31](C:/Users/Brian/Repos/CS296N-CourseMaterials/LectureNotes/ccbysa88x31.png)](http://creativecommons.org/licenses/by-sa/4.0/)ASP.NET Core MVC course materials by [Brian Bird](https://profbird.dev) , written 2017, revised 2022, are licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 

-----

