# Suggestions for Next Year's Class (2023)

[TOC]

## Ideas for web dev lab projects

- Ride share service (like uber)

- Psychology web site with personality survey? (maybe better for a demo)
  - Eliza type "psychoanalysis"

- Video and/or music streaming site

- Travel site (book busses and flights)

- Messaging site with channels that can be subscribed to (like Telegram)
- Chatbot site (with fake chatbot, not real AI) for some topic (programming, travel, gaming, food, etc.)
- Dating site?
- 



## Things to include in the current projects (projects similar to book reviews)

- Auto recommendation of books
- Auto scanning of reviews and comments for inappropriate language
  - Include a policy statement on acceptable use
- Moderator role for approving posts (?), deleting posts, banning users from posting
- Upload of book cover photos
- Upload and download of public domain books
- E-mail notifications (other kinds of notifications too?)
- Chat-bot type help or discussion
- Static files in wwwroot for non-dynamic content?
- Genres on books
- Paging long lists (like lists of books or authors)



## Cross-Cutting Topics

- HTTP
  - HTTP protocol (request/response, types of requests, queries, headers, etc.)
  - Ports
  - Statelessness
  - Cookies
  - Sessions and session object (based on cookies)
  - HTTPS and everything related (SSL certificates, TLS, etc.)
- Security
  - Cross-site scripting
  - Authentication with cookies, other types of authentication
- UX and UI Design
- C# Features
  - Lambdas
  - Linq
  - Async/Await
- Performance
  - Do load testing early so we can check performance often
- Unit testing and TDD
- **Ethics**
- Debugging and troubleshooting
- OOAnD and UML



## Week X - Security

Look at this article for more on security in ASP.NET: https://cheatsheetseries.owasp.org/cheatsheets/DotNet_Security_Cheat_Sheet.html

## Lab 9 - Docker

Ask for some kind of verification that the container is in the registry and that the app is running in a container (screen-shot of the app service setup?)

## Term Project

- Don't allow projects that are too similar to the example: review sites, or sites with the same domain model structure.
- Add requirement for updated UML diagram of domain model.
  - Require at least 3 of the 4 classes to be related to each other and at least one one-to-many or many-to-many relationship.
- Number of pages doesn't count unmodified scaffolded pages. (modification means at least a 25% change.)
- Add a requirement and grading criteria for UX (more than just navigation).
- Add a requirement for validation
- Make clear criteria for what should be tested by unit tests and min number of tests, 3?
- Make clear criteria for what can be copied from Stack Overflow--etc.
- Remove advice about using Winhost, add permission to use SQLite or MySQL on Azure.
- Require seed data and a seed admin user.
- Require repositories?
- More detailed requirements for load testing and reporting.



