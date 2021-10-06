using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Zoka.IInjectable
{
	/// <summary>Extenstion to the IServiceCollection for IInjectable</summary>
	public static class DependencyInjectionExtensions
	{
		/// <summary>When used during Startup.ConfigureServices, it registers all types derived from IInjectable as ScopedService</summary>
		public static IServiceCollection					RegisterInjectables(this IServiceCollection _service_collection)
		{
			foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies().Union(AppDomain.CurrentDomain.ReflectionOnlyGetAssemblies()))
			{
				foreach (Type t in a.GetTypes())
				{
					if (typeof(IInjectable).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
					{
						var inject_as_collection = t.GetCustomAttributes<InjectAsAttribute>();
						if (inject_as_collection.Any())
						{
							foreach (var inject_as_attribute in inject_as_collection)
							{
								_service_collection.AddScoped(inject_as_attribute.InjectAsType, t);
							}
						}
						else
						{
							_service_collection.AddScoped(t);
						}
					}
				}
			}

			return _service_collection;
		}
	}
}
