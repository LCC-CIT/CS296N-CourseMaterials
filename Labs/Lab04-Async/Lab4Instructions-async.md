# Lab 4 – Asynchronous Programming

CS296N, Web Development 2: ASP.NET

## Objective

Get practice using async methods in controllers, repositories and unit tests.

## Requirements

Modify the controllers so that they uses async methods. You only need to make the methods that access the database or that use the UserManager or RoleManager async. 

This will have ripple effects:

- You will need to make methods in the repository async as well; that includes the Interface, real repository, and fake repository. 
- You will need to modify any affected unit tests to use .Wait() or .Result on the async controller methods.

## Review and Submission

### Beta Version and Code Review

1. Send a pull request to another student asking them to review the code in your beta version. 

   After the review is done, you can merge this lab's branch into the main branch, but keep the lab branch, don't delete it.

2. You should get a pull request from the other student to review the code in their beta version.

   In the "online text" field of the Code Review assignment on Moodle, enter the URL of the pull request where you gave another student a code review.

### Production Version

In the "online text" for the Moodle assignment paste a link to your GitHub repository and branch.

Publishing to a web server is optional. You may want to wait until after we will do load testing next week so you can compare the results of load testing before and after changing your controller methods to async methods.



------

Written by Brian Bird, Lane Community College, winter 2019, revised winter <time>2024</time>

------

