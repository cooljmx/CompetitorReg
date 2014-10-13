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
                Data.BirthPlace = competitor.BirthPlace;
                Data.PassportSerial = competitor.PassportSerial;
                Data.PassportNumber = competitor.PassportNumber;
                Data.IssuingAuthority = competitor.IssuingAuthority;
                Data.DepartmentCode = competitor.DepartmentCode;
                Data.IssueDate = competitor.IssueDate;
                Data.Nee = competitor.Nee;
                Data.IncorporationPlace = competitor.IncorporationPlace;
                Data.ResidencePlace = competitor.ResidencePlace;
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
                    BirthDate = Data.BirthDate,
                    BirthPlace = Data.BirthPlace,
                    PassportNumber = Data.PassportNumber,
                    PassportSerial = Data.PassportSerial,
                    IssuingAuthority = Data.IssuingAuthority,
                    DepartmentCode = Data.DepartmentCode,
                    IssueDate = Data.IssueDate,
                    Nee = Data.Nee,
                    IncorporationPlace = Data.IncorporationPlace,
                    ResidencePlace = Data.ResidencePlace
                };
                session.SaveOrUpdate(competitor);
                session.Flush();
                Data.Id = competitor.Id;
                IsSaved = true;
            }
        }
    }
}
