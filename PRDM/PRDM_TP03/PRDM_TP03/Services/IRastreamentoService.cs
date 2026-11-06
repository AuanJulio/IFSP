using PRDM_TP03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Auan Julio Galvão dos Santos - CB303069
// Paulo Eduardo da Silva Pessoa - CB303092x
namespace PRDM_TP03.Services
{
    public interface IRastreamentoService
    {
        /// <summary>
        /// Busca um pacote pelo código. Retorna null se não for encontrado.
        /// </summary>
        Task<Pacote?> BuscarPacoteAsync(string codigo);
    }
}
