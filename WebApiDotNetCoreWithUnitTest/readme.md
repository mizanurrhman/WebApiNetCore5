# Asp.Net Core Web API 

> Some of the topics that covers are:

- Introduction to Web API
- Building your first Asp.Net Core (.NET 5) API
- Working with relational data
- Controller Action return types
- Error & Exception handling
- Sorting, Filtering, and Paging
- Web API Versioning
- Unit Testing
- Logging information
- Deploying your app and database to Azure

> Install Entity framework core 
- `install-package Microsoft.EntityFrameworkCore`
- add AppDbContext inside data  class `public class AppDbContext: DbContext`
> add connection String in `appsetting.json`
-- ```json 
    "ConnectionStrings": {
           "DefaultConnectionString": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WebApiDotNetCorewithUTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
     }```

> set ConnectionString in `Startup.cs` 
```cs
        public string ConnectionString { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DefaultConnectionString");
        }
```
> Configure database context with sql database install 
- `install-package Microsoft.EntityFrameworkCore.SqlServer`
```cs
    services.AddControllers();
    services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionString));
```
> Adding first ef core migration 
 Install Entity Framework core Tools : `install-package Microsoft.EntityFrameworkCore.Tools` 
 `add-migration initialMigration` `update-database`
 Create a class `AppDBInitializer` to seed data and seed it in `startup.cs` after endpoint `AppDBInitializer.Seed(app);`

 # Adding Controller 
  
 add a controller , then add a service where inject appdbcontext add BookVM  then in book service create a Methode AddBook then call it from controller 
 now here applied `post get  put & Delete `

> `Entity Data Model`  `Entity FrameWork Core`  `Added First Controller and Service` 
`HttpPost - Add New data`  `HttpGet - Get Data`  `HttpPut -Update Data` `HttpDelete - Delete Data` 


 

 > Versioning 
 add NPM `Microsoft.AspNetCore.Mvc.Versioning` add service `services.AddApiVersioning();` in `startup.cs`
 
 `[ApiVersion("1.0")]`
 `https://localhost:44353/api/test/get-test-data?api-version=1.0`
 
 > Default API versioning in `startup.cs`
 ```cs
 services.AddApiVersioning(config => {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
            });
 ```
 > URL Based versioning 
 
 - add  `[Route("api/v{version:apiVersion}/[controller]")]` 
 - url : `https://localhost:44353/api/v1/test/get-test-data`
 - OutPut: `This is TestController V1`









