using System;
using System.Windows.Input;
using CompetitorReg.Infrastructure.Abstract;
using CompetitorReg.Infrastructure.Concrete;
using CompetitorReg.Models.PositionModels;
using CompetitorReg.UI.Windows;
using DevExpress.Xpf.Bars;

namespace CompetitorReg.UI.UserControls
{
    public partial class PositionUserControl : IDocumentPanelManager
    {
        private readonly IResolver resolver;
        private readonly PositionListModel model;

        public string PanelTitle { get { return "Должности"; } }
        public int? PanelId { get; set; }
        public PositionListModel Model { get { return model; } }

        public PositionUserControl(ISessionHelper sessionHelper, IResolver resolver)
        {
            InitializeComponent();
            this.resolver = resolver;
            model = new PositionListModel(sessionHelper);
            model.ReloadData();
        }

        private void BarButtonAdd_OnItemClickmClick(object sender, ItemClickEventArgs e)
        {
            var card = resolver.CreateInstance<PositionCard>();
            card.ShowDialog();
            if (card.Model.IsSaved)
                Model.ReloadAfterAdd(card.Model.Data.Id);
        }

        private void BarButtonModify_OnItemClickModify_OnItemClick(object sender, ItemClickEventArgs e)
        {
            DoModify();
        }

        private void BarButtonRemove_OnItemClickttonRemove_OnItemClick(object sender, ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Control_OnMouseDoubleClickoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!UiHelper.TestGridControlForRowCell(sender, e)) return;
            DoModify();
        }

        private void DoModify()
        {
            var card = resolver.CreateInstance<PositionCard>();
            card.Model.LoadData(model.FocusedRow.Id);
            card.ShowDialog();
            if (card.Model.IsSaved)
                Model.ReloadFocusedRow();
        }
    }
}
