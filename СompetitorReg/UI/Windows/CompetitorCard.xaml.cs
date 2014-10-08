using CompetitorReg.Infrastructure.Abstract;

namespace CompetitorReg.UI.Windows
{
    /// <summary>
    /// Interaction logic for CompetitorCard.xaml
    /// </summary>
    public partial class CompetitorCard
    {
        private readonly ISessionHelper sessionHelper;
        public CompetitorCard(ISessionHelper sessionHelper)
        {
            InitializeComponent();
            this.sessionHelper = sessionHelper;
        }
    }
}
