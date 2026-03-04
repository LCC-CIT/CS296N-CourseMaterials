**CS296N Web Development 2: ASP.NET** 

<h1>Week 8 Overview and Announcements</h1>



| Weekly topics                   |                                |
| ------------------------------- | ------------------------------ |
| 1. Intro to Identity            | 6. Complex domain models       |
| 2. Authentication               | 7. A more complex domain model |
| 3. Authorization                | <mark>8. Validation</mark>     |
| 4. Async/Await                  | 10. Term project               |
| 5. Load testing and performance | 11. Project presentations      |



<h2>Contents</h2>

[TOC]


### Announcements for Winter 2024

- I finished updating my complex domain model with replies: https://github.com/ProfBird/CS296_AllAboutPigeons/tree/Lab06

- For lab 6 (complex domain model): 

  - Regarding complexity of your domain model, since you already have two persistent domain model classes (counting AppUser) you only need one additional domain model class which is related to an existing domain model class (probably a root entity) by composition. 
    - My Book Review example from 2023 is much more complex than that. If you look at the [example from 2022](https://github.com/LCC-CIT/CS296N-Example-BookReviews/tree/7-ComplexDomain) it just has one additional domain model class&mdash;like you you do for your assignment.

    - My All About Pigeons example for this year, 2024, has a self-refrerential model, `Message`, which also satisfys the requirement to have three persistent model classes since `Message` sort of  taking the place of two models.

  - ~~I haven't demonstrated scaffolding yet. I'll do that today.  
    Add scaffolding for one of your classes. It makes the most sense to do it for your root entity. Modify the scaffolding so that the the code that load data from your DbContext object also loads the related data (composed classes).~~  
    This isn't actually a requirement in the lab 6 instructions.

- Validation lectures: I was out sick Monday, so hopefully you watched the recorded lecture from 2022.



[ ![Creative Commons License](https://i.creativecommons.org/l/by/4.0/80x15.png)](http://creativecommons.org/licenses/by-sa/4.0/)ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev), written 2020, revised <time>2024</time>, are licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 

