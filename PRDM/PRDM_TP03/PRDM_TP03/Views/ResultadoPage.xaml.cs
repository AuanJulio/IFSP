using PRDM_TP03.ViewModels;

namespace PRDM_TP03.Views;

public partial class ResultadoPage : ContentPage
{
    public ResultadoPage(ResultadoViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}