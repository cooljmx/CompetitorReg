using System;
using CompetitorReg.Infrastructure.Concrete;

namespace CompetitorReg.Models.InterviewModels
{
    public class InterviewModel : VirtualNotifyPropertyChanged
    {
        private int id;
        private int idCompetitor;
        private int idStatusR;
        private string statusR;
        private string hrComment;
        private DateTime date;
        private string testResult;
        private int idInterviewStatus;
        private string interviewStatus;
        private int idInterviewSecurityStatus;
        private string interviewSecurityStatus;
        private string competitorComment;
        private string positions;

        public int Id { get { return id; } set { id = value; NotifyPropertyChanged("Id"); } }
        public int IdCompetitor { get { return idCompetitor; } set { idCompetitor = value; NotifyPropertyChanged("IdCompetitor"); } }
        public int IdStatusR { get { return idStatusR; } set { idStatusR = value; NotifyPropertyChanged("IdStatusR"); } }
        public string StatusR { get { return statusR; } set { statusR = value; NotifyPropertyChanged("StatusR"); } }
        public string HrComment { get { return hrComment; } set { hrComment = value; NotifyPropertyChanged("HrComment"); } }
        public DateTime Date { get { return date; } set { date = value; NotifyPropertyChanged("Date"); } }
        public string TestResult { get { return testResult; } set { testResult = value; NotifyPropertyChanged("TestResult"); } }
        public int IdInterviewStatus { get { return idInterviewStatus; } set { idInterviewStatus = value; NotifyPropertyChanged("IdInterviewStatus"); } }
        public string InterviewStatus { get { return interviewStatus; } set { interviewStatus = value; NotifyPropertyChanged("InterviewStatus"); } }
        public int IdInterviewSecurityStatus { get { return idInterviewSecurityStatus; } set { idInterviewSecurityStatus = value; NotifyPropertyChanged("IdInterviewSecurityStatus"); } }
        public string InterviewSecurityStatus { get { return interviewSecurityStatus; } set { interviewSecurityStatus = value; NotifyPropertyChanged("InterviewSecurityStatus"); } }
        public string CompetitorComment { get { return competitorComment; } set { competitorComment = value; NotifyPropertyChanged("CompetitorComment"); } }
        public string Positions { get { return positions; } set { positions = value; NotifyPropertyChanged("Positions"); } }
    }
}
