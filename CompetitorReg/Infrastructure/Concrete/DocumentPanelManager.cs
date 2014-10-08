using System;
using System.Linq;
using CompetitorReg.Infrastructure.Abstract;
using DevExpress.Xpf.Docking;

namespace CompetitorReg.Infrastructure.Concrete
{
    class DocumentPanelManager
    {
        private readonly DockLayoutManager manager;
        private readonly DocumentGroup baseGroup;
        public IResolver DependencyResolver { get; set; }

        public DocumentPanelManager(DockLayoutManager aManager, DocumentGroup aBaseGroup)
        {
            manager = aManager;
            baseGroup = aBaseGroup;
        }

        public DocumentPanel SelectPanel(Type controlType, bool autoActivate = false)
        {
            DocumentPanel panel = null;
            if (controlType.GetInterfaces().Contains(typeof(IDocumentPanelManager)))
            {
                // Тип реализует интерфейс
                string controlId = controlType.FullName;
                foreach (
                    var baseLayoutItem in
                        baseGroup.Items.Where(
                            x => x is DocumentPanel && (x as DocumentPanel).Control is IDocumentPanelManager))
                {
                    var localpanel = (DocumentPanel)baseLayoutItem;
                    var panelControlId = localpanel.Control.GetType().ToString();
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
                    //panel.Content = DependencyResolver.CreateInstance<controlType>();
                    #endregion
                    var documentPanelControl = panel.Control as IDocumentPanelManager;
                    if (documentPanelControl != null)
                    {
                        panel.Caption = documentPanelControl.PanelTitle;
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
    }
}
