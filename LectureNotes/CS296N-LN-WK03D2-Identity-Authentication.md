**CS296N Web Development 2: ASP.NET**                                                        

<h1>Authentication with Identity</h1>

| Weekly topics                   |                               |
| ------------------------------- | ----------------------------- |
| 1. Intro to Identity            | 6. Complex domain models      |
| <mark>2. Authentication</mark>  | 7. More complex domain models |
| 3. Authorization                | 8. Validation                 |
| 4. Async/Await                  | 9. Web Security               |
| 5. Load testing and performance | 10. Term project              |

<h2>Contents</h2>

[TOC]

# Introduction

- Q and A
- Reminder to check Azure credit balances

- I fixed a problem in the SeedData code.

# Review User Registration

Last time we added user registration to our web app by adding the following:

- A view-model: RegisterVM
- A view: Registration
- Methods in the AccountController:
  - HttpGet version of `Register`
  - HttpPost version of `Register`



# Authentication: Registration and Login

## Overview

We will use Delamater and Murach (2022) as a guide to adding authentication to our web app. We'll discuss both the "how" and the "why" as we do it.

## Adding Authentication to Our Web App

### Login and Logout 

#### Modify the navbar

Pages 662&mdash;663, "How to add Log In/Out buttons" and links to the layout; and add a register button as well. This can also be found in the Ch16Bookstore app.

We're not going make our navbar look quite like the one in the book. Here are some differences:

- We don't need a cart button.
- We won't use the `Nav` class in the BookStore models.
- We will change the style of the buttons and links in the textbook to match our existing navbar styles.

Here's our version of the new navbar code:

```html
<!-- head element ends here -->
@using Microsoft.AspNetCore.Identity
@inject SignInManager<AppUser> signInManager
<!-- body element starts here 
     New code goes after the existing <ul> in the navbar -->
<ul class="navbar-nav flex-grow-1">
    @if (signInManager.IsSignedIn(User))
    {
        // Signed-in user - Log Out button and username 
        <li class="nav-item"> 
            <form method="post" asp-action="Logout" asp-controller="Account">
                <input type="submit" value="Log Out" class="btn btn-outline-dark" />
                <span class="text-dark">@User.Identity.Name</span>
            </form>
        </li>
    }
    else
    {
        // Get current action 
        var action = ViewContext.RouteData.Values["action"]?.ToString();
        // anonymous user - Register link and Log In button 
        <li class="nav-item"> 
            <a class="nav-link text-dark" asp-controller="Account" asp-action="Register">
                <span class="fas fa-edit"></span> &nbsp; Register </a> 
        </li>
        <li class="nav-item"> 
            <a asp-action="Login" asp-controller="Account" class="btn btn-outline-dark">
                Log In
            </a>
        </li> 
    }
</ul>
    
```

**Bootstrap notes**

- `ps-3` adds one *spacer* of padding on the left, `pe-3` adds one *spacer* of padding on the right.
- `ms-auto` and`me-auto` (margin start and margin end) are auto-margin class that push items to the left, or right, respectively.

**Font Awesome notes**

- `fas` is the Font Awesome *solid* style, which is used for buttons, icons, or links.

- `fa-edit` is the Font Awesome icon used for registration.

- If you aren't using *Font Awesome* in your site yet, you can add this `link` element to the `head` of your shared layout:
  ```html
  <link rel="stylesheet"
  href="https://use.fontawesome.com/releases/v6.1.1/css/all.css" integrity="sha-long-hash_code" crossorigin="anonymous">
  ```

  

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

The Login view has a check box labeled "Remember me". When this box is checked, the user's login information will be stored in a *persistent cookie*[^1] instead of a *session cookie*. The type of cookie that is created is determined by the `isPersistent` parameter of `SignInManager.PasswordSignInAsync`. 

### Updating code that uses `AppUser`

Since we refactored our user domain model, now named `AppUser`, to inherit from `IdentityUser` we need to change the way we use the user model in some of our code.

#### Saving new items in the database

In the instructor's BookReview example app, this is done in the *Post* version of the `Review` method in the `BookReviews` controller:

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

##### Getting a AppUser model from Identity

The `Review` model contains an `AppUser` object named `Reviewer`:
(Validation annotations removed for clarity)

```c#
public class Review
    {
        public int ReviewID { get; set; }
        public Book Book { get; set; }
        public AppUser Reviewer { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }
    }
```

The `Reviewer` object is currently being supplied by the Reivew.cshtml view. We need to get it from Identity instead. We'll do this by refactoring the *Post* version of the `Review` method in the `BookReviews` controller:



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

- *Murach’s ASP.NET Core MVC*, Second Ed., Mary Delamater and Joel Murach, 2022 

  Ch. 16, "How to Authenticate and Authorize Users"

- [Overview of ASP.NET Core Authentication](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/?view=aspnetcore-6.0)&mdash;Microsoft Tutorial for .Net 6.0

- [Bootstrap NavBar](https://getbootstrap.com/docs/5.1/components/navbar/)&mdash;Bootstrap 5.1 Documentation



## Conclusion

- Review due dates on Moodle
- Talk about the lab assignment



## Footnotes

[^1]:  A *session cookie* expires as soon as its browser session ends. A *persistent cookie* can persist across multiple sessions and has an expiration date and time on it that determine its lifetime. See [Define the lifetime of a cookie](https://developer.mozilla.org/en-US/docs/Web/HTTP/Cookies#define_the_lifetime_of_a_cookie).



------



[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png) ](http://creativecommons.org/licenses/by-sa/4.0/)
ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev), written 2019, revised 2023, is licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 