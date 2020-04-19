using api.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
using HotChocolate.AspNetCore.Playground;
using api.Types;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using System.Security.Claims;
using HotChocolate.Execution.Configuration;
using System.Threading.Tasks;

namespace api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration
		{
			get;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
	 			options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

			services.AddCors();

			services.AddScoped<IAuthRepository, AuthRepository>();
			services.AddGraphQL(sp => SchemaBuilder.New()
			 .AddServices(sp)
			 // Adds the authorize directive and
			 // enable the authorization middleware.
			 .AddAuthorizeDirectiveType()
			 .AddQueryType<QueryType>()
			 .AddMutationType<MutationType>()
			 .AddType<UserType>()
			 .AddType<UserInputType>()
			 .AddType<LoginUserType>()
			 .AddType<AuthUserType>()
			 .Create(),
				new QueryExecutionOptions { ForceSerialExecution = true });

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			 .AddJwtBearer(options =>
			 {
				 options.TokenValidationParameters = new TokenValidationParameters
				 {
					 // validates token secret
					 ValidateIssuerSigningKey = true,
					 IssuerSigningKey = new SymmetricSecurityKey(
						Encoding.ASCII.GetBytes(
							Configuration.GetSection("AppSettings:Token").Value
						)
					),
					 ValidateIssuer = false,
					 ValidateAudience = false
				 };
				 options.Events = new JwtBearerEvents
				 {
					 OnMessageReceived = context =>
					 {
						 if (context.HttpContext.Request.Query.ContainsKey("token"))
						 {
							 context.Token = context.HttpContext.Request.Query["token"];
						 }
						 return Task.CompletedTask;
					 }
				 };
			 });

			services.AddAuthorization(options =>
				{
					options.AddPolicy("IsUser", policy =>
							policy.RequireAssertion(context =>
									context.User.HasClaim(c => (c.Type == ClaimTypes.Role))));
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			// Prod only configs
			if (env.IsProduction())
			{
				app.UseHsts();
				app.UseHttpsRedirection();
			}

			app.UseCors(o => o
			 .AllowAnyHeader()
			 .AllowAnyMethod()
			 .AllowAnyOrigin());

			app
			 .UseRouting()
			 .UseAuthentication()
			 .UseWebSockets()
			 .UseGraphQL("/graphql")
			 .UsePlayground(new PlaygroundOptions
			 {
				 QueryPath = "/graphql",
				 Path = "/graphql"
			 })
			 .UseVoyager("/graphql");
		}
	}
}