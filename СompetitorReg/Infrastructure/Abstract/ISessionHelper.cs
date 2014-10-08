using NHibernate;

namespace CompetitorReg.Infrastructure.Abstract
{
    public interface ISessionHelper
    {
        ISession NewSession();
    }
}