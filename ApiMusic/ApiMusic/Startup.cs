using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.Generation.Processors.Security;
using Persistent;
using Services.AlbumService;
using Services.ArtistService;
using Services.AuthServices;
using Services.MusicService;
using Services.PersonService;
using Services.PlayListService;

namespace ApiMusic
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
            //configuration Token

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters()
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = Configuration["JWT:Issuer"],
                   ValidAudience = Configuration["JWT:Audience"],
                   IssuerSigningKey = new SymmetricSecurityKey(
                       Encoding.UTF8.GetBytes(Configuration["JWT:ClaveSecreta"]))
               };
           });


            //Configuration Service 
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<IMusicService, MusicService>();
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IPlayListService, PlayListService>();
            services.AddScoped<IAuthService, AuthService>();

            //Configuration database 
            var connectionString = Configuration.GetConnectionString("dev");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper();
            //Configuration swagger
            services.AddOpenApiDocument(document =>
            {

                document.Version = "v1";
                document.Title = "Api music";
                document.Description = "Api sobre la musica, donde los usuarios podran crear sus playlist";

                //configuracion de JWT para swagger
                document.AddSecurity("JWT", Enumerable.Empty<string>(),
                    new NSwag.OpenApiSecurityScheme
                    {
                        Type = OpenApiSecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        In = OpenApiSecurityApiKeyLocation.Header,
                        Description = "Copia y pega el Token en el campo 'Value:' de esta manera, Bearer {Token JWT}."
                    }

                );

                document.OperationProcessors.Add(
                    new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication(); //auth

            //Add swagger
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseMvc();
        }
    }
}
