using DevExpress.Xpf.Bars;
using StaffReg.Tools;
using StaffReg.UI.UserControls;

namespace StaffReg
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BarButtonStaffList_OnItemClick(object sender, ItemClickEventArgs e)
        {
            DocumentPanelManager.SelectPanel(DockLayoutManager, DocumentContainer, typeof(StaffUserControl), true);
        }
    }
}
