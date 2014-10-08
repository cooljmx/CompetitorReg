using NHibernate;
using StaffReg.Infrastructure.Abstract;

namespace StaffReg.Infrastructure.Concrete
{
    public class SessionHelper : ISessionHelper{
        private readonly ISessionFactoryHelper sessionFactoryHelper;
        public SessionHelper(ISessionFactoryHelper sessionFactoryHelper)
        {
            this.sessionFactoryHelper = sessionFactoryHelper;
        }

        public ISession NewSession()
        {
            return sessionFactoryHelper.GetSessionFactory.OpenSession();
        }
    }
}