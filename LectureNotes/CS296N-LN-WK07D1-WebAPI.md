**[CS296N Web Development 2: ASP.NET](file:///data/brian/repos/CS296N-CourseMaterials/index.html)**

# Creating a REST Web API




| Topics by week                       |                                     |
| ------------------------------------ | ----------------------------------- |
| 1. Validation                        | 6. ~~Load Testing and Performance~~ |
| 2. Identity                          | **7. Creating a Web Service**       |
| 3. Authentication and Authorization  | 8. Consuming a Web Service          |
| 4. Web Security                      | 9. Docker Containers                |
| 5. Publishing to a Production Server | 10. Term Project                    |

## Contents

[TOC]

## Announcements

- Review due dates on Moodle
- Term Project



## Web Services


An ASP.NET Core Web API (aka web service) can be used in several ways: 	

1. As a way to add AJAX to Razor views to make them more efficient.
    		The reservation web app in Ch. 20 of Freeman (2017) is an example of this.

2. As a way to create a web service.

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

## REST Architecture

- Not really a new protocol - just uses HTTP
  Example: [Weather Underground REST API](https://www.wunderground.com/weather/api/d/docs)

  `http://api.wunderground.com/api/0e3e69302fba4e56/conditions/q/CA/San_Francisco.json` 		

  ### Representations

- Resources - a REST service provides access to resources, which can be any kind of digital object: image, video, text, etc.

- There is no restriction on the way resources can be represented, but the two most common means are:

  - JSON - JavaScript Object Notation
  Example:
    
    ```json
      {
            "response": {
              "version": "0.1",
                "termsofService": "http://www.wunderground.com/weather/api/d/terms.html",
                "features": {
                    "conditions": 1
                }
            },
            "current_observation": {
                "image": {
                    "url": "http://icons-ak.wxug.com/graphics/wu2/logo_130x80.png",
                    "title": "Weather Underground",
                    "link": "http://www.wunderground.com"
                },
                "display_location": {
                    "full": "San Francisco, CA",
                    "city": "San Francisco",
                    "state": "CA",
                    "state_name": "California",
                    "country": "US",
                    "country_iso3166": "US",
                    "zip": "94101",
                    "latitude": "37.77500916",
                    "longitude": "-122.41825867",
                    "elevation": "47.00000000"
                },
                "observation_location": {
                    "full": "SOMA - Near Van Ness, San Francisco, California",
                    "city": "SOMA - Near Van Ness, San Francisco",
                    "state": "California",
                    "country": "US",
                    "country_iso3166": "US",
                    "latitude": "37.773285",
                    "longitude": "-122.417725",
                    "elevation": "49 ft"
                },
                "estimated": {},
                "station_id": "KCASANFR58",
                "observation_time": "Last Updated on June 27, 5:27 PM PDT",
                "observation_time_rfc822": "Wed, 27 Jun 2012 17:27:13 -0700",
                "observation_epoch": "1340843233",
                "local_time_rfc822": "Wed, 27 Jun 2012 17:27:14 -0700",
                "local_epoch": "1340843234",
                "local_tz_short": "PDT",
                "local_tz_long": "America/Los_Angeles",
                "local_tz_offset": "-0700",
                "weather": "Partly Cloudy",
                "temperature_string": "66.3 F (19.1 C)",
                "temp_f": 66.3,
                "temp_c": 19.1,
                "relative_humidity": "65%",
                "wind_string": "From the NNW at 22.0 MPH Gusting to 28.0 MPH",
                "wind_dir": "NNW",
                "wind_degrees": 346,
                "wind_mph": 22.0,
                "wind_gust_mph": "28.0",
                "wind_kph": 35.4,
                "wind_gust_kph": "45.1",
                "pressure_mb": "1013",
                "pressure_in": "29.93",
                "pressure_trend": "+",
                "dewpoint_string": "54 F (12 C)",
                "dewpoint_f": 54,
                "dewpoint_c": 12,
                "heat_index_string": "NA",
                "heat_index_f": "NA",
                "heat_index_c": "NA",
                "windchill_string": "NA",
                "windchill_f": "NA",
                "windchill_c": "NA",
                "feelslike_string": "66.3 F (19.1 C)",
                "feelslike_f": "66.3",
                "feelslike_c": "19.1",
                "visibility_mi": "10.0",
                "visibility_km": "16.1",
                "solarradiation": "",
                "UV": "5",
                "precip_1hr_string": "0.00 in ( 0 mm)",
                "precip_1hr_in": "0.00",
                "precip_1hr_metric": " 0",
                "precip_today_string": "0.00 in (0 mm)",
                "precip_today_in": "0.00",
                "precip_today_metric": "0",
                "icon": "partlycloudy",
                "icon_url": "http://icons-ak.wxug.com/i/c/k/partlycloudy.gif",
                "forecast_url": "http://www.wunderground.com/US/CA/San_Francisco.html",
                "history_url": "http://www.wunderground.com/history/airport/KCASANFR58/2012/6/27/DailyHistory.html",
                "ob_url": "http://www.wunderground.com/cgi-bin/findweather/getForecast?query=37.773285,-122.417725"
            }
        }
    }
    ```
    
    

  - XML - eXtensible Markup Language
    Example:
    [Weather forecast for San Francisco](San_Francisco.xml)
### Messages


- Messages from the client are [HTTP Requests](https://en.wikipedia.org/wiki/Hypertext_Transfer_Protocol#Request_message)

  - Verbs can be: GET, PUT, POST, DELETE, OPTIONS, HEAD.

- A request should only affect one resource. (Each resource should have at least one URI.)
- Messages from the service are [HTTP Responses](https://en.wikipedia.org/wiki/Hypertext_Transfer_Protocol#Response_message)
- Each message is independent - RESTful services are stateless

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
ASP.NETCore MVC Lecture Notes by [Brian Bird](https://profbird.online) are licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/).

------