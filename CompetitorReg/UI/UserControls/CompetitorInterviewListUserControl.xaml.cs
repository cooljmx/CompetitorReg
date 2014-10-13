using System;
using System.Windows.Input;
using CompetitorReg.Infrastructure.Abstract;
using CompetitorReg.Infrastructure.Concrete;
using CompetitorReg.Models.InterviewModels;
using CompetitorReg.UI.Windows;
using DevExpress.Xpf.Bars;

namespace CompetitorReg.UI.UserControls
{
    public partial class CompetitorInterviewListUserControl : IDocumentPanelManager
    {
        private readonly ISessionHelper sessionHelper;
        private readonly IResolver resolver;
        private readonly CompetitorInterviewListModel model;
        private int? panelId;

        public string PanelTitle { get { return "CompetitorInterviewList"; } }

        public int? PanelId { get { return panelId; } set { panelId = value; if (value!=null) model.Init((int)value); } }

        public CompetitorInterviewListModel Model { get { return model; } }

        public CompetitorInterviewListUserControl(ISessionHelper sessionHelper, IResolver resolver)
        {
            InitializeComponent();
            this.sessionHelper = sessionHelper;
            this.resolver = resolver;
            model = new CompetitorInterviewListModel(sessionHelper);
        }

        private void BarButtonAdd_OnItemClickdd_OnItemClick(object sender, ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BarButtonModify_OnItemClickButtonModify_OnItemClick(object sender, ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BarButtonRemove_OnItemClicknRemove_OnItemClick(object sender, ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Control_OnMouseDoubleClickMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!UiHelper.TestGridControlForRowCell(sender, e)) return;
            DoModify();
        }

        private void DoModify()
        {
            var card = resolver.CreateInstance<InterviewCard>();
            card.Model.LoadData(Model.FocusedRow.Id);
            card.ShowDialog();
        }
    }
}
