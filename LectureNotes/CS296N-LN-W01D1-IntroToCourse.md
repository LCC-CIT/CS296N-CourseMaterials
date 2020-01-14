**CS296N Web Development 2: ASP.NET** 

# Introduction to the Course

| Topics by week                          |                                 |
| --------------------------------------- | ------------------------------- |
| 1. Intro to course and Input validation | 6. Load Testing and Performance |
| 2. Identity                             | 7. Creating a Web Service       |
| 3. Authentication and authorization     | 8. Consuming a Web Service      |
| 4. Publishing to a production server    | 9. Docker containers            |
| 5. Security                             | 10. Term project                |



## Contents

[TOC]
------



## Introduction

- Overview of this course.
- Review of key concepts from last term.
- This week, we will cover the "left over" topic from fall term, input validation.

------



## Course Overview

### Changes to teaching and learning

This term I'll be making these changes to the class:

- More coding demonstrations prerecorded.
- More lab time in class.
- Use Git for submissions and use pull requests for code reviews.
- Quizzes-- more accountability to do the weekly reading .   

### Code Reviews

#### How to make pull requests         

<iframe width="560" height="315" src="https://www.youtube.com/embed/d5wpJ5VimSU" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
#### How to do code reviews on GitHub         

<iframe width="560" height="315" src="https://www.youtube.com/embed/HW0RPaJqm4g" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
### Syllabus
Let's look at the syllabus together.

------



## Review

### Basic Concepts from Last Term

#### The Model-View-Controller Architectural Pattern         

- What is the MVC pattern? *
  \*            

- - Explain dependencies in MVC
                

- What are it's advantages?

- What MVC frameworks are popular besides ASP.NET MVC?
            

- What are some alternative web architectures*?*

#### Server and Browser interaction         

- Explain the "statelessness of HTTP"

- - Where can state be stored?
                

- What kind of code runs on the server, the browser?
            

- What happens in the browser, what happens on the server?

- - A cshtml view is rendered into HTML
  - C# code in a cshtml page is executed
  - Code in a controller is executed
  - Data entered into an HTML form is stored in a model
    
  - Data from a model is diplayed in a view

#### Entity Framework

- What is an ORM? What does it do for us?

- What is the relationship between the domain models and the            database tables?

- What are the three different cardinalities in entity            relationships?
            

- - Does EF Core currently support the many-to-many              relationship?

- What kind of data stores are supported by EF Core?

------



[![ccbysa88x31](ccbysa88x31.png)](http://creativecommons.org/licenses/by-sa/4.0/)ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.online) are licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 

