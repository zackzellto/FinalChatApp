using System.Configuration;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Npgsql;
using Swashbuckle.AspNetCore.Filters;
using Newtonsoft.Json.Serialization;

using Microsoft.EntityFrameworkCore;
using FinalChatApp.Data;
using FinalChatApp.Helpers;
using FinalChatApp.Hubs;

//using FinalChatApp.IService;
//using FinalChatApp.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//Enable CORS
//builder.Services.AddCors(c =>
//    {
//        c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
//    });


    //JSON Serializer
    builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
        .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
        = new DefaultContractResolver());

//EF setting up connection with DB
builder.Services.AddDbContext<ChatAppDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DBConnectionString")));

builder.Services.AddControllers();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();

builder.Services.AddSignalR();

builder.Services.AddEndpointsApiExplorer();


//Add jwt authorization in swagger to confirm token auth
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});



var app = builder.Build();

//Enable WebSockets

//var webSocketOptions = new WebSocketOptions
//{
//    KeepAliveInterval = TimeSpan.FromMinutes(2)
//};

//app.UseWebSockets(webSocketOptions);


//Enable CORS
app.UseCors(options => options
    .WithOrigins(new []{"http://localhost:3000", "http://localhost:8080", "http://localhost:4200" })
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    );

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseWebSockets();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapHub<ChatAppHub>("/chat");
});

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";

    {
        spa.UseReactDevelopmentServer(npmScript: "start");
    }
});

app.Run();








