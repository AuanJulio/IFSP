using PRDM_TP03.Views;

namespace PRDM_TP03
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ResultadoPage), typeof(ResultadoPage));
        }
    }
}
