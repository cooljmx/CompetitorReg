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
                        StatusR = interview.StatusR == null ? null : interview.StatusR.Name,
                        HrComment = interview.HrComment,
                        Date = interview.Date,
                        TestResult = interview.TestResult,
                        InterviewStatus = interview.InterviewStatus == null ? null : interview.InterviewStatus.Name,
                        InterviewSecurityStatus = interview.InterviewSecurityStatus == null ? null : interview.InterviewSecurityStatus.Name,
                        CompetitorComment = interview.CompetitorComment,
                        Positions = interview.PositionList.Count == 0 ? string.Empty : interview.PositionList.Select(x => x.Name) .OrderBy(x => x) .Aggregate((a, b) => a + "," + b) 
                    });
                }
            }
        }

        public override void ReloadFocusedRow()
        {
            if (FocusedRow == null) return;
            using (var session = sessionHelper.NewSession())
            {
                var itemDb = session.Get<Interview>(FocusedRow.Id);
                var itemGrid = Data.FirstOrDefault(x => x.Id == FocusedRow.Id);
                if (itemDb == null || itemGrid == null) return;

                var index = Data.IndexOf(itemGrid);
                Data[index] = new InterviewListItemModel
                {
                    Id = itemDb.Id,
                    IdCompetitor = competitorId,
                    StatusR = itemDb.StatusR == null ? null : itemDb.StatusR.Name,
                    HrComment = itemDb.HrComment,
                    Date = itemDb.Date,
                    TestResult = itemDb.TestResult,
                    InterviewStatus = itemDb.InterviewStatus == null ? null : itemDb.InterviewStatus.Name,
                    InterviewSecurityStatus = itemDb.InterviewSecurityStatus == null ? null : itemDb.InterviewSecurityStatus.Name,
                    CompetitorComment = itemDb.CompetitorComment,
                    Positions = itemDb.PositionList.Count == 0 ? string.Empty : itemDb.PositionList.Select(x => x.Name).OrderBy(x => x).Aggregate((a, b) => a + "," + b)
                };
                FocusedRow = Data[index];
            }
        }

        public override void ReloadAfterAdd(int id)
        {
            using (var session = sessionHelper.NewSession())
            {
                var itemDb = session.Get<Interview>(id);
                var itemGrid = new InterviewListItemModel
                {
                    Id = itemDb.Id,
                    IdCompetitor = competitorId,
                    StatusR = itemDb.StatusR == null ? null : itemDb.StatusR.Name,
                    HrComment = itemDb.HrComment,
                    Date = itemDb.Date,
                    TestResult = itemDb.TestResult,
                    InterviewStatus = itemDb.InterviewStatus == null ? null : itemDb.InterviewStatus.Name,
                    InterviewSecurityStatus = itemDb.InterviewSecurityStatus == null ? null : itemDb.InterviewSecurityStatus.Name,
                    CompetitorComment = itemDb.CompetitorComment,
                    Positions = itemDb.PositionList.Count == 0 ? string.Empty : itemDb.PositionList.Select(x => x.Name).OrderBy(x => x).Aggregate((a, b) => a + "," + b)
                };
                Data.Add(itemGrid);
                FocusedRow = itemGrid;
            }
        }
    }
}
