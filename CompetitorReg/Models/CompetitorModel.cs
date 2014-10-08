using System;
using CompetitorReg.Infrastructure.Concrete;

namespace CompetitorReg.Models
{
    public class CompetitorModel : VirtualNotifyPropertyChanged
    {
        private int idCompetitor;
        private string surname;
        private string name;
        private string middleName;
        private string contactPhone;
        private DateTime birthDate;

        public int IdСompetitor { get { return idCompetitor; } set { idCompetitor = value; NotifyPropertyChanged("IdCompetitor"); } }
        public string Surname { get { return surname; } set { surname = value; NotifyPropertyChanged("Surname"); } }
        public string Name { get { return name; } set { name = value; NotifyPropertyChanged("Name"); } }
        public string MiddleName { get { return middleName; } set { middleName = value; NotifyPropertyChanged("MiddleName"); } }
        public string ContactPhone { get { return contactPhone; } set { contactPhone = value; NotifyPropertyChanged("ContactPhone"); } }
        public DateTime BirthDate { get { return birthDate; } set { birthDate = value; NotifyPropertyChanged("BirthDate"); } }
    }
}
