# Lab 4 – Web Security Testing and Countermeasures

**Objectives**

Get practice:

- Testing your web app using the Zed Attack Proxy
  - Passive testing
  - Active testing
- Reducing or eliminating security vulnerabilities in your app’s code.

**Instructions**

Use OWASP ZAP to do both passive and active testing of your web app, then fix at least three of the security vulnerabilities identified in the alerts. Preferably, solve the highest priority issues. Only solve issues that can be fixed in your app’s code, not issues that require changes to the server.

In order to solve the security issues, you will first need to do some research. Work with one or two other students and choose one issue to research. Post a description of the issue you are researching in the course Moodle forum. Try to choose issues that others haven't chosen. When you have finished your research, share it with the class in the forum.

See the instructor’s example posts at the end of this document for an idea of what to include in your posts.

**Submission to Git and Moodle**

   **Code Review**

   1. Using GitHub, send a pull request to another student asking them to review your code. After you have gotten a review, and finished revising your code, merge it into the master branch. Keep the lab branch, don't delete it.
   2. You should get a pull request from the other student. Review their code and paste the review form into the comments of their pull request.
   3. In the "online text" field of the Code Review assignment on Moodle, enter the URL of the pull request you responded to and which contains the review you gave.

   **Production Version**

1. In the "online text" for the Moodle assignment, paste a link to your GitHub repository and branch for this lab.
2. Upload a copy of the security research you posted in the forum.
3. Upload a code review document containing a review of your code.



## Example Fourm Posts

Here are examples of posts you would make as you identify the security issue you are researching, then find some information about it, then find a way to mitigate it.

**Lab 4 Research: X-Frame-Options Header Not Set**

The security vulnerability I am researching is: X-Frame-Options Header Not Set

**RE: Lab 4 Research: X-Frame-Options Header Not Set**

Here's what I've found out about this issue so far:

X-Frame-Options header is not included in the HTTP response to protect against 'ClickJacking' attacks.

Clickjacking (User Interface redress attack, UI redress attack, UI redressing) is a malicious technique of tricking a Web user into clicking on something different from what the user perceives they are clicking on, thus potentially revealing confidential information or taking control of their computer while clicking on seemingly innocuous web pages. (Clickjacking - Wikipedia)

**RE: Lab 4 Research: X-Frame-Options Header Not Set**

How to fix this in ASP.NET Core: [Set X-FRAME OPTIONS in ASP.NET Core](https://dotnetcoretutorials.com/2017/01/08/set-x-frame-options-asp-net-core/)

 

------

Written by Brian Bird, Lane Community College, winter 2019

CS296N, Web Development 2: ASP.NET

------

