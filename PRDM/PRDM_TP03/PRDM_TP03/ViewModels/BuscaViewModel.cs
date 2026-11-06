using PRDM_TP03.Services;
using PRDM_TP03.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Auan Julio Galvão dos Santos - CB303069
// Paulo Eduardo da Silva Pessoa - CB303092x
namespace PRDM_TP03.ViewModels
{
    public class BuscaViewModel : ViewModelBase
    {
        private readonly IRastreamentoService _service;

        private string _codigoRastreamento = string.Empty;
        private string _mensagemErro = string.Empty;
        private bool _isBusy;

        public BuscaViewModel(IRastreamentoService service)
        {
            _service = service;
            BuscarCommand = new Command(async () => await BuscarAsync(), PodeBuscar);
        }

        public string CodigoRastreamento
        {
            get => _codigoRastreamento;
            set
            {
                if (SetProperty(ref _codigoRastreamento, value))
                {
                    MensagemErro = string.Empty;
                    BuscarCommand.ChangeCanExecute();
                }
            }
        }

        public string MensagemErro
        {
            get => _mensagemErro;
            private set
            {
                if (SetProperty(ref _mensagemErro, value))
                    OnPropertyChanged(nameof(TemErro));
            }
        }

        public bool TemErro => !string.IsNullOrEmpty(MensagemErro);

        public bool IsBusy
        {
            get => _isBusy;
            private set
            {
                if (SetProperty(ref _isBusy, value))
                    BuscarCommand.ChangeCanExecute();
            }
        }

        public Command BuscarCommand { get; }

        private bool PodeBuscar() => !IsBusy && !string.IsNullOrWhiteSpace(CodigoRastreamento);

        private async Task BuscarAsync()
        {
            if (!PodeBuscar())
                return;

            try
            {
                IsBusy = true;
                MensagemErro = string.Empty;

                var pacote = await _service.BuscarPacoteAsync(CodigoRastreamento);

                if (pacote is null)
                {
                    MensagemErro = "Pacote não encontrado. Verifique o código e tente novamente.";
                    return;
                }

                await Shell.Current.GoToAsync(nameof(ResultadoPage), new ShellNavigationQueryParameters
            {
                { "Pacote", pacote }
            });
            }
            catch (Exception)
            {
                MensagemErro = "Ocorreu um erro ao buscar o pacote. Tente novamente.";
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
