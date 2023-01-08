**[CS296N Web Development 2: ASP.NET](http://lcc-cit.github.io/CS296N-CourseMaterials/)**

#   Deploying a Web App to a Linux Server   

| Weekly topics                                           |                                  |
| ------------------------------------------------------- | -------------------------------- |
| <mark>1. Intro to course and Publishing to Linux</mark> | 6.  A More Complex Domain Model  |
| 2. Identity                                             | 7.  Load Testing and Performance |
| 3. Authentication                                       | 8. Validation                    |
| 4. Authorization                                        | 9. Docker containers             |
| 5. Async/Await                                          | 10. Term project                 |

## Contents

[TOC]

------

## Overview 

ASP.NET Core web apps use Kestrel as a lightweight web server. Kestrel can be used as an Internet-facing server, but the recommended production configuration is to use it with Apache, Nginx, or another secure, high-performance server as a reverse proxy.            

 ![kestrel-to-internet](Images/kestrel-to-internet.png)                            Diagram by Microsoft in "[Web Server Implementations in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/?view=aspnetcore-2.1&tabs=windows)"            

The proxy will be listening for client HTTP requests on  port 80 (the standard HTTP port). When a request is received, it will be forwarded to Kestrel which will be listening on a loop-back (localhost) port such as 127.0.0.1:5000.  (On citweb, you will each have your own port number.)         

These are the steps to publish an ASP.NET Core web app to a Linux server:    

1. Install the .NET Core SDK on the server. (Already done on citweb.)
2. Configure the web app to use a database on the server.
3. Set up a [reverse proxy server](https://en.wikipedia.org/wiki/Reverse_proxy) to forward requests to the [Kestrel web server](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/?view=aspnetcore-2.1&tabs=aspnetcore2x#kestrel).
4. Deploy the web app's executable code to the web server.
5. Ensure the web app runs on startup as a daemon.
6. Configure a process management tool to help restart the web app.

------

## Detailed Instructions

### 1. Install the .NET Core SDK on the server

***Note: Version 3.1.1 (as of 2/4/2020) of the dotnet SDK has already been installed*** on the CIT department's server, citweb, which is running the Linux [CentOS](https://www.centos.org/) 7 operating system.

 The .NET Core runtime is a package that provides the resources to run any kind of .NET Core app, from console apps to web  apps, on the server. We are installing the SDK, which includes the runtime as well as command line tools for development.         

1. Log into citweb using a terminal app or SSH client
   Example: `ssh  myusername@citweb.lanecc.net`
2. Add the dotnet product feed to the installer:
`sudo rpm  -Uvh  https://packages.microsoft.com/config/rhel/7/packages-microsoft-prod.rpm`
3. Install the SDK
   `sudo yum install dotnet-sdk-2.1`

### 2. Configuring an App to use MariaDB

The current version of [MariaDB](https://mariadb.com) on citweb is 15.1 (as of 2/4/2020).

1. In your ASP.NET Core project, add an EntityFramework provider for MariaDB. Since MariaDB is binary compatibility with MySQL  we can use a MySQL provider. One of the better providers is [Pomelo.EntityFrameworkCore.MySQL](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql). Add a reference to this to your project.

2. Add code to Startup.cs in the ConfigureServices method to add a service for MySQL:
  
   ```C#
   services.AddDbContext(options => options.UseMySql(
      Configuration.GetConnectionString("MySqlConnection")));
   ```
   
3. In appsettings.json, add a connection string similar to this one:

    ```Json
    "MySqlConnection": 
    "server=localhost;user id=xxxxx;password=xxxxxxxx;database=xxxxx;"
    ```

5. Create a database on the web server.                

  - Connect to MariaDB with your database username (the same as your Linux user name). Enter your database password when prompted.
    `mysql --user=mydbusername -p`
  - At the MariaDB prompt type: 
    `CREATE DATABASE databasename;`

*Note: a useful cross-platform free, open-source database manager is [DBeaver](https://dbeaver.io)*.

### 3. Using a Reverse Proxy 

1. Configure your app to use the Forwarded Headers Middleware.
   The middleware updates the Request.Scheme, using the X-Forwarded-Proto  header, so that redirect URIs and other security policies work  correctly. Add the code below to Startup.configure before a call to UseAuthentication or similar authentication scheme middleware. 

   ```c#
   app.UseForwardedHeaders( new ForwardedHeadersOptions {
      ForwardedHeaders = ForwardedHeaders.XForwardedFor |
      ForwardedHeaders.XForwardedProto
   });
   ```

2. Configure Apache
   ***Note: This is already done for you on citweb.***
   Follow the instructions here: [Host  ASP.NET Core on Linux with Apache: Configure a Proxy Server - Configure Apache](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/linux-apache?view=aspnetcore-2.1&tabs=aspnetcore2x#configure-apache)

### 4. Deploying a web app

We will be doing a [Framework Dependent Deployment](https://docs.microsoft.com/en-us/dotnet/core/deploying/#framework-dependent-deployments-fdd). This means that in a previous step we installed the .NET Core runtime so it is available system-wide.

1. Preparing the app for deployment 

   - Add code to create a database if it doesn't exist and to apply any pending migrations. This code goes in Startup.cs,  in the Configure method, before calling the seed data method.

   ```C#
   context.Database.Migrate();
   ```
   
   - Exclude Application Insights from the code in the release build's publish folder 
     Add the line below to your .csproj file:
     
     ```json
    <PropertyGroup
        <PublishWithAspNetCoreTargetManifest>
           false
        </PublishWithAspNetCoreTargetManifest>
     </PropertyGroup>
     ```
   
2. Deploying the app
  - Run [dotnet publish](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish?tabs=netcore21) from the development environment on your local machine to package an app into a directory (folder) that will contain code that can run on the server. Example:
    `dotnet  publish --configuration Release `
    Alternatively, you can publish your app from Visual Studio.
    
  - Copy the directory above, which contains your application's executable code, to the server using a means of your choice such as *ftp*, *scp,* *rsync*, or a continuous integration server.
  
    Example (assuming you are in the project directory on your local machine):
     `rsync -avz bin/Release/netcoreapp2.0/publish/   myusername@citweb.lanecc.net:apps/bookinfo`
    
    *Note: You should create a sub-directory in your home directory for your web apps, in the example below I named it apps. Here is the Linux command to create a directory:*
    `mkdir apps`

3. Testing the App

  - This test will just be run on the server itself, the web pages won't be delivered over the Internet. From the command line, run the app: 
    `dotnet myapp.dll`
      A typical response will be:  
   ```
   Hosting environment: Production
   Content root path: /home//apps/myapp
   Now listening on: http://localhost:5000
   Application started. Press Ctrl+C to shut down.   
   ```
  - Use the text based browser, [ELinks](http://elinks.or.cz/), to view the web page:
    `elinks http://localhost:5000 `

------



## References

- Boyer, Shayne. 2020. [Host ASP.NET Core on Linux with Apache ](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/linux-apache?view=aspnetcore-2.1&tabs=aspnetcore2x#configure-apache). Microsoft.
- Contributors. 2018. [.NET Core Application Deployment](https://docs.microsoft.com/en-us/dotnet/core/deploying/#framework-dependent-deployments-fdd). Microsoft.
- Dykstra, Smith, Halter, and Ross. 2019. [Web Server Implementations in .NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/?view=aspnetcore-2.1&tabs=aspnetcore2x). Microsoft.
- [A Ten Minute MariaDB Primer](https://mariadb.com/kb/en/a-mariadb-primer/). Official MariaDB Documentation.
- Pelser, Jerrie. 2017. [Using MariaDB with ASP.NET Core 2.0](https://www.jerriepelser.com/blog/using-mariadb-with-aspnet-core). Personal blog.
- Customer Content Services. [Using .NET Core 3.1 on RHEL](https://access.redhat.com/documentation/en-us/net_core/3.1/html/getting_started_guide/gs_install_dotnet). Red Hat.
  *Note that RHEL (Red Hat Enterprise Linux) is identical to CentOS.*

------

[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png)](http://creativecommons.org/licenses/by-sa/4.0/) 
​ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.online), 2019, is licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 

------