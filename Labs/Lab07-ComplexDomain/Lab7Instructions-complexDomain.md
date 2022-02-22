# Lab 7 – A More Complex Domain Model



## Objectives

1. Learn to design and implement a domain model that has more than two classes and includes a one-to-many, or many-to-one relationship.
2. Create Views and Controllers using Scaffolding.



## Part 1

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



## Part 2



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

Written by Brian Bird for CS296N, Web Design 2 at Lane Community College, winter 2019, revised winter <time>2022</time>

------

