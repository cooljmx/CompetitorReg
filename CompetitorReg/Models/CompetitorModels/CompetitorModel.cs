using System;
using CompetitorReg.Infrastructure.Concrete;

namespace CompetitorReg.Models.CompetitorModels
{
    public class CompetitorModel : VirtualNotifyPropertyChanged
    {
        private int id;
        private string surname;
        private string name;
        private string middleName;
        private string contactPhone;
        private DateTime birthDate;

        public int Id { get { return id; } set { id = value; NotifyPropertyChanged("Id"); } }
        public string Surname { get { return surname; } set { surname = value; NotifyPropertyChanged("Surname"); } }
        public string Name { get { return name; } set { name = value; NotifyPropertyChanged("Name"); } }
        public string MiddleName { get { return middleName; } set { middleName = value; NotifyPropertyChanged("MiddleName"); } }
        public string ContactPhone { get { return contactPhone; } set { contactPhone = value; NotifyPropertyChanged("ContactPhone"); } }
        public DateTime BirthDate { get { return birthDate; } set { birthDate = value; NotifyPropertyChanged("BirthDate"); } }
        public string ShortName { get
        {
            return middleName == null
                ? string.Format("{0} {1}.", surname, name.Substring(0, 1))
                : string.Format("{0} {1}.{2}.", surname, name.Substring(0, 1), middleName.Substring(0, 1));
        } }
    }
}
