using System.Linq;
using CompetitorReg.Entities;
using CompetitorReg.Infrastructure.Abstract;

namespace CompetitorReg.Models.InterviewModels
{
    public class InterviewCardModel : CommonCardModel<InterviewCardItemModel>
    {
        public InterviewCardModel(ISessionHelper sessionHelper) : base(sessionHelper)
        {
            using (var session = sessionHelper.NewSession())
            {
                Data.StatusRList = session.QueryOver<StatusR>().List();
                Data.ExistsPositionList = session.QueryOver<Position>().List();
            }
        }

        public override void LoadData(int id)
        {
            using (var session = sessionHelper.NewSession())
            {
                var query = session.Get<Interview>(id);
                Data.Id = query.Id;
                Data.StatusR = Data.StatusRList.FirstOrDefault(x => x.Id == query.Id);
                foreach (var position in query.PositionList)
                {
                    Data.PositionList.Add(position);
                }
            }
        }

        public override void SaveData()
        {
        }

        public void AddPosition()
        {
            Data.PositionList.Add(Data.SelectedExistsPosition);
        }

        public void RemovePosition()
        {
            Data.PositionList.Remove(Data.SelectedPosition);
        }
    }
}
