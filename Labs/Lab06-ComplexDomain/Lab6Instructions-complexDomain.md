# Lab 6 – A More Complex Domain Model

[TOC]

## Objectives

A. Learn to design and implement a domain model that has composition relationship(s) and includes a one-to-many relationship.

B. Create Views and Controllers that use complex objects.



## Part A

Add one or two additional model classes to your web site's domain model. One of them should have a composition relationship with another. You should end up with a total of three or more classes in your domain model (not counting IdentityUser).

Make a UML class diagram of your domain model with the new class(es)&mdash;include multiplicity. Identify at least one aggregate and root entity.

### Suggested Domain Model additions

You can add any additional model class(es) that make sense, but here are some suggestions:

- Group A

  Add replies as an additional type of message. A message can have multiple replies. Hint: a reply is a message.

- Group B

  Add comments to stories. A story can have multiple comments.

- Group C

  Add replies to posts. A post can have multiple replies. 



## Part B

Code the new domain model and add the corresponding controller method(s) and view(s) so that the new feature can be used. Use async methods in the controller's HTTP POST methods.



## Part C

Modify your domain model so that cascade delete is enabled for any related data that should be deleted with the root entity.



## Review and Submission

### Code Review

1. Put the UML diagram in a *docs* folder in your Visual Studio solution and commit to Git. Add two versions of the diagram:

   - UMLet .uxf file
   - PDF file

2. Send a pull request to another student asking them to review your class diagram and the beta version of your code. 

   After the review is done, you can merge this lab's branch into the main branch, but keep the lab branch, don't delete it.

3. You should get a pull request from the other student and review their diagram and beta code.

   In the "online text" field of the Code Review assignment on Moodle, enter the URL of the pull request you responded to and gave another student a code review.

### Production Version

1.  Re-publish your web site to Azure.
2.  In the "online text" for the Moodle assignment:
    - Paste a link to your GitHub repository and branch for part 2.
    - Paste a link to your site running on Azure (or another web host).



------

Written by Brian Bird for CS296N, Web Design 2 at Lane Community College, winter 2019, revised winter <time>2024</time>.

------

