# Designing a Domain Model

**CS296N ASP.NET Core MVC**

[TOC]

## Review: Designing Domain Models for ASP.NET Core MVC

### What is a domain model?

- What is the meaning of "[domain](https://www.wolframalpha.com/input/?i=domain)" in general, in math?
- What is meant by the problem "domain" in software development?
- When we design a set of classes to model a problem's domain, how do we identify those classes?
  - What will nouns become?
  - What will verbs become?
  - Do we represent all the nouns and verbs in our domain model?
- What kind of UML diagram do we draw when we create our domain model?

### What are the three primary OOP relationships?

- What are the names and meanings of these relationships?

- How do we represent them in UML?
- What is cardinality?
- How do we implement them in C#?

### What constraints are imposed by Entity Framework?

- Which OOP relationships are allowed and/or useful?
- Are there work-arounds for relationships that aren't allowed?
- What is a circular relationship? Are those OK?
- Do all domain model classes need to be related? If not, how do we decide?
- How will users be modeled if we are using Identity?



## Exercise: Tip of the Day Domain Model





## Answers

### Three primary OOP relationships

- Aggregation (aka association)
  The "has-a" relationship.
- Composition
  The "is-a-part-of" relationship.
- Inheritance
  The "is-a" relationship.

### Work-around for implementing many-to-many relationships

Use an [*association class*](https://www.ibm.com/support/knowledgecenter/SSCLKU_7.5.5/com.ibm.xtools.modeler.doc/topics/cassnclss.html). This will be translated to a *junction table* in the database.

------

 [![Creative Commons License](https://i.creativecommons.org/l/by/4.0/88x31.png)](http://creativecommons.org/licenses/by/4.0/)System Design  Lecture Notes by [Brian Bird](https://profbird.online), 2018 (Revised 2020), are licensed under a [Creative Commons Attribution 4.0 International License](http://creativecommons.org/licenses/by/4.0/). 

------