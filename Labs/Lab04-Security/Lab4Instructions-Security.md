# Lab 6 – Web Security Testing and Countermeasures

## Objectives

Get practice:

- Testing your web app using the Zed Attack Proxy using:
  - A manual, passive scan
  - An automated, passive scan
  - An active attack scan
- Mitigating (reducing or eliminating) security vulnerabilities in your app by changing your app’s code.

## Instructions

#### Testing with ZAP

Use OWASP ZAP to scan your code for security vulnerabilities.

1. Do a manual passive scan.
   Before doing the scan, log in as a registered user, but not as an admin. Navigate to every page of your web site and enter data in all the forms.  
2. Run an automated passive scan.
3. Without closing the app, or after loading a stored passive testing session, run an active test of your web app.
4. Fix at least three of the security vulnerabilities identified in the alerts. Preferably, solve the highest priority issues. Only solve issues that can be fixed in your app’s code, not issues that require changes to the web server.

#### Research

In order to solve the security issues, you will first need to do some research. Work with one or two other students and choose one issue each to research. Each of you will <u>post a description of the issue you are researching</u> to the forum for this lab.

- Focus on the high risk issues.
- Try to choose issues that others haven't chosen. 
- When you have finished your research, share relevant links and information on how to mitigate the issue with the class by replying to your own post in the forum.

See the instructor’s example posts at the end of this document for an idea of what to include in your posts.

#### Security Risk Mitigation in Code

Based on the research you, your team and the rest of the class have done, fix <u>three</u> of the highest priority issues that ZAP found in your app.

#### Reporting

You will report in two places:

- In the lab forum

- In the docs folder, on the Lab06 branch of your Git repository.

  Add a markdown document containing:

  1. A list of the high, medium and low priority issues that came up in the initial passive and active scans of your app.
  2. The issues you chose to mitigate and the classes and methods that you changed to implement the mitigation.
  3. A list of the issues that come up in passive and active scans after making the code changes.

## Submission to Git and Moodle

####  Code Review

   1. Using GitHub, send a pull request to another student asking them to review your code. After you have gotten a review, and finished revising your code, merge it into the master branch. Keep the lab branch, don't delete it.
   2. You should get a pull request from the other student. Review their code and forum posts. You don't need to run ZAP against their web app--just verify that the app still works, that they have used best practices, and fulfilled the lab requirements.
      3. Paste the review form into the comments of the other student's pull request.
      4. In the "online text" field of the Code Review assignment on Moodle, enter the URL of the pull request you responded to and which contains the review you gave.

   **Production Version**

1. In the "online text" for the Moodle assignment, paste a link to your GitHub repository and branch for this lab.
2. Upload a document with copies of the security research you posted in the forum. Just copy and paste the text, no screen shots are needed.
3. Upload a code review document containing the review done on your code.



## Example Fourm Posts

Here are examples of posts you would make as you identify the security issue you are researching, then find some information about it, then find a way to mitigate it.

**Research: X-Frame-Options Header Not Set**

The security vulnerability I am researching is: X-Frame-Options Header Not Set

**RE: Research: X-Frame-Options Header Not Set**

Here's what I've found out about this issue so far:

X-Frame-Options header is not included in the HTTP response to protect against 'ClickJacking' attacks.

Clickjacking (User Interface redress attack, UI redress attack, UI redressing) is a malicious technique of tricking a Web user into clicking on something different from what the user perceives they are clicking on, thus potentially revealing confidential information or taking control of their computer while clicking on seemingly innocuous web pages. (Clickjacking - Wikipedia)

**RE: Research: X-Frame-Options Header Not Set**

How to fix this in ASP.NET Core: [Set X-FRAME OPTIONS in ASP.NET Core](https://dotnetcoretutorials.com/2017/01/08/set-x-frame-options-asp-net-core/)

 

------

Written by Brian Bird, Lane Community College, winter 2019, revised winter 2020.

CS296N, Web Development 2: ASP.NET

------

