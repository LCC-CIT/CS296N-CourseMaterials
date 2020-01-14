# Code Review Form

|                                                      |                                                 |
| ---------------------------------------------------- | ----------------------------------------------- |
| Course  number, lab number and lab group             | CS296N, Lab 1, A                                |
| Developer                                            | Gill Bates                                      |
| URL  for the project repository and branch on GitHub | [Cat Dating Repo](https://github.com/catdating) |
| URL  on a server (if it has been published)          | [Cat Dating Site](https://catdatingharmony.com) |
| Reviewer  and Date                                   | Brian Bird, 1/14/2019                           |

###  Instructions

The reviewer will complete this form for the beta version of a lab assignment done by one of their lab partners. After filling out the “Beta” column and adding comments, the reviewer will submit this document to the Code Review assignment on the LMS.

The developer will revise the beta version of their lab work and fill out the “Production” column to reflect any changes they have made. The developer will submit this completed form along with the production version of their lab assignment.

### Review

| **Criteria**                                                 | **Beta** | **Release** |
| ------------------------------------------------------------ | -------- | ----------- |
| Does  it compile and run without errors?                     | Y        |             |
|                                                              |          |             |
| Do  all the pages load correctly?                            | Y        |             |
|                                                              |          |             |
| Does  the style conform to MVC conventions and our class standards? | Y        |             |
|                                                              |          |             |
| Do  all the links, buttons or other UI elements work correctly? | Y        |             |
|                                                              |          |             |
|                                                              | Y        |             |
| Do  the design and implementation conform to OOP best practices? | N        |             |
| In the DoingItAgain.cs file, the same block of code for searching for cats by breed has been copied three times. |          |             |
|                                                              |          |             |
| Does  the style conform to C# coding conventions?            | N        |             |
| In the MadeUp.cs file, there are constants without underscores in the names. |          |             |
|                                                              | Y        |             |
| Does  the solution meet all the requirements? (list any issues below) | N        |             |
| 1. There is no validation annotation on the Name filed in the Cat model. |          |             |
| 2. There is no validation summary on the /Dates/CreateProfile view. |          |             |
|                                                              |          |             |
|                                                              |          |             |
|                                                              |          |             |

#### Comments:

 Great we site! My cat Fluffy has already posted a profile and gotten three or four likes!





------

 

## Appendix

### Aspects of coding style to check

- Is proper indentation used?
- Are the HTML elements and variables named descriptively?
- Have any unnecessary lines of code or files been removed?
- Are there explanatory comments in the code?
- Do variable names use camelCase? 
- Are properties, methods and classes named using PascalCase (aka TitleCase)?
- Are constant names written using ALL_CAPS?

### Best practices in Object Oriented Programming

- Is the code DRY (no duplicated blocks of code)?
- Are named constants used instead of repeated literal constants?
- Is code that does computation or logical operations separated into its own class instead of being added to the code-behind?
- Are all instance variables private?
- Are local variables used instead of instance variables wherever possible?
- Does each method do just one thing (no “Swiss Armey” methods)?
- Are classes “loosely coupled” and “highly coherent”?

 

------

Written by Brian Bird, Lane Community College, winter 2017, updated winter 2020

------

