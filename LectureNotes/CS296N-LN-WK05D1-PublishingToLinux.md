**[CS296N         Web Development 2: ASP.NET](http://lcc-cit.github.io/CS296N-CourseMaterials/)**

#   *Deploying a Web App **to a Linux Server***   

| Weekly topics                            |                                 |
| ---------------------------------------- | ------------------------------- |
| 1. Intro to course and Input validation  | 6. Load Testing and Performance |
| 2. Identity                              | 7. Creating a Web Service       |
| 3. Authentication and authorization      | 8. Consuming a Web Service      |
| 4. Security                              | 9. Docker containers            |
| **5. Publishing to a production server** | 10. Term project                |

## Contents

[TOC]

------

## Overview 

ASP.NET Core web apps use Kestrel as a lightweight web  server. Kestrel can be used as an Internet-facing server, but the  recommended production configuration is to use it with Apache, Nginx, or another secure, high-performance server as a reverse proxy.            

​                ![img](file:///home/brian/Repos/CS296N-CourseMaterials/LectureNotes/Images/kestrel-to-internet.png)                Diagram by Microsoft in "[Web Server Implementations in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/?view=aspnetcore-2.1&tabs=windows)"            

The proxy will be listening for client HTTP requests on  port 80 (the standard HTTP port). When a request is received, it will be forwarded to Kestrel which will be listening on a loop-back (localhost)  port such as 127.0.0.1:5000.            

These are the steps to publish an ASP.NET Core web app to a Linux server:    

1. Install the .NET Core SDK on the server.
2. Configure the web app to use a database on the server.
3. Deploy the web app's executable code to the web server.
4. Set up a [reverse proxy server](https://en.wikipedia.org/wiki/Reverse_proxy) to forward requests to the [Kestrel web server](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/?view=aspnetcore-2.1&tabs=aspnetcore2x#kestrel).
5. Ensure the web app runs on startup as a daemon.
6. Configure a process management tool to help restart the web app.

------

## Detailed Instructions

### 1. Installing the .NET Core SDK on the server

The .NET Core runtime is a package that provides the  resources to run any kind of .NET Core app, from console apps to web  apps, on the server. Note that the CIT department's server, citweb,  is running the Linux [CentOS](https://www.centos.org/) operating system.            

1. 
2. 1. Log into citweb using a terminal app or SSH client
       Example: ssh  myusername@citweb.lanecc.net
   2. Add the dotnet product feed to the installer:
       sudo rpm  -Uvh  https://packages.microsoft.com/config/rhel/7/packages-microsoft-prod.rpm
   3. Install the SDK
      sudo yum install dotnet-sdk-2.1 

*TODO: Add a description of the .NET Core runtime and an explanation of how it works.*

### 2. Configuring an App to use MariaDB

The current version of MariaDB on citstudent as of 6/12/18 is 5.5.56

1. In your ASP.NET Core project, add an EntityFramework provider for MariaDB. Since MariaDB is binary compatibility with MySQL  we can use a MySQL provider. One of the better providers is [Pomelo.EntityFrameworkCore.MySQL](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql). Add a reference to this to your project.
2. Add code to Startup.cs in the ConfigureServices method to add a service for MySQL
   ` services.AddDbContext(options =>                                options.UseMySql(Configuration.GetConnectionString("MySqlConnection")));`                
3. In appsettings.json, add a connection string similar to this one:
    `"MySqlConnection": "server=localhost;user id=brian;password=xxxxxxxx;database=MyDatabase;"`
4. If you haven't already added migrations to your project, do it now:                    
   dotnet ef  migrations add InitialMigration
5. Create a database on the server. On citstudent type:                    
   1. mysql --user=mydbusername
   2. At the prompt type: CREATE DATABASE mydatabase

Note: a useful cross-platform free, open-source database manager is [DBeaver](https://dbeaver.io)

​            

### 3. Deploying a web app

We will be doing a [Framework Dependent Deployment](https://docs.microsoft.com/en-us/dotnet/core/deploying/#framework-dependent-deployments-fdd). This means that in a previous step we installed the .NET Core runtime so the it is available system-wide.

1. Deploying the App                    

   1. Add code to create a database if it doesn't  exist and to apply any pending migrations. This code goes in Starup.cs,  in the Configure method:
      `using (var serviceScope = app.ApplicationServices.GetRequiredService().CreateScope())                  {                    var context =                  serviceScope.ServiceProvider.GetService();                    context.Database.Migrate();                   }` 
   2. Exclude Application Insights from the code in the release build's publish folder (See Issue #13542 below)
       Add the line below to your .csproj file:
                                  `                    false                  `
   3. Run [dotnet                   publish](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish?tabs=netcore21) from the development environment on your  local machine to package an app into a directory (folder) that will  contain code that can run on the server. 
       Example:                            
       dotnet  publish --configuration Release 
   4. Copy the directory above, which contains your application's executable code, to the server using a means of your choice such as *ftp*, *scp,* *rsync*, or a continuous integration server.
       Note: You should create                            a sub-directory in your home directory for your web apps, in the example below I named it *apps*
       Example (assuming you are in the project directory on your local machine):                            
                                  rsync                  -avz bin/Release/netcoreapp2.0/publish/                  myusername@citstudent.lanecc.edu:apps/bookinfo

2. Testing the App

    This test will just be run on the server itself, the web pages won't be delivered over the internet                    

   1. From the command line, run the app: 

      ​                            dotnet myapp.dll

      1. A typical response will be: Hosting environment: Production                                    
          Content root path: /home//apps/myapp
          Now listening on: http://localhost:5000
          Application started. Press Ctrl+C to shut down.                                

   2. Use the text based browser, elinks, to view the web page:
                                                                  elinks http://localhost:5000 

### 4. Configuring a Reverse Proxy 

1. Configure your app                    

   1. Use the Forwarded Headers Middleware 
        The middleware updates the Request.Scheme, using the X-Forwarded-Proto  header, so that redirect URIs and other security policies work  correctly. Add the code below to Startup.configure                            before a call to UseAuthentication or  similar authentication scheme middleware. 
                                  `app.UseForwardedHeaders(new ForwardedHeadersOptions                  {                    ForwardedHeaders =                  ForwardedHeaders.XForwardedFor |                  ForwardedHeaders.XForwardedProto                  });` 
   2. Issue with links                            
      - See Issues #1120 and #2302 in the references section below
      - See                        this Stack Overflow discussion about the general issue                        (not just for ASP.NET) that when using Apache as a                        reverse proxy,                                                            ProxyPassRewrite does not rewrite the response bodies, only headers (like redirects to a 404 page and such).                      https://serverfault.com/questions/561892/how-to-handle-relative-urls-correctly-with-a-reverse-proxy#561897                                

2. Configure Apache

    Follow the instructions here: 

   Host              ASP.NET Core on Linux with Apache: Configure a Proxy Server -              Configure Apache

   ​                    

   A reverse proxy has already been set up on citstudent to forward HTTP requests to [Kestral](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/?view=aspnetcore-2.1&tabs=aspnetcore2x#kestrel)                        port 5000. The proxy listens for requests at:[                 http://citstudent.lanecc.edu/dotnet/](http://citstudent.lanecc.edu/dotnet/) 

[             ](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/linux-nginx?view=aspnetcore-2.1&tabs=aspnetcore2x)

​            

[             ](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/linux-nginx?view=aspnetcore-2.1&tabs=aspnetcore2x)

------

## References

- Boyer, Shayne. 2019. [                     Host ASP.NET Core on Linux with Apache ](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/linux-apache?view=aspnetcore-2.1&tabs=aspnetcore2x#configure-apache). Microsoft.
- Contributors. 2018. [                     .NET Core Application Deployment](https://docs.microsoft.com/en-us/dotnet/core/deploying/#framework-dependent-deployments-fdd). Microsoft.
- Dykstra, Smith, Halter, and Ross. 2019. [                     Web Server Implementations in .NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/?view=aspnetcore-2.1&tabs=aspnetcore2x). Microsoft.
- Pelser, Jerrie. 2017. [Using MariaDB with ASP.NET Core 2.0](https://www.jerriepelser.com/blog/using-mariadb-with-aspnet-core). Personal Blog.
- Customer Content Services. [Product documentation for .NET Core 2.2](https://access.redhat.com/documentation/en-us/net_core/2.2/). Redhat.

------

​        [             ![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png)         ](http://creativecommons.org/licenses/by-sa/4.0/) 
​        ASP.NET        Core MVC Lecture Notes by [Brian         Bird](https://profbird.online), 2019, is licensed under a [Creative         Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 

------