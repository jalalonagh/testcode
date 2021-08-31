using AutoMapper;
using ManaAutoMapper.CustomMapping;
using System;
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
            mapper = assembly.GenerateMapper(profile);
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
