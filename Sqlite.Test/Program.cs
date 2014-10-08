using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using StaffReg.Entities;

namespace Sqlite.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "";
            var cfg = SQLiteConfiguration.Standard;
            var db = cfg.ConnectionString("data source=h:\\github\\staffreg\\db\\staffreg.sqlite;version=3;").ShowSql();
            var sessionFactory = Fluently.Configure()
                .Database(db)
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("StaffReg.Entities")))
                .Diagnostics(x => x.Enable())
                .BuildSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                var l = session.Get<Staff>(1);
                Console.WriteLine(l.Surname);
                Console.ReadKey();
            }
        }
    }
}
