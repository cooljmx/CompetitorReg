using System;
using System.Linq;
using DevExpress.Xpf.Docking;
using StaffReg.Infrastructure.Abstract;

namespace StaffReg.Infrastructure.Concrete
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
                    panel.Content = Activator.CreateInstance(controlType);
                    var documentPanelControl = panel.Control as IDocumentPanelManager;
                    if (documentPanelControl != null)
                    {
                        panel.Caption = documentPanelControl.PanelTitle;
                        documentPanelControl.DependencyResolver = DependencyResolver;
                        if (DependencyResolver != null)
                            DependencyResolver.Inject(panel.Control);    
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

        /*
        public static DocumentPanel SelectPanel(DockLayoutManager manager, DocumentGroup baseGroup, Type controlType, bool autoActivate = false)
        {
            DocumentPanel panel = null;
            if (controlType.GetInterfaces().Contains(typeof (IDocumentPanelManager)))
            {
                // Тип реализует интерфейс
                string controlId = controlType.FullName;
                foreach (
                    var baseLayoutItem in
                        baseGroup.Items.Where(
                            x => x is DocumentPanel && (x as DocumentPanel).Control is IDocumentPanelManager))
                {
                    var localpanel = (DocumentPanel) baseLayoutItem;
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
                    panel.Content = Activator.CreateInstance(controlType);
                    panel.Caption = (panel.Control as IDocumentPanelManager).PanelTitle;
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
         * */
    }

    interface IDocumentPanelManager
    {
        string PanelTitle { get; }
        IResolver DependencyResolver { get; set; }
    }
}
