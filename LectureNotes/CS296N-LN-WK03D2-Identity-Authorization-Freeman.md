**CS296N Web Development 2: ASP.NET, 2020**                                                    

# *Authorization with Identity*

| Weekly topics                           |                                 |
| --------------------------------------- | ------------------------------- |
| 1. Intro to course and Input validation | 6. Load Testing and Performance |
| 2. Identity                             | 7. Creating a Web Service       |
| **3. Authentication and authorization** | 8. Consuming a Web Service      |
| 4. Security                             | 9. Docker containers            |
| 5. Publishing to a production server    | 10. Term project                |



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



## Adding Authorization to Your Web App

### Authorization by Role

1. Create roles

   We could add code in the application's *Startup* class, *Configure* method to create the roles we want. For example, we could add roles for Admin and Member using the code below (but we won't).

```C#
const string ADMIN = "Admin";
const string MEMBER = "Member";
if (await roleManager.FindByNameAsync(ADMIN) == null) {
      await roleManager.CreateAsync(new IdentityRole(ADMIN));
}
if (await roleManager.FindByNameAsync(MEMBER) == null) {
      await roleManager.CreateAsync(new IdentityRole(MEMBER));
}
```

In this example, I used constants for the role names. It would be better to get the role names from your appsettings.json file, like the author of our textbook does:

```C#
configuration["Data:AdminUser:Role"]
```



### Seed the database with a temporary admin account

In order to avoid the chicken and egg problem of how do you create an admin accout if you have to be an admin to craet the accout, you can seed your Identity database with an admin account that you would remove or change as soon as you deploy your web app.

One way to do this is by storing the account credentials in appsettings.json, and then using them to create a user account at startup. For example:

*appsettings.json* - The account settings are stored here

```javascript
"Data": {
  "AdminUser": {
    "Name": "Admin",
    "Email": "admin@example.com",
    "Password": "secret",
    "Role": "Admins"
}
```



*AppDbContext.cs* - The role and account are created here:

```C#
public static async Task CreateAdminAccount(IServiceProvider serviceProvider, IConfiguration configuration) {
  UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();
  RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
  string username = configuration["Data:AdminUser:Name"];
  string email = configuration["Data:AdminUser:Email"];
  string password = configuration["Data:AdminUser:Password"];
  string role = configuration["Data:AdminUser:Role"];
  if (await userManager.FindByNameAsync(username) == null) {
    if (await roleManager.FindByNameAsync(role) == null) {
      await roleManager.CreateAsync(new IdentityRole(role));
    }
    User user = new User {UserName = username, Email = email};
    IdentityResult result = await userManager.CreateAsync(user, password);
    if (result.Succeeded) {
      await userManager.AddToRoleAsync(user, role);
    }
  }
}
```

*Startup.cs* - The method defined above is called here:

```C#
public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
  . . . 
  // lines of code omitted, the line below is at the end of the method
  ApplicationDbContext.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();
}
```



### Authorize a controller or method by role

Add the attribute `[Authorize(Role="SomeRole")]` to a class or method.

If a user who is authenticated, but not in the correct role attempts to access this, they will be redirected to /Account/AccessDenied

------

## Role Management

Create and edit user roles using the *Role* *Manager* class.
Edit user roles to add a user 

------



## Example Code Repositories

[BookInfo, Core 2.2, AddLogin branch](https://github.com/LCC-CIT/CS296N-BookInfo-Core-2/tree/AddIdentity) &mdash;User login and logout and authorization of controller methods.

[BookInfo, Core 3.1, Authorization branch](https://github.com/ProfBird/BookInfo-WebApp-Core3/tree/Authorization) &mdash;Create an admin role, admin user, restrict access.

### 

## Reading

**Freeman,** ***Pro ASP.NET Core MVC 2***

- Ch. 12 - SportsStore: Sections on Identity - [Notes](SportsStoreCh12.html)
- Ch. 29 - Applying ASP.NET Core Identity: Authorizing users with roles 

**Microsoft ASP.NET Core MVC Tutorial** 

- [Authorization in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/authorization/)&mdash;for ASP.NET Core 3.1 

------

## Conclusion

- Review due dates on Moodle

------

[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png) ](http://creativecommons.org/licenses/by-sa/4.0/)
ASP.NET Core MVC Lecture Notes by [Brian Bird](https://birdsbits.blog) is licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 