using API.Middleware;
using Application.Interfaces;
using Application.User.Login;
using AutoMapper;
using Domain;
using EFData;
using Infrastructure.Security;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace API
{
	public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
			services.AddDbContext<DataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddMediatR(typeof(LoginHandler).Assembly);

			services.AddMvc(option =>
				{
					option.EnableEndpointRouting = false;
					var policy = new AuthorizationPolicyBuilder()
						.RequireAuthenticatedUser()
						.Build();
					option.Filters.Add(new AuthorizeFilter(policy));
				}).SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.TryAddSingleton<ISystemClock, SystemClock>();

            var builder = services.AddIdentityCore<AppUser>();
            var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);
            identityBuilder.AddEntityFrameworkStores<DataContext>();
            identityBuilder.AddSignInManager<SignInManager<AppUser>>();

            services.AddAutoMapper(typeof(Application.User.User).Assembly);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Api", Version = "v1"});             

            });

            //var jwtTokenSettingsConfiguration = Configuration.GetSection("JwtTokenSettings").Get<JwtTokenSettings>();
            //services.AddSingleton(jwtTokenSettingsConfiguration);

            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenSettingsConfiguration.AccessTokenSecret));
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
            //    opt =>
            //        {
            //            opt.TokenValidationParameters = new TokenValidationParameters
            //                                                {
            //                                                    ValidateIssuerSigningKey = true,
            //                                                    IssuerSigningKey = key,
            //                                                    ValidateAudience = false,
            //                                                    ValidateIssuer = false,
            //                                                };
            //        });

            services.AddScoped<IJwtGenerator, JwtGenerator>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });
        }
    }
}
