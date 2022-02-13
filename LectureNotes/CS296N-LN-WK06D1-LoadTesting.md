**[CS296N Web Development 2: ASP.NET](http://lcc-cit.github.io/CS296N-CourseMaterials/CS296N_Syllabus.pdf)**                         

# *Load Testing and Performance* 

| Weekly topics                              |                                     |
| ------------------------------------------ | ----------------------------------- |
| 1. Intro to course and Input validation    | 6. Async/Await                      |
| 2. Repositories and Unit Testing           | **7. Load Testing and Performance** |
| 3. Publishing to Azure / Intro to Identity | 8. Complex Domain Models            |
| 4. Authentication                          | 9. Docker containers                |
| 5. Authorization                           | 10. Term project                    |

## Contents

[TOC]

------

## Overview 

We will be learning to do load testing using JMeter.

------

## JMeter

Thread Group: controls simulation of users

Sampler: Generates requests. Most common: HTTP Request

Listener: Collects results

- View results in table
- View results in tree (mainly used for debugging a test or diangnosing failures)
- Aggregate report
- Graph result
- Summary report
- Simple data writer

Command line:
On Mac: sh jmeter (runs jmeter.sh)
On Windows: jmeter (runs jmeter.bat)

- -h help
- -n non-gui mode
- -t location of test script (.jmx)
- -l location of the result file
- -e generate html report
- \- o location of html report folder

 

## APDEX

Apdex (Application Performance Index) is an open standard developed by an alliance of companies for measuring performance of software applications.

https://en.wikipedia.org/wiki/Apdex

## FAQ

Q: Does Visual Studio have a load testing add-on?
A: Yes, but only for the Enterprise Edition.

Q: What is latency?
A: The time between the start of the connection and the first byte of the response.

 

------

## References

- [JMeter Web Site](http://jmeter.apache.org/usermanual/generating-dashboard.html)&mdash;Downloads, Documentation, and Tutorials 
- [JMeter HTTP(S) Test Script Recorder](https://jmeter.apache.org/usermanual/jmeter_proxy_step_by_step.html)&mdash;how to record your browser actions in a test script
- [JMeter Beginner Tutorials](https://www.youtube.com/playlist?list=PLhW3qG5bs-L-zox1h3eIL7CZh5zJmci4c) on YouTube
- [ASP.NET Core Performance Best Practices](https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices?view=aspnetcore-6.0#cache-aggressively)&mdash;MIcrosoft tutorial



------

[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png) ](http://creativecommons.org/licenses/by-sa/4.0/)
ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev) is licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 

------