using AutoMapper;
using ManaAutoMapper.CustomMapping;
using ManaAutoMapper.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace ManaAutoMapper
{
    public sealed class LazySingletonDTO
    {
        private static CustomMappingProfile profile;
        private static Assembly assembly;
        private static IMapper mapper;

        private LazySingletonDTO()
        {
            if (assembly == null)
                assembly = typeof(IHaveCustomMapping).Assembly;
            var allTypes = assembly.ExportedTypes;
            var listTemp = allTypes.Where(type => type.IsClass && !type.IsAbstract && type.GetInterfaces().Contains(typeof(IHaveCustomMapping)));
            var list = listTemp.Select(type => (IHaveCustomMapping)Activator.CreateInstance(type));
            profile = new CustomMappingProfile(list);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(profile);
            });
            config.CompileMappings();
            mapper = config.CreateMapper();
        }

        private static readonly Lazy<LazySingletonDTO> lazy = new Lazy<LazySingletonDTO>(() => new LazySingletonDTO());
        public static LazySingletonDTO Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public static LazySingletonDTO SetCustomAssembly(Assembly _assembly)
        {
            assembly = _assembly;

            return lazy.Value;
        }

        public Assembly GetAssembly()
        {
            return assembly;
        }

        public CustomMappingProfile GetProfile()
        {
            return profile;
        }

        public IMapper GetMapper()
        {
            return mapper;
        }
    }
}
