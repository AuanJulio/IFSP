using TarefasApp.Models;
using TarefasApp.Services;

namespace TarefasApp;

[QueryProperty(nameof(Tarefa), "Tarefa")]
public partial class DetalhesPage : ContentPage
{
    private readonly TarefaService _service;
    private Tarefa _tarefa = null!;

    public Tarefa Tarefa
    {
        get => _tarefa;
        set
        {
            _tarefa = value;
            BindingContext = value;
        }
    }

    public DetalhesPage(TarefaService service)
    {
        InitializeComponent();
        _service = service;
    }

    private async void OnEditarClicked(object? sender, EventArgs e)
    {
        var copia = Tarefa.Clonar();

        var modal = new TarefaFormPage(copia, "Editar tarefa");
        await Navigation.PushModalAsync(modal);

        var resultado = await modal.Resultado;

        if (resultado is not null)
            Tarefa.CopiarDe(resultado);
    }

    private async void OnExcluirClicked(object? sender, EventArgs e)
    {
        bool confirmou = await DisplayAlert(
            "Excluir tarefa",
            $"Deseja realmente excluir a tarefa \"{Tarefa.Titulo}\"?",
            "Sim, excluir",
            "Cancelar");

        if (!confirmou)
            return;

        _service.Remover(Tarefa);

        await Shell.Current.GoToAsync("..");
    }
}