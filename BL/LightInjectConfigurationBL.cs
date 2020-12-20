using DAL.Context;
using DAL.Repository;
using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class LightInjectConfigurationBL
    {
        public static ServiceContainer Configurate(ServiceContainer container)
        {
            container.Register<ApplicationContext>(new PerScopeLifetime());
            container.Register(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return container;
        }
    }
}
