﻿using Entities;
using System;

namespace ManaAutoMapper.Models
{
    [Serializable]
    public class AutoMapperDTO<TDTO, TEntity, TKey> : AutoMapperBaseDTO<TDTO, TEntity, TKey>
        where TDTO : class, new()
        where TEntity : BaseEntity, new()
        where TKey : struct
    {
        public AutoMapperDTO()
        {

        }

        public TEntity ToEntity()
        {
            var mapper = LazySingleton.Instance;

            return mapper.GetMapper().Map<TEntity>(CastToDerivedClass(this));
        }

        public TEntity ToEntity(TEntity entity)
        {
            var mapper = LazySingleton.Instance;

            return mapper.GetMapper().Map(CastToDerivedClass(this), entity);
        }

        public static TDTO FromEntity(TEntity model)
        {
            var mapper = LazySingleton.Instance;
            return mapper.GetMapper().Map<TDTO>(model);
        }

        public TDTO DTOFromEntity(TEntity model)
        {
            var mapper = LazySingleton.Instance;
            return mapper.GetMapper().Map<TDTO>(model);
        }

        protected TDTO CastToDerivedClass(AutoMapperDTO<TDTO, TEntity, TKey> baseInstance)
        {
            var mapper = LazySingleton.Instance;

            return mapper.GetMapper().Map<TDTO>(baseInstance);
        }
    }
}
