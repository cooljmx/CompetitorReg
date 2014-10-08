using System.Windows;
using DevExpress.Xpf.Bars;
using StaffReg.Infrastructure.Abstract;
using StaffReg.Infrastructure.Concrete;
using StaffReg.Models;

namespace StaffReg.UI.UserControls
{
    public partial class StaffUserControl : IDocumentPanelManager
    {
        private readonly StaffListModel model;
        private readonly ISessionHelper sessionHelper;
        private readonly IResolver resolver;

        public StaffListModel Model { get { return model; } }

        public string PanelTitle { get { return "Персонал"; } }


        public StaffUserControl(ISessionHelper sessionHelper, IResolver resolver)
        {
            InitializeComponent();
            this.sessionHelper = sessionHelper;
            this.resolver = resolver;
            model = new StaffListModel(sessionHelper);
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
    }
}
