using Autofac.Extensions.DependencyInjection;
using Autofac;
using Newtonsoft.Json.Serialization;
using Todo.Data.Infrastructure;
using OfficeOpenXml;

var builder = WebApplication.CreateBuilder(args);

// Set license for EPPLUS
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
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
