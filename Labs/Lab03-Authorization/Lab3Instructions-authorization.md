# Lab 3 – Authorization and Admin

CS296N, Web Development 2: ASP.NET

## Contents

[TOC]

## Objective

Learn how to authorize user access to different sections of a web app based on user roles.

## Instructions

You will add all the same Authorization and Administration features to your web site that your instructor added to the example web site:

- Add the code needed to support authorization (inject `UserManager` and `RoleManager` objects into the appropriate controllers, etc.)
- Add a page for user and role management. 
  The page will have these features at a minimum:
  - Delete user
  - Add to Admin
  - Remove from Admin
  - Delete role
- Restrict some parts of the web site:
  - Only logged in users can do operations that store information in the database.
  - Only admin users can access the admin pages.

- Seed the database with a user who is in the Admin. In addition, be sure to add or change the appropriate code in the `Startup` and `Program` classes.


- Add a link for the admin page to the navigation menu that only appears when a user in the Admin role is logged in.



## Review and Submission

### Beta Code Review

1. Send a pull request to another student asking them to review the beta version of your code. 

   After you have finished revising your code, you can merge it into the main branch, but keep the lab branch, don't delete it.

2. You should get a pull request from the other student and review the beta version of their code.

   In the "online text" field of the Code Review assignment on Moodle, enter the URL of the pull request you responded to and gave another student a code review.

### Production Version

In the "online text" for the Moodle assignment:
- Paste a link to your GitHub repository and branch for part 2.
- Paste a link to your site running on Azure (or another web host).



## Assessment

[Grading rubric for this lab assignment](Lab3Rubric-Authorization.htm)



------

Written by Brian Bird, Lane Community College, winter 2019, revised winter 2024

------

