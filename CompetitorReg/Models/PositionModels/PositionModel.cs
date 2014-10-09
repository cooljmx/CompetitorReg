using CompetitorReg.Infrastructure.Concrete;

namespace CompetitorReg.Models.PositionModels
{
    public class PositionModel : VirtualNotifyPropertyChanged
    {
        private int id;
        private string name;

        public int Id { get { return id; } set { id = value; NotifyPropertyChanged("Id"); } }
        public string Name { get { return name; } set { name = value; NotifyPropertyChanged("Name"); } }
    }
}
