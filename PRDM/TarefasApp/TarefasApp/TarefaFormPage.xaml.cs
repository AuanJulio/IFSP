using TarefasApp.Models;

namespace TarefasApp;

public partial class TarefaFormPage : ContentPage
{
    private readonly TaskCompletionSource<Tarefa?> _resultado =
        new(TaskCreationOptions.RunContinuationsAsynchronously);

    private readonly Tarefa _tarefa;

    public Task<Tarefa?> Resultado => _resultado.Task;

    public TarefaFormPage(Tarefa tarefa, string tituloPagina)
    {
        InitializeComponent();

        _tarefa = tarefa;
        TituloPagina.Text = tituloPagina;

        PrioridadePicker.ItemsSource = Tarefa.Prioridades;
        BindingContext = tarefa;
    }

    private async void OnSalvarClicked(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_tarefa.Titulo))
        {
            await DisplayAlert("Atenção", "Informe o título da tarefa.", "OK");
            return;
        }

        _resultado.TrySetResult(_tarefa);
        await Navigation.PopModalAsync();
    }

    private async void OnCancelarClicked(object? sender, EventArgs e)
    {
        _resultado.TrySetResult(null);
        await Navigation.PopModalAsync();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _resultado.TrySetResult(null);
    }
}