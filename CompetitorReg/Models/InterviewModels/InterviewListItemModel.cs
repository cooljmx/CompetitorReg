using System;
using CompetitorReg.Infrastructure.Concrete;

namespace CompetitorReg.Models.InterviewModels
{
    public class InterviewListItemModel : VirtualNotifyPropertyChanged
    {
        private int id;
        private int idCompetitor;
        //private string competitorName;
        private string statusR;
        private string hrComment;
        private DateTime date;
        private string testResult;
        private string interviewStatus;
        private string interviewSecurityStatus;
        private string competitorComment;
        private string positions;

        public int Id { get { return id; } set { id = value; NotifyPropertyChanged("Id"); } }
        public int IdCompetitor { get { return idCompetitor; } set { idCompetitor = value; NotifyPropertyChanged("IdCompetitor"); } }
        //public string CompetitorName { get { return competitorName; } set { competitorName = value; NotifyPropertyChanged("CompetitorName"); } }
        public string StatusR { get { return statusR; } set { statusR = value; NotifyPropertyChanged("StatusR"); } }
        public string HrComment { get { return hrComment; } set { hrComment = value; NotifyPropertyChanged("HrComment"); } }
        public DateTime Date { get { return date; } set { date = value; NotifyPropertyChanged("Date"); } }
        public string TestResult { get { return testResult; } set { testResult = value; NotifyPropertyChanged("TestResult"); } }
        public string InterviewStatus { get { return interviewStatus; } set { interviewStatus = value; NotifyPropertyChanged("InterviewStatus"); } }
        public string InterviewSecurityStatus { get { return interviewSecurityStatus; } set { interviewSecurityStatus = value; NotifyPropertyChanged("InterviewSecurityStatus"); } }
        public string CompetitorComment { get { return competitorComment; } set { competitorComment = value; NotifyPropertyChanged("CompetitorComment"); } }
        public string Positions { get { return positions; } set { positions = value; NotifyPropertyChanged("Positions"); } }
    }
}
