# *Load Testing* 

| Weekly topics                              |                                     |
| ------------------------------------------ | ----------------------------------- |
| 1. Intro to course and Input validation    | 6. Async/Await                      |
| 2. Repositories and Unit Testing           | **7. Performance and Load Testing** |
| 3. Publishing to Azure / Intro to Identity | 8. Complex Domain Models            |
| 4. Authentication                          | 9. Docker containers                |
| 5. Authorization                           | 10. Term project                    |

## Contents

[TOC]

------

## Introduction

Winter 2022 topics

- Q and A

## Performance Under Load

If your site is successful, then you should expect to have multiple simultaneous users on your site. There are two types of testing that will help you understand what your site's performance will be for those users:

- **Load tests**: measure system behaves under an expected load.
- **Stress tests**: measure the upper limits of a system's capacity using a load the expected maximum.

Your goal will be to have a site that performs in accord with Google's definition of a "good" site even when there are multiple simultaneous users. 

You can do both load testing and stress testing using automated tools that simulate multiple users.

### Measuring Performance Under Load

JMeter is a popular free, open source, tool for load testing web sites. You can use it to simulate any number of simultaneous visitors to your site and you can write (or record) a test script of actions that those simulated visitors will take on the site. These actions can include registering, logging in, making posts, etc.

Two of the primary metrics reported by JMeter are:

- **Latency**: The time elapsed from when the HTTP request was sent and when an initial response was received. This is comparable to *First Contentful Paint*.
- **Sample Time**: The time that the server took to fully serve the request (response + latency). This is comparable to *Time to Interactive*.

## How to Use JMeter

### Downloading and Running JMeter

JMeter requires the Java Runtime Environment (JRE). You can check to see if Java is installed on your Windows computer by opening a command prompt and typing: `java -versioin`. For the current version of JMeter, you need version 1.8 (known as "Java 8") or higher. If Java is not on your computer, or you have an older version, you can download the latest version from the [official Oracle Java website](https://www.java.com/en/) and install it.

 Download JMeter from the [official Apache JMeter web site](https://jmeter.apache.org/). You can either download a "tarball" (.tgz) file or a Zip (.zip) file. Download whichever one you know how to unarchive (unzip). 

JMeter doesn't have an installation or setup program. You just run it from wherever you put the unarchived apache-jmeter-5.4.3 folder.  The program will run from almost anywhere you put the folder,but some features won't work if you put it in You can put C:\Program Files&mdash;particularly, you won't be able to record test scripts because JMeter won't have permission to write a file in the Program Files folder.

You run JMeter by double-clicking on ApacheJMeter.bat, which is in the bin folder. If you want to create a shortcut to the .bat file to more easily start JMeter, you can do that and place it on your desktop.

### Setting up a Test Plan Manually

Follow the instructions in the tutorial by Anicas (2014),  [How To Use Apache JMeter To Perform Load Testing on a Web Server](https://www.digitalocean.com/community/tutorials/how-to-use-apache-jmeter-to-perform-load-testing-on-a-web-server). Here are some supplemental notes:

#### Thread Group, Ramp-up period
The JMeter help docs give this additional information:

> The ramp-up period tells JMeter how long to take to "ramp-up" to the full number of threads chosen. If 10 threads are used, and the ramp-up period is 100 seconds, then JMeter will take 100 seconds to get all 10 threads up and running. Each thread will start 10 (100/10) seconds after the previous thread was begun. If there are 30 threads and a ramp-up period of 120 seconds, then each successive thread will be delayed by 4 seconds.
>

Note that a ramp up time that equates to 

#### HTTP Request Defaults, Server Name or IP

Do not include https:// or http:// in the server name. If you wish to specify https do it in the *protocol* field.

#### Additional Listeners

You may want to add other listeners besides "View Results in Table". Here are some useful ones:

##### View Results Tree

This listener will let you see detailed results for each HTTP response. If you are getting error responses this is especially useful in helping you determine the cause of the errors. Here's an example:

###### Unsuccessful results

This is the type of error you might get when the web server is getting too many simultaneous requests to handle:

>  Response code: 503
> Response message: Service Unavailable

This error message indicates that you are trying to send requests at a rate the computer running JMeter can't handle:

>  Response code: Non HTTP response code: java.net.SocketException
> Response message:Non HTTP response message: Socket closed

##### Graph Results
This listener shows you graphs of web stite performance over time as more simulated users are added to the test.

##### Summary Report
This listener gives you a statistical summary of the parameters measured in your test.


### Recording a Test Plan

Follow the instructions in the tutorial by Anicas (2014), [How to Use JMeter to Record Test Scenarios](https://www.digitalocean.com/community/tutorials/how-to-use-jmeter-to-record-test-scenarios). 



## References

- [JMeter Web Site](http://jmeter.apache.org/usermanual/generating-dashboard.html)&mdash;Official site: downloads and documentation
- [Load Testing with Apache JMeter](https://www.digitalocean.com/community/tutorial_series/load-testing-with-apache-jmeter)&mdash;DigitalOcean tutorial by Mitchell Anicas, 2014.
- [JMeter Beginner Tutorials](https://www.youtube.com/playlist?list=PLhW3qG5bs-L-zox1h3eIL7CZh5zJmci4c)&mdash;YouTube



[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png) ](http://creativecommons.org/licenses/by-sa/4.0/)
ASP.NET Core MVC Lecture Notes written by [Brian Bird](https://profbird.dev) in 2018, revised in 2022, are licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 




[^1]:[Apdex](https://en.wikipedia.org/wiki/Apdex) (Application Performance Index) is an open standard developed by an alliance of companies for measuring performance of software applications.
[^2]:These standards are based onGoogle's [Lighthouse Scoring Calculator](https://googlechrome.github.io/lighthouse/scorecalc/) and their criteria for a score of 90&mdash;which is the minimum for what they consider a "good" site.

