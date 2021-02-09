**CS296N Web Development 2: ASP.NET**

# Web Security

| Weekly topics                           |                            |
| --------------------------------------- | -------------------------- |
| 1. Intro to course and Input validation | 6. **Security**            |
| 2. Identity                             | 7. Creating a Web Service  |
| 3. Authentication                       | 8. Consuming a Web Service |
| 4. Authorization                        | 9. Docker containers       |
| 5. Async/Await & Complex Domain Model   | 10. Term project           |

## 

## Contents

[TOC]

## Introduction

- Talk about the term project proposal
- Any questions about lab 6?
- Review the quiz



## Common Security Vulnerabilities

### Cross-site scripting (XSS)

An attacker puts html and JavaScript into an input element on a web page so that the script gets saved in the database. When another user displays the data, the script can be executed by the browser and perform some malicious action.

Example: 

```html
<script>alert("You've been hacked!");</script>
```

Mitigation:

Always use HTML encoding.

### Cross-site request forgery (XSRF)

An attacker tricks a user into sending a request from a malicious web site that steals an authentication cookie or other authentication token for a trusted browser session with a legitimate web site and uses it to exploit the interaction between the legitimate site and the browser. This is also known as *session riding*.

Mitigation:

Always use HTTP Post with forms.

### Open redirect attacks

An attacker modifies the return URL query string associated with a redirect to a login page so that the user is redirected to malicious web site.

Example:

An attacker might trick a user into clicking on a link to a legitimate site, but with a fake redirect URL

```html
https://localhost:44337/Account/Login?ReturnUrl=https://bookreviewsstaging2021.azurewebsites.net/%2FBook%2FReview
```

Mitigation:

Use the `IsLocalUrl` method to check that the return URL is not from another site.

### SQL Injection





------

## Resources

### Tutorials 

- Overview of ASP.NET Core Security: Common Vulnerabilities
  - [Cross-site scripting attacks
    ](https://docs.microsoft.com/en-us/aspnet/core/security/cross-site-scripting?view=aspnetcore-2.2)An attacker places client side scripts (usually JavaScript) into web pages. When other users load the affected pages the attacker's scripts will run, enabling the attacker to do something malicious.[
    ](https://docs.microsoft.com/en-us/aspnet/core/security/cross-site-scripting?view=aspnetcore-2.2)
  - [SQL injection attacks](SQL injection attacks)
    [Cross-Site Request Forgery (CSRF)
    ](Cross-Site Request Forgery (CSRF))A malicious web app can take advantage of the user's previously authenticated session to gain access to secured pages.[
    ](Cross-Site Request Forgery (CSRF))
  - [Open redirect attacks
    ](https://docs.microsoft.com/en-us/aspnet/core/security/preventing-open-redirects?view=aspnetcore-3.1)A redirect URL that's specified via the request such as the query-string, or form data, can potentially be tampered with to redirect users to an external, malicious URL.[
    ](https://docs.microsoft.com/en-us/aspnet/core/security/preventing-open-redirects?view=aspnetcore-3.1)

### Videos

- [.NET Conf 2017: ASP.NET Core 2.0 Security - Barry Dorrans](https://channel9.msdn.com/Events/dotnetConf/2017/T324)

### Web Sites

- [Barry Dorrans web site](https://idunno.org)
- [Troy Hunt](https://www.troyhunt.com/) - security blog

------

## Conclusion

- Review lab due dates on Moodle

  

------

[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png)](http://creativecommons.org/licenses/by-sa/4.0/)
ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev), written 2018, revised 2021, are licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/).

------