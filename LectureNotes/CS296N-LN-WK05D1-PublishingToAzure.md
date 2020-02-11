**[CS296N Web Development 2: ASP.NET](http://lcc-cit.github.io/CS296N-CourseMaterials/)**

#   Deploying a Web App to Azure   

| Weekly topics                            |                                          |
| ---------------------------------------- | ---------------------------------------- |
| 1. Intro to course and Input validation  | **6. Publishing to Azure & Async/Await** |
| 2. Identity                              | 7. Creating a Web Service                |
| 3. Authentication and authorization      | 8. Consuming a Web Service               |
| 4. Security                              | 9. Docker containers                     |
| 5. ~~Publishing to a production server~~ | 10. Term project                         |



## Contents

[TOC]
## Overview

**Microsoft Azure** is a [cloud computing](https://en.wikipedia.org/wiki/Cloud_computing) service created by [Microsoft](https://en.wikipedia.org/wiki/Microsoft) for building, testing, deploying, and managing applications and services through Microsoft-managed [data centers](https://en.wikipedia.org/wiki/Data_center). It provides [software as a service (SaaS)](https://en.wikipedia.org/wiki/Software_as_a_service), [platform as a service (PaaS)](https://en.wikipedia.org/wiki/Platform_as_a_service) and [infrastructure as a service (IaaS)](https://en.wikipedia.org/wiki/Infrastructure_as_a_service) and supports many different [programming languages](https://en.wikipedia.org/wiki/Programming_language), tools and frameworks, including both Microsoft-specific and third-party software and systems. ([Wikipedia](https://en.wikipedia.org/wiki/Microsoft_Azure))



## Azure for Students

Microsoft offers a free Azure subscription for students and gives you $100 in credit on to spend on Azure services. The subscription is good for 12 moths <u>or</u> until you use up your credit&mdash;whichever comes first. There are many [services that are free](https://azure.microsoft.com/en-us/free/students/) with this subscription. We will not use Azure for anything that requires you to use your Azure credit in this class, so you should be able to use your account for the full 12 months. If you are still a student when the 12 months end, you can renew your free subscription.

### Get a Free *Azure for Students* Account 

1. If you haven't already [signed up for a personal Microsoft account](https://account.microsoft.com/) using your LCC e-mail address, do it now. Be sure to select the "Personal" account option **not** the "Work or Scool" option.
2. Sign up for [Azure Dev Tools for Teaching](https://signup.azure.com/studentverification?offerType=3) using your LCC e-mail address&mdash;if you haven't already done this.
3. On the [Azure Dev Tools for Teaching](https://portal.azure.com/?Microsoft_Azure_Education_correlationId=bbe97574-470e-4568-b0db-4d73ba7adfd2#blade/Microsoft_Azure_Education/EducationMenuBlade/overview) page, click the blue button with the title "Claim your Azure Credit Now"
4. On the following page, [Start building the future with Azure for Students](https://azure.microsoft.com/en-us/free/students/), click the green button with the title "Activate now".

​    

## Deploy a Web App to Azure

### Create a database via the Azure Web Portal         

- Log into the [Azure portal](https://portal.azure.com).

- Select SQL databases from the menu of services.

- Click on +Add, then fill in the required fields.

- - Create a resource group if you don't already have one.

  - Create a server. You are only allowed to have one free database per region. You select the region when you set up your  server.

  - Select a pricing tier

  - - If you are using a free student subscription, select the "Standard" option. (You will be charged for any of the others, including "Basic").

- Copy the ADO.NET connection string for your database. You will need to add it to the publish profile in Visual Studio.
   Example connection string:
   `Server=tcp:practiceserver.database.windows.net,1433;Initial Catalog=Movie; Persist Security Info=False; User ID={your_username}; Password={your_password}; MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=False; Connection Timeout=30;`



### Publish Your App from Visual Studio         


-  In Visual Studio, run the publish wizard by right-clicking on the project and selecting publish.

- Click on configure to change the settings in your publish profile

- Select the Settings page

-  - In the *Databases* section, check the checkbox for your SQL Server connection string and paste the connection string for your Azure SQL Database.

    - Be sure to put the <u>user name and password</u> for your Azure SQL Database in place of your_username and your_password and delete the curly braces.

  - In the *Entity Framework Migrations* section, check the check box for AppDbContext and add the connection string again.

- Now you can publish your web app.

------



## References

- Anderson, Rick. 2020. [Host ASP.NET Core on Linux with Apache](https://docs.microsoft.com/en-us/aspnet/core/tutorials/publish-to-azure-webapp-using-vs?view=aspnetcore-3.1). Microsoft.
- [Azure for Students FAQ](https://azure.microsoft.com/en-us/free/free-account-students-faq/)

------

[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png)](http://creativecommons.org/licenses/by-sa/4.0/) 
​ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.online), 2020, are licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 

------