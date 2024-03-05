# Term Project Requirements 

**Web Development 2: ASP.NET**

Your web site should meet the following requirements:

1. **Rich Media**

   Include some kind of interactive “rich” media. This could be as simple as images the user can click on, and/or various images that are displayed in response to user input. It could involve video, sound, jQuery animations, or some other media that's not text.

2. **Data-driven**

   To be data-driven means that the content of one or more of your web pages contains content derived from information stored in a database. 
   In addition:

   - Users should be able to enter data that will be stored in the database.
   - Some of the data entered by users should be visible to other users. 
   - Users should be able to do some kind of searching or filtering of the database.

     An example would be a classified advertising site where users could enter items for sale and other users would be able to see those items and search for items by keywords in the item description.

3.  **Validation**

   There should be both client-side and server-side validation on data input by users. Not every property in your models needs validation, add it to those that need it for good UX; that probably means every domain model class will have at least one property that is validated. Use appropriate validation for each input type. 

4. **Moderately Complex**

   Your site shouldn't be too simple, but not too hard to build either. Here are some criteria:

   - There should be 4 to 6 persistant domain model classes.
   - The total number of fields in the domain models should be between 12 and 30 (not counting Identity fields).
   - There should be between 10 and 15 views. At least 8 views should be used for either getting or displaying user input.

5. **Authentication, Authorization, and Administration**
   Require authentication and authorization. This means there will be a way for users to register and log in. There should be at least three levels of authorization:

   - Guest: these users don’t need to log in, but will only be able to access a limited number of pages and/or features. (This does not need an Identity Role.)
   - Member: these users can access anything except the pages/features that are only for administrators.
   - Administrator: these users can access everything.

   There should be administrative page(s) for managing users.

6. **Publish to a server**

   Publish your web app to Azure or some other web host.

   - On Azure this will require a second Azure database. If you're using MySQL you can add a second database to the same server you are using for your lab assignment and I *think* it will still be free. Check your credits to make there aren't too many being used.
   - Alternatively, you could use a [low-cost hosting service](https://birdsbits.wordpress.com/2019/02/18/publishing-an-asp-net-core-web-app-to-a-cheap-windows-hosting-service/). 

7. **Load testing**

   Show results of testing your web site using JMeter.

   

**Notes**

- The term project must be different from:
  -  The web app you used in your weekly lab assignments
  -  The instructor's examples
  - The textbook examples. 


- It can be an enhancement of last term's project.

- Good design and development practices are expected, such as using:
  -  Unit tests.
  - Async controller methods.
  - Consistent navigation on each page.
  - Following coding conventions, etc.




------

[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png)](http://creativecommons.org/licenses/by-sa/4.0/) 
​ASP.NET Core MVC course materials written by [Brian Bird](https://profbird.dev), 2020 and revised 2024, are licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 

------

