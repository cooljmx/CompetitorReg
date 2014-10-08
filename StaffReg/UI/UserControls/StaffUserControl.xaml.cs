using System.Windows.Controls;
using Ninject;
using StaffReg.Infrastructure.Abstract;
using StaffReg.Tools;

namespace StaffReg.UI.UserControls
{
    public partial class StaffUserControl : UserControl, IDocumentPanelManager
    {
        public string PanelTitle { get { return "Персонал"; } }

        public IResolver DependencyResolver { get; set; }

        [Inject]
        public ISessionHelper SessionHelper { get; set; }

        public StaffUserControl()
        {
            InitializeComponent();
        }
    }
}
