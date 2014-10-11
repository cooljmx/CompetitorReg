namespace CompetitorReg.Infrastructure.Abstract
{
    public interface IResolver
    {
        T GetService<T>();
        T CreateInstance<T>();
    }
}
