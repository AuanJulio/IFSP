using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasApp.Models;

// Auan Julio Galvão dos Santos CB3030369
// Paulo Eduardo da Silva Pessoa CB303092x

namespace TarefasApp.Services
{
    public class TarefaService
    {

        public ObservableCollection<Tarefa> Tarefas { get; } = new()
    {
        new Tarefa
        {
            Titulo = "Estudar .NET MAUI",
            Descricao = "Revisar navegação, modais e CollectionView.",
            DataCriacao = DateTime.Today.AddDays(-2),
            Prioridade = "Alta"
        },
        new Tarefa
        {
            Titulo = "Fazer compras",
            Descricao = "Comprar frutas, pão e leite no mercado.",
            DataCriacao = DateTime.Today.AddDays(-1),
            Prioridade = "Média"
        },
        new Tarefa
        {
            Titulo = "Ligar para o dentista",
            Descricao = "Marcar consulta de rotina para o próximo mês.",
            DataCriacao = DateTime.Today,
            Prioridade = "Baixa"
        }
    };

        public void Adicionar(Tarefa tarefa) => Tarefas.Insert(0, tarefa);

        public void Remover(Tarefa tarefa) => Tarefas.Remove(tarefa);

    }
}
