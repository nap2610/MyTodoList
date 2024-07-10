using Newtonsoft.Json.Serialization;
using Todo.Data.TodoList;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
        .AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ContractResolver = new DefaultContractResolver();
        });

//ADD DBCONTEXT
builder.Services.AddSingleton<DapperContext>();

//ADD Interface to Class
builder.Services.AddTransient<ITodo_Repository, Todo_Repository>();

// Add Kendo UI 
builder.Services.AddKendo();

var app = builder.Build();

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
