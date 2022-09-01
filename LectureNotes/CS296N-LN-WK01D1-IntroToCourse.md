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

- What did you do last term? Did you:
  - do three different versions of each lab assignment? Let me know which version each of you are doing
    - Group A: Community site
    - Group B: Fan site
    - Group C: Informational site

  - Have lab partners, each partner doing a different version (A, B, or C) of the lab project?
    - Let me know who your lab partner is or if you want to switch lab partners.

  - Do code reviews using GitHub pull requests?
  - Do lab 9, Adding seed data to a web app and writing Linq expressions?
  - Publish you lab assignments and term project to a web server?

- This week, we will cover the "left over" topic from fall term, input validation.



## Review

### Basic Concepts from Last Term

#### The Model-View-Controller Architectural Pattern         

- What is the MVC pattern? 
  
- Explain dependencies in MVC
  
  - What are it's advantages?
  
  - What MVC frameworks are popular besides ASP.NET MVC?
  
- What are some alternative web architectures*?*

#### Server and Browser interaction         

- Explain the "statelessness of HTTP"

  - Where can state be stored?

- What kind of code runs on the server, the browser?
            

- What happens in the browser, what happens on the server?

  - A cshtml view is rendered into HTML
  - C# code in a cshtml page is executed
  - Code in a controller is executed
  - Data entered into an HTML form is stored in a model

  - Data from a model is displayed in a view

#### Entity Framework

- What is an ORM? What does it do for us?
- What is the relationship between the domain models and the database tables?
- What are the three different types of entity relationships?
- Does EF Core 3.1 support the many-to-many relationship?
- What kind of data stores are supported by EF Core?

------

## Course Overview

### Syllabus

Let's look at the syllabus together.

### Term Project

Let's look at the term project requirements.

### Lab Assignments

- Make a new repository for use this term.

  - Create a new, empty, repository on GitHub but with a .gitignore file.

  - Clone the repository to your local machine

  - Copy your working files from the last lab of last term into the local repository and commit the files to Git.

  - Push the newly committed files up to GitHub.

- Look at this week's learning activities and due dates.

  - Quiz

  - Lab assignment
    - Beta version
      - Code review
      - Production version



[![ccbysa88x31](ccbysa88x31.png)](http://creativecommons.org/licenses/by-sa/4.0/)ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev) , 2020, revised 2022, are licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 

