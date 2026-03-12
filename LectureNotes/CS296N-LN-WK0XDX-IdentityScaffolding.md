---
title: Identity Scaffolding
description: How to work with the AspNetCore.Identity.UI library
keywords: Identity, scaffolding
material: Lecture Notes
generator: Typora
author: Brian Bird

---

<h1>How to Add Identity Using Scaffolding</h1>

**CS296N Web Development 2**

<h2>Contents</h2>

[TOC]
## Overview

Identity is the ASP.NET package that provides authentication and authorization libraries for ASP.NET apps. It can be added to a project in one of three ways:

- By selecting the option to include Identity when creating a new project.
- Using the Visual Studio scaffolding feature to add it to an existing project.
- By adding the NuGet package manually and editing project code to work with it.

### Identity Option Selected for a New Project

When you create a new ASP.NET MVC project and select the option to add *Individual Authorization* to the project, Visual Studio adds a library (a NuGet package), *AspNetCore.Identity.UI* (aka Identity UI), that contains views and all the code that goes with them for a large number of Identity related operations. This code is already compiled into a library, so you don't see any source files in Visual Studio's Solution Explorer.

(See "Create a Web App with Authentication" in the References.)

### Scaffolding Identity

You can add the Identity UI library, a DbContext class and all that goes with Identity to an existing project without Identity by adding Identity Scaffolding (See "Scaffold Identity in ASP.NET Core projects" in the References.) When you add the scaffolding, you have the option to "override" the library code with source code files that it will add to the project so that you can customize them. You can also use the scaffolder to add these files to a project that is already using the Identity UI library.

![IdentityScaffoldDialog](Images\IdentityScaffoldDialog.png)

#### Steps to Add Identity Scaffolding to a Project

1. Right-click on the project in the Visual Studio Solution Explorer
2. Select **Add** > **New Scaffolded Item**
3. Choose **Identity** from the left menu
4. Select **Add Identity**
5. In the scaffolding dialog:
   - Select the pages you want to override (or select all)
   - The scaffolder will create a new DbContext (e.g., `CodeReviewsContext`)
   - Click **Add**

##### Files added by scaffolding

- `Areas/Identity/Pages/Account/` folder with Razor Pages
- `Areas/Identity/Data/CodeReviewsContext.cs` (a separate context)
- Identity configuration in `Program.cs`

##### Packages Added by Scaffolding

The scaffolder automatically adds these NuGet packages:

```xml
<PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="10.0.2" />
<PackageReference Include="Microsoft.AspNetCore.Identity.UI" Version="10.0.2" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="10.0.2" />
<PackageReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Design" Version="10.0.2" />
```



#### Refactoring Steps

The scaffolded Identity system creates a separate context, but we want to use our existing `AppDbContext` and `AppUser` model. Here are the refactoring steps:

##### 1. Modify your user model class to inherit from `IdentityUser`

Modify your user model class to inherit from `IdentityUser`. For example, if your user model class was named `AppUser` and had one property, `Name`, you would modify it like this:

```csharp
using Microsoft.AspNetCore.Identity;

namespace CodeReviews.Models
{
    public class AppUser : IdentityUser
    {
        // The person's full name
        public string Name { get; set; } = string.Empty;
    }
}
```

##### 2. Modify your DbContext class

- Modify your DbContext class to Inherit from `IdentityDbContext<AppUser>`  
  The`IdentityDbContext` class requires a generic type. Provide the type of your user model.
- Remove the `DbSet` for your user model class (`AppUser` in this example).

Note: The `OnModelCreating` method is optional. Only include it if you were already doing something in that method.

```csharp
using CodeReviews.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodeReviews.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Remove or comment out AppUsers DbSet - Identity provides this
        // public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentVersion> AssignmentVersions { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Your custom configurations here
        }
    }
}
```

##### 3. Update `Program.cs`

Configure Identity to use your existing context by making these changes:

- Add `using Microsoft.AspNetCore.Identity;` and `using CodeReviews.Models;` .
- If you are using precompiler directives to select the database provider, move Identity configuration outside the `#if/#else` block so it applies to both databases.
- Use `AddDefaultIdentity<AppUser>()` instead of `IdentityUser`  (Where `AppUser` is your user model class).
- Call `.AddEntityFrameworkStores<AppDbContext>()` to use your existing context.
- Add `app.UseAuthentication();` before `app.UseAuthorization(); ` .
- Add `app.MapRazorPages();` for Identity Razor Pages routing.

Here's an example:

```csharp
#undef SQLITE  // To use SQLite, change #undef to #define. MySQL is the default.
using CodeReviews.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CodeReviews.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#if SQLITE
var connectionString = builder.Configuration.GetConnectionString("SqliteConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));
#else
var baseConnectionString = builder.Configuration.GetConnectionString("MySqlConnection");
var user = builder.Configuration["DbUser"];
var password = builder.Configuration["DbPassword"];
var connectionString = $"{baseConnectionString}userid={user};password={password};";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(connectionString));
#endif

// Configure Identity - applies to both SQLite and MySQL
builder.Services.AddDefaultIdentity<AppUser>(options => 
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication(); // Add this - must be before UseAuthorization
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages(); // Add this - required for Identity Razor Pages

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    SeedData.Seed(dbContext);
}

app.Run();
```

**Key Changes:**

- ? Add `using Microsoft.AspNetCore.Identity;` and `using CodeReviews.Models;`
- ? Move Identity configuration outside the `#if/#else` block so it applies to both databases
- ? Use `AddDefaultIdentity<AppUser>()` instead of `IdentityUser`
- ? Call `.AddEntityFrameworkStores<AppDbContext>()` to use your existing context
- ? Add `app.UseAuthentication();` before `app.UseAuthorization();`
- ? Add `app.MapRazorPages();` for Identity Razor Pages routing

##### 4. Delete the scaffolded Context

Delete the file:

- `Areas/Identity/Data/CodeReviewsContext.cs`

##### 5. Update all identity Razor Page code-behind Files

All scaffolded Identity pages use `IdentityUser` by default. You need to replace all references with `AppUser` (or whatever your user model class is named). These files are all in the Pages/Account and Pages/Account/Manage folders.

For each file, make these replacements:

1. Add the using statement for the namespace for the models in your project. For example:

```csharp
using CodeReviews.Models;
```

1. Replace all type references:

```csharp
// Before:
private readonly SignInManager<IdentityUser> _signInManager;
private readonly UserManager<IdentityUser> _userManager;
private readonly IUserStore<IdentityUser> _userStore;
private readonly IUserEmailStore<IdentityUser> _emailStore;

// After:
private readonly SignInManager<AppUser> _signInManager;
private readonly UserManager<AppUser> _userManager;
private readonly IUserStore<AppUser> _userStore;
private readonly IUserEmailStore<AppUser> _emailStore;
```

1. Replace in constructor parameters:

```csharp
// Before:
public RegisterModel(
    UserManager<IdentityUser> userManager,
    IUserStore<IdentityUser> userStore,
    SignInManager<IdentityUser> signInManager,
    // ...
)

// After:
public RegisterModel(
    UserManager<AppUser> userManager,
    IUserStore<AppUser> userStore,
    SignInManager<AppUser> signInManager,
    // ...
)
```

1. Replace in helper methods:

```csharp
// Before:
private IdentityUser CreateUser()
{
    return Activator.CreateInstance<IdentityUser>();
}

private async Task LoadAsync(IdentityUser user) { }

// After:
private AppUser CreateUser()
{
    return Activator.CreateInstance<AppUser>();
}

private async Task LoadAsync(AppUser user) { }
```

1. Replace in return types:

```csharp
// Before:
private IUserEmailStore<IdentityUser> GetEmailStore()
{
    return (IUserEmailStore<IdentityUser>)_userStore;
}

// After:
private IUserEmailStore<AppUser> GetEmailStore()
{
    return (IUserEmailStore<AppUser>)_userStore;
}
```

###### A PowerShell Script to Update All Files:

```powershell
$files = Get-ChildItem -Path "CodeReviews\Areas\Identity\Pages\Account" -Recurse -Filter "*.cs"

foreach ($file in $files) {
    $content = Get-Content $file.FullName -Raw
    
    # Skip if already using AppUser
    if ($content -notmatch "IdentityUser") { continue }
    
    $newContent = $content `
        -replace 'UserManager<IdentityUser>', 'UserManager<AppUser>' `
        -replace 'SignInManager<IdentityUser>', 'SignInManager<AppUser>' `
        -replace 'IUserStore<IdentityUser>', 'IUserStore<AppUser>' `
        -replace 'IUserEmailStore<IdentityUser>', 'IUserEmailStore<AppUser>' `
        -replace 'Activator\.CreateInstance<IdentityUser>\(\)', 'Activator.CreateInstance<AppUser>()' `
        -replace "nameof\(IdentityUser\)", "nameof(AppUser)" `
        -replace 'Task LoadAsync\(IdentityUser user\)', 'Task LoadAsync(AppUser user)' `
        -replace 'Task LoadSharedKeyAndQrCodeUriAsync\(IdentityUser user\)', 'Task LoadSharedKeyAndQrCodeUriAsync(AppUser user)'
    
    # Add using statement if not present
    if ($newContent -notmatch "using CodeReviews.Models;") {
        $newContent = $newContent -replace '(using Microsoft\.AspNetCore\.Mvc\.RazorPages;)', "`$1`r`nusing CodeReviews.Models;"
    }
    
    Set-Content -Path $file.FullName -Value $newContent -NoNewline
}
```

##### 6. Update Foreign Key References (If Applicable)

If you have model classes with foreign keys to `AppUser`, update them from `int` to `string`:

**Example - Before:**

```csharp
public class Submission
{
    public int SubmissionId { get; set; }
    public int SubmitterId { get; set; } // Foreign key to AppUser
    public AppUser Submitter { get; set; }
}
```

**Example - After:**

```csharp
public class Submission
{
    public int SubmissionId { get; set; }
    public string SubmitterId { get; set; } // Changed to string (IdentityUser.Id is string)
    public AppUser Submitter { get; set; }
}
```

##### 7. Create New Migrations

Here are the CLI commands to create new migrations and a new database schema:

- `dotnet ef database drop`
- `dotnet ef migrations remove` (This only removes the most recent migration. To remove them all, manually delete the contents of the migrations folder.)
- `dotnet ef migrations add InitialMigration`
- `dotnet ef database update`



## Editing Identity UI Razor Pages

The web pages provided by Identity UI are not MVC views, they are Razor Pages. (Not to be confused with Razor views! See "Introduction to Razor Pages" in the References below.)

Also, see Andrew Locke's blog post, Customizing the ASP.NET Core default UI without editing the PageModels, in the References below.

Here are some comments on Andrew's post about customizing the default UI:

- **Customizing the default UI**
  In this section he tells you how you can override the default pages by placing your own pages in a "magic" location to override the default pages. It appears that these have to be Razor Pages, not MVC views.
- **Scaffolding Identity files with the .NET CLI**
  In this section he shows you how to add the Identity files that we already added to our project. We did it using the scaffolding feature in Visual Studio, he did it suing the .NET CLI (Command Line Interface).
- **Remove your liabilities - deleting the scaffolded PageModel**
  Here he reccomends that you remove any scaffolded pages that you didn't modify so you don't have to keep them in your source control (Git).

## A Brief Intro to Razor Pages

### Razor Pages service added to your app

Note that when the scaffolder added the Identity UI library, it also added this line to the ConfigureServices method in your Startup class: `services.AddRazorPages();` So that your project is now using both MVC and Razor Pages.

### Razor Page .cshtml files

These look a lot like MVC views, but they have the `@page` directive at the top of the file that changes their behavior. They actually act like a combination of an MVC controller method and a view (kind of weird, huh!). So when an HTTP request comes into your web app, it gets routed directly to the Razor Page&mdash;no controller involved!

### PageModel .cshtml.cs files

This should not be confused with a domain model (like the models in MVC). This is different. It does contain some properties that are used sort of like those in a ViewModel, but only in the sense that they hold state for the page. Since there is no controller, there is no need to use a ViewModel to send data to the Page. 

The main purpose of the PageModel class is to do any logical processing needed by the page&mdash; providing *separation of concerns*&mdash;separating the presentation code in the Page from the logic code in the PageModel.

The PageModel does it's work in methods called *handlers*. Some common handlers are:

- OnGet to initialize state of the page.
- OnPost to handle form submissions.

#### Nested model classes

A model that is just used in one PageModel can be defined as a nested class, like the `InputModel` in Register.cshtml.cs.

#### Model validation

You can use the same validation attributes on the properties in a PageModel as you use on an MVC model. 

#### Model Binding

Properties in the PageModel can have the `[BindProperty]` attribute applied to them. Model binding in Razor Pages is the same as in MVC controllers. It invokes automatic retrieval of route data from an HTTP request so that the route data (like queries on HTTP GET requests or data from the body of an HTTP POST request) is put into the model. 

Example from Register.cshtml.cs:

```c#
        [BindProperty]
        public InputModel Input { get; set;
```

#### Database operations

Pretty much all the database operations are done through Identity method calls like `UserManager.CreateAsync` so there isn't really any need for the code in the Identity UI library to directly use the DbContext class (or your repository, if you have one). 

## References

- Microsoft. 2025. [Introduction to Identity on ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-10.0&tabs=visual-studio)

  - [Create an MVC App with Authentication](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-10.0&tabs=visual-studio#create-an-mvc-app-with-authentication)

- Microsoft. 2025. [Scaffold Identity in ASP.NET Core projects](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-10.0&tabs=visual-studio)

  - [Scaffold Identity into an MVC project without existing authorization](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-10.0&tabs=visual-studio#scaffold-identity-into-an-mvc-project-without-existing-authorization)

- Lock, Andrew, .NET Escapades. 2020. [Customizing the ASP.NET Core default UI without editing the PageModels](https://andrewlock.net/customising-aspnetcore-identity-without-editing-the-pagemodel/) 

- Microsoft. 2025. [Razor Pages architecture and concepts in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-10.0&tabs=visual-studio#razor-pages-1)

- MIcrosoft. 2025. [Model Binding in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-10.0)

  

------

[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png)](http://creativecommons.org/licenses/by-sa/4.0/) 
​ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev), 2022, revised in <time>2026</time>, are licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 

------