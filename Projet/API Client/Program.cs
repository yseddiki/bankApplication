using API_Client.Repositories;
using API_Client.Services;
using API_Client.Controllers;
using API_Client.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using API_Client.Interfaces;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IBankTransferService,BankTransfersService>();
builder.Services.AddScoped<IBankTransferRepository, BankTransferRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//DB Context Connection
builder.Services.AddDbContext<DatabaseContext>(options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//Swagger Banque HELB VERSION
    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new() { Title = "API BANQUE HELB", Version = "v5000000" });
   
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Description = "Bearer Authentication with JWT",
            Type = SecuritySchemeType.Http
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                new List<string>()
            }
        });
    });
    //Service d'authentification
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer
        (options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateActor = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                ClockSkew = TimeSpan.Zero
            };
        });
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AnyOrigin", builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod();
        });
    });
/// <summary>
/// Build app
/// </summary>
var app = builder.Build();
/// <summary>
/// Helb
/// </summary>
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HELB"));
}
app.UseCors("AnyOrigin");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
