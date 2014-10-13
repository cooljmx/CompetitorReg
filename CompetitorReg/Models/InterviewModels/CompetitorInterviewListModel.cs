using System.Linq;
using CompetitorReg.Entities;
using CompetitorReg.Infrastructure.Abstract;

namespace CompetitorReg.Models.InterviewModels
{
    public class CompetitorInterviewListModel : CommonListModel<InterviewListItemModel>
    {
        private int competitorId;

        public CompetitorInterviewListModel(ISessionHelper sessionHelper) : base(sessionHelper)
        {
        }

        public void Init(int id)
        {
            competitorId = id;
            ReloadData();
        }
        
        public override sealed void ReloadData()
        {
            Data.Clear();
            using (var session = sessionHelper.NewSession())
            {
                var query = session.QueryOver<Interview>().Where(x => x.Competitor.Id == competitorId).List();
                foreach (var interview in query)
                {
                    Data.Add(new InterviewListItemModel
                    {
                        Id = interview.Id,
                        IdCompetitor = competitorId,
                        //CompetitorName = string.Format("{0} {1} {2}", interview.Competitor.Surname, interview.Competitor.Name, interview.Competitor.MiddleName),
                        StatusR = interview.StatusR.Name,
                        HrComment = interview.HrComment,
                        Date = interview.Date,
                        TestResult = interview.TestResult,
                        InterviewStatus = interview.InterviewStatus.Name,
                        InterviewSecurityStatus = interview.InterviewSecurityStatus.Name,
                        CompetitorComment = interview.CompetitorComment,
                        Positions = interview.PositionList.Select(x => x.Name).Aggregate((a, b) => a + "," + b)
                    });
                }
            }
        }

        public override void ReloadFocusedRow()
        {
        }

        public override void ReloadAfterAdd(int id)
        {
        }
    }
}
