---
title: Identity Scaffolding
description: How to work with the AspNetCore.Identity.UI library
keywords: Identity, scaffolding
material: Lecture Notes
generator: Typora
author: Brian Bird

---

# How to Use Scaffolding

**CS296N Web Development 2**

## Contents

[TOC]
## Overview

When you create a new ASP.NET MVC project and select the option to add *Individual Authorization* to the project, Visual Studio adds a library (a NuGet package), *AspNetCore.Identity.UI* (aka Identity UI), that contains views and all the code that goes with them for a large number of Identity related operations. This code is already compiled into a library, so you don't seen any source files in Visual Studio's Solution Explorer.

(See "Create a Web App with Authentication" in the References.)

## Scaffolding Identity

You can add the Identity UI library, a DbContext class and all that goes with Identity to an existing project without Identity by adding Identity Scaffolding (See "Scaffold Identity in ASP.NET Core projects" in the References.) When you add the scaffolding, you have the option to "override" the library code with source code files that it will add to the project so that you can customize them. You can also use the scaffolder to add these files to a project that is already using the Identity UI library.

![IdentityScaffoldDialog](D:\Repos\CS296N-CourseMaterials\LectureNotes\Images\IdentityScaffoldDialog.png)



## Editing Identity UI Pages

The web pages provided by Identity UI are not MVC views, they are Razor Pages. (Not to be confused with Razor views! See "Introduction to Razor Pages" in the References below.)

Also, see Andrew Locke's blog post, Customizing the ASP.NET Core default UI without editing the PageModels, in the References below.
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

- Microsoft. 2022. [Create a Web App with Authentication](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-5.0&tabs=visual-studio#create-a-web-app-with-authentication-1)

- Microsoft. 2022. [Scaffold Identity in ASP.NET Core projects](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-5.0&tabs=visual-studio)

- Lock, Andrew, .NET Escapades. 2020. [Customizing the ASP.NET Core default UI without editing the PageModels](https://andrewlock.net/customising-aspnetcore-identity-without-editing-the-pagemodel/) 

- Microsoft. 2022. [Introduction to Razor Pages](https://docs.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-5.0&tabs=visual-studio#razor-pages-1)

- MIcrosoft. 2022. [Model Binding in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-5.0)

  

------

[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png)](http://creativecommons.org/licenses/by-sa/4.0/) 
​ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev), <time>2022</time>, are licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 

------