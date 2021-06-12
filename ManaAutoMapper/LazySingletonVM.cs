using AutoMapper;
using ManaAutoMapper.CustomMapping;
using ManaAutoMapper.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace ManaAutoMapper
{
    public sealed class LazySingletonVM
    {
        private static CustomMappingProfile profile;
        private static Assembly assembly;
        private static IMapper mapper;

        private LazySingletonVM()
        {
            if (assembly == null)
                assembly = typeof(IHaveCustomMapping).Assembly;

            var allTypes = assembly.ExportedTypes;

            var listtemp = allTypes.Where(type => type.IsClass && !type.IsAbstract && type.GetInterfaces().Contains(typeof(IHaveCustomMapping)));
            var list = listtemp.Select(type => (IHaveCustomMapping)Activator.CreateInstance(type));

            profile = new CustomMappingProfile(list);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(profile);
            });

            config.CompileMappings();

            mapper = config.CreateMapper();
        }

        private static readonly Lazy<LazySingletonVM> lazy = new Lazy<LazySingletonVM>(() => new LazySingletonVM());
        public static LazySingletonVM Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public static LazySingletonVM SetCustomAssembly(Assembly _assembly)
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
