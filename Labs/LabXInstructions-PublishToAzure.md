# Azure Lab

Follow these steps to publish your web site to Azure:

### Create a database via the Azure Web Portal         

- Log into the [Azure portal](https://portal.azure.com).
- Select SQL databases from the menu of services.
- Click on +Add, then fill in the required fields.
- - Create a resource group if you don't already have one.
  - Create a server. **Caution**: You are only allowed to have one free database per region. You select the region when you set up your  server.
  - Select a pricing tier
  - If you are using a free student subscription, select the "Standard" option. (You will be charged for any of the others, including "Basic").
- Copy the ADO.NET connection string for your database. You will need to add it to the publish profile in Visual Studio.
  Example connection string:
  `Server=tcp:practiceserver.database.windows.net,1433;Initial Catalog=Movie; Persist Security Info=False; User ID={your_username}; Password={your_password}; MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=False; Connection Timeout=30;`

### Publish Your App from Visual Studio         


-  In Visual Studio, run the publish wizard by right-clicking on the project and selecting publish.

-  Click on configure to change the settings in your publish profile

-  Select the Settings page

-  - In the *Databases* section, check the checkbox for your SQL Server connection string and paste the connection string for your Azure SQL Database.

    - Be sure to put the <u>user name and password</u> for your Azure SQL Database in place of your_username and your_password and delete the curly braces.

   - In the *Entity Framework Migrations* section, check the check box for AppDbContext and add the connection string again.

-  Now you can publish your web app.



## Review and Submission

No code review is needed.

### Production Version

In the "online text" for the Moodle assignment paste a link to your web app running on Azure.



------

Written by Brian Bird, Lane Community College, Fall 2017, revised Winter 2022

------

