using TarefasApp.Models;
using TarefasApp.Services;

namespace TarefasApp;

public partial class MainPage : ContentPage
{
    private readonly TarefaService _service;

    public MainPage(TarefaService service)
    {
        InitializeComponent();

        _service = service;
        BindingContext = service;
    }

    private async void OnTarefaSelecionada(object? sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Tarefa tarefa)
            return;

        ((CollectionView)sender!).SelectedItem = null;

        await Shell.Current.GoToAsync(nameof(DetalhesPage), new Dictionary<string, object>
        {
            { "Tarefa", tarefa }
        });
    }

    private async void OnAdicionarClicked(object? sender, EventArgs e)
    {
        var novaTarefa = new Tarefa
        {
            DataCriacao = DateTime.Today,
            Prioridade = "Média"
        };

        var modal = new TarefaFormPage(novaTarefa, "Nova tarefa");
        await Navigation.PushModalAsync(modal);

        var resultado = await modal.Resultado;

        if (resultado is not null)
            _service.Adicionar(resultado);
    }
}