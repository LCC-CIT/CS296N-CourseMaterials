**[CS296N Web Development 2: ASP.NET](http://lcc-cit.github.io/CS296N-CourseMaterials/)**

#   Troubleshooting Deployment to Azure   

| Weekly topics                            |                                              |
| ---------------------------------------- | -------------------------------------------- |
| 1. Intro to course and Input validation  | **6. Publishing to Azure ~~& Async/Await~~** |
| 2. Identity                              | 7. Creating a Web Service                    |
| 3. Authentication and authorization      | 8. Consuming a Web Service                   |
| 4. Security                              | 9. Docker containers                         |
| 5. ~~Publishing to a production server~~ | 10. Term project                             |



## Contents

[TOC]



## Problems with the Publish Process

#### Database Connection String

- **Database(s) not showing up in the settings dialog**
  The publish tool finds the databases used in your app by scanning appsettings.json. It looks for an object named "ConnectionStrings" as a top-level object in the file. Make sure the connection string(s) are there.

- **Error when trying to open the Entity Framework Migrations drop-down in the Publish dialog box.**
  I installed the .NET Core 3.1.1 SDK. I don't know why I had to add this SDK. Perhaps, even though my project is targeting .NET Core 3.1, the publish wizard wants me to use the latest version in the 3.1 series? I don't know. Weird!

## Problems with the SQL Database on Azure

- **Database migration not applied**
  If you get a [TODO: *add error page message*] error page, it could be caused by the migration not being applied when your app was published. To check for this, look at the event log. If you see an error message about missing tables, then this is probably the cause.
  Solutions:
  - **Add code to your app to apply the migration on startup.**
    Add the line of code below to Startup.cs and republished your site. 

  ```C#
  context.Database.Migrate();
  ```
  
  - **Unblock the database TCP/IP connection through firewalls.**
    There are two firewalls that could block Visual Studio's connection to your database on Azure:
    1. A firewall on your end (the college firewall, your how firewall, etc.)
       You will need to follow whatever procedures apply to unblock the database IP address and port, 1433.
    2. The Azure database server firewall.
       On Azure, open the SQL Server service, then open the Firewalls and Virtual Networks page, add your local IP address so it is allowed through the firewall.

- **Viewing your database tables**
  You can use any database management tool, such as:

  1.  The Server Explorer in Visual Studio.
  2. The Query Editor on the Azure Portal, SQL database page.

  Note: You will need to be sure that the database IP connection isn't blocked by a firewall for either of these options.

## Problems with the App on Azure App Service

- **View the log files**
  The best place to start troubleshooting problems with your app not running or not running correctly is by looking at the event log. First, you need to enable error logging by following these instructions:

  https://docs.microsoft.com/en-us/azure/app-service/troubleshoot-diagnostic-logs
  [*TODO: provide the steps for viewing the error log on the Azure portal*]

- **Use the VS Debugger**
  Use the Visual Studio 2019 debugger to debug your app while running on an Azure App Service. See these instructions: https://docs.microsoft.com/en-us/aspnet/core/tutorials/publish-to-azure-webapp-using-vs

## Problems with the Azure for Students Account

- **Checking your credit balance**
  https://www.microsoftazuresponsorships.com/Usage
- **Charges for using an App Service.**
  If you used the publish wizard to create your App Service, be sure to go to your Azure portal and change the service plan from Standard to Free. This way you won't spend any of your $100 credit on your App Service.

------



## References

- Anderson, Rick. 2020. [Publish an ASP.NET Core app to Azure with Visual Studio](https://docs.microsoft.com/en-us/aspnet/core/tutorials/publish-to-azure-webapp-using-vs). Microsoft.
- Latham, Luke and Kotalik, Justin. 2020. [Troubleshoot ASP.NET Core on Azure App Service and IIS](https://docs.microsoft.com/en-us/aspnet/core/test/troubleshoot-azure-iis?view=aspnetcore-3.1). Microsoft.
- Jones, Mike, et al. 2018. [Remote Debug ASP.NET Core on an Azure App Service](https://docs.microsoft.com/en-us/visualstudio/debugger/remote-debugging-azure?view=vs-2019#remote_debug_azure_app_service). Microsoft.
- Lin, Cephas, et al. 2019. [Enable diagnostics logging for apps in Azure App Service](https://docs.microsoft.com/en-us/azure/app-service/troubleshoot-diagnostic-logs). Microsoft.

------

[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png)](http://creativecommons.org/licenses/by-sa/4.0/) 
​ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.online), 2020, are licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 

------