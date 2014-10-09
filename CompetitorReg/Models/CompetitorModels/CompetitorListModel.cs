using System.Collections.ObjectModel;
using System.Linq;
using CompetitorReg.Entities;
using CompetitorReg.Infrastructure.Abstract;

namespace CompetitorReg.Models.CompetitorModels
{
    public class CompetitorListModel : CommonListModel<CompetitorModel>
    {
        private string surnameFilter;
        protected readonly ObservableCollection<CompetitorModel> unfilteredData = new ObservableCollection<CompetitorModel>();

        public string SurnameFilter { get { return surnameFilter; } set { surnameFilter = value; NotifyPropertyChanged("SurnameFilter"); FilterData(); } }

        public CompetitorListModel(ISessionHelper sessionHelper) : base(sessionHelper)
        {
        }

        private void FilterData()
        {
            Data.Clear();
            var tmp = unfilteredData
                .Where(x => (surnameFilter == null) || (surnameFilter != null && x.Surname.ToUpper().Contains(surnameFilter.ToUpper())));
            foreach (var competitorModel in tmp)
            {
                Data.Add(competitorModel);
            }
        }

        public override void ReloadData()
        {
            unfilteredData.Clear();
            using (var session = sessionHelper.NewSession())
            {
                var query = session.QueryOver<Competitor>().List();
                foreach (var competitor in query)
                {
                    unfilteredData.Add(new CompetitorModel
                    {
                        Id = competitor.Id,
                        Surname = competitor.Surname,
                        Name = competitor.Name,
                        MiddleName = competitor.MiddleName,
                        ContactPhone = competitor.ContactPhone,
                        BirthDate = competitor.BirthDate
                    });
                }
            }
            FilterData();
        }

        public override void ReloadFocusedRow()
        {
            if (FocusedRow == null) return;
            using (var session = sessionHelper.NewSession())
            {
                var itemDb = session.Get<Competitor>(FocusedRow.Id);
                var itemGrid = unfilteredData.FirstOrDefault(x => x.Id == FocusedRow.Id);
                if (itemDb == null || itemGrid == null) return;

                var index = unfilteredData.IndexOf(itemGrid);
                unfilteredData[index] = new CompetitorModel
                {
                    Id = itemDb.Id,
                    Surname = itemDb.Surname,
                    Name = itemDb.Name,
                    MiddleName = itemDb.MiddleName,
                    ContactPhone = itemDb.ContactPhone,
                    BirthDate = itemDb.BirthDate
                };
                FilterData();
                FocusedRow = unfilteredData[index]; // must be after filter
            }
        }

        public override void ReloadAfterAdd(int id)
        {
            using (var session = sessionHelper.NewSession())
            {
                var itemDb = session.Get<Competitor>(id);
                var itemGrid = new CompetitorModel
                {
                    Id = itemDb.Id,
                    Surname = itemDb.Surname,
                    Name = itemDb.Name,
                    MiddleName = itemDb.MiddleName,
                    ContactPhone = itemDb.ContactPhone,
                    BirthDate = itemDb.BirthDate
                };
                unfilteredData.Add(itemGrid);
                FilterData();
                FocusedRow = itemGrid; // must be after filter
            }
        }
    }
}
