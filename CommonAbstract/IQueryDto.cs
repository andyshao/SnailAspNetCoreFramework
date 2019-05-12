﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace CommonAbstract
{
    /// <summary>
    /// 所有的查询条件
    /// </summary>
    public interface IQueryDto<T> where T:IBaseEntity
    {
        Expression<Func<T,bool>> GeneratePredicateExpression();
        Func<IQueryable<T>, IQueryable<T>> IncludeFunc();
        Func<IQueryable<T>, IQueryable<T>> OrderFunc();
        Expression<Func<T, TResult>> SelectorExpression<TResult>();
    }
}