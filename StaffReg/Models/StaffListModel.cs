using System.Collections.ObjectModel;
using Ninject;
using StaffReg.Entities;
using StaffReg.Infrastructure.Abstract;

namespace StaffReg.Models
{
    public class StaffListModel
    {
        private readonly ISessionHelper sessionHelper;

        private readonly ObservableCollection<StaffModel> data = new ObservableCollection<StaffModel>();
        public ObservableCollection<StaffModel> Data { get { return data; } }

        public StaffListModel(ISessionHelper sessionHelper)
        {
            this.sessionHelper = sessionHelper;
        }

        public void ReloadData()
        {
            Data.Clear();
            using (var session = sessionHelper.NewSession())
            {
                var query = session.QueryOver<Staff>().List();
                foreach (var staff in query)
                {
                    Data.Add(new StaffModel
                    {
                        IdStaff = staff.IdStaff,
                        Surname = staff.Surname,
                        Name = staff.Name,
                        MiddleName = staff.MiddleName
                    });
                }
            }
        }
    }
}
