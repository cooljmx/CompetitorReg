using Ninject;
using StaffReg.Infrastructure.Abstract;
using StaffReg.Infrastructure.Concrete;

namespace StaffReg.UI.UserControls
{
    public partial class StaffUserControl : IDocumentPanelManager
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
