
# Microservice Architecture in ASP.NET 6

This is an eCommerce project with Microservice Architecture implementation with aid from design patterns & many technologies.

Each service uses its own sub-architecture and database. 
I have selected clean and layerd as sub-architecutres. 
To achive fast respons from database I used NoSQL such as MongoDB and Redis, and where I needed strong solid base between entities I used MS SQL & PostgreSQL.

It uses DDD, Repository/CQRS with Mediator pattern in persistance and buissenes layer to access database layer and persist data. 

Finaly to agregate all the services and allow users to access them uniformly i used Ocelot gateway together with many features that it provides (Caching, Req. Limiting, Balancing, Security, ...)

## Overall view of the system

![img](https://user-images.githubusercontent.com/45321513/192594683-70e5ea72-5fc3-46ab-bc66-2e7cbb51caad.jpeg)

## Logical view of the system

![image](https://user-images.githubusercontent.com/45321513/211333548-c90bb464-2803-4a63-b735-fa296f3ba5f8.png)

## Project is consisted of the following

### Catalog microservice :
- N-tier sub-architecture
- REST API principles, CRUD operations
- MongoDB database connection and containerization
- Repository Pattern Implementation
- Swagger Open API implementation

### Basket microservice :
- N-tier sub-architecture
- REST API principles, CRUD operations
- Publish BasketCheckout Queue using MassTransit and RabbitMQ
- Redis database connection and containerization
- Repository Pattern Implementation
- Swagger Open API implementation

### User microservice :
- Implementing DDD, CQRS, and Clean Architecture
- Using Fluent Migrator for migrating entities
- PostgreSQL database connection and containerization
- Using Dapper for micro-orm implementation to simplify data access and ensure high performance
- Developing CQRS using MediatR, FluentValidation and AutoMapper
- Swagger Open API implementation

### Ordering Microservice :
- Implementing DDD, CQRS, and Clean Architecture
- Consuming RabbitMQ BasketCheckout event queue using MassTransit and RabbitMQ 
- SqlServer database connection and containerization
- Using Entity Framework Core ORM and auto migrate to SqlServer on application startup
- Developing CQRS using MediatR, FluentValidation and AutoMapper
- Swagger Open API implementation

### API Gateway Ocelot Microservice :
- Implementing API Gateways with Ocelot
- Using data cashing 
- Restricting requests
- Using load balancing

Implementing Centralized Distributed Logging with Elastic Stack (ELK); Elasticsearch, Logstash, Kibana and SeriLog for Microservices

Author: Armin Smajlagić
