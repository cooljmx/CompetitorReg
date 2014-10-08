using System.Collections.ObjectModel;
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
            using (var session = sessionHelper.NewSession())
            {

            }
        }
    }
}
