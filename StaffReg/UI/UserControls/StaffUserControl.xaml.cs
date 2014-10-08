using System.Windows.Controls;
using StaffReg.Tools;

namespace StaffReg.UI.UserControls
{
    public partial class StaffUserControl : UserControl, IDocumentPanelManager
    {
        public string PanelTitle { get { return "Персонал"; } }

        public StaffUserControl()
        {
            InitializeComponent();
        }
    }
}
