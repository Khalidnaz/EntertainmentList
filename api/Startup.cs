using EntertainmentList.Models;
using EntertainmentList.Repositories;
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
using EntertainmentList.Types;
using EntertainmentList.Mutations;

namespace EntertainmentList
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
			services.AddDbContext<ApplicationDbContext>(options =>
			 options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

			services.AddCors(options =>
			{
				options.AddPolicy(name: "AllowedOrigins",
					builder =>
					{
						builder.WithOrigins("http://localhost:8080",
																		"http://prodUrl");
					});
			});

			services.AddScoped<IAuthRepository, AuthRepository>();
			services.AddGraphQL(sp => SchemaBuilder.New()
			.AddServices(sp)

			// Adds the authorize directive and
			// enable the authorization middleware.
			.AddAuthorizeDirectiveType()

			.AddQueryType<QueryType>()
			.AddMutationType<UserMutations>()
			// .AddSubscriptionType<SubscriptionType>()
			.AddType<UserType>()
			.Create());
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			}

			// Prod only configs
			if (env.IsProduction())
			{
				app.UseHsts();
				app.UseHttpsRedirection();
			}

			// app.UseStaticFiles();
			// app.UseAuthorization();

			app
				.UseCors("AllowedOrigins")
				.UseWebSockets()
				.UseRouting()
				.UseGraphQL("/graphql")
				.UsePlayground(new PlaygroundOptions { QueryPath = "/graphql", Path = "/graphql" })
				.UseVoyager("/graphql");
		}
	}
}
