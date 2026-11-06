using PRDM_TP03.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Auan Julio Galvão dos Santos - CB303069
// Paulo Eduardo da Silva Pessoa - CB303092x
namespace PRDM_TP03.ViewModels
{
    public class ResultadoViewModel : ViewModelBase, IQueryAttributable
    {
        private Pacote _pacoteAtual = new();

        public ResultadoViewModel()
        {
            VoltarCommand = new Command(async () => await Shell.Current.GoToAsync(".."));
        }

        public Pacote PacoteAtual
        {
            get => _pacoteAtual;
            private set
            {
                if (SetProperty(ref _pacoteAtual, value))
                    OnPropertyChanged(nameof(CorStatus));
            }
        }

        public ObservableCollection<EventoRastreamento> Historico { get; } = new();

        public Color CorStatus => PacoteAtual.Status switch
        {
            StatusPacote.Entregue => Color.FromArgb("#2E7D32"),
            StatusPacote.SaiuParaEntrega => Color.FromArgb("#EF6C00"),
            StatusPacote.EmTransito => Color.FromArgb("#1565C0"),
            _ => Color.FromArgb("#616161")
        };

        public Command VoltarCommand { get; }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("Pacote", out var valor) && valor is Pacote pacote)
            {
                PacoteAtual = pacote;

                Historico.Clear();
                foreach (var evento in pacote.Historico.OrderByDescending(e => e.DataHora))
                    Historico.Add(evento);
            }
        }
    }
}
