
# Microservice Architecture in ASP.NET 6



This is an e-commerce project with microservice architecture implementation and variety of technologies.

Each service uses its own sub-architecture and database.

It encorporates many desgin patterns, architectures and technologies to ensure quality.


![img](https://user-images.githubusercontent.com/45321513/192594683-70e5ea72-5fc3-46ab-bc66-2e7cbb51caad.jpeg)

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
- Redis database connection and containerization
- Publish BasketCheckout Queue using MassTransit and RabbitMQ
- Repository Pattern Implementation
- Swagger Open API implementation

### User microservice :
- Implementing DDD, CQRS, and Clean Architecture
- Developing CQRS using MediatR, FluentValidation and AutoMapper
- Using Fluent Migrator for migrating entities
- PostgreSQL database connection and containerization
- Using Dapper for micro-orm implementation to simplify data access and ensure high performance
- Swagger Open API implementation

### Ordering Microservice :
- Implementing DDD, CQRS, and Clean Architecture
- Developing CQRS using MediatR, FluentValidation and AutoMapper
- Consuming RabbitMQ BasketCheckout event queue using MassTransit and RabbitMQ 
- SqlServer database connection and containerization
- Using Entity Framework Core ORM and auto migrate to SqlServer on application startup
- Swagger Open API implementation

### API Gateway Ocelot Microservice :
- Implementing API Gateways with Ocelot
- Using data cashing 
- Restricting requests
- Using load balancing

Implementing Centralized Distributed Logging with Elastic Stack (ELK); Elasticsearch, Logstash, Kibana and SeriLog for Microservices
