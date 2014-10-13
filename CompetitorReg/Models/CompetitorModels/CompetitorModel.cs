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
        private string birthPlace;
        private string passportSerial;
        private int passportNumber;
        private string issuingAuthority;
        private string departmentCode;
        private DateTime issueDate;
        private string nee;
        private string incorporationPlace;
        private string residencePlace;

        public int Id { get { return id; } set { id = value; NotifyPropertyChanged("Id"); } }
        public string Surname { get { return surname; } set { surname = value; NotifyPropertyChanged("Surname"); } }
        public string Name { get { return name; } set { name = value; NotifyPropertyChanged("Name"); } }
        public string MiddleName { get { return middleName; } set { middleName = value; NotifyPropertyChanged("MiddleName"); } }
        public string ContactPhone { get { return contactPhone; } set { contactPhone = value; NotifyPropertyChanged("ContactPhone"); } }
        public DateTime BirthDate { get { return birthDate; } set { birthDate = value; NotifyPropertyChanged("BirthDate"); } }
        public string BirthPlace { get { return birthPlace; } set { birthPlace = value; NotifyPropertyChanged("BirthPlace"); } }
        public string PassportSerial { get { return passportSerial; } set { passportSerial = value;NotifyPropertyChanged("PassportSerial"); } }
        public int PassportNumber { get { return passportNumber; } set { passportNumber = value; NotifyPropertyChanged("PassportNumber"); } }
        public string IssuingAuthority { get { return issuingAuthority; } set { issuingAuthority = value; NotifyPropertyChanged("IssuingAuthority"); } }
        public string DepartmentCode { get { return departmentCode; } set { departmentCode = value; NotifyPropertyChanged("DepartmentCode"); } }
        public DateTime IssueDate { get { return issueDate; } set { issueDate = value; NotifyPropertyChanged("IssueDate"); } }
        public string Nee { get { return nee; } set { nee = value; NotifyPropertyChanged("Nee"); } }
        public string IncorporationPlace { get { return incorporationPlace; } set { incorporationPlace = value; NotifyPropertyChanged("IncorporationPlace"); } }
        public string ResidencePlace { get { return residencePlace; } set { residencePlace = value; NotifyPropertyChanged("ResidencePlace"); } }

        public string ShortName
        {
            get
            {
                return middleName == null
                    ? string.Format("{0} {1}.", surname, name.Substring(0, 1))
                    : string.Format("{0} {1}.{2}.", surname, name.Substring(0, 1), middleName.Substring(0, 1));
            }
        }
    }
}
