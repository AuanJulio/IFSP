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
    /// Representa um evento do histórico de um pacote.
    /// </summary>
    public class EventoRastreamento
    {
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string Local { get; set; } = string.Empty;
    }
}
