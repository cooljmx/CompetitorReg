using System;
using DevExpress.Xpf.Bars;
using Ninject;
using StaffReg.Infrastructure.Abstract;
using StaffReg.Infrastructure.Concrete;
using StaffReg.Models;

namespace StaffReg.UI.UserControls
{
    public partial class StaffUserControl : IDocumentPanelManager
    {
        private StaffListModel model;
        public StaffListModel Model { get { return model; } }

        public string PanelTitle { get { return "Персонал"; } }

        public IResolver DependencyResolver { get; set; }

        private ISessionHelper sessionHelper;

        [Inject]
        public ISessionHelper SessionHelper
        {
            get { return sessionHelper; }
            set
            {
                if (value != null && sessionHelper == null)
                {
                    model = new StaffListModel(value);
                }
                sessionHelper = value;
            }
        }

        public StaffUserControl()
        {
            InitializeComponent();
        }

        private void BarButtonAdd_OnItemClick(object sender, ItemClickEventArgs e)
        {
            
        }
    }
}
