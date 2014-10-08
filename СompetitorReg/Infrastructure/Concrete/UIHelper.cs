using System.Windows;
using System.Windows.Input;
using DevExpress.Xpf.Grid;

namespace CompetitorReg.Infrastructure.Concrete
{
    class UiHelper
    {
        public static bool TestGridControlForRowCell(object source, MouseButtonEventArgs e)
        {
            return
                (((TableView) ((GridControl) e.Source).View).CalcHitInfo(e.OriginalSource as DependencyObject))
                    .InRowCell;
        }
    }
}
