using Autofac.Extensions.DependencyInjection;
using Autofac;
using Newtonsoft.Json.Serialization;
using Todo.Data.Infrastructure;
using OfficeOpenXml;
using Autofac.Core;

var builder = WebApplication.CreateBuilder(args);

// Set license for EPPLUS
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
        //options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

builder.Services.AddSingleton<DapperContext>();

builder.Services.AddKendo();

#region AutoFac
// Configure Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    // Register all repository classes from the referenced assembly
    containerBuilder.RegisterModule(new InfrastructureAutofac());
});
#endregion

#region Session
    builder.Services.AddDistributedMemoryCache();

    builder.Services.AddSession(options =>
    {
        options.IdleTimeout = TimeSpan.FromSeconds(10);
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
    });

    // Add IHttpContextAccessor
    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
