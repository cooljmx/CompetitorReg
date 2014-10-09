using CompetitorReg.Infrastructure.Abstract;

namespace CompetitorReg.Models.CompetitorModels
{
    public class CompetitorCardModel : CommonCardModel<CompetitorModel>
    {
        public CompetitorCardModel(ISessionHelper sessionHelper) : base(sessionHelper)
        {
        }

        public override void LoadData(int id)
        {
            using (var session = sessionHelper.NewSession())
            {
                var competitor = session.Get<Entities.Competitor>(id);
                Data.Id = competitor.Id;
                Data.Surname = competitor.Surname;
                Data.Name = competitor.Name;
                Data.MiddleName = competitor.MiddleName;
                Data.ContactPhone = competitor.ContactPhone;
                Data.BirthDate = competitor.BirthDate;
            }
        }

        public override void SaveData()
        {
            using (var session = sessionHelper.NewSession())
            {
                var competitor = new Entities.Competitor
                {
                    Id = Data.Id,
                    Surname = Data.Surname,
                    Name = Data.Name,
                    MiddleName = Data.MiddleName,
                    ContactPhone = Data.ContactPhone,
                    BirthDate = Data.BirthDate
                };
                session.SaveOrUpdate(competitor);
                session.Flush();
                Data.Id = competitor.Id;
                IsSaved = true;
            }
        }
    }
}
