**CS296N Web Development 2: ASP.NET**                                                        

<h1>Authentication with Identity</h1>

| Weekly topics                          |                                 |
| -------------------------------------- | ------------------------------- |
| 1. Publishing a site to a Linux server | 6. Load testing and performance |
| 2. Intro to Identity                   | 7. Complex domain models        |
| <mark>3. Authentication</mark>         | 8. Validation                   |
| 4. Authorization                       | 9. Docker containers            |
| 5. Async/Await                         | 10. Term project                |

<h2>Contents</h2>

[TOC]

## Introduction

- Q and A
- Reminder to check Azure credit balances



### Review User Registration

Last time we added user registration to our web app by adding the following:

- A view-model: RegisterVM
- A view: Registration
- Methods in the AccountController:
  - HttpGet version of `Register`
  - HttpPost version of `Register`



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

Pages 674&ndash;679 describe the process of adding:

- `LoginVM` view model
- `Login` view
- `AccountController` methods
  - HttpGet version of `Login`
    - Note: this method will be called with a returnUrl as an argument if an unauthorized user tries to access an action method that requires authorization. When they do that, they are automatically redirected to this action method.

  - HttpPost version of `Login`
  - `Logout`


##### Setting a persistent cookie

The Login view has a check box labeled "Remember me". When this box is checked, the user's login information will be stored in a *persistent cookie*[^1] instead of a *session cookie*. The type of cookie is that is created is determined by the `isPersistent` parameter of `SignInManager.PasswordSignInAsync`. 

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



## Example Code on GitHub

Instructor's Demo Web App using ASP.NET Core 6.0: [BookInfo&mdash;Authentication](https://github.com/LCC-CIT/CS296N-Example-BookReviews-DotNet6/tree/03-Authentication)



## References

*Murach’s ASP.NET Core MVC*, Second Ed., Mary Delamater and Joel Murach, 2022

- Ch. 16, "How to Authenticate and Authorize Users"

Microsoft ASP.NET Core MVC Tutorial 

- [Overview of ASP.NET Core Authentication](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/?view=aspnetcore-6.0)&mdash;for ASP.NET Core 6.0

------



## Conclusion

- Review due dates on Moodle
- Talk about the lab assignment



## Footnotes

[^1]:  A *session cookie* expires as soon as its browser session ends. A *persistent cookie* can persist across multiple sessions and has an expiration date and time on it that determine its lifetime. See [Define the lifetime of a cookie](https://developer.mozilla.org/en-US/docs/Web/HTTP/Cookies#define_the_lifetime_of_a_cookie).



------



[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png) ](http://creativecommons.org/licenses/by-sa/4.0/)
ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev), 2023, is licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 