**[CS296N Web Development 2: ASP.NET](http://lcc-cit.github.io/CS296N-CourseMaterials/)**

#   Troubleshooting a Web App on Linux

| Weekly topics                                           |                                  |
| ------------------------------------------------------- | -------------------------------- |
| <mark>1. Intro to course and Publishing to Linux</mark> | 6.  Load Testing and Performance |
| 2. Identity                                             | 7.  A More Complex Domain Model  |
| 3. Authentication                                       | 8. Validation                    |
| 4. Authorization                                        | 9. Docker containers             |
| 5. Async/Await                                          | 10. Term project                 |

## Contents

## Forwarding requests to Kestral from Apache

### For a single web site

Apache Configuration files are in the /etc/httpd/conf.d/ directory. Any files with the .conf extension are processed in alphabetical order in addition to the module configuration files in the /etc/httpd/conf.modules.d/ directory.

1. Create a configuration file for your app.

   Note that the example conf file below could be improved by using variables for the request type and log file names, and by specifying a domain.

   myapp.conf:

   ```
   <VirtualHost *:*>
     RequestHeader set X-Forwarded-Proto "http"
   </VirtualHost>
   
   <VirtualHost *:80>
     ProxyPreserveHost On
     ProxyPass / http://127.0.0.1:5000/
     ProxyPassReverse / http://127.0.0.1:5000/
     ErrorLog /var/log/apache2/myapp-error.log
     CustomLog /var/log/apache2/myapp-access.log common
   </VirtualHost>
                       
   ```

   - **ProxyPreserveHost** - Instructs Apache mod_proxy, when acting as a reverse proxy, to preserve the original host header from the client browser when constructing the proxied request to send to the backend server.
   - **ProxyPass** - Specifies the mapping of incoming requests to a backend server.
   - **ProxyPassReverse** - Ensures that Location headers generated from the backend are modified to point to the reverse proxy, instead of back to itself.

2. Restart Apache:

   ```bash
   sudo systemctl restart httpd
   sudo systemctl enable httpd
   ```

## Notes:

### Find the Apache Web Roots

On CentOs:

```bash
# grep -i 'DocumentRoot' /etc/httpd/conf/httpd.conf
```

## References

- Staff. 2019. [Reverse Proxy Guide](https://httpd.apache.org/docs/2.4/howto/reverse_proxy.html). Apache HTTP Server Project.

- osterik. 2017. [Apache as reverse proxy for multiple destinations and one default destination](https://superuser.com/questions/739736/apache-as-reverse-proxy-for-multiple-destinations-and-one-default-destination). Superuser

- H., Chris. 2018. [Conditional reverse proxy in apache](https://stackoverflow.com/questions/50361316/conditional-reverse-proxy-in-apache). Stack Overflow.

- Contributors. 2018. [.NET Core Application Deployment](https://docs.microsoft.com/en-us/dotnet/core/deploying/#framework-dependent-deployments-fdd). Microsoft.

- Dykstra, Halter, Smith, and Ross. 2019. [Web Server Implementations in .NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/?view=aspnetcore-2.1&tabs=aspnetcore2x). Microsoft.

- Fritz, Jeffery T. 2017. [Build and Deploy Your ASP.NET Core Application with Apache](https://www.telerik.com/blogs/build-deploy-asp-net-core-application-apache). Telerik.

  

------

[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png)](http://creativecommons.org/licenses/by-sa/4.0/) 
​ASP.NET Core MVC Lecture Notes by [Brian Bird](https://profbird.online), 2019, is licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/). 

------