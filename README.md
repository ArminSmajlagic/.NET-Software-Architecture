<p align="center">
	<img src="https://badgen.net/badge/.NET/6/cyan">
	<img src="https://badgen.net/badge/icon/Docker?icon=docker&label">
</p>

# Microservice Architecture in ASP.NET 6

This is an eCommerce project with Microservice Architecture that demonstrates usage of design patterns & many technologies.

Each service uses different sub-architecture and database to demonstrate true microservices and their potential. 
I have mainly used clean and layerd as sub-architecutres for each of the service. 
To achive fast respons from database I used NoSQL such as MongoDB and Redis (as DB), and for more solid and scalable databases I used MS SQL & PostgreSQL.

Project demonstrates use of DDD, Repository/CQRS with Mediator pattern in persistance and buissenes layers to access database layer and persist data. 

Finally to agregate all the services and allow users to access them uniformly I used Ocelot gateway together with many features that it provides (Caching, Req. Limiting, Load Balancing, Security, ...)

## Overall view of the system

![img](https://user-images.githubusercontent.com/45321513/192594683-70e5ea72-5fc3-46ab-bc66-2e7cbb51caad.jpeg)

## Logical view of the system

![image](https://user-images.githubusercontent.com/45321513/211333548-c90bb464-2803-4a63-b735-fa296f3ba5f8.png)

## Project is consisted of the following

1️⃣ Catalog Service:
- ✅Implemented an N-tier sub-architecture, ensuring a well-organized codebase.
- ✅ Leveraged REST API principles for seamless communication and CRUD operations.
- ✅ Utilized MongoDB as the database, providing high scalability.
- ✅ Employed the Repository Pattern for efficient data access.
- ✅ Enabled easy API testing and documentation with Swagger Open API standard.
- ✅ Dockerized both API and Database for streamlined deployment.

2️⃣ Basket Service:
- ✅ Followed similar N-tier sub-architecture approach for maintainability.
- ✅ Built REST API adhering to industry-standard principles.
- ✅ Implemented MassTransit & RabbitMQ for reliable messaging.
- ✅ Redis served as the database, delivering lightning-fast performance.
- ✅ Repository Pattern utilized for efficient data management.
- ✅ Ensured easy collaboration and API documentation with Swagger Open API.
- ✅ Dockerized both API and Database for hassle-free deployments.

3️⃣ User Service:
- ✅ Implemented a clean architecture with Domain-Driven Design (DDD) principles.
- ✅ Utilized Fluent migrator & Dapper for smooth database migration and access.
- ✅ PostgreSQL acted as the reliable and robust database.
- ✅ Followed the CQRS pattern with MediatR & FluentValidation for improved separation of concerns.
- ✅ Swagger Open API provided easy testing and documentation capabilities.
- ✅ Leverage the power of AutoMapper for seamless mapping between objects.

4️⃣ Ordering Service:
- ✅ Adopted a clean and scalable architecture based on Domain-Driven Design (DDD).
- ✅ Employed MassTransit & RabbitMQ for reliable messaging between services.
- ✅ MS SQL served as the reliable and robust database.
- ✅ Entity Framework Core ORM helped manage migrations and ensured smooth database creation.
- ✅ Implemented CQRS pattern with MediatR & FluentValidation for flexible and maintainable code.
- ✅ Swagger Open API facilitated easy testing and documentation.

To tie it all together, an API Gateway, powered by Ocelot Microservice, was integrated to provide:
- ✅ Seamless API Gateway implementation, ensuring efficient communication between services.
- ✅ Caching of API resources for improved performance.
- ✅ Requests throttling, preventing system overload.
- ✅ Load balancing for distributing traffic effectively.


- Centralized Distributed Logging with Elastic Stack (ELK); Elasticsearch, Logstash, Kibana and SeriLog for Microservices

<p>
 To run all required containers with Docker compose orchestration : 
	
	docker-compose up
</p>

Software and ilustrations were create by me.
Author : Armin Smajlagić
