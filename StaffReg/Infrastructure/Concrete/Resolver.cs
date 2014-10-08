using Ninject;
using StaffReg.Infrastructure.Abstract;

namespace StaffReg.Infrastructure.Concrete
{
    public class Resolver : IResolver
    {
        private readonly IKernel kernel;

        public Resolver()
        {
            kernel = new StandardKernel();

            kernel.Bind<ISessionHelper>().To<SessionHelper>().WithConstructorArgument("sessionFactoryHelper", new SessionFactoryHelper());
        }

        public void Inject(object instance)
        {
            kernel.Inject(instance);
        }
    }
}
