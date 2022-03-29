//using Newtonsoft.Json.Serialization;
//using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
//using Microsoft.OpenApi.Models;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Swashbuckle.AspNetCore.Filters;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;

//namespace FinalChatApp
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }



//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {

//            var builder = WebApplication.CreateBuilder();

//            builder.Services.AddControllers();


//            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//            builder.Services.AddEndpointsApiExplorer();

//            //Add jwt authorization in swagger to confirm token auth
//            services.AddSwaggerGen(options =>
//            {
//                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
//                {
//                    Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
//                    In = ParameterLocation.Header,
//                    Name = "Authorization",
//                    Type = SecuritySchemeType.ApiKey
//                });

//                options.OperationFilter<SecurityRequirementsOperationFilter>();
//            });
//            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//                .AddJwtBearer(options =>
//                {
//                    options.TokenValidationParameters = new TokenValidationParameters
//                    {
//                        ValidateIssuerSigningKey = true,
//                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
//                        .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
//                        ValidateIssuer = false,
//                        ValidateAudience = false
//                    };
//                });

//            //Enable CORS
//            services.AddCors(c =>
//            {
//                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
//            });


//            //JSON Serializer
//            services.AddControllersWithViews().AddNewtonsoftJson(options =>
//            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
//                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
//                = new DefaultContractResolver());

//            services.AddControllers();
//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            //Enable CORS
//            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());



//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//                app.UseSwagger();
//                app.UseSwaggerUI();
//            }

//            app.UseHttpsRedirection();
//            app.UseAuthentication();
//            app.UseRouting();

//            app.UseAuthorization();

//            //app.Run();

//            app.UseSpa(spa =>
//            {
//                spa.Options.SourcePath = "ClientApp";

//                {
//                    spa.UseReactDevelopmentServer(npmScript: "start");
//                }
//            });

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllers();
//                endpoints.MapControllerRoute(
//                    name: "default",
//                    pattern: "{controller=Home}/{action=Index}/{id?}");
//            });

//            app.UseStaticFiles();
//        }
//    }
//}