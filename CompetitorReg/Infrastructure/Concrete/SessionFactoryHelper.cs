using System.Configuration;
using System.Reflection;
using System.Windows;
using CompetitorReg.Infrastructure.Abstract;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace CompetitorReg.Infrastructure.Concrete
{
    public class SessionFactoryHelper : ISessionFactoryHelper
    {
        private readonly ISessionFactory sessionFactory;

        // TODO: Сделать SessionFactoryHelper синглтоном уровня приложения
        public SessionFactoryHelper()
        {
            var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            var cfg = SQLiteConfiguration.Standard; 
            sessionFactory = Fluently.Configure()
                .Database(cfg.ConnectionString(connectionString).ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .Diagnostics(x => x.Enable())
                .BuildSessionFactory();
            //MessageBox.Show(connectionString);
        }

        public ISessionFactory GetSessionFactory { get { return sessionFactory; } }
    }
}