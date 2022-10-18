---
title: AJAX
description: How to use AJAX with ASP.NET MVC
keywords: AJAX
material: Lecture Notes
generator: Typora
author: Brian Bird

---

<h1>AJAX</h1>

**CS296N Web Development 2**

<h2>Contents</h2>

[TOC]

### Using XMLHttpRequest

```JavaScript
 const URL = "http://localhost:5000/api/product";

      function get() { 
		let req = new XMLHttpRequest();
		req.onreadystatechange = function () {
		  if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
			console.log(this.response);
			displayMessage("Products Retrieved");
		  }
		};
		req.open("GET", URL);
		req.send();
      }
```

## Example Code

- For 2021 CODE Magazine article

## References

- Paul D. Sheriff, [Using Ajax and REST APIs in.NET 5](https://www.codemag.com/Article/2103031/Using-Ajax-and-REST-APIs-in.NET-5#:~:text=Using%20Ajax%20and%20REST%20APIs%20in.NET%205%20Asynchronous,send%20and%20receive%20data%20from%20a%20Web%20server.), 2021, CODE Magazine.


------

[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png)](http://creativecommons.org/licenses/by-sa/4.0/) 
​ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.dev), <time>2022</time>, are licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 

------