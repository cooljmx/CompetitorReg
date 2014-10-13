using System.Linq;
using System.Windows;
using CompetitorReg.Entities;
using CompetitorReg.Infrastructure.Abstract;
using FluentNHibernate.Utils;

namespace CompetitorReg.Models.InterviewModels
{
    public class InterviewCardModel : CommonCardModel<InterviewCardItemModel>
    {
        public InterviewCardModel(ISessionHelper sessionHelper) : base(sessionHelper)
        {
            using (var session = sessionHelper.NewSession())
            {
                Data.StatusRList = session.QueryOver<StatusR>().List();
                Data.InterviewStatusList = session.QueryOver<InterviewStatus>().List();
                Data.InterviewSecurityStatusList = session.QueryOver<InterviewSecurityStatus>().List();
                Data.ExistsPositionList = session.QueryOver<Position>().List();
            }
        }

        public override void LoadData(int id)
        {
            using (var session = sessionHelper.NewSession())
            {
                var query = session.Get<Interview>(id);
                Data.Id = query.Id;
                Data.Competitor = new Competitor // Todo выяснить почему прямым присваиванием работает через раз
                {
                    Id = query.Competitor.Id,
                    BirthDate = query.Competitor.BirthDate,
                    ContactPhone = query.Competitor.ContactPhone,
                    MiddleName = query.Competitor.MiddleName,
                    Name = query.Competitor.Name,
                    Surname = query.Competitor.Surname
                };
                Data.CompetitorComment = query.CompetitorComment;
                Data.Date = query.Date;
                Data.HrComment = query.HrComment;
                Data.InterviewSecurityStatus = Data.InterviewSecurityStatusList.FirstOrDefault(x => x.Id == query.InterviewSecurityStatus.Id);
                Data.InterviewStatus = Data.InterviewStatusList.FirstOrDefault(x => x.Id == query.InterviewStatus.Id);
                Data.TestResult = query.TestResult;
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
