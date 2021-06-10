using AutoMapper;
using ManaAutoMapper.CustomMapping;
using ManaAutoMapper.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace ManaAutoMapper
{
    public sealed class LazySingleton
    {
        private static CustomMappingProfile profile;
        private static Assembly assembly;
        private static IMapper mapper;

        private LazySingleton()
        {
            assembly = typeof(IHaveCustomMapping).Assembly;

            var allTypes = assembly.ExportedTypes;

            var list = allTypes.Where(type => type.IsClass && !type.IsAbstract
            && type.GetInterfaces().Contains(typeof(IHaveCustomMapping)))
                .Select(type => (IHaveCustomMapping)Activator.CreateInstance(type));

            profile = new CustomMappingProfile(list);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(profile);
            });

            config.CompileMappings();

            mapper = config.CreateMapper();
        }

        private static readonly Lazy<LazySingleton> lazy = new Lazy<LazySingleton>(() => new LazySingleton());
        public static LazySingleton Instance
        {
            get
            {
                return lazy.Value;
            }
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
