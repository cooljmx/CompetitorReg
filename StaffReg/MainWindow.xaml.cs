using DevExpress.Xpf.Bars;
using StaffReg.Infrastructure.Abstract;
using StaffReg.Infrastructure.Concrete;
using StaffReg.UI.UserControls;

namespace StaffReg
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
            panelManager.SelectPanel(typeof (StaffUserControl), true);
        }
    }
}
