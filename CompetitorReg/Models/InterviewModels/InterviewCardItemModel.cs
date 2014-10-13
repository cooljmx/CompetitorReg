using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using CompetitorReg.Entities;
using CompetitorReg.Infrastructure.Concrete;


namespace CompetitorReg.Models.InterviewModels
{
    public class InterviewCardItemModel : VirtualNotifyPropertyChanged
    {
        private int id;
        private StatusR statusR;
        private Competitor competitor;
        private string hrComment;
        private DateTime date;
        private string testResult;
        private InterviewStatus interviewStatus;
        private string competitorComment;
        private InterviewSecurityStatus interviewSecurityStatus;
        private Position selectedPosition;
        private Position selectedExistsPosition;
        private readonly ObservableCollection<Position> positionList = new ObservableCollection<Position>();

        public int Id { get { return id; } set { id = value; NotifyPropertyChanged("Id"); } }
        public StatusR StatusR { get { return statusR; } set { statusR = value; NotifyPropertyChanged("StatusR"); } }
        public IList<StatusR> StatusRList { get; set; }

        public Competitor Competitor
        {
            get
            {
                return competitor;
            }
            set
            {
                competitor = value;
                NotifyPropertyChanged("Competitor");
                NotifyPropertyChanged("CompetitorName");
            }
        }

        public string CompetitorName
        {
            get
            {
                return Competitor.MiddleName == null
                    ? string.Format("{0} {1}", Competitor.Surname, Competitor.Name)
                    : string.Format("{0} {1} {2} ", Competitor.Surname, Competitor.Name, Competitor.MiddleName);
            }
        }
        public string HrComment { get { return hrComment; } set { hrComment = value; NotifyPropertyChanged("HrComment"); } }
        public DateTime Date { get { return date; } set { date = value; NotifyPropertyChanged("Date"); } }
        public string TestResult { get { return testResult; } set { testResult = value; NotifyPropertyChanged("TestResult"); } }
        public InterviewStatus InterviewStatus { get { return interviewStatus; } set { interviewStatus = value; NotifyPropertyChanged("InterviewStatus"); } }
        public IList<InterviewStatus> InterviewStatusList { get; set; }
        public string CompetitorComment { get { return competitorComment; } set { competitorComment = value; NotifyPropertyChanged("CompetitorComment"); } }
        public InterviewSecurityStatus InterviewSecurityStatus { get { return interviewSecurityStatus; } set { interviewSecurityStatus = value; NotifyPropertyChanged("InterviewSecurityStatus"); } }
        public IList<InterviewSecurityStatus> InterviewSecurityStatusList { get; set; }

        public Position SelectedPosition { get { return selectedPosition; } set { selectedPosition = value; NotifyPropertyChanged("SelectedPosition"); } }
        public Position SelectedExistsPosition { get { return selectedExistsPosition; } set { selectedExistsPosition = value; NotifyPropertyChanged("SelectedExistsPosition"); } }
        public ObservableCollection<Position> PositionList { get { return positionList; } }
        public IList<Position> ExistsPositionList { get; set; }
    }
}
