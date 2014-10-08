using System.Windows.Controls;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Docking.VisualElements;
using StaffReg.Infrastructure.Abstract;
using StaffReg.Infrastructure.Concrete;
using StaffReg.Tools;
using StaffReg.UI.UserControls;

namespace StaffReg
{
    public partial class MainWindow 
    {
        private IResolver resolver = new Resolver();
        private readonly DocumentPanelManager panelManager;

        public MainWindow()
        {
            InitializeComponent();
            panelManager = new DocumentPanelManager(DockLayoutManager, DocumentContainer);
            panelManager.DependencyResolver = resolver;
        }

        private void BarButtonStaffList_OnItemClick(object sender, ItemClickEventArgs e)
        {
            //   DocumentPanelManager.SelectPanel(DockLayoutManager, DocumentContainer, typeof(StaffUserControl), true);
            panelManager.SelectPanel(typeof (StaffUserControl), true);
        }
    }
}
