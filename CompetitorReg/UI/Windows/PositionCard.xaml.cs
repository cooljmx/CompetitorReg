using System;
using System.Windows;
using CompetitorReg.Infrastructure.Abstract;
using CompetitorReg.Models.PositionModels;

namespace CompetitorReg.UI.Windows
{
    public partial class PositionCard
    {
        private readonly PositionCardModel model;

        public PositionCardModel Model { get { return model; } }
        public PositionCard(ISessionHelper sessionHelper)
        {
            InitializeComponent();
            model = new PositionCardModel(sessionHelper);
        }

        private void SaveButton_OnClickOnClick(object sender, RoutedEventArgs e)
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

        private void CancelButton_OnClickon_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
