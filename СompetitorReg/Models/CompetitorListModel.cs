using System.Collections.ObjectModel;
using CompetitorReg.Entities;
using CompetitorReg.Infrastructure.Abstract;

namespace CompetitorReg.Models
{
    public class CompetitorListModel
    {
        private readonly ISessionHelper sessionHelper;

        private readonly ObservableCollection<СompetitorModel> data = new ObservableCollection<СompetitorModel>();
        public ObservableCollection<СompetitorModel> Data { get { return data; } }

        public CompetitorListModel(ISessionHelper sessionHelper)
        {
            this.sessionHelper = sessionHelper;
        }

        public void ReloadData()
        {
            Data.Clear();
            using (var session = sessionHelper.NewSession())
            {
                var query = session.QueryOver<Сompetitor>().List();
                foreach (var сompetitor in query)
                {
                    Data.Add(new СompetitorModel
                    {
                        IdСompetitor = сompetitor.IdСompetitor,
                        Surname = сompetitor.Surname,
                        Name = сompetitor.Name,
                        MiddleName = сompetitor.MiddleName,
                        ContactPhone = сompetitor.ContactPhone,
                        BirthDate = сompetitor.BirthDate
                    });
                }
            }
        }
    }
}
