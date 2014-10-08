using NHibernate;

namespace StaffReg.Infrastructure.Abstract
{
    public interface ISessionFactoryHelper
    {
        ISessionFactory GetSessionFactory { get; }
    }
}