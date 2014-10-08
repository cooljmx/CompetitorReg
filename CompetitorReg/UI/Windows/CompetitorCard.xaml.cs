using System;
using System.Windows;
using CompetitorReg.Infrastructure.Abstract;
using CompetitorReg.Models;

namespace CompetitorReg.UI.Windows
{
    /// <summary>
    /// Interaction logic for CompetitorCard.xaml
    /// </summary>
    public partial class CompetitorCard
    {
        private readonly ISessionHelper sessionHelper;
        private readonly CompetitorCardModel model;

        public CompetitorCardModel Model { get { return model; } }
        public CompetitorCard(ISessionHelper sessionHelper)
        {
            InitializeComponent();
            this.sessionHelper = sessionHelper;
            model = new CompetitorCardModel(sessionHelper);
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
    }
}
