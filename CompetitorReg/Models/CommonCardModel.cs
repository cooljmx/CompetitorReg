using System;
using CompetitorReg.Infrastructure.Abstract;

namespace CompetitorReg.Models
{
    public abstract class CommonCardModel<T>
    {
        protected readonly ISessionHelper sessionHelper;
        private readonly T data;

        public T Data
        {
            get { return data; }
        }

        public bool IsSaved { get; set; }

        protected CommonCardModel(ISessionHelper sessionHelper)
        {
            this.sessionHelper = sessionHelper;
            data = (T)Activator.CreateInstance<T>();
            IsSaved = false;
        }

        public abstract void LoadData(int id);
        public abstract void SaveData();
    }
}