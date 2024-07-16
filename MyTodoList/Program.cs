using Autofac;
using Autofac.Extensions.DependencyInjection;
using MyTodoList.App.ErrorHandling;
using Newtonsoft.Json.Serialization;
using Todo.Data.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Register the exception handler middleware to the application.
/*builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
 builder.Services.AddProblemDetails();*/

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
    });

//ADD DBCONTEXT
builder.Services.AddSingleton<DapperContext>();

#region AutoFac
// Configure Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    // Register all repository classes from the referenced assembly
    containerBuilder.RegisterModule(new InfrastructureAutofac());
});
#endregion

//ADD Interface to Class @@-- dont use anymore --@@
/*builder.Services.AddTransient<ITodo_Repository, Todo_Repository>();*/

// Add Kendo UI 
builder.Services.AddKendo();

var app = builder.Build();

#region Middleware
// Default Global Exception Handling Middleware in .NET
/*app.UseExceptionHandler(builder =>
{

});*/

//Custom Exceptions

// Custom Global Middleware handler error
/*app.UseMiddleware<ErrorHandlerMiddleware>();*/
#endregion

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();