using Microsoft.OpenApi.Models;
using SuperviseurApi.Handlers;
using SuperviseurApi.Services;
using SuperviseurApi.Services.HelbService;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Swagger Banque HELB VERSION
builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new() { Title = "API Supervisor", Version = "v1" });

        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Description = "Bearer Authentication with JWT",
            Type = SecuritySchemeType.Http
        });
    });
builder.Services.AddCors(options =>
{
    options.AddPolicy("AnyOrigin", policyBuilder =>
    {
        policyBuilder.SetIsOriginAllowed((host) => true)
            .WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});
string uriHelb = builder.Configuration.GetValue<string>("HelbAPI");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMemoryCache();
builder.Services.AddTransient<HelbAuthenticationHandler>();
builder.Services.AddTransient<IHelbAuthenticationService,HelbAuthenticationService>();

builder.Services.AddHttpClient<IUserService, UserService>()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri(uriHelb))
    .AddHttpMessageHandler<HelbAuthenticationHandler>();

builder.Services.AddHttpClient<IAccountService, AccountService>()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri(uriHelb))
    .AddHttpMessageHandler<HelbAuthenticationHandler>();

builder.Services.AddHttpClient<IBankTransferService, BankTransferService>()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri(uriHelb))
    .AddHttpMessageHandler<HelbAuthenticationHandler>();

builder.Services.AddHttpClient<IHelbAuthenticationService, HelbAuthenticationService>()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri(uriHelb));

var app = builder.Build();
app.UseCors("AnyOrigin");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
