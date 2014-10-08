using System.Windows;
using System.Windows.Input;
using CompetitorReg.Infrastructure.Abstract;
using CompetitorReg.Infrastructure.Concrete;
using CompetitorReg.Models;
using CompetitorReg.UI.Windows;
using DevExpress.Xpf.Bars;

namespace CompetitorReg.UI.UserControls
{
    public partial class CompetitorUserControl : IDocumentPanelManager
    {
        private readonly CompetitorListModel model;
        private readonly ISessionHelper sessionHelper;
        private readonly IResolver resolver;

        public CompetitorListModel Model { get { return model; } }

        public string PanelTitle { get { return "Персонал"; } }


        public CompetitorUserControl(ISessionHelper sessionHelper, IResolver resolver)
        {
            InitializeComponent();
            this.sessionHelper = sessionHelper;
            this.resolver = resolver;
            model = new CompetitorListModel(sessionHelper);
            model.ReloadData();
        }

        private void BarButtonAdd_OnItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void StaffUserControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            //DependencyResolver.Inject(model);
            //Model.ReloadData();
        }

        private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!UiHelper.TestGridControlForRowCell(sender, e)) return;
            var card = resolver.CreateInstance<CompetitorCard>();
            card.ShowDialog();
        }
    }
}
