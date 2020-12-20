using System;
using System.Collections.Generic;
//using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Web;
using AutoMapper;
using BL;
using BL.Services;
using LightInject;

namespace Level.App_Start
{
    public static class LightInjectConfig
    {
        public static void Configurate()
        {
            var container = new ServiceContainer();
            container.RegisterControllers(Assembly.GetExecutingAssembly());

            container.EnablePerWebRequestScope();

            var config = new MapperConfiguration(cfg => cfg.AddProfiles(
                  new List<Profile>() { new AutomapperProfileWeb(), new AutomapperProfileBL() }));

            container.Register(c => config.CreateMapper());

            container = LightInjectConfigurationBL.Configurate(container);

            container.Register<ITransactionService, TransactionService>();
            container.Register<ICategoryService, CategoryService>();

            //container.Register<IEmailService, EmailService>();
            //var resolver = new LightInjectWebApiDependencyResolver(container);             
            //DependencyResolver.SetResolver(new LightInjectMvcDependencyResolver(container));
            container.EnableMvc();
        }
    }
}