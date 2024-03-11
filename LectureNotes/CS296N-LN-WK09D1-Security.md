---
title: Web Security
description: Learn about common security vulnerabilities and how to mitigate them.
keywords: security
material: Lecture Notes
generator: Typora
author: Brian Bird
---

**CS296N Web Development 2: ASP.NET**

<h1>Web Security</h1>


<h2>Contents</h2>

[TOC]

## Introduction

- Talk about the term project proposal
- Any questions about lab 6?
- Review the quiz

 

## Common Security Vulnerabilities

### Cross-Site Scripting (XSS)

An attacker puts HTML and JavaScript into an `input` element on a web page so that the script gets saved in the web app's database. When another user displays the data, the script will potentially be executed by the browser and perform some malicious action.

This is done automatically by the ASP.NET Razor engine. Try putting HTML into an input element, submit it, then view the data on a web page. View the source to see the html encoding.

Example: 

```html
<script>alert("You've been hacked!");</script>
```

#### Mitigation

- Use input validation.

- Use HTML encoding on data from HTML form input elements. 
  For implementation details, see the XSS tutorial by Anderson (2022) in the references section below.
  Example:

```html
&lt;script&gt;alert("You've been hacked!");&lt;/script&gt;
```



### Cross-Site Request Forgery (XSRF)

An attacker tricks a user into sending a request from a malicious web site that steals an authentication cookie or other authentication token for a trusted browser session. The request is sent to a legitimate web site and used to exploit the interaction between the legitimate site and the browser. This is also known as *session riding*.

#### Mitigation

In ASP.NET Core, mitigation middle-ware is automatically added when any of the following APIs are called in program.cs:

- AddMvc
- MapRazorPages
- MapControllerRoute
- MapBlazorHub

For mitigation when not using ASP.NET, see the tutorial by Acunetix in the References below.

Here's a tutorial containing some [XSRF scenario examples](https://brightsec.com/blog/csrf-example/).

### Open Redirect Attacks

An attacker modifies the return URL query string associated with a redirect to a login page so that the user is redirected to malicious web site.

Example:

An attacker might trick a user into clicking on a link to a legitimate site, but with a fake redirect URL

```
https://localhost:44337/Account/Login?ReturnUrl=https://bookreviewsstaging2021.azurewebsites.net/%2FBook%2FReview
```

#### Mitigation

- Use the ASP.NET `IsLocalUrl` method to check that the return URL is not from another site.
- See the Microsoft tutorial in the references below for more mitigation methods.



### SQL Injection

An attacker enters an SQL statement into an input field on a web page which could be executed by your database when the data is submitted.

#### Mitigation

- Use input validation
- Use LINQ queries instead of direct SQL queries



## References

### Tutorials

- Anderson, Rick, [Prevent Cross-Site Scripting (XSS) in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/cross-site-scripting?view=aspnetcore-6.0), Microsoft, 2022.[ ](https://docs.microsoft.com/en-us/aspnet/core/security/cross-site-scripting?view=aspnetcore-2.2)
- [SQL injection attacks](https://docs.microsoft.com/en-us/ef/core/querying/raw-sql), Microsoft, 2021.
-  Hasan, Fiyaz; Anderson, Rick; Smith, Steve, [Prevent Cross-Site Request Forgery (XSRF/CSRF) attacks in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/anti-request-forgery?view=aspnetcore-6.0), Microsoft, 2022.
- [CSRF Attacks: Anatomy, Prevention, and XSRF Tokens](https://www.acunetix.com/websitesecurity/csrf-attacks/), Acunetix[.
  ](Cross-Site Request Forgery (CSRF))
- [Prevent open redirect attacks in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/preventing-open-redirects?view=aspnetcore-6.0)[,](https://docs.microsoft.com/en-us/aspnet/core/security/preventing-open-redirects?view=aspnetcore-3.1) Microsoft, 2022.[ ](https://docs.microsoft.com/en-us/aspnet/core/security/preventing-open-redirects?view=aspnetcore-3.1)

### Videos

- [.NET Conf 2017: ASP.NET Core 2.0 Security - Barry Dorrans](https://channel9.msdn.com/Events/dotnetConf/2017/T324)

### Web Sites

- [Barry Dorrans web site](https://idunno.org)
- [Troy Hunt](https://www.troyhunt.com/) - security blog

------

## Conclusion

- Review lab due dates on Moodle.

   

------

[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png)](http://creativecommons.org/licenses/by-sa/4.0/) ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev), written 2018, revised 2022, are licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/).

------