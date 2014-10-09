using System;
using System.Collections.Generic;
using CompetitorReg.Infrastructure.Abstract;
using Ninject;

namespace CompetitorReg.Infrastructure.Concrete
{
    public class Resolver : IResolver
    {
        private readonly IKernel kernel;

        public Resolver()
        {
            kernel = new StandardKernel();

            kernel.Bind<ISessionHelper>().To<SessionHelper>().WithConstructorArgument("sessionFactoryHelper", new SessionFactoryHelper());
        }

        /*public void Inject(object instance)
        {
            kernel.Inject(instance);
        }*/

        public T CreateInstance<T>()
        {
            var activatorParams = new List<object>();
            var t = typeof(T);

            var constructors = t.GetConstructors();
            // берем первый конструктор
            var constructorInfo = constructors[0];
            foreach (var parameterInfo in constructorInfo.GetParameters())
            {
                var type = parameterInfo.ParameterType;
                var obj = type == typeof(IResolver) ? this : kernel.GetService(type);
                activatorParams.Add(obj);
            }

            return (T)Activator.CreateInstance(t,activatorParams.ToArray());
        }
    }
}
