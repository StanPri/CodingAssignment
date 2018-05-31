# Code Assignment Solution  



## Getting Started

### Installing

Download the solution and open it in Visual Studio. 

Once the application is started, it should open http://localhost:60023/ in browser.

## Project features

Here are the highlights of the application

### Displays 'Hello World' to the screen

A simple page is displayed in the browser to output the message and demonstrate CRUD operations.

### API that is separated from the program logic

The client (mobile app, browser, etc.) can be created to consume the API. Postman or curl can be used as the client to test the app.

### Existance of future enhancements:
a. Common design patterns to account for the future concerns. 

```csharp
//Dependency Injection
namespace CodingAssessment
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<OutputMessageContext>(opt =>
                opt.UseInMemoryDatabase("OutMessage"));
            services.AddMvc();
        }
        
        //...
```

```c
//Inheritance
namespace CodingAssessment.Models
{
    public class OutputMessageContext : DbContext
    {
        public OutputMessageContext(DbContextOptions<OutputMessageContext> options) : base(options)
        {
		//...
```

b. Use configuration files or another industry standard mechanism for determining where to write the information to.

```csharp
//In-memory database is injected into the service container and can be replaced by another DB
services.AddDbContext<TodoContext>(opt => 
                opt.UseInMemoryDatabase("TodoList"));
```
### Support of CRUD operations
In order to demonstrate the database functionality, the user can use displayed browser page.
Also, Postman can be used to hit API's endpoints:
| API        | Description           | 
| ------------- |:-------------| 
| GET /api/outputmessage     | Get all to-do items | 
| GET /api/outputmessage/{id}     | Get an item by ID      |  
| POST /api/outputmessage | Add a new item      |
| PUT /api/outputmessage/{id}      | Update an existing item | 
| DELETE /api/outputmessage/{id}       | Delete an item      | 

### Unit tests to support the API


## Authors

* **Stanislav Pribytkovsky** project.