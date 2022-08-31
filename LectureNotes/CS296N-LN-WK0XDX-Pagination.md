**[CS296N Web Development 2: ASP.NET](http://lcc-cit.github.io/CS296N-CourseMaterials/)**

#   Publishing a Web App  to Azure   

How to deploy an ASP.NET Core web app with a database to the Azure cloud

## Contents

[TOC]
## Overview

**Microsoft Azure** is a [cloud computing](https://en.wikipedia.org/wiki/Cloud_computing) service created by [Microsoft](https://en.wikipedia.org/wiki/Microsoft) for building, testing, deploying, and managing applications and services through Microsoft-managed [data centers](https://en.wikipedia.org/wiki/Data_center). It provides [software as a service (SaaS)](https://en.wikipedia.org/wiki/Software_as_a_service), [platform as a service (PaaS)](https://en.wikipedia.org/wiki/Platform_as_a_service) and [infrastructure as a service (IaaS)](https://en.wikipedia.org/wiki/Infrastructure_as_a_service) and supports many different [programming languages](https://en.wikipedia.org/wiki/Programming_language), tools and frameworks, including both Microsoft-specific and third-party software and systems. ([Wikipedia](https://en.wikipedia.org/wiki/Microsoft_Azure))



## Azure for Students

Microsoft offers a free Azure subscription for students and gives you $100 in credit on to spend on Azure services. The subscription is good for 12 moths <u>or</u> until you use up your credit&mdash;whichever comes first. There are many [services that are free](https://azure.microsoft.com/en-us/free/students/) with this subscription. If you are still a student when the 12 months end, you can renew your free subscription.

We will not use Azure for anything that requires you to spend your Azure credit in this class until you do your term project and then you will only use about &dollar;5 a month. So you should be able to use your account for the full 12 months. 

### Get a Free *Azure for Students* Account 

1. If you haven't already [signed up for a personal Microsoft account](https://account.microsoft.com/) using your LCC e-mail address, do it now.
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
  - Create a server. **Caution**: You are only allowed to have one free database per region. You select the region when you set up your  server.
  - Select a pricing tier
  - 
    Select the "**Standard**" option. (You will be charged for any of the others, including "Basic").
- Copy the ADO.NET connection string for your database. You will need to add it to the publish profile in Visual Studio.
   Example connection string:
   `Server=tcp:practiceserver.database.windows.net,1433;Initial Catalog=Movie; Persist Security Info=False; User ID={your_username}; Password={your_password}; MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=False; Connection Timeout=30;`



### Publish Your App from Visual Studio         


-  In Visual Studio 2022, run the publish wizard by right-clicking on the project name in Solution Explorer and selecting "Publish...".
-  Click on "More Actions", then "Edit" to change the settings in your publish profile
-  Select the Settings page

    -  In the *Databases* section, check the checkbox for your SQL Server connection string name and paste in the connection string for your Azure SQL Database. (The one you got from the Azure portal web page.)

    -  Be sure to put the <u>user name and password</u> for your Azure SQL Database into the connection string in place of your_username and your_password and delete the curly braces.

   -  In the *Entity Framework Migrations* section, check the check box for AppDbContext and add the connection string again.

-  Now you can publish your web app.



## Managing Your Free Account

If you aren't careful, you may accidentally use services for which you are charged. The charge will be deducted from your $100 credit and if you use up all of your credit, your account will be terminated. So, it's important to be sure you are using free services. To see which services are free, refer to the Azure for Students FAQ in the [references](#References) section.

### Free services and pricing plans

All of the services we will use in this class are free and will not reduce your $100 credit. The services and pricing plans you will use are:

- Azure App Service on the "F1:Free" pricing plan

- SQL Server&mdash;no pricing plan required

- SQL Database on the "Standard S0: 10 DTUs" pricing plan

  Note that currently (winter 2022), a billing rate is shown when you select this pricing plan, but that billing rate does not apply to Azure for Students accounts. the Standard plan is actually free.

### Monitoring your charges

Some of your accounts give you one way to check the usage of your $100 credit, some another. These are the two different ways to check:

1. By going to the https://www.microsoftazuresponsorships.com/ web page and checking it there.
2. By going to https://azure.portal.com and clicking your name in the upper-right corner, then clicking the three dots, then the menu option: "View My Bill."

## Troubleshooting Your Web App on Azure

If you are having problems with your web app on Azure the main thing that will help you with debugging is enabling logging and looking at log files:

https://stackify.com/azure-app-service-log-files/



---



## References

- [Azure for Students FAQ](https://azure.microsoft.com/en-us/free/free-account-students-faq/)&mdash;Microsoft

- [Microsoft Azure Sponsorships](https://www.microsoftazuresponsorships.com/)&mdash;Check your Azure credit billing

- [Publish a Web App to Azure App Service using Visual Studio](https://docs.microsoft.com/en-US/visualstudio/deployment/quickstart-deploy-to-azure?view=vs-2019)&mdash;Microsoft Visual Studio Docs

- Anderson, Rick. 2021. [Publish an ASP.NET Core app to Azure with Visual Studio&mdash;Deploy the App to Azure](https://docs.microsoft.com/en-us/aspnet/core/tutorials/publish-to-azure-webapp-using-vs?view=aspnetcore-3.1#deploy-the-app-to-azure). Microsoft.

  

------

[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png)](http://creativecommons.org/licenses/by-sa/4.0/) 
​ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev), 2020, revised 2022, are licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 

------