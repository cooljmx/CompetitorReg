using CompetitorReg.Entities;
using CompetitorReg.Infrastructure.Abstract;

namespace CompetitorReg.Models.PositionModels
{
    public class PositionCardModel : CommonCardModel<PositionModel>
    {
        public PositionCardModel(ISessionHelper sessionHelper) : base (sessionHelper)
        {
        }

        public override void LoadData(int id)
        {
            using (var session = sessionHelper.NewSession())
            {
                var position = session.Get<Position>(id);
                Data.Id = position.Id;
                Data.Name = position.Name;
            }
        }

        public override void SaveData()
        {
            using (var session = sessionHelper.NewSession())
            {
                var position = new Position
                {
                    Id = Data.Id,
                    Name = Data.Name
                };
                session.SaveOrUpdate(position);
                session.Flush();
                Data.Id = position.Id;
                IsSaved = true;
            }
        }
    }
}
