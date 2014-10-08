using CompetitorReg.Entities;
using CompetitorReg.Infrastructure.Abstract;

namespace CompetitorReg.Models
{
    public class CompetitorCardModel
    {
        private readonly ISessionHelper sessionHelper;
        private readonly CompetitorModel data;
        public CompetitorModel Data { get { return data; } }
        public bool IsSaved { get; set; }

        public CompetitorCardModel(ISessionHelper sessionHelper)
        {
            this.sessionHelper = sessionHelper;
            data = new CompetitorModel();
            IsSaved = false;
        }

        public void LoadData(int idCompetitor)
        {
            using (var session = sessionHelper.NewSession())
            {
                var competitor = session.Get<Competitor>(idCompetitor);
                Data.IdСompetitor = competitor.IdСompetitor;
                Data.Surname = competitor.Surname;
                Data.Name = competitor.Name;
                Data.MiddleName = competitor.MiddleName;
                Data.ContactPhone = competitor.ContactPhone;
                Data.BirthDate = competitor.BirthDate;
            }
        }

        public void SaveData()
        {
            using (var session = sessionHelper.NewSession())
            {
                var competitor = new Competitor
                {
                    IdСompetitor = data.IdСompetitor,
                    Surname = data.Surname,
                    Name = data.Name,
                    MiddleName = data.MiddleName,
                    ContactPhone = data.ContactPhone,
                    BirthDate = data.BirthDate
                };
                session.SaveOrUpdate(competitor);
                session.Flush();
                Data.IdСompetitor = competitor.IdСompetitor;
                IsSaved = true;
            }
        }
    }
}
