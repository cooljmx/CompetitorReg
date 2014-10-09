using CompetitorReg.Infrastructure.Abstract;
using CompetitorReg.Infrastructure.Concrete;
using CompetitorReg.UI.UserControls;
using DevExpress.Xpf.Bars;

namespace CompetitorReg
{
    public partial class MainWindow 
    {
        private readonly IResolver resolver = new Resolver();
        private readonly DocumentPanelManager panelManager;

        public MainWindow()
        {
            InitializeComponent();
            panelManager = new DocumentPanelManager(DockLayoutManager, DocumentContainer)
            {
                DependencyResolver = resolver
            };
        }

        private void BarButtonStaffList_OnItemClick(object sender, ItemClickEventArgs e)
        {
            panelManager.SelectPanel(typeof (CompetitorUserControl), true);
        }

        private void BarButtonPositionList_OnItemClick(object sender, ItemClickEventArgs e)
        {
            panelManager.SelectPanel(typeof (PositionUserControl), true);
        }
    }
}
