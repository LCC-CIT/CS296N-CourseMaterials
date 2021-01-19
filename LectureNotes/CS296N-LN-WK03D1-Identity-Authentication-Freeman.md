**CS296N Web Development 2: ASP.NET**                                                        

 Brian Bird

# *Authentication with Identity*

| Weekly topics                           |                                 |
| --------------------------------------- | ------------------------------- |
| 1. Intro to course and input validation | 6. Load testing and performance |
| 2. Identity                             | 7. Creating a web service       |
| **3. Authentication and authorization** | 8. Consuming a web service      |
| 4. Security                             | 9. Docker containers            |
| 5. Publishing to a production server    | 10. Term project                |



## Introduction

- Do PRs and code reviews
- Review quiz 2

------



## Review - Identity

- Run BookInfo
- Add a user, list the accounts
- [What else do we need? ](#weneed)

------



## Textbook Example (Freeman, Ch. 29)

The example MVC app has the following features 

- /Home - Shows details on the currently logged in user

- - Index - requires login, has [Authorize] attribute
  - OtherAction - same as above, has [Authorize(Roles="Users")] attribute 

- /Admin - Shows a list of users and has buttons for:

- - Create - create a user account
  - Edit
  - Delete

- /Account

- - Login
  - Logout

- /RoleAdmin - Shows roles and the users in them and has buttons for:

- - Create - will only be useful after adding claims (Ch. 29)
  - Edit - use this to add a user to a role 
  - Delete - will only be useful after adding claims (Ch. 29)

------



## Adding Authentication to Your Web App

### Authentication: Login and Logout 

In an account controller, add:

TODO: Show code needed for dependency injection of Identity objects into the constructor of the controller.

- Login methods:

  ```C#
  [AllowAnonymous]
  public IActionResult Login(string returnUrl) { 
    ViewBag.returnUrl = returnUrl; return View();
  }
  
  [HttpPost]
  [AllowAnonymous]
  [ValidateAntiForgeryToken]
  public async Task Login(LoginViewModel model, string returnUrl) { 
    if (ModelState.IsValid) {   
      User user = await userManager.FindByEmailAsync(model.Email);
      if (user != null) {
        await signInManager.SignOutAsync();
        var result = await signInManager.PasswordSignInAsync(user, 
                                             model.Password, false, false);
        if (result.Succeeded) {
          return Redirect(returnUrl ?? "/");
        }
      }
      ModelState.AddModelError(nameof(LoginViewModel.Email), 
                                        "Invalid user or password");
    }
    return View(model);
  }
  ```

- logout method:
  
```C#
[Authorize]
public async Task Logout() {
   await signInManager.SignOutAsync();
   return RedirectToAction("Index", "Home");
}
```

In views, add:

- A login view
  `@model LoginViewModelLog In      Log In`
- A logout view `x `

- Add the [Authorize] attribute to methods that require authorization

------



### Redirection to Login

The ASP.NET Core platform provides information about the user through the HttpContext object, which is used by the Authorize attribute to check the status of the current request and see whether the user has been authenticated. 

Add the [Authorize] attributes to methods that require authentication.

- This will cause a redirect to *Account/Login*

- And a parameter for the return URL will be appended to the Account/Login URL. For example:

  Account/Login?ReturnUrl=%2FBook%2FAdd

  - Note: %2F is the hex code for the forward slash, /

> > ##### Default Login URL 
> >
> > > The URL /Account/Login is the default for ASP.NET Core MVC, but you can specify your own URL in Startup.cs, *ConfigureServices*, like this:
> > > `services.ConfigureApplicationCookie(opts => opts.LoginPath = "/Users/Login"`

------



## Example Code Repositories

[BookInfo, Core 2.2, AddLogin branch](https://github.com/LCC-CIT/CS296N-BookInfo-Core-2/tree/AddIdentity) &mdash;User login and logout and authorization of controller methods.

[BookInfo, Core 3.1, Authentication branch](https://github.com/ProfBird/BookInfo-WebApp-Core3/tree/Authentication) &mdash;User login and logout controller methods and views.

### Getting the Current User

Example from the default Visual Studio MVC project with authentication, from the Manage controller:

```C#
[HttpGet]
public async Task<IActionResult> Index()
{
  var user = await _userManager.GetUserAsync(User); 
  if (user == null)
  { 
    throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'."); 
  }
  var model = new IndexViewModel {
	  Username = user.UserName,
	  Email = user.Email,
	  PhoneNumber = user.PhoneNumber,
	  IsEmailConfirmed = user.EmailConfirmed,
	  StatusMessage = StatusMessage };
  return View(model);
}
```

------



## Reading

**Freeman,** ***Pro ASP.NET Core MVC 2***

- Ch. 12 - SportsStore: Sections on Identity - [Notes](SportsStoreCh12.html)
- Ch. 29 - Applying ASP.NET Core Identity: Authorizing users with roles 

**Microsoft ASP.NET Core MVC Tutorial** 

- [Overview of ASP.NET Core Authentication](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/?view=aspnetcore-3.1)&mdash;for ASP.NET Core 3.1 

------



## Conclusion

- Review due dates on Moodle

------



[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png) ](http://creativecommons.org/licenses/by-sa/4.0/)
ASP.NET Core MVC Lecture Notes by [Brian Bird](https://birdsbits.blog) is licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 