using System;

namespace StaffReg.Infrastructure.Abstract
{
    public interface IResolver
    {
        void Inject(object instance);
        object CreateInstance(Type controlType);
    }
}
