# Lab 6 – Load Testing

CS296N, Web Development 2: ASP.NET

## Objectives

Get practice:

- Creating a JMeter test plan
- Running a JMeter test
- Viewing load test results
  - Creating a report
  - Creating a graph



## Instructions

1. Download the JMeter app from [https://jmeter.apache.org](https://jmeter.apache.org/) and unzip it.

2. Create a test script.

   - Record a test script using JMeter as a proxy.
     - Include logging in and logging out.
     - Open each page of your web site.
     - Do a search, if your site supports searching.

   - Modify the test script to manage the antiforgery token on the login page.

   - Add listeners for:
     - A summary report.
     - A graph report.

   - Validate the script to ensure there are no response errors.

3. Run the test.
   - Target your online web site.
   - Set the Thread Group parameters so that your web site is fairly heavily loaded (100 or more users, 10 or more loops).

4. View the test results.
   - View the summary report and take a screen-shot
   - View the graph and take a screen-shot

 

## Submission to Git and Moodle


 There is no beta version or code review required for this lab assignment.

### Production Version

1. Document your load tests.
   - Put your test script in an appropriate folder in your repository and commit it to an appropriately named branch (for example:lab6).
   - Put the screen-shots of your reports in a document (Word or PDF)
2. Submit to Moodle 
   - Upload the screen-shot document
   - Paste URLs into the "Online text" box:
     - The URL of your lab 6 branch on GitHub
     - The URL of your site running on Azure



------

Written by Brian Bird, Lane Community College, winter 2019, revised winter 2022

------

