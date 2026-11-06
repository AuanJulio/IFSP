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
    /// <summary>
    /// Implementação que SIMULA uma consulta usando dados fictícios.
    /// </summary>
    public class RastreamentoService : IRastreamentoService
    {
        private readonly Dictionary<string, Pacote> _bancoFicticio;

        public RastreamentoService()
        {
            _bancoFicticio = new Dictionary<string, Pacote>(StringComparer.OrdinalIgnoreCase)
            {
                // 1) Pacote em trânsito
                ["BR123456789BR"] = new Pacote
                {
                    Id = "BR123456789BR",
                    Status = StatusPacote.EmTransito,
                    DataEnvio = Dia(-3),
                    DataPrevistaEntrega = Dia(2),
                    LocalizacaoAtual = "Centro de Distribuição - Campinas, SP",
                    Historico = new List<EventoRastreamento>
                {
                    new() { DataHora = Dia(-3, 9, 15),  Descricao = "Objeto postado", Local = "São Vicente, SP" },
                    new() { DataHora = Dia(-3, 18, 40), Descricao = "Objeto encaminhado para unidade de tratamento", Local = "Santos, SP" },
                    new() { DataHora = Dia(-2, 7, 30),  Descricao = "Objeto em trânsito", Local = "Centro de Triagem - São Paulo, SP" },
                    new() { DataHora = Dia(-1, 22, 10), Descricao = "Objeto chegou ao centro de distribuição", Local = "Campinas, SP" }
                }
                },

                // 2) Pacote entregue
                ["BR987654321BR"] = new Pacote
                {
                    Id = "BR987654321BR",
                    Status = StatusPacote.Entregue,
                    DataEnvio = Dia(-7),
                    DataPrevistaEntrega = Dia(-2),
                    LocalizacaoAtual = "Entregue ao destinatário - Rio de Janeiro, RJ",
                    Historico = new List<EventoRastreamento>
                {
                    new() { DataHora = Dia(-7, 10, 0),  Descricao = "Objeto postado", Local = "Cubatão, SP" },
                    new() { DataHora = Dia(-6, 14, 20), Descricao = "Objeto em trânsito", Local = "São Paulo, SP" },
                    new() { DataHora = Dia(-4, 8, 45),  Descricao = "Objeto chegou à unidade de destino", Local = "Rio de Janeiro, RJ" },
                    new() { DataHora = Dia(-3, 9, 5),   Descricao = "Objeto saiu para entrega ao destinatário", Local = "Rio de Janeiro, RJ" },
                    new() { DataHora = Dia(-3, 15, 30), Descricao = "Objeto entregue ao destinatário", Local = "Rio de Janeiro, RJ" }
                }
                },

                // 3) Pacote que saiu para entrega
                ["BR555555555BR"] = new Pacote
                {
                    Id = "BR555555555BR",
                    Status = StatusPacote.SaiuParaEntrega,
                    DataEnvio = Dia(-4),
                    DataPrevistaEntrega = Dia(0),
                    LocalizacaoAtual = "Em rota de entrega - Santos, SP",
                    Historico = new List<EventoRastreamento>
                {
                    new() { DataHora = Dia(-4, 11, 0), Descricao = "Objeto postado", Local = "Curitiba, PR" },
                    new() { DataHora = Dia(-2, 6, 50), Descricao = "Objeto em trânsito", Local = "São Paulo, SP" },
                    new() { DataHora = Dia(-1, 19, 0), Descricao = "Objeto chegou à unidade de destino", Local = "Santos, SP" },
                    new() { DataHora = Dia(0, 8, 10),  Descricao = "Objeto saiu para entrega ao destinatário", Local = "Santos, SP" }
                }
                }
            };
        }

        public async Task<Pacote?> BuscarPacoteAsync(string codigo)
        {
            await Task.Delay(1500);

            if (string.IsNullOrWhiteSpace(codigo))
                return null;

            _bancoFicticio.TryGetValue(codigo.Trim(), out var pacote);
            return pacote;
        }

        private static DateTime Dia(int diasRelativos, int hora = 0, int minuto = 0)
            => DateTime.Today.AddDays(diasRelativos).AddHours(hora).AddMinutes(minuto);
    }
}
