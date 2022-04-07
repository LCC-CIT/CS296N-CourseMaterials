# Lab 5 – Async Methods and a Complex Domain Model

CS296N, Web Development 2: ASP.NET

## Objectives

1. Learn to use async methods in controllers and repositories.
2. Learn to design and implement a domain model that has more than two classes and includes a one-to-many, or many-to-one relationship.

## Part 1

Modify the controller that will use your new model class(es) so that it uses async methods. You only need to make the methods that access the database or that use the UserManager or RoleManager async. 

This will have ripple effects:

- You will need to make methods in the repository async as well&mdash;Interface, real repository, and fake repository. 
- You will need to modify any affected unit tests to use .Wait() on the async controller methods

## Part 2

Add one or two additional model classes to your web site's domain model.

- Make a UML class diagram of your domain model with the new class(es)--include cardinality.
- Code the new domain model and add the corresponding controller method(s) and view(s) so that the new feature can be used. Use async methods in the controller.

### Suggested Domain Model additions

You can add any additional model(s) classes that make sense, but here are some suggestions:

#### Group A

Add replies as an additional type of message. A message can have multiple replies. Hint: a reply is a message.

#### Group B

Add comments to stories. A story can have multiple comments.

#### Group C

Add replies to posts. A post can have multiple replies and a reply is a post.





## Review and Submission

### Code Review

1. Put the UML diagram in a *docs* folder in your Visual Studio solution and commit to Git. Add two versions of the diagram:

   - UMLet .uxf file
   - PDF file

2. Send a pull request to another student asking them to review your class diagram and code. 

   After the review is done, you can merge this lab's branch into the main branch, but keep the lab branch, don't delete it.

3. You should get a pull request from the other student and review their diagram and code.

   In the "online text" field of the Code Review assignment on Moodle, enter the URL of the pull request you responded to and gave another student a code review.

### Production Version

1.  Re-publish your web site.
2.  In the "online text" for the Moodle assignment:
    - Paste a link to your GitHub repository and branch for part 2.
    - Paste a link to your site running on Azure (or another web host).



------

Written by Brian Bird, Lane Community College, winter 2019, revised winter <time>2022</time>

------

