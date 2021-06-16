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
            mapper = assembly.GenerateMapper(profile);
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
