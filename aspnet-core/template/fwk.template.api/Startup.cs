using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using fwkSec = fwk.security.identity.core;
using System.Text;
using System.IO;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;
using pelsoft.api.service;
using Microsoft.AspNetCore.Http.Extensions;
using pelsoft.api.middleware;
using fwk.template.api.common.jwt;
using fwk.template.api.common;

namespace pelsoft.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region load appSettings

            var connectionStrings = new Fwk.Database.ConnectionStrings();
            Configuration.Bind("ConnectionStrings", connectionStrings);

            var apiConfigSection = Configuration.GetSection("apiConfig");
            var apiConfig = new apiConfig();
            Configuration.Bind("apiConfig",apiConfig);
            var m = apiConfig.api_mail;
            services.Configure<IApiConfig>(apiConfigSection);

       
         

            apiAppSettings.connectionStrings = connectionStrings;
            apiAppSettings.apiConfig = apiConfig;


            var providers = new List<Fwk.Security.Identity.jwtSecurityProvider>();
            Configuration.Bind("fwk_securityProviders", providers);

            var secConfig = new Fwk.Security.Identity.secConfig();
            secConfig.fwk_securityProviders = providers;
            secConfig.cnnStrings = connectionStrings;


            fwkSec.SecurityManager.set_secConfig(secConfig);

            #endregion

            #region configure DI for application services

            //Transient objects are always different; a new instance is provided to every controller and every service.
            services.AddTransient<TokenManagerMiddleware>();
            services.AddTransient<ITokenManager, TokenManager>();
    
        
            // Scoped objects are the same within a request, but different across different requests 
            //services.AddScoped<IpelsoftService, pelsoftService>();

            //Singleton objects are the same for every object and every request (regardless of whether an instance is provided in ConfigureServices)
            services.AddSingleton<IpelsoftService, pelsoftService>();
            services.AddSingleton<IApiLogServices, ApiLogServices>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDistributedMemoryCache();


            #endregion

            services.AddControllers();

            #region configure jwt authentication


            //  var appSettings = appSettingsSection.Get<serverSettings>();
            //var key = Encoding.UTF8.GetBytes(apiAppSettings.apiConfig.api_secretKey);
            var secretKey = Encoding.ASCII.GetBytes(apiAppSettings.apiConfig.api_secretKey);

            var securityKey = new SymmetricSecurityKey(secretKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwtBearerOptions =>
            {
                jwtBearerOptions.Events = new JwtBearerEvents()
                {
                    //captura el evento de autenticaci�n
                    OnTokenValidated = context =>
                    {

                        return Task.CompletedTask;
                    }
                 
                };

                jwtBearerOptions.RequireHttpsMetadata = false;
                jwtBearerOptions.SaveToken = true;

                //https://tools.ietf.org.html/rfc7519
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    SaveSigninToken = true,
                    ValidateActor = true,
                    ValidateIssuer = true, //emisor
                    ValidateAudience = true, //destinatarios del token 
                    ValidateLifetime = true,//
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,
                    RequireExpirationTime = false,
                    ValidIssuer = apiAppSettings.apiConfig.api_issuerToken,
                    ValidAudience = apiAppSettings.apiConfig.api_audienceToken,
                    

                };
            });

            #endregion


            #region CORS
            //CORS  policy :  global cors policy allow all
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                       builder.WithOrigins("http://192.168.0.74:4200/")
                      .AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader());
            });

            #endregion

            IdentityModelEventSource.ShowPII = true;

            #region servicios  de swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new OpenApiInfo
                {
                    Title = "pelsoft  API ",
                    Version = "v1"
                });
            });
            
            #endregion

            //Permite conservar los nombres de los atributos 
            //Core 3 uses System.Text.Json, which by default does not preserve the case. 
            //Setting the PropertyNamingPolicy to null will fix the problem.
            services.AddControllers()
              .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        
            #region servicios meidleware de swagger

            app.UseSwagger();

        // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
        // specifying the Swagger JSON endpoint.
        //https://localhost:44359/swagger/v1/swagger.json
        //https://localhost:44351/index.html
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "pelsoft  API");
                c.RoutePrefix = "";

            });

            #endregion

            

            app.UseLogsMiddleware();
            app.UseErrorHandlerMiddleware();
            
            app.UseTokenManagerMiddleware(); // puede ser      app.UseMiddleware<TokenManagerMiddleware>();

            
            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();
            //app.UseStaticFiles();

            //requiere store folder
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"store")),
            //    RequestPath = new PathString("/store")
            //});
            //custom kwk middleware
           
            //////app.Use(async (context, next) =>
            //////{
               

            //////    var url = UriHelper.GetDisplayUrl(context.Request);

            //////    if (!context.Request.Headers.ContainsKey("Authorization"))
            //////    {
            //////        //The next parameter represents the next delegate in the pipeline. You can short-circuit the pipeline by not calling the next parameter
            //////        //When a delegate doesn't pass a request to the next delegate, it's called short-circuiting the request pipeline.
            //////        await context.Response.WriteAsync("Contiene , bearer header!");
            //////    }

            //////    // Do work that doesn't write to the Response.

            //////    await next.Invoke();
            //////    // Do logging or other work that doesn't write to the Response.
            //////});
            ///
            //app.Map("pelsoft", pelsofttHandler);
            //app.Map("meucci", meucciHandler);

            //Run delegates don't receive a next parameter. 
            //The first Run delegate is always terminal and terminates the pipeline.
            // Run is a convention. Some middleware components may expose Run[Middleware] methods that run at the end of the pipeline:
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello from 2nd delegate. and last");
            //If another Use or Run delegate is added after the Run delegate, it's not called.
            //});
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
