﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Utility.Page;

namespace ApplicationCore.Abstract
{
    public interface ICRUDService<TEntity, Source,TKey> where TEntity : IEntityId<TKey>
    {
        void InitQuerySource();
        PageResult<TResult> QueryPage<TResult, TQueryDto>(TQueryDto queryDto) where TResult : class where TQueryDto : IPagination;
        List<TResult> Query<TResult, TQueryDto>(TQueryDto queryDto) where TResult : class;
        TEntity Add<TSaveDto>(TSaveDto saveDto) where TSaveDto : IIdField<TKey>;
        TEntity Update<TSaveDto>(TSaveDto saveDto) where TSaveDto : IIdField<TKey>;
        void Delete(object id);
    }
}
