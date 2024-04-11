---
title: OWASP ZAP
description: Learn how to test web apps for security vulnerabilities using ZAP.
keywords: OWASP, security, test
material: Lecture Notes
generator: Typora
author: Brian Bird
---

**CS296N Web Development 2: ASP.NET        

<h1>Web Security</h1>

<h2>Contents</h2>

[TOC]

------

## Introduction

- Questions about labs or term project?

------



## Web Security Testing with ZAP

[OWASP Zed Attack Proxy Project](https://www.owasp.org/index.php/OWASP_Zed_Attack_Proxy_Project) 
Official Open Web Application Security Project, ZAP web site.

[Getting Started with ZAP
](https://www.zaproxy.org/getting-started/)Introduction to security testing and to installing and using the Zed Attack Proxy.[
](https://www.zaproxy.org/getting-started/)

#### Overview of ZAP

##### Modes of operation 

- Automated passive scanning: ZAP uses a spider to explore your web site and look for vulnerabilities without issuing any attacks.
- Manual passive scanning: ZAP watches your web app while you register, log in, and navigate between pages and enter data. ZAP scans all HTTP messages (requests and responses) sent to the web app for vulnerabilities without making attacks.
- Active scanning: ZAP fires HTTP requests at your web app using known attack techniques and scans the responses.
  Note: manual, passive scanning, followed by an active scan is the most effective form of security testing.

##### How to do an automated passive scan 

1. Start ZAP.
2. In the dialog that asks about persisting a session, select no. (Yes, will record the scan session to a database file.)
3. Start your web app in Visual Studio.
4. In ZAP, on the Quick Start tab:
   - Click on "Automated Scan".
   - Enter your site's URL.
   - Check the "Use traditional spider" check box.
6. Click attack. 
  
   ZAP will passively scan all HTTP requests and responses as the spider navigates your site.

##### How to do a manual, passive scan 

1. Start your web app in Visual Studio.
2. In ZAP, on the Quick Start tab:
   - Click on "Manual Explore".
   - Enter the URL.
   - Check the "Enable HUD" check box. (Heads Up Display--provides access to ZAP through a launched browser.)
3. Click "Launch Browser". 
  
   As you navigate your site and enter data in forms, ZAP will passively scan all HTTP requests and responses.

##### How to do an active scan 

You need to have done a passive scan first and either saved your passive scan session or not closed ZAP.

1. Start your web app in Visual Studio.

2. In ZAP, select the Active Scan tab in the bottom pane:

   - Click on "New Scan".
   - To the right of "Starting Point", click "Select" and choose the URL where you want to start the scan.
   - Click "Start Scan"

The scan could take several minutes or more. You can see the progress at the top of the bottom pane.

### Results from a passive scan of the BookInfo example app

<span style="color:#ff0000; background-color:black;">High
            priority</span> <b>Path Traversal</b> (2) <br>
<span style="color:#ff0000; background-color:black;">High
            priority</span> <b>Remote OS Command Injection</b><br>
<span style="color:#ff0000; background-color:black;">High
            poriority</span> <b>SQL Injection</b><br>
          <br>
<span style="color:#ff6600; background-color:black;">Medium
            priority</span> <b>X-Frame-Options Header Not Set</b> (5) <br>
<span style="color:#ff6600; background-color:black;">Medium
            priority</span> <b>Application Error Disclosure</b> (5)<br>
<span style="color:#ff6600; background-color:black;">Medium
            priority</span> <b>Cookie No HttpOnly Flag</b> (6)<br>
          <br>
<span style="color:#ffff00; background-color:#000000;">Low
            priority</span> <b>Web Browser XSS Protection Not Enabled </b>(7)<br>
<span style="color:#ffff00; background-color:black;">Low
            priority</span> <b>X-Content-Type-Options Header Missing </b>(9)



### Results from an active scan

<span style="color:#ff6600; background-color:black;">Medium priority</span> &nbsp; <b> X-Frame-Options Header Not Set</b> (17)<br>
<span style="color:#ffff00; background-color:black;">Low priority</span> <b>Web Browser XSS Protection Not Enabled</b> (18)<br>
<span style="color:#ffff00; background-color:black;">Low priority</span> <b> X-Content-Type-Options Header Missing</b> (20)



### Discussion of Alerts

#### X-Frame-Options Header Not Set

X-Frame-Options header is not included in the HTTP response to protect against 'ClickJacking' attacks.

Clickjacking (User Interface redress attack, UI redress attack, UI redressing) is a malicious technique of tricking a Web user into clicking on something different from what the user perceives they are clicking on, thus potentially revealing confidential information or taking control of their computer while clicking on seemingly innocuous web pages. ([Clickjacking - Wikipedia](https://en.wikipedia.org/wiki/Clickjacking))

Most modern Web browsers support the X-Frame-Options HTTP header. Ensure it's set on all web pages returned by your site (if you expect the page to be put in an iframe only by pages on your server (e.g. it's part of a FRAMESET) then you'll want to use SAMEORIGIN, otherwise if you never expect the page to be in an iframe, you should use DENY. ALLOW-FROM allows specific websites to frame the web page in supported web browsers).

[Set X-FRAME OPTIONS in ASP.NET Core](https://dotnetcoretutorials.com/2017/01/08/set-x-frame-options-asp-net-core/)

[Combating ClickJacking With X-Frame-Options](https://blogs.msdn.microsoft.com/ieinternals/2010/03/30/combating-clickjacking-with-x-frame-options/)



## Testing Web APIs with ZAP

In order to test a web API with ZAP, some form of API definition file is needed. There is more than one way to do this, several are outlined here: [How Can You Use ZAP to Scan APIs?](https://www.zaproxy.org/faq/how-can-you-use-zap-to-scan-apis/)

- Postman can be used to create the API definition: 

  [API Security Testing with Postman and OWASP ZAP](https://thetesttherapist.com/2022/02/13/api-security-testing-with-postman-and-owasp-zap)

- OpenAPI / Swagger endpoint definitions can also be used:

  [Exploring APIs with ZAP](https://www.zaproxy.org/blog/2017-04-03-exploring-apis-with-zap/)

  

## Conclusion

- Review lab due dates on Moodle

  

------

[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png) ](http://creativecommons.org/licenses/by-sa/4.0/)
ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev) is licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 

------