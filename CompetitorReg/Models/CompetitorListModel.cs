using System.Collections.ObjectModel;
using System.Linq;
using CompetitorReg.Entities;
using CompetitorReg.Infrastructure.Abstract;
using CompetitorReg.Infrastructure.Concrete;
using NHibernate.Linq;

namespace CompetitorReg.Models
{
    public class CompetitorListModel : VirtualNotifyPropertyChanged
    {
        private readonly ISessionHelper sessionHelper;
        private readonly ObservableCollection<CompetitorModel> unfilteredData = new ObservableCollection<CompetitorModel>();
        private readonly ObservableCollection<CompetitorModel> data = new ObservableCollection<CompetitorModel>();
        private CompetitorModel focusedRow;
        private string surnameFilter;

        public ObservableCollection<CompetitorModel> Data { get { return data; } }

        public CompetitorModel FocusedRow { get { return focusedRow; } set { focusedRow = value; NotifyPropertyChanged("FocusedRow"); } }

        public string SurnameFilter { get { return surnameFilter; } set { surnameFilter = value; NotifyPropertyChanged("SurnameFilter"); FilterData(); } }

        public CompetitorListModel(ISessionHelper sessionHelper)
        {
            this.sessionHelper = sessionHelper;
        }

        private void FilterData()
        {
            data.Clear();
            var tmp = unfilteredData
                .Where(x => (surnameFilter == null) || (surnameFilter != null && x.Surname.ToUpper().Contains(surnameFilter.ToUpper())));
            foreach (var competitorModel in tmp)
            {
                data.Add(competitorModel);
            }
        }

        public void ReloadData()
        {
            unfilteredData.Clear();
            using (var session = sessionHelper.NewSession())
            {
                var query = session.QueryOver<Competitor>().List();
                foreach (var сompetitor in query)
                {
                    unfilteredData.Add(new CompetitorModel
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
            FilterData();
        }

        public void ReloadFocusedRow()
        {
            if (FocusedRow == null) return;
            using (var session = sessionHelper.NewSession())
            {
                var itemDb = session.Get<Competitor>(FocusedRow.IdСompetitor);
                var itemGrid = unfilteredData.FirstOrDefault(x => x.IdСompetitor == FocusedRow.IdСompetitor);
                if (itemDb == null || itemGrid == null) return;

                var index = unfilteredData.IndexOf(itemGrid);
                unfilteredData[index] = new CompetitorModel
                {
                    IdСompetitor = itemDb.IdСompetitor,
                    Surname = itemDb.Surname,
                    Name = itemDb.Name,
                    MiddleName = itemDb.MiddleName,
                    ContactPhone = itemDb.ContactPhone,
                    BirthDate = itemDb.BirthDate
                };
                FocusedRow = unfilteredData[index];
            }
            FilterData();
        }

        public void ReloadAfterAdd(int idCompetitor)
        {
            using (var session = sessionHelper.NewSession())
            {
                var itemDb = session.Get<Competitor>(idCompetitor);
                var itemGrid = new CompetitorModel
                {
                    IdСompetitor = itemDb.IdСompetitor,
                    Surname = itemDb.Surname,
                    Name = itemDb.Name,
                    MiddleName = itemDb.MiddleName,
                    ContactPhone = itemDb.ContactPhone,
                    BirthDate = itemDb.BirthDate
                };
                unfilteredData.Add(itemGrid);
                FocusedRow = itemGrid;
            }
            FilterData();
        }
    }
}
