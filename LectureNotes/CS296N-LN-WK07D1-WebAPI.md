**[CS296N Web Development 2: ASP.NET](file:///data/brian/repos/CS296N-CourseMaterials/index.html)**

# Creating a REST Web API



| Weekly topics                           |                                        |
| --------------------------------------- | -------------------------------------- |
| 1. Intro to course and Input validation | 6. Security                            |
| 2. Identity                             | 7. <mark>Creating a Web Service</mark> |
| 3. Authentication                       | 8. Consuming a Web Service             |
| 4. Authorization                        | 9. Docker containers                   |
| 5. Async/Await & Complex Domain Model   | 10. Term project                       |

## 

## Contents

[TOC]

## Announcements

- Review due dates on Moodle
- Term Project



## Web APIs


An ASP.NET Core Web API (aka web service) can be used in several ways: 	

1. As a way to add AJAX to Razor views to make them more efficient.
    The reservation web app in Ch. 20 of Freeman (2017) is an example of this.

2. As a way to create a web service

   - Think of a web service as a web site that doesn't have a UI, it is meant to be accessed by a computer not a human. 
- You can also think of it as an API that contains methods that can be called over a network or over the Internet. 		
  

There are two main scenarios in which web services are used: 		

1. To facilitate a [Service Oriented Architecture](https://en.wikipedia.org/wiki/Service-oriented_architecture) in which different components of a system communicate over a network.
   2. To provide a service that can be used by third parties or subscribers.

- Advantages of using web services: 		
  - Allows computing services to be distributed across: 			
    - Multiple machines
    - Any distance
  - Provides a service that is: 			
    - OS independent
    - Language independent
- Types of Web Services 		
  - SOAP - Simple Object Access Protocol 			
    
    - An older protocol that is more difficult to implement and consume.
    
  - REST - Representational State Transfer 			
    
    - A newer type of web service that is easier to implement and consume. It is being used for most new web service implementations.
    
------

​    

## REST Architecture

REST is not really a new protocol&mdash;it is just HTTP.

Examples from [OpenWeather](https://openweathermap.org):

-  [List of OpenWeather REST APIs](https://openweathermap.org/api)
  
- [Documentation for the current weather API](https://openweathermap.org/current)
  
- Rest Query for the current weather:
  [api.openweathermap.org/data/2.5/weather?q=London](http://samples.openweathermap.org/data/2.5/weather?q=London,uk&appid=b6907d289e10d714a6e88b30761fae22)

###   HTTP Messages


- Each message is independent - RESTful services are stateless.
- Messages from the client are [HTTP Requests](https://en.wikipedia.org/wiki/Hypertext_Transfer_Protocol#Request_message). 
- Messages from the service are [HTTP Responses](https://en.wikipedia.org/wiki/Hypertext_Transfer_Protocol#Response_message).

#### HTTP requests
Requests have these parts:

  1. Start line&mdash;this includes the URL and things that are appended to it.

     - An [HTTP Method](https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods) (a verb)
       Common methods are: GET, POST, PUT, PATCH, DELETE.

     - Request target&mdash;normally a URL.

     - HTTP version.

     - Example: 

       ```http
       POST /api/Book HTTP/1.1
       Host: localhost:5000
       ```

  2. Header&mdash;this is optional and provides information about the request; such as the source of the request, the format of the body, etc. The information included depends on the type and content of the request. For requests that have a body, you can specify its format here.

     - Example: 

       ```http
       Content-Type:application/json
       ```

  3. Body&mdash;Not all requests have a body, but request methods that send data to be stored (POST, PUT, etc.) will have a body.

     - Example:

       ```json
       {
           "title": "Huckleberry Finn",
           "date": "4/3/1875",
           "name": "Mark Twain",
           "birthday": "11/30/1835"
       }
       ```


### REST Resource Representation

-  Resources - a REST service provides access to resources, which can be any kind of digital object: image, video, text, etc.

-  There is no restriction on the way resources can be represented, but the two most common means are:

   - JSON - JavaScript Object NotationExample:
     [Weather forecast for San Francisco](San_Francisco.json)
   - XML - eXtensible Markup Language
     Example:
     [Weather forecast for San Francisco](San_Francisco.xml)

------



## Consuming a REST Service

### Web Service Clients

- Can be written in any programming language

- Can run on any OS

- Normally integrated into other software (many apps include code that calls a web service)

- Can run on any type of platform - server, browser, mobile app, etc. 

- Server-side client code can be written in any language that runs on the server, but
  - Browser client code has traditionally been written in JavaScript and may use a framework like jQuery or React.
  - In the past, browser extensions allowed client code in other languages; like Silverlight which was programmed in C#.
  - With the advent of [WebAssembly](https://webassembly.org/) (Wasm), client code can be written in any language that can be compile to Wasm; like C# and the client-side [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) framework.

### Web Service Testing

- [SoapUI ](https://www.soapui.org) - for testing both SOAP and REST
  
- [Postman](https://www.getpostman.com) - primarily for REST, but can also be used for SOAP
- [curl](http://manpages.ubuntu.com/manpages/trusty/en/man1/curl.1.html) - Linux command to transfer a URL. Can be to test both SOAP and REST 

------

## References

- Freeman, Adam. 2017. Ch. 20, "Web API," in *Pro ASP.NET Core MVC 2.* 
- [RESTful Web Services: A Tutorial - Dr. Dobb's](http://www.drdobbs.com/web-development/restful-web-services-a-tutorial/240169069)
- [Weather Underground Web API](https://www.wunderground.com/weather/api/d/docs)

------

​	[ 	![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png) 	](http://creativecommons.org/licenses/by-sa/4.0/)
ASP.NETCore MVC Lecture Notes by [Brian Bird](https://profbird.dev) are licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/).

------