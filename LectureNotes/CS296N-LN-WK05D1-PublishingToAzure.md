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
## Sign Up for a Free Azure Student Account 

1. If you haven't already [signed up for a personal Microsoft account](https://account.microsoft.com/) using your LCC e-mail address, do it now.
2. Sign up for [Azure Dev Tools for Teaching](https://signup.azure.com/studentverification?offerType=3) using your LCC e-mail address&mdash;if you haven't already done this.
3. On the [Azure Dev Tools for Teaching](https://portal.azure.com/?Microsoft_Azure_Education_correlationId=bbe97574-470e-4568-b0db-4d73ba7adfd2#blade/Microsoft_Azure_Education/EducationMenuBlade/overview) page, click the blue button with the title "Claim your Azure Credit Now"
4. On the following page, [Start building the future with Azure for Students](https://azure.microsoft.com/en-us/free/students/), click the green button with the title "Activate now".

​    

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
              `Server=tcp:practiceserver.database.windows.net,1433;Initial Catalog=Movie;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection               Timeout=30;`



### Publish Your Web App from Visual Studio         


-  In Visual Studio, run the publish wizard by right-clicking on the project and selecting publish.

- Click on configure to change the settings in your publish profile

- Select the Settings page

- - In the *Databases* section, check the checkbox for your SQL Server connection string and paste the connection string for your Azure SQL Database.

  - - Be sure to put the user name and password for your Azure SQL Database in place of your_username and your_password and delete the curly braces.

  - In the *Entity Framework Migrations* section, check the check box for AppDbContext and add the              connection string again.

- Now you can publish your web app.

------



## References

- Anderson, Rick. 2020. [Host ASP.NET Core on Linux with Apache](https://docs.microsoft.com/en-us/aspnet/core/tutorials/publish-to-azure-webapp-using-vs?view=aspnetcore-3.1). Microsoft.

------

[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png)](http://creativecommons.org/licenses/by-sa/4.0/) 
​ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.online), 2020, are licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 

------