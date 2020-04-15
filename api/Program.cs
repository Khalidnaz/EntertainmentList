using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EntertainmentList
{
	public class Program
	{
		public static void Main(string[] args)
		{
			if (args.Length == 1 && args[0] == "schema")
			{
				var serviceCollection = new ServiceCollection();
				var startup = new Startup(null);
				startup.ConfigureServices(serviceCollection);

				File.WriteAllText(
						"Schema.graphql",
						serviceCollection.BuildServiceProvider()
								.GetRequiredService<ISchema>()
								.ToString());
			}
			else
			{
				CreateHostBuilder(args).Build().Run();
			}
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
