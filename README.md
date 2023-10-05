# Library Automation - ASP.NET Core Backend Solution

ASP.NET Core Web API solution built on “Clean Architecture”  consisting of Application, Domain, Persistence and WebApi subprojects in order to simulate online library system.

Entity Framework (EF Core) was used to relate the data in the local MSSQL database and objects in the .NET solution. In this way, Database context was accessed through objects, without writing SQL commands for each information access request.

"Dependency Injection" approach has been applied in order to reduce the dependency between classes within the project.

JWT (RFC 7519) standard is used to verify user identity and authorization.
