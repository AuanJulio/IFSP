using PRDM_TP03.ViewModels;

namespace PRDM_TP03.Views;

public partial class BuscaPage : ContentPage
{
    public BuscaPage(BuscaViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}