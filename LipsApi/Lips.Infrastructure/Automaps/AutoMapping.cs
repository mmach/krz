using Lips.Domain.Bases;
using Lips.Dto.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lips.Dto.Users;
using Lips.Domain.Users;

namespace Lips.Infrastructure.Automaps
{
    public static class AutoMapping
    {
        public const string DtoPostfix = "Dto";
        public  static IMapper QueryConfig=null;
  
        public static IMapperConfigurationExpression Register(IMapperConfigurationExpression cfg)
        {
            var maps = DefaultMap(typeof(Base), typeof(BaseDto));
          
            
                foreach (var map in maps)
                {
                    RegisterTwoWaysMaps(map.Key, map.Value, cfg);
                }
                RegisterTwoWaysMaps(typeof(UserAuthDto), typeof(User), cfg);
            
           // QueryConfig = config);
            return cfg;
        }

        private static void RegisterTwoWaysMaps(Type first, Type second, IMapperConfigurationExpression cfg)
        {
           
            
                cfg.CreateMap(first, second).MaxDepth(1).PreserveReferences();
                cfg.CreateMap(second, first).MaxDepth(1).PreserveReferences(); ;
                cfg.CreateMap(first, first).MaxDepth(1).PreserveReferences(); ;
                cfg.CreateMap(second, second).MaxDepth(1).PreserveReferences(); ;
           
           
        }


        private static Dictionary<Type, Type> DefaultMap(Type baseDomainType, Type baseDtoType)
        {
            var result = new Dictionary<Type, Type>();
            var domainTypes = baseDomainType.Assembly.GetTypes().Where(p => baseDomainType.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract).ToList();
            var baseDtoTypes = baseDtoType.Assembly.GetTypes().Where(p => baseDtoType.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract).ToList();

            foreach (var domainType in domainTypes)
            {
                var connection = baseDtoTypes.SingleOrDefault(p => p.Name == domainType.Name + DtoPostfix);
                if (connection != null)
                {
                    result.Add(domainType,connection);
                }
            }

            return result;
        }
    }
}
