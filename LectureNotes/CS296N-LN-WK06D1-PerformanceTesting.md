---
title: Performance Testing
description: Testing and improving page load speed in a web site.
keywords: Lighthouse, PageInsights
---

# *Performance Testing* 

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

- Additional example of unit testing async controller methods&mdash;specifically, methods that use IQueryable: https://github.com/LCC-CIT/CS296N-Example-BookReviews/tree/5-AsyncQueriesRefactored
- Term project proposals. Will finish grading today.
- Q and A



## Web Site Performance

### Why Performance Matters

Web pages that load quickly are a major contributor to UX (User experience) on your site. Site UX matters, because better UX means that users:

- Stay on your site longer.
- Are more like to return to your site.
- Are more likely to engage in the mission of your site (buy, donate, read, post, comment, etc.).

Page load time is also a significant factor in SEO (Search Engine Optimization). Google uses this aspect of UX as part of their determination of search rankings.

### Performance Standards

How fast is fast enough? There are no universally accepted standards[^1] for page loading speed, but one way to answer this question is to use Google's standards for what their site ranking tools consider "good"[^2]. These are their current (2/13/2022) standards:

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

Google provides a tool called [Lighthouse](https://developers.google.com/web/tools/lighthouse/) so developers can evaluate the performance of their web pages the same way Google does. It is available at [Page Speed Insights](https://pagespeed.web.dev/) and will run in any browser without installing any software or browser extensions. Note that this tool only loads your site with a single user. 

Here is an example of "desktop" results from the [show all reviews](https://bookreviews.azurewebsites.net/Review) page of the instructor's example web site running on an Azure App Service using the free pricing plan:

- First Contentful Paint: 600 ms
  
- Time to Interactive: 600 ms
  
- Speed Index: 700 ms

- Total Blocking Time: 0 ms

- Largest Contentful Paint: 600 ms

- Cumulative Layout Shift: 0

Overall score: 100/100



## Performance Under Load

If your site is successful, then you should expect to have multiple simultaneous users on your site. There are two types of testing that will help you understand what your site's performance will be for those users:

- **Load tests**: measure system behavior under an expected load.
- **Stress tests**: measure the upper limits of a system's capacity using a load beyond the expected maximum.

Your goal will be to have a site that performs in accord with Google's definition of a "good" site even under a heavy load. 

You can do both load testing and stress testing using automated tools that simulate multiple users.



## Improving Site Performance

### Optimize Web Site Code

This can be "low hanging fruit"&mdash;meaning it may not take much effort to get significant performance improvements.

Here are some common types of code optimization:

- **Async methods**: Make CPU or I/O bound controller methods async.

- **Caching**: You can cash a whole page or part of a page 

  - Cache a whole page just by using a C# attribute:

    ```C#
    [OutputCache(Duration=10, VaryByParam="none")] 
        public ActionResult Index() { 
            return View(); 
        } 
    ```

  - Cache part of a page using a tag helper:

    ```C#
    <cache expires-after="@TimeSpan.FromMinutes(10)">
        @Html.Partial("_WhatsNew")
        *last updated  @DateTime.Now.ToLongTimeString()
    </cache>
    ```

    (Examples from Tims 2018)

There are many more things you can do to optimize code. See the References section at the end of the notes.

### Increase Server Performance

#### Optimize Server Configuration

In an Azure App Service, most of this has already been done for you. These are default settings:

- **Response Compression**: Compression of response headers using gzip is turned on by default for ASP.NET Core apps running on Azure App Service. (This needs to be verified.)
- **Logging**: Off by default.
- **Remote Debugging**: Off by default.

But, there are still a few things you can do:

- Under "Settings", "Configuration", on the "Application Settings" tab:
  - **Local Cache**: Create a new App Setting for the app with a key of WEBSITE_LOCAL_CACHE_OPTION and a value of Always. Note that this option is only viable if your application doesn't write files to the server's file system.
- Under "Settings", "Configuration", on the "General" tab:
  - **HTTP 2**: Set the protocol to HTTP 2.
  - **Always On**: Set to "on". When *Always On* is not turned on (the default), the app is unloaded after 20 minutes without any incoming requests. Unfortunately this can not be turned off on the free pricing plan.
  - **ARR Affinity**: Turn off the *Application Request Routing* cookie. This is only needed when you have multiple instances of the app and you are doing load balancing.



#### Upgrade Server Resources

This normally means greater monthly expenses.

**Azure App Service Plan Resources**

|           | Free   | Shared | Basic      | Standard   | Premium      |
| --------- | ------ | ------ | ---------- | ---------- | ------------ |
| **Disk**  | 1 GB   | 1 GB   | 10 GB      | 50 GB      | 250 GB       |
| **Cores** | shared | shared | 1 to 4     | 1 to 4     | 1 to 8       |
| **RAM**   | 1 GB   | 1 GB   | Up to 7 GB | Up to 7 GB | 3.5 to 32 GB |



### Use a Content Delivery Network

This works best for static pages, but can have some benefit for dynamic pages as well.

A popular CDN is provided by [Cloud Flare](https://www.cloudflare.com/cdn/). You can get a [free account](https://www.cloudflare.com/plans/applicationservices/#overview) for personal web sites.



## References

### Lighthouse

[Google Lighthouse](https://developers.google.com/web/tools/lighthouse/) 

[Google Page Speed Insights](https://pagespeed.web.dev/)

### ASP.NET Core Code Optimization

- [ASP.NET Core Performance Best Practices](https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices?view=aspnetcore-6.0#cache-aggressively)&mdash;Microsoft tutorial
- [15 Simple ASP.NET Performance Tuning Tips](https://stackify.com/asp-net-performance-tuning/)&mdash;Stackify article by Simon Tims. 2018.

### Azure App Service Configuration

- [Nine Performance Tips for Azure App Services](https://odetocode.com/blogs/scott/archive/2020/01/14/nine-performance-tips-for-azure-app-services.aspx)&mdash;Ode to Code by K. Scott Allen. 2020.
- [Configure an Azure App Service](https://docs.microsoft.com/en-us/azure/app-service/configure-common?tabs=portal)&mdash;Microsoft tutorial. 2022.



[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png) ](http://creativecommons.org/licenses/by-sa/4.0/)
ASP.NET Core MVC Lecture Notes written by [Brian Bird](https://profbird.dev) in 2018, revised in <time>2022</time>, are licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 




[^1]: [Apdex](https://en.wikipedia.org/wiki/Apdex) (Application Performance Index) is an open standard developed by an alliance of companies for measuring performance of software applications.
[^2]: These standards are based onGoogle's [Lighthouse Scoring Calculator](https://googlechrome.github.io/lighthouse/scorecalc/) and their criteria for a score of 90&mdash;which is the minimum for what they consider a "good" site.

