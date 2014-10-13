using System.Windows;
using CompetitorReg.Infrastructure.Abstract;
using CompetitorReg.Models.InterviewModels;

namespace CompetitorReg.UI.Windows
{
    public partial class InterviewCard
    {
        private readonly InterviewCardModel model;

        public InterviewCardModel Model { get { return model; } }

        public InterviewCard(ISessionHelper sessionHelper)
        {
            InitializeComponent();
            model = new InterviewCardModel(sessionHelper);
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void AddPositionButton_OnClick(object sender, RoutedEventArgs e)
        {
            Model.AddPosition();
        }

        private void RemovePositionButton_OnClick(object sender, RoutedEventArgs e)
        {
            Model.RemovePosition();
        }
    }
}
