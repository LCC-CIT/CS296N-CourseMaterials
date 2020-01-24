**CS296N Web Development 2: ASP.NET**                                                        

 Brian Bird

# *Authentication with Identity*

| Weekly topics                           |                                 |
| --------------------------------------- | ------------------------------- |
| 1. Intro to course and Input validation | 6. Load Testing and Performance |
| 2. Identity                             | 7. Creating a Web Service       |
| **3. Authentication and authorization** | 8. Consuming a Web Service      |
| 4. Publishing to a production server    | 9. Docker containers            |
| 5. Security                             | 10. Term project                |



## Introduction

- Discuss lab 1 PRs and code reviews
- Review quiz 1

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

## Adding Authentication and Authorization to Your Web App

### Authorization: Login and Logout 

In an account controller, add:

TODO: Show code needed for dependency injection of Identity objects into the constructor of the controller.

- Login methods:

  `[AllowAnonymous]public IActionResult Login(string returnUrl){ ViewBag.returnUrl = returnUrl; return View();}`
  `[HttpPost][AllowAnonymous][ValidateAntiForgeryToken]public async Task Login(LoginViewModel model, string returnUrl){ if (ModelState.IsValid) {   User user = await userManager.FindByEmailAsync(model.Email);   if (user != null) {    await signInManager.SignOutAsync();    var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);    if (result.Succeeded) {     return Redirect(returnUrl ?? "/");    }   }   ModelState.AddModelError(nameof(LoginViewModel.Email), "Invalid user or password");  }  return View(model);}`

- logout method:
   `[Authorize]public async Task Logout(){await signInManager.SignOutAsync();return RedirectToAction("Index", "Home");}`

In views, add:

- A login view
  `@model LoginViewModelLog In      Log In`
- A logout view `x `

- Add the [Authorize] attribute to methods that require authorization

------

### Authorization

The ASP.NET Core platform provides information about the user through the HttpContext object, which is used by the Authorize attribute to check the status of the current request and see whether the user has been authenticated. 

Add the [Authorize] attributes to methods that require authorization

- This will cause a redirect to *Account/Login*

- And a parameter for the return URL will be passed automatically. For example:

   

  ?ReturnUrl=%2FBook%2FAdd

  - Note: %2F is the hex code for the forward slash, /

> > ##### Default Login URL 
> >
> > > The URL /Account/Login is the default for ASP.NET Core MVC, but you can specify your own URL in Startup.cs, *ConfigureServices*, like this:
> > > `services.ConfigureApplicationCookie(opts => opts.LoginPath = "/Users/Login"`

### Authorization by Role

1. Create roles

   - In the application's *DbContext* class, add code to create the roles you want. The roles we are adding are:

   - - Admin

   - - Member

       ```
       const string ADMIN = "Admin";
       const string MEMBER = "Member";
       if (await roleManager.FindByNameAsync(ADMIN) == null)  {
           await roleManager.CreateAsync(new IdentityRole(ADMIN));
       }
       if (await roleManager.FindByNameAsync(MEMBER) == null)  {
           await roleManager.CreateAsync(new IdentityRole(MEMBER));
       }
       ```

       Note: In this example, I used constants for the role names. You may want to get the role names from your

        

       appsettings.json

        

       file, like the author of our textbook does:

       ```
       configuration["Data:AdminUser:Role"]
       ```

### Seed the database with a temporary admin account

In order to avoid the chicken and egg problem of how do you create an admin accout if you have to be an admin to craet the accout, you can seed your Identity database with an admin account that you would remove or change as soon as you deploy your web app.

One way to do this is by storing the account credentials in appsettings.json, and then using them to create a user account at startup. For example:

*appsettings.json* - The account settings are stored here
`"Data": { "AdminUser": {  "Name": "Admin",  "Email": "admin@example.com",  "Password": "secret",  "Role": "Admins"},`

*AppDbContext.cs* - The role and account are created here `public static async Task CreateAdminAccount(IServiceProvider serviceProvider, IConfiguration configuration) { UserManager userManager = serviceProvider.GetRequiredService>(); RoleManager roleManager = serviceProvider.GetRequiredService>(); string username = configuration["Data:AdminUser:Name"]; string email = configuration["Data:AdminUser:Email"]; string password = configuration["Data:AdminUser:Password"]; string role = configuration["Data:AdminUser:Role"]; if (await userManager.FindByNameAsync(username) == null) {  if (await roleManager.FindByNameAsync(role) == null) {   await roleManager.CreateAsync(new IdentityRole(role));  }  User user = new User {UserName = username, Email = email};  IdentityResult result = await userManager.CreateAsync(user, password);  if (result.Succeeded) {   await userManager.AddToRoleAsync(user, role);  } }}`

*Startup.cs* - The method defined above is called here`public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory){ . . .  // lines of code omitted, the line below is at the end of the method ApplicationDbContext.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();}`

### Authorize a controller or method by role

Add the attribute [Authorize(Role="SomeRole")] to a class or method.

If a user who is authenticated, but not in the correct role attempts to access this, they will be redirected to /Account/AccessDenied

------

## Role Management

Create and edit user roles using the *Role* *Manager* class.
Edit user roles to add a user 



------

## Web App Examples - BookInfo  

### User login and logout and authorization of controller methods  

[GitHub Repository: CS296N-BookInfo-Core-2 - AddLogin branch](https://github.com/LCC-CIT/CS296N-BookInfo-Core-2/tree/AddIdentity) 



### Role management and authorization based on roles

[GitHub Repository: CS296N-BookInfo-Core-2 - UserRoles branch](https://github.com/LCC-CIT/CS296N-BookInfo-Core-2/tree/AddIdentity)

**Note:**
 I discovered I needed to comment out the last two lines in Startup.Cofigure like this:



```
// SeedData.EnsurePopulated(app); 
// ApplicationDbContext.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();
```

Then I could run dotnet ef database update successfully

After updating the database, I uncommented the lines and ran the app. When I ran the app the database was seeded and the Admin account created.



## Web App Examples - App from the VS MVC project template

### Getting the Current User

Example from the default Visual Studio MVC project with authentication, from the Manage controller:

```
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

**Freeman,** ***Pro ASP.NET Core MVC 2\***

- Ch. 12 - SportsStore: Sections on Identity - [Notes](SportsStoreCh12.html)
- Ch. 29 - Applying ASP.NET Core Identity: Authorizing users with roles 

**Microsoft ASP.NET Core MVC Tutorial** 

- [Authorization in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/authorization/)

------

## Conclusion

- Review due dates on Moodle

------

[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png) ](http://creativecommons.org/licenses/by-sa/4.0/)
ASP.NET Core MVC Lecture Notes by [Brian Bird](https://birdsbits.blog) is licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 