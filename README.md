# Parcel.Handling.WebApi

## Objective
This application was developed with the aim of automating the distribution of packages that are received daily for their respective department.

## Technologies

- [Visual Studio 2019](https://visualstudio.microsoft.com/pt-br/downloads/)
- [.NET Core 3.1.0](https://dotnet.microsoft.com/download/dotnet-core/3.1)
- [Microsoft.EntityFrameworkCore 5.0.10](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/5.0.10)

#### How to run it
 - Download or clone this project locally 
 - Then in the console, within the current project folder, run the next two commands: `dotnet restore`, and then `dotnet run`
 - The ASP.NET Core WebAPI will run using IIS, URL: https://localhost:5001/index.html

## Project Structure

Initially, We use DDD as a software designer and using a SOLID concepts, so our solution will have 4 layers: Web Api,Application,Domain and Infra.

The web API layer will contain the controllers.
The Application layer contain the Dtos, Services and Interfaces.
The Domain layer will contain the data access and consume resources from the infrastructure layer
The Infra layer will be responsible for the repositories and database in memory using a Entity Framework.


## Project Endpoints
We have some endpoints in our solution. Below is a brief explanation of each:

* **Department**
*<br>Fist Execution
	*<br>.Post api/v1/department/first-departments:
	*<br>Must run before all other endpoints.Is fundamental to the execution of our application, because it performs the initial loading of departments in the database in memory for our application.("Mail","Regular","Heavy","Insurance")
		

*<br>Executions without order 
	*<br>.Get api/v1/department:
		*<br><br>this endpoint accesses our database in memory to search all departments in the base, always sorting by ID
	*<br>.Post api/v1/department:
		*<br><br>this endpoint inserts into our database a new department, great for companies that are expanding and creating new departments.
	*<br>.Delete api/v1/department:
		*<br><br>this endpoint delete into our database a department through id, so be careful when using!

* **Parcel**
	*<br>.Post api/v1/parcel/new-parcel:
		*<br><br>this is the endpoint responsible for reading the XML file with all received packets and distributing them among departments according to established business rule. 
	*<br>.Post api/v1/parcel:
		*<br><br>this is the endpoint responsible for accesses our database to search all parcels with their respective departments, always sorting by ID
	*<br>.Post api/v1/parcel/{id}:
		*<br><br>this is the endpoint responsible for accesses our database to search the especific parcel with their respective department.