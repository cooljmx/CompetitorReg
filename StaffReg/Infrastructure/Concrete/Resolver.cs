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
        }

        public void Inject(object instance)
        {
            kernel.Inject(instance);
        }
    }
}
