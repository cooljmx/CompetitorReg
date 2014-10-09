using System.Collections.ObjectModel;
using CompetitorReg.Infrastructure.Abstract;
using CompetitorReg.Infrastructure.Concrete;

namespace CompetitorReg.Models
{
    public abstract class CommonListModel<T> : VirtualNotifyPropertyChanged
    {
        protected readonly ISessionHelper sessionHelper;

        private readonly ObservableCollection<T> data = new ObservableCollection<T>();
        private T focusedRow;

        public ObservableCollection<T> Data { get { return data; } } 

        public T FocusedRow { get { return focusedRow; } set { focusedRow = value; NotifyPropertyChanged("FocusedRow"); } }


        protected CommonListModel(ISessionHelper sessionHelper)
        {
            this.sessionHelper = sessionHelper;
        }

        public abstract void ReloadData();

        public abstract void ReloadFocusedRow();

        public abstract void ReloadAfterAdd(int id);
    }
}
