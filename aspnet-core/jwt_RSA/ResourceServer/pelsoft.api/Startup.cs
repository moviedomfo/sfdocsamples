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
using pelsoft.api.common;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.AspNetCore.Internal;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using fwkSec = fwk.security.identity.core;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;
using System.Security.Cryptography;

namespace pelsoft.api
{
    public static class TypeConverterExtension
    {
        /// <summary>
        /// Convierte base 64 text a byte[]
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this string value) => Convert.FromBase64String(value);

        /// <summary>
        /// Convierte byte cualquiera a Base64String
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string FromByteArray(this Byte[] buffer)
        {
            return Convert.ToBase64String(buffer);
        }
    }
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

            var apiConfig = new apiConfig();
            Configuration.Bind("apiConfig", apiConfig);      //  <--- This


            apiAppSettings.connectionStrings = connectionStrings;
            apiAppSettings.apiConfig = apiConfig;


            //var providers = new List<Fwk.Security.Identity.jwtSecurityProvider>();
            //Configuration.Bind("fwk_securityProviders", providers);

            var secConfig = new Fwk.Security.Identity.secConfig();
            //secConfig.fwk_securityProviders = providers;
            secConfig.cnnStrings = connectionStrings;


            fwkSec.SecurityManager.set_secConfig(secConfig);

            #endregion

  
  
            services.AddControllers();
            #region configure jwt authentication

     

           

            var publicKey = apiAppSettings.apiConfig.api_RsaPublicKey.ToByteArray();

            using RSA rsa = RSA.Create();
            rsa.ImportRSAPublicKey(publicKey, out _);
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
                    ValidateIssuer = false, //emisor
                    ValidateAudience = true, //destinatarios del token 
                    ValidateLifetime = true,//
                    ValidateIssuerSigningKey = true,

                    IssuerSigningKey = new RsaSecurityKey(rsa) ,
                    RequireExpirationTime = false,
                    ValidIssuer = apiAppSettings.apiConfig.api_issuerToken,
                    ValidAudience = apiAppSettings.apiConfig.api_audienceToken,
                    

                };
            });

            #endregion

            services.AddTransient<IJwtHandler, JwtHandler>();
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
                    Title = "Konecta API ",
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "";

            });


           
            #endregion


            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();
            //app.UseStaticFiles();

            //requiere store folder
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"store")),
            //    RequestPath = new PathString("/store")
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
