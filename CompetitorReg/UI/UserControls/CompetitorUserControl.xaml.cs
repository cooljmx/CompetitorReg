using System.Windows.Input;
using CompetitorReg.Infrastructure.Abstract;
using CompetitorReg.Infrastructure.Concrete;
using CompetitorReg.Models.CompetitorModels;
using CompetitorReg.UI.Windows;
using DevExpress.Xpf.Bars;

namespace CompetitorReg.UI.UserControls
{
    public partial class CompetitorUserControl : IDocumentPanelManager
    {
        private readonly CompetitorListModel model;
        private readonly IResolver resolver;
        private readonly DocumentPanelManager documentPanelManager;

        public CompetitorListModel Model { get { return model; } }

        public string PanelTitle { get { return "Соискатели"; } }
        public int? PanelId { get; set; }


        public CompetitorUserControl(ISessionHelper sessionHelper, IResolver resolver, DocumentPanelManager documentPanelManager)
        {
            InitializeComponent();
            this.resolver = resolver;
            this.documentPanelManager = documentPanelManager;
            model = new CompetitorListModel(sessionHelper);
            model.ReloadData();
        }
        
        private void BarButtonAdd_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var card = resolver.CreateInstance<CompetitorCard>();
            card.ShowDialog();
            if (card.Model.IsSaved)
                Model.ReloadAfterAdd(card.Model.Data.Id);
        }

        private void BarButtonRemove_OnItemClick(object sender, ItemClickEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void DoModify()
        {
            var card = resolver.CreateInstance<CompetitorCard>();
            card.Model.LoadData(model.FocusedRow.Id);
            card.ShowDialog();
            if (card.Model.IsSaved)
                Model.ReloadFocusedRow();
        }

        private void BarButtonModify_OnItemClick(object sender, ItemClickEventArgs e)
        {
            DoModify();
        }

        private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!UiHelper.TestGridControlForRowCell(sender, e)) return;
            documentPanelManager.SelectPanel(typeof(CompetitorInterviewListUserControl), Model.FocusedRow.Id, Model.FocusedRow.ShortName, true);
        }

        private void BarButtonExport_OnItemClick(object sender, ItemClickEventArgs e)
        {
            Model.ExportToExcel();
        }
    }
}
