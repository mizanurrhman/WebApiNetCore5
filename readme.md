# DotNet Core Web API 


> Manage Nuget packages
* Create a Asp dotnet core web api project 
* add  `Serilog.AspNetCore`
		`Microsoft.AspNetCore.Authentication.JWTBearer` & 
		`Microsoft.AspNetCore.Authentication.OpenIdConnect`  By Microsoft
        `Microsoft.EntityframeworkCore`
        `Microsoft.EntityframeworkCore.SqlServer`
        `Microsoft.EntityframeworkCore.Tools`
* add `UseSerilog()` Serilog to `Program.cs`
> Creating logger
> CORS Configuration
```cs
services.AddCors(o =>
            {
                o.AddPolicy("CorsPolicyAllowAll", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                );
            });
```
         
use it to config  `   app.UseCors("CorsPolicyAllowAll");`

 ## DataBase Modeling 
 * Add DatabaseContext 
 ```cs
  public class DatabaseContext: DbContext
    {
       public DatabaseContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
    }
 ```
 > Add connectionString to `appsettings.json`
 ```json
 "ConnectionStrings": {
    "sqlConnection": "server=(localdb)\\mssqllocaldb; database=WebAPIdotNetCore5_db; integrated security=true"
  },
 ```
at configureservice In Startup.cs add  
```cs
services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("sqlConnection"))
            );
```
## Seed data Tables


> Add Auto Mapper 
* `AutoMapper.Extensions.Microsoft.DependencyInjection`   
* add a folder named `configuration` to configure auto mapper and create class `MapperInitiazier` 
* add `services.AddAutoMapper(typeof(MapperInitilizer));` at `StartUp.cs`

# Constructing  Controller

> create a empty api controller then configure it to endpoints `startup.cs`
```cs
endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
```
> Add startup class `services.AddTransient<IUnitOfWork, UnitOfWork>();`
> add NuGet Solution  `Microsoft.AspNetCore.Mvc.NewtonsoftJson` then modify in startup.cs
 ```cs
            //services.AddControllers()
            services.AddControllers().AddNewtonsoftJson(op =>
            op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
```
# Make Secure the App using JWT

Install Package `Microsoft.AspNetCore.Identity.EntityFrameworkCore`
Change inherited from `DbContext` to `IdentityDbContext<ApiUser>` `ApiUser` is a user class  add `base.OnModelCreating(builder);` at `OnModelCreating` methode 

In `StartUp` file add `services.AddAuthentication(); services.ConfigureIdentity();` 
those are stand in another `ServiceExtensions` class then 
`add-migration addedIdentity` `update-database`

Create `AccountController` apply here Register & Signin with userDTo
Create `RoleConfiguration` entities


