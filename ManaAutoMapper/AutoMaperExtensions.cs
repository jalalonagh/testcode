using AutoMapper;
using ManaAutoMapper.CustomMapping;
using ManaAutoMapper.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace ManaAutoMapper
{
    public static class AutoMaperExtensions
    {
        public static IMapper GenerateMapper(this Assembly assembly, CustomMappingProfile profile)
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
            return config.CreateMapper();
        }
    }
}
