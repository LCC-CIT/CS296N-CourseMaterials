---
title: End of term wrap-up, part 2
description: Discussion of related data and other topics we skipped earlier in the term.
keywords: Term project, related data, capstone

---

# End of Term Wrap-Up, Part 2

**CS296N Web  Development 2: ASP.NET**

| Weekly topics                              |                                 |
| ------------------------------------------ | ------------------------------- |
| 1. Intro to course and Input validation    | 6. Async/Await                  |
| 2. Repositories and Unit Testing           | 7. Performance and Load Testing |
| 3. Publishing to Azure / Intro to Identity | 8. Complex Domain Models        |
| 4. Authentication                          | 9. Docker containers            |
| 5. Authorization                           | **10. Term project**            |

[TOC]

## Announcements and Questions

- Q and A
- Review due dates



## Uploading Files

Today we'll talk about providing a way for users to upload files to a web site. This is a a topic that a number of you have requested that we cover.

## Trying out HTML code in the wwwroot folder

This is an approach to testing or experimenting with new new UI code without having to make controller methods and a view to do it.

#### Start with a good tutorial

When I want to learn how to do something with HTML, my favorite starting place is W3Schools. Here's what they have for file upload: [How To - File Upload Button](https://www.w3schools.com/howto/howto_html_file_upload_button.asp).

- Read the tutorial and run the "Try it Yourself" demo.

#### Do some experiments

- Copy the code from the Try it Yourself demo and put it in a .html file in the wwwroot folder of an ASP.NET MVC project.
  - First create a "throw away" experimental project. Run it.
  - Right-click on the wwwroot folder and add a new item, which will be an html page.
  - Copy the code from the W3Schools tutorial into the page.
  - Remove the action attribute (for now).
  - Run the web app in VS, go to the address: https://localhost:5001/upload.html and see what happens when you try to upload a file. (using the port number VS is using on your machine).
    - Look at the query on the URL in the browser. What does this tell you?

- So, the `<input type=file>` element will let you choose a filename and send it somewhere. Where can it send it? Think about the problem:

  - Where will the files the user wants to upload be?
  - Where do we want them to be uploaded to?
  - Where does the code in the browser run?
  - How can we get a file from the user's computer to the server?

- Time for more tutorials.

  - Read the W3 Schools tutorial about [form attributes](https://www.w3schools.com/html/html_forms_attributes.asp), in particular the [action attribute](https://www.w3schools.com/tags/att_form_action.asp).

    - Can we set the file upload destination just using the `action` attribute?

  - We need some server side code. We can't just do this with HTML and JavaScript. Here's a tutorial that shows us how to do that: [Upload files in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-3.1)

    - You'll want to read through the whole tutorial at some point, but we can start by skimming it and look for the "core" code for uploading a file.

    - This section looks promising: [Upload small files with buffered model binding to physical storage](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-3.1#upload-small-files-with-buffered-model-binding-to-physical-storage-1).

      - Copy the View and Controller code into your experimental project so you can play with it. I would just use the Home controller since this is "throw away" code and doesn't need to be pretty.

        


## Debugging and Code help

Time to do some screen sharing and look at people's code.

## Example

[FileUploader](https://github.com/ProfBird/FileUploader) on GitHub

An experimental web app based on the Microsoft tutorial shown below.

## References

[How To - File Upload Button](https://www.w3schools.com/howto/howto_html_file_upload_button.asp). W3Schools.

Smith, Steve, and Storm, Rutger. [Upload files in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-3.1). Microsoft, 2022. 

MDN. [Using files from web applications](https://developer.mozilla.org/en-US/docs/Web/API/File/Using_files_from_web_applications). Mozilla Developer Network. This tutorial shows you how to do a lot of different operations with files using just HTML and JavaScript, including:

- [Upload a file to a server](https://developer.mozilla.org/en-US/docs/Web/API/File/Using_files_from_web_applications#example_uploading_a_user-selected_file) using XMLHttpRequest (AJAX).
- [Create thumbnails of images](https://developer.mozilla.org/en-US/docs/Web/API/File/Using_files_from_web_applications#example_using_object_urls_to_display_images).



[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png) ](http://creativecommons.org/licenses/by-sa/4.0/)
ASP.NET Core MVC Lecture Notes written by [Brian Bird](https://profbird.dev) in 2022, revised <time>2023</time>, are licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 
