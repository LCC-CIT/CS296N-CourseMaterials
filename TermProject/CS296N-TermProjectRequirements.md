# Term Project Requirements 

**Web Development 2: ASP.NET**

Your web site should meet the following requirements:

1. **Rich Media**

   Include some kind of interactive “rich” media. This could be as simple as images the user can click on, and/or various images that are displayed in response to user input. It could involve video or sound or jQuery animations, or some other media besides text.

2. **Data-driven**

   To be data-driven means that the content of one or more of your web pages contains content derived from information stored in a database. In addition:

   - Users should be able to enter data that will be stored in the database.
   - Some of the data entered by users should be visible to other users. 
   - Users should be able to do some kind of searching of the database.

     An example would be a classified advertising site where users could enter items for sale and other users would be able to see those items and search for items by key words in the item description.

3. **Moderately Complexity**

   Your site shouldn't be too simple, but not too hard to build either. Here are some criteria:

   - The should be 4 to 6 domain models.
   - The total number of fields in the domain models should be between 12 and 30.
   - There should be between 10 and 15 web pages.

4. **Identity**
   Require authentication and authorization. This means there will be a way for users to register and log in. There should be at least three levels of authorization:

   - Guest: these users don’t need to log in, but will only be able to access a limited number of pages and/or features. (This does not need an Identity Role.)
   - Member: these users can access anything except the pages/features that are only for administrators.
   - Administrator: these users can access everything.

   There should be administrative pages for managing users.

5. **Publish to a server**

   Publish your web app to Azure or some other web host.

   - On Azure this will require a second Azure database. Use a database with the Basic pricing tier. This will only use about $5 a month of your student credit.
   - Alternatively, you could use a [low-cost hosting service](https://birdsbits.wordpress.com/2019/02/18/publishing-an-asp-net-core-web-app-to-a-cheap-windows-hosting-service/). 

6. **Load testing**

   Show results of testing your web site using JMeter.

   

**Notes**

- The term project must be different from the web app you used in your weekly lab assignments and different from the instructor's examples or the textbook examples.
- Good design and development practices are expected, such as using:
  -  Unit tests
  - Async controller methods
  - Consistent navigation on each page
  - Following coding conventions, etc.


 

------

[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png)](http://creativecommons.org/licenses/by-sa/4.0/) 
​ASP.NET Core MVC course materials written by [Brian Bird](https://profbird.dev), 2020 and revised 2022, are licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 

------

