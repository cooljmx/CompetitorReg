using System.Collections.Generic;
using CompetitorReg.Entities;
using CompetitorReg.Infrastructure.Concrete;
using Remotion.Linq.Collections;

namespace CompetitorReg.Models.InterviewModels
{
    public class InterviewCardItemModel : VirtualNotifyPropertyChanged
    {
        private int id;
        private StatusR statusR;
        private Position selectedPosition;
        private Position selectedExistsPosition;
        private readonly ObservableCollection<Position> positionList = new ObservableCollection<Position>();

        public int Id { get { return id; } set { id = value; NotifyPropertyChanged("Id"); } }
        public StatusR StatusR { get { return statusR; } set { statusR = value; NotifyPropertyChanged("StatusR"); } }
        public IList<StatusR> StatusRList { get; set; }

        public Position SelectedPosition { get { return selectedPosition; } set { selectedPosition = value; NotifyPropertyChanged("SelectedPosition"); } }
        public Position SelectedExistsPosition { get { return selectedExistsPosition; } set { selectedExistsPosition = value; NotifyPropertyChanged("SelectedExistsPosition"); } }
        public ObservableCollection<Position> PositionList { get { return positionList; } }
        public IList<Position> ExistsPositionList { get; set; }
    }
}
