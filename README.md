# Repository pattern demo
Usage of Repository pattern in .NET.

From Martin Fowler enterprise patterns:
* Unit of Work pattern - http://martinfowler.com/eaaCatalog/unitOfWork.html
* Repository pattern - http://martinfowler.com/eaaCatalog/repository.html

## Entity framework

In .NET, Entity Framework implements both Unit of Work and Repository pattern. DbContext bundles all updates in a single transaction with SaveChanges() method. This implements the Unit of Work pattern. DbSet provides a queryable interface to compose complex queries. DbSet holds a collection of objects which can be added, modified, deleted. DbSet implements the Repository pattern.

Repository classes can be implemented on top of Entity Framework DbContext, DbSet as reusable convenience wrappers. 

## Domain Driven Design

There is a problem with using entities from Entity framework outside the persistence layer. Entities are not useful for serialization because of lazy loading. This is especially painful when the entities have to be used as Models in presentation framework or stored in distributed cache (like memcached or redis).

Domain Driven Design is useful for implementing repositories from multiple data stores. In Domain driven design, business entities are different from persistence entities defined in Entity Framework. Multiple persistence stores exist and business entities are used for querying and updating repositories.

Using domain driven design and repository pattern together is much more complex. Dependency injection, Unit testing via Mocking, Mapping between persistence entities and business entities add to the complexity.

## Reference implementation

The reference implementation is an example of repository pattern in domain driven design. It uses a single data store accessed by Entity Framework. The demo is more of a starting point to discuss the complex trade-offs involved in the repository pattern used in domain driven design. Some of the design patterns used in this are:

* Dependency injection via Structure map.
* Mocks using Moq.
* Composition over inheritance.
* Reusable DbRepository for CRUD operations.
* Mapper for converting between persistence entities and business entities.

Some of the pain-points involved in the design are:
* Mapping code is elaborate. 
* Performance may not be optimal with the use of Generic DbRepository.
* Id of an inserted entity is not readily available.
