

using Lips.Domain.Bases;
using Lips.Dto.Bases;
using Lips.Repository;
using Lips.Service.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Lips.Infrastructure.Bootstrappers
{
    public static class Bootstrapper
    {
        public static object AutoMapping { get; set; }
        public static UnityContainer container { set; get; }

        public static void Register(HttpConfiguration config)
        {
            container = new UnityContainer();
        var repositoriesDependencies = DefaultDependencies(typeof(IBaseRepository<>), typeof(Base));

            foreach (var dependency in repositoriesDependencies)
                container.RegisterType(dependency.Key, dependency.Value);

            var servicesDependencies = DefaultDependencies(typeof(IBaseService<>), typeof(BaseDto));

            foreach (var dependency in servicesDependencies)
                container.RegisterType(dependency.Key, dependency.Value);

            config.DependencyResolver = new UnityDependencyResolver(container);
            //return UnityContainer;
        }

        private static Dictionary<Type, Type> DefaultDependencies(Type baseGenericInterfaceType, Type baseType)
        {
            var result = new Dictionary<Type, Type>();

            var childTypes = baseType.Assembly.GetTypes().Where(p => p.BaseType.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract).ToList();
            var implementationTypes = baseGenericInterfaceType.Assembly.GetTypes().Where(p => p.IsClass && !p.IsAbstract).ToList();

            foreach (var childType in childTypes)
            {
                var filledGenericInterface = baseGenericInterfaceType.MakeGenericType(new Type[] { childType });
                var implementationType = implementationTypes.SingleOrDefault(p => filledGenericInterface.IsAssignableFrom(p));

                if (implementationType != null)
                {
                    var childInterfaces = implementationType.GetInterfaces().Where(p => filledGenericInterface.IsAssignableFrom(p)).ToList();

                    foreach (var childInterface in childInterfaces)
                    {
                        result.Add(childInterface, implementationType);
                    }
                }
            }

            return result;
        }
    }
}
