﻿using ApplicationCore.IServices;
using Autofac;
using Infrastructure;
using Service;
using Snail.Cache;
using System;
using System.Collections.Generic;
using Module = Autofac.Module;

namespace Web.AutoFacModule
{
    /// <summary>
    /// 非service的其它类的注册
    /// </summary>
    public class OtherModule: Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            var exceptTypes = new List<Type>
            {
                typeof(SnailMemoryCache),
                typeof(SnailRedisCache),
            };
            //所有的非IService的注册，并启动用属性注册
            builder.RegisterAssemblyTypes(typeof(IService).Assembly, typeof(AppDbContext).Assembly, typeof(Startup).Assembly, typeof(ServiceContext).Assembly).Where(a => !typeof(IService).IsAssignableFrom(a) && !exceptTypes.Contains(a)).AsSelf().AsImplementedInterfaces().PropertiesAutowired();

        }
    }
}
