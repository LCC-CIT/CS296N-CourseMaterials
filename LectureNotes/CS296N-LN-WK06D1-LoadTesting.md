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

## Web Site Performance

### Why Performance Matters

Web pages that load quickly are a major contributor to UX on your site. Site UX matters, because better UX means that users:

- stay on your site longer.
- are more like to return to your site.
- are more likely to engage in the mission of your site (buy, donate, read, post, comment, etc.).

Page load time is also a significant factor in SEO. Google uses this aspect of UX as part of their determination of search rankings.

### Performance Standards

How fast is fast enough? There are no universally accepted standards[^1] for this, but, one way to answer this question is to use Google's standards for what their site ranking tools consider "good" page load speeds[^2]. These are their current (2/13/2022) standards:

| Desktop Sites            |          |
| ------------------------ | -------- |
| First Contentful Paint   | 930 ms   |
| Speed Index              | 1,310 ms |
| Largest Contentful Paint | 1,200 ms |
| Time to Interactive      | 2,470 ms |
| Total Blocking Time      | 150 ms   |
| Cumulative Layout Shift  | 0.10     |

| Mobile Sites (or reactive sites) |          |
| -------------------------------- | -------- |
| First Contentful Paint           | 1,800 ms |
| Speed Index                      | 3,390 ms |
| Largest Contentful Paint         | 2,500 ms |
| Time to Interactive              | 3,780 ms |
| Total Blocking Time              | 200 ms   |
| Cumulative Layout Shift          | 0.10     |

#### Definitions

- **First Contentful Paint**
  
  How long it takes the browser to render the first item of DOM content after a user navigates to your page. 10% of Lighthouse score.
  
- **Speed Index**
  
  How quickly content is visually displayed during page load. 10% of Lighthouse score.
  
- **Largest Contentful Paint**
  
  The perceived load speed&mdash;it marks the point when the page's main content has likely loaded. 25% of Lighthouse score.
  
- **Time to Interactive**
  
  How long it takes a page to become *fully* interactive. 10% of Lighthouse score.
  
- **Total Blocking Time**
  
  The total amount of time that a page is blocked from responding to user input. 30% of Lighthouse score.
  
- **Cumulative Layout Shift**
  
  A measure of the largest burst of *layout shift scores* for every [unexpected](https://web.dev/cls/#expected-vs.-unexpected-layout-shifts) layout shift that occurs during the entire lifespan of a page. 15% of Lighthouse score.

Notice that the most heavily weighted metrics are *Largest Contentful Paint* and *Total Blocking Time*.

### Measuring Page Performance

Google provides a tool called [Lighthouse](https://developers.google.com/web/tools/lighthouse/) so developers can evaluate their page performance the same way Google does. It is available at [Page Speed Insights](https://pagespeed.web.dev/) and will run in any browser without installing any software or browser extensions. Note that this tool only loads your site with a single user. 

Here is an example of "desktop" results from the [show all reviews](https://bookreviews.azurewebsites.net/Review) page of the instructor's example web site running on an Azure App Service using the free pricing plan:

- First Contentful Paint:
  600 ms

- Time to Interactive:
  600 ms

- Speed Index: 700 ms

- Total Blocking Time: 0 ms

- Largest Contentful Paint: 600 ms

- Cumulative Layout Shift:
  0

Overall score: 100/100



## Performance Under Load

If your site is successful, then you should expect to have multiple simultaneous users on your site. There are two types of testing that will help you understand what your site's performance will be for those users:

- **Load tests**: measure system behaves under an expected load.
- **Stress tests**: measure the upper limits of a system's capacity using a load the expected maximum.

Your goal will be to have a site that performs in accord with Google's definition of a "good" site even when there are multiple simultaneous users. 

You can do both load testing and stress testing using automated tools that simulate multiple users.

### JMeter

JMeter is a popular free, open source, tool for load testing web sites. You can use it to simulate any number of simultaneous visitors to your site and you can write (or record) a test script of actions that those simulated visitors will take on the site. These actions can include registering, logging in, making posts, etc.

Two of the primary metrics reported by JMeter are:

- **Latency**: The time elapsed from when the HTTP request was sent and when an initial response was received. This is comparable to *First Contentful Paint*.
- **Sample Time**: The time that the server took to fully serve the request (response + latency). This is comparable to *Time to Interactive*.







 ## Footnotes

[^1]: [Apdex](https://en.wikipedia.org/wiki/Apdex) (Application Performance Index) is an open standard developed by an alliance of companies for measuring performance of software applications.
[^2]: These standards are based on Google's [Lighthouse Scoring Calculator](https://googlechrome.github.io/lighthouse/scorecalc/) metrics for a score of 90, which is the minimum for a "good" site.

------

## References

- [JMeter Web Site](http://jmeter.apache.org/usermanual/generating-dashboard.html)&mdash;Official site: downloads and documentation
- [JMeter HTTP(S) Test Script Recorder](https://jmeter.apache.org/usermanual/jmeter_proxy_step_by_step.html)&mdash;how to record your browser actions in a test script
- [JMeter Beginner Tutorials](https://www.youtube.com/playlist?list=PLhW3qG5bs-L-zox1h3eIL7CZh5zJmci4c)&mdash;YouTube
- [ASP.NET Core Performance Best Practices](https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices?view=aspnetcore-6.0#cache-aggressively)&mdash;MIcrosoft tutorial
- [15 Simple ASP.NET Performance Tuning Tips](https://stackify.com/asp-net-performance-tuning/)&mdash;Stackify article



------

[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png) ](http://creativecommons.org/licenses/by-sa/4.0/)
ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev) is licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 

------