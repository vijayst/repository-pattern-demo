# repository-pattern-demo
Usage of Repository pattern in .NET.

From Martin Fowler enterprise patterns:
* Unit of Work pattern - http://martinfowler.com/eaaCatalog/unitOfWork.html
* Repository pattern - http://martinfowler.com/eaaCatalog/repository.html

In .NET, Entity Framework implements both UoW and Repository pattern. DbContext bundles all updates in a single transactions and is committed with SaveChanges(). DbSet provides a queryable interface to compose complex queries.

Repositories can be implemented on top of Entity Framework DbContext, DbSet as reusable convenience wrappers. Entities exposed by Entity Framework are not useful for serialization because of lazy loading. This is especially painful when the entities have to be used as Models in presentation framework or stored in caching framework.

Domain Driven Design is useful for implementing repositories from multiple data stores. In Domain driven design, business entities are different from persistence entities defined in Entity Framework. Multiple persistence stores exist and business entities are used for querying and updating repositories.

This is an example of repository pattern in domain driven design. It uses a single data store accessed by Entity Framework. The demo is more of a starting point to discuss the complex trade-offs involved in the repository pattern used in domain driven design.

