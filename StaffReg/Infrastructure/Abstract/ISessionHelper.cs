using NHibernate;

namespace StaffReg.Infrastructure.Abstract
{
    public interface ISessionHelper
    {
        ISession NewSession();
    }
}