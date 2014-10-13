using System;
using System.Windows;
using System.Windows.Input;
using CompetitorReg.Infrastructure.Abstract;
using CompetitorReg.Infrastructure.Concrete;
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
            try
            {
                model.SaveData();
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddPositionButton_OnClick(object sender, RoutedEventArgs e)
        {
            Model.AddPosition();
        }

        private void RemovePositionButton_OnClick(object sender, RoutedEventArgs e)
        {
            Model.RemovePosition();
        }

        private void ExistsPositionGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!UiHelper.TestGridControlForRowCell(sender, e)) return;
            Model.AddPosition();
        }

        private void PositionGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!UiHelper.TestGridControlForRowCell(sender, e)) return;
            Model.RemovePosition();}
    }
}
