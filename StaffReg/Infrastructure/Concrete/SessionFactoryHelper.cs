using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using StaffReg.Infrastructure.Abstract;

namespace StaffReg.Infrastructure.Concrete
{
    public class SessionFactoryHelper : ISessionFactoryHelper
    {
        private readonly ISessionFactory sessionFactory;

        // TODO: Сделать SessionFactoryHelper синглтоном уровня приложения
        public SessionFactoryHelper()
        {
            //var root = WebConfigurationManager.OpenWebConfiguration(HostingEnvironment.ApplicationVirtualPath);
            var connectionString = "";//root.AppSettings.Settings["ConnectionString"];
            
            var cfg = MsSqlConfiguration.MsSql2012; //FirebirdConfiguration();

            //log4net.Config.XmlConfigurator.Configure(); 
            /*
            sessionFactory = Fluently.Configure()
                .Database(cfg.ConnectionString(connectionString).ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ExtReg.Entities")))
                .Diagnostics(x => x.Enable())
                .BuildSessionFactory();
             * */
        }

        public ISessionFactory GetSessionFactory { get { return sessionFactory; } }
    }
}