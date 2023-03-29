using System;
using AppDAL.Interfaces;
using AppDAL.Repositories;
using Ninject.Modules;

namespace LayerApp.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule {

        private string connectionString;

        public ServiceModule(string connection) {
            connectionString = connection;
        }

        public override void Load() {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}

