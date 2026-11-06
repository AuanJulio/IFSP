using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Auan Julio Galvão dos Santos - CB303069
// Paulo Eduardo da Silva Pessoa - CB303092x
namespace PRDM_TP03.Models
{
    /// <summary>
    /// Representa as informações de um pacote rastreado.
    /// </summary>
    public class Pacote
    {
        public string Id { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime DataEnvio { get; set; }
        public DateTime DataPrevistaEntrega { get; set; }
        public string LocalizacaoAtual { get; set; } = string.Empty;
        public List<EventoRastreamento> Historico { get; set; } = new();
    }
}
