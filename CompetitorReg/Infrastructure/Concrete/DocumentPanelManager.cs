using System;
using System.Linq;
using CompetitorReg.Infrastructure.Abstract;
using DevExpress.Xpf.Docking;

namespace CompetitorReg.Infrastructure.Concrete
{
    public class DocumentPanelManager
    {
        private readonly DockLayoutManager manager;
        private readonly DocumentGroup baseGroup;
        public IResolver DependencyResolver { get; set; }

        public DocumentPanelManager(DockLayoutManager aManager, DocumentGroup aBaseGroup)
        {
            manager = aManager;
            baseGroup = aBaseGroup;
        }

        public DocumentPanel SelectPanel(Type controlType, int? panelId = null, string panelTitle = null, bool autoActivate = false)
        {
            DocumentPanel panel = null;
            if (controlType.GetInterfaces().Contains(typeof(IDocumentPanelManager)))
            {
                // Тип реализует интерфейс
                var controlId = panelId==null ? controlType.FullName : controlType.FullName + panelId;
                foreach (var baseLayoutItem in baseGroup.Items.Where(x => x is DocumentPanel && (x as DocumentPanel).Control is IDocumentPanelManager))
                {
                    var localpanel = (DocumentPanel)baseLayoutItem;
                    var panelControlId = localpanel.Control.GetType().FullName + ((IDocumentPanelManager)localpanel.Control).PanelId;
                    if (panelControlId == controlId)
                    {
                        panel = localpanel;
                        break;
                    }
                }

                if (panel == null)
                {
                    // Не найден - создать
                    panel = manager.DockController.AddDocumentPanel(baseGroup);

                    #region generic
                    var method = typeof (IResolver).GetMethod("CreateInstance");
                    method = method.MakeGenericMethod(controlType);
                    panel.Content = method.Invoke(DependencyResolver, new object[0]);
                    #endregion
                    var documentPanelControl = panel.Control as IDocumentPanelManager;
                    if (documentPanelControl != null)
                    {
                        documentPanelControl.PanelId = panelId;
                        panel.Caption = panelTitle ?? documentPanelControl.PanelTitle;
                    }
                }
                if (autoActivate)
                    manager.Activate(panel);
            }
            else
            {
                // Тип не реализует интерфейс
                panel = manager.DockController.AddDocumentPanel(baseGroup);
                panel.Content = Activator.CreateInstance(controlType);
                if (autoActivate)
                    manager.Activate(panel);
            }
            return
                panel;            
        }
    }

    interface IDocumentPanelManager
    {
        string PanelTitle { get; }
        int? PanelId { get; set; }
    }
}
