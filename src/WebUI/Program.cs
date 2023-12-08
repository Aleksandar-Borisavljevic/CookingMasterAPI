using CookingMasterApi.Infrastructure.Persistence;
using Serilog;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebUIServices();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.WebHost.UseStaticWebAssets();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Initialise and seed database
using (var scope = app.Services.CreateScope())
{
    var initialiser = scope.ServiceProvider.GetRequiredService<CookingMasterDbContextInitialiser>();
    await initialiser.InitialiseAsync();
    await initialiser.SeedAsync();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapRazorPages();

//app.Use((context, next) =>
//{
//    context.Request.Host = new HostString("localhost:5001");
//    return next(context);
//});

app.Run();