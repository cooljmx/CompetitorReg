using System;
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
                Data.InterviewStatusList = session.QueryOver<InterviewStatus>().List();
                Data.InterviewSecurityStatusList = session.QueryOver<InterviewSecurityStatus>().List();
                foreach (var position in session.QueryOver<Position>().List())
                {
                    Data.ExistsPositionList.Add(position);   
                }
            }
        }

        public void Init(int competitorId)
        {
            using (var session = sessionHelper.NewSession())
            {
                Data.Competitor = session.Get<Competitor>(competitorId);
                Data.Date = DateTime.Now;
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
                if (query.InterviewSecurityStatus != null)
                    Data.InterviewSecurityStatus = Data.InterviewSecurityStatusList.FirstOrDefault(x => x.Id == query.InterviewSecurityStatus.Id);
                if (query.InterviewStatus != null)
                    Data.InterviewStatus = Data.InterviewStatusList.FirstOrDefault(x => x.Id == query.InterviewStatus.Id);
                if (query.StatusR != null)
                    Data.StatusR = Data.StatusRList.FirstOrDefault(x => x.Id == query.StatusR.Id);
                Data.TestResult = query.TestResult;
                foreach (var position in query.PositionList)
                {
                    var item = Data.ExistsPositionList.FirstOrDefault(x => x.Id == position.Id); // берем из листа существующих, чтобы иметь одинаковые ссылки
                    Data.PositionList.Add(item); 
                    Data.ExistsPositionList.Remove(item);
                }
            }
        }

        public override void SaveData()
        {
            using (var session = sessionHelper.NewSession())
            {
                var interview = new Interview
                {
                    Id = Data.Id,
                    Competitor = Data.Competitor,
                    CompetitorComment = Data.CompetitorComment,
                    Date = Data.Date,
                    HrComment = Data.HrComment,
                    InterviewSecurityStatus = Data.InterviewSecurityStatus,
                    PositionList = Data.PositionList,
                    InterviewStatus = Data.InterviewStatus,
                    StatusR = Data.StatusR,
                    TestResult = Data.TestResult
                };
                session.SaveOrUpdate(interview);
                session.Flush();
                Data.Id = interview.Id;
                IsSaved = true;
            }
        }

        public void AddPosition()
        {
            Data.PositionList.Add(Data.SelectedExistsPosition);
            Data.ExistsPositionList.Remove(Data.SelectedExistsPosition);
        }

        public void RemovePosition()
        {
            Data.ExistsPositionList.Add(Data.SelectedPosition);
            Data.PositionList.Remove(Data.SelectedPosition);
        }
    }
}
