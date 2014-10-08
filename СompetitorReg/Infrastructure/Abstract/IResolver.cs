using System;

namespace CompetitorReg.Infrastructure.Abstract
{
    public interface IResolver
    {
        void Inject(object instance);
        T CreateInstance<T>();
    }
}
