# Lab 1 – Identity

CS296N, Web Development 2: ASP.NET

## Objective

Learn how to add Identity to a web app.

## Instructions

### Part 1, Textbook Tutorial

Do the first 10 steps of exercise 16-1 in *Murach's ASP.NET Core*.

Do steps 8 through 10 first.

For steps 1 through 7, in addition to inspecting the code, set a breakpoint in each of the locations described and run the app so that it hits the breakpoint. Think about the sequence of events that led to hitting each breakpoint to help you better understand the purpose of each block of code.

#### Reporting

Report what you did for this exercise by entering the appropriate phrase in the online text of the Moodle assignment:

- "Did it all" means you added a migration, updated the database, set breakpoints, ran the app and studied the code.
- "Inspected the code" means that's all you did.
- "None of the above" means you didn't do the exercise

### Part 2, Your Web Site

-   Since this is the first lab of the term in which you are pushing code to GitHub, you can delete all your old branches from last term. Be sure your main branch is up to date before deleting them!
-   Create a new branch named *Lab02* based on your main branch.
-   You may want to upgrade your web site to use .NET 6.0, but this is not required.
-   Add Identity to your web app&mdash;use the same database as the one used by your application. (**don't** create a separate `DbContext` class.)
- Your *user* model will need to inherit from the IdentityUser class. Make the following changes to your *user* model.

  -   Remove the the `DbSet` you were using for your *user* model
  -   Remove the ID.
  -   Add one or more properties. You can choose the properties, just don't duplicate the ones already in `IdentityUser`. 
-   Add a migration and update your database. Confirm that the identity tables have been added to your database correctly.

The changes you've made to your project won't have any effect on the way the web app works, but the database will now contain the Identity tables, including a new table for `AppUser`.



## Review and Submission

### Beta Version Code Review

1. Send a pull request to another student asking them to review the beta version of your code. 

   After you have finished revising your code, you can merge it into the master branch, but keep the lab branch, don't delete it.

2. You should get a pull request from the other student and review the beta version of their code.

   In the "online text" field of the Code Review assignment on Moodle, enter the URL of the pull request you responded to.

### Production Version

1.  In the "online text" for the Moodle assignment:
    - Report of what you did for part 1.
    - Paste a link to your GitHub repository and branch for part 2.
    - Optional: paste a link to your site running on a web server.
    
    
    

------

Written by Brian Bird, Lane Community College, winter 2019, revised winter 2024

------

