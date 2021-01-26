**CS296N Web Development 2: ASP.NET**                                                        

# *Authentication with Identity*

| Weekly topics                           |                                 |
| --------------------------------------- | ------------------------------- |
| 1. Intro to course and input validation | 6. Load testing and performance |
| 2. Identity                             | 7. Creating a web service       |
| **3. Authentication and authorization** | 8. Consuming a web service      |
| 4. A more complex data model            | 9. Docker containers            |
| 5. Security                             | 10. Term project                |

## Contents

[TOC]

## Introduction

- Q and A
- Review quiz 3



## Review of last class

### Adding Identity

We Added Identity to a project by adding these things:

- NuGet package
- Startup service and configuration
- User model inherits from `IdentityUser`
- App's DbContext class inherits from `IdentityDbContext`
- New migration and database update

When we were done with this, we were able to see Identity tables in our database, but that is all. Nothing changed in our web site behavior.

### Adding User Registration

We got a head-start on this week's topic of Authentication by adding registration to our web app by adding the following:

- A view: Registration
- A view-model: RegisterVM
- Methods in the AccountController:
  - HttpGet version of Register
  - HttpPost version of Register



## Overview

We will use Delamater and Murach (2020) as a guide to adding authentication to our web app. We'll discuss both the "how" and the "why" as we do it.



## Adding Authentication to Our Web App

### Login and Logout 

#### Modify the navbar

Page 665, "How to add Log In/Out buttons" and links to the layout.
Note: add a register button as well.

##### Using DI with views

Page 568 describes this.

Normally it's not a good practice to inject dependencies into views, but since a layout doesn't have a controller method to pass it a model, this is an acceptable solution.

The @Inject directive does the same thing for a view that adding a parameter to a controller does for a type for which a DI service is defined in startup.

#### Login

Pages 674&ndash;679 describe the process of adding login

- ViewModel
- View
- Controller methods

### Updating code that uses `AppUser`

Since we refactored our user domain model, now named `AppUser`, to inherit from `IdentityUser` we need to change the way we use the user model in some of our code.

#### Saving new reviews in the database

This is done in the *Post* version of the `Review` method in the `BookReviews` controller:

```c#
[HttpPost]
public IActionResult Review(Review model)
{
    model.ReviewDate = DateTime.Now;
    // Store the model in the database
    if(ModelState.IsValid)
    { 
        repo.AddReview(model);
    }
    return View(model);
}
```

##### Getting a `Reviewer` model from Identity

The Review model contains an `AppUser object named Reviewer:
(Validation annotations removed for clarity)

```c#
public class Review
    {
        public int ReviewID { get; set; }
        public string BookTitle { get; set; }
        public string AuthorName { get; set; }
        public AppUser Reviewer { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }
    }
```

The Reviewer object is currently being supplied by the Reivew.cshtml view. We need to get it from Identity instead. We'll do this by refactoring the *Post* version of the `Review` method in the `BookReviews` controller:



##### Getting the current user

 To get the current user, simply use the `User` property of the controller to get an object that identifies the current user, then use `GetUserAsync` to get the `AppUser` object:

```c#
  model.Reviewer = userManager.GetUserAsync(User).Result;
```

```c#
[HttpPost]
public IActionResult Review(Review model)
{
    // Get the AppUser object for the current user
    model.Reviewer = userManager.GetUserAsync(User).Result;
    // TODO: modify the register code to get the user's name
    model.Reviewer.Name = model.Reviewer.UserName;  // Temporary hack
    model.ReviewDate = DateTime.Now;
    // Store the model in the database
    repo.AddReview(model);
    return View(model);
}
```



## Example Code Repositories

[BookReivew, Lab03 branch](https://github.com/LCC-CIT/CS296N-Winter2021LabExample/tree/Lab03)&mdash;Instructor's 2021 example

[BookInfo, Authentication branch](https://github.com/ProfBird/BookInfo-WebApp-Core3/tree/Authentication) &mdash;Instructors 2020 example.



## References

*Murach’s ASP.NET Core MVC*, Mary Delamater and Joel Murach, 2020

- Ch. 16, "How to Authenticate and Authorize Users"

Freeman, *Pro ASP.NET Core MVC 2*, Freeman, 2017

- Ch. 12 - SportsStore: Sections on Identity - [Notes](SportsStoreCh12.html)
- Ch. 29 - Applying ASP.NET Core Identity: Authorizing users with roles 

Microsoft ASP.NET Core MVC Tutorial 

- [Overview of ASP.NET Core Authentication](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/?view=aspnetcore-3.1)&mdash;for ASP.NET Core 3.1 

------



## Conclusion

- Review due dates on Moodle
- Talk about the lab assignment

------



[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png) ](http://creativecommons.org/licenses/by-sa/4.0/)
ASP.NET Core MVC Lecture Notes by [Brian Bird](https://birdsbits.blog) is licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 