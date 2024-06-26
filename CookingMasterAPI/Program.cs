using Microsoft.EntityFrameworkCore;
using FluentValidation;
using CookingMasterAPI.Data;
using CookingMasterAPI.Services;
using CookingMasterAPI.Services.ServiceInterfaces;
using CookingMasterAPI.Models.Request.AuthRequests;
using CookingMasterAPI.Models.RequestValidation.AuthValidation;
using CookingMasterAPI.Models.Request.IngredientCategoryRequests;
using CookingMasterAPI.Models.RequestValidation.IngredientCategoryValidation;
using CookingMasterAPI.Models.Request.IngredientRequests;
using CookingMasterAPI.Models.RequestValidation.IngredientValidation;
using CookingMasterAPI.Models.RequestValidation.IngredientNutrientValidation;
using CookingMasterAPI.Models.Request.IngredientNutrientRequests;
using CookingMasterAPI.Models.Request.CulinaryRecipeRequests;
using CookingMasterAPI.Models.RequestValidation.CulinaryRecipeValidation;

var builder = WebApplication.CreateBuilder(args);

#region Dependency Injection Services
builder.Services.AddSingleton<IEmailGenerateService, EmailGenerateService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IIngredientCategoryService, IngredientCategoryService>();
builder.Services.AddScoped<IIngredientService, IngredientService>();
builder.Services.AddScoped<IIngredientNutrientService, IngredientNutrientService>();
builder.Services.AddScoped<ICulinaryRecipeService, CulinaryRecipeService>();
builder.Services.AddScoped<ICuisineTypeService, CuisineTypeService>();

builder.Services.AddSingleton<IValidator<UserRegisterRequest>, UserRegisterValidator>();
builder.Services.AddSingleton<IValidator<UserLoginRequest>, UserLoginValidator>();
builder.Services.AddSingleton<IValidator<ResetPasswordRequest>, ResetPasswordValidator>();
builder.Services.AddSingleton<IValidator<CreateIngredientCategoryRequest>, CreateIngredientCategoryValidator>();
builder.Services.AddSingleton<IValidator<CreateIngredientRequest>, CreateIngredientValidator>();
builder.Services.AddSingleton<IValidator<CreateIngredientNutrientRequest>, CreateIngredientNutrientValidator>();
builder.Services.AddSingleton<IValidator<CreateCulinaryRecipeRequest>, CreateCulinaryRecipeValidator>();

#endregion

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<APIDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
