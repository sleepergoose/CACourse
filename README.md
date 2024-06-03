# CACourse

> **Outside layers can reference inside layers but inside layers cannot reference outside layers.**


## Domain 
The Core of the project. Defines entities, business rules, aggregates, Value objects, domain events. <br/>
Then we can define Repositories interfaces, Factory Interf, Domain Services and Custom Exceptions.<br/>
The only rule that can't be broken in the Domain layer: __Domain cannot reference any outter layers.__ <br/>
Outter layers may reference the Domain layer, but not vice versa.<br/>


## Application 
Orchestrate the domain layer and tells how to perform the business logic, use cases. <br/>
Typically this layer is implemented as a set of application services. <br/>
If we are using CQRS patter that in the Application layer we will see sets of Commands and Queries. <br/>
Should not reference any other layers except the Domain layer.


## Presentation - Infrastructure
They are allowed to reference the Application and Domain layers but they are not allowed reference each other

### 3.1 Infrastructure 
Anything that is related to the external systems is here. <br/>
Here we define things like DB access, message queues, email, notification services, storage services, etc. <br/>
This layer is responsible for hidding the implementation details for any external service we need to integrate with. 	<br/>

### 3.2 Presentation
Is used to define the entry points for outter user to be able to interract with our system. <br/>
Typically this implemented as a REST API.<br/>


## WebApi

It references all the previous layers


## Some notes

1. __Commands__ - can only alter state and do not return any values then 
```
SomeCoolCommand : IRequest
```

2. __Queries__ - don't change state but can only read and return data
```
SomeCoolQuery : IRequest<DataModel>
```

3. __Common practice__ is to give the entity properties private setter. 
Because in DDD we don't want to allow modifying properties of the specific entity outside that entity.
Because of this we need to specify entity's contructor that accepts all the necessary parameters.

4. In DDD two entities are considered equal if they have the same identifier even though the object reference might be different

