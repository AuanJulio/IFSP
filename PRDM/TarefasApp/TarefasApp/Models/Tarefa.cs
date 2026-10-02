using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

// Auan Julio Galvão dos Santos CB3030369
// Paulo Eduardo da Silva Pessoa CB303092x

namespace TarefasApp.Models
{
    public class Tarefa : INotifyPropertyChanged
    {
        public static readonly string[] Prioridades = { "Baixa", "Média", "Alta" };

        private string _titulo = string.Empty;
        private string _descricao = string.Empty;
        private DateTime _dataCriacao = DateTime.Today;
        private string _prioridade = "Média";

        public Guid Id { get; set; } = Guid.NewGuid();

        public string Titulo
        {
            get => _titulo;
            set => SetField(ref _titulo, value);
        }

        public string Descricao
        {
            get => _descricao;
            set => SetField(ref _descricao, value);
        }

        public DateTime DataCriacao
        {
            get => _dataCriacao;
            set => SetField(ref _dataCriacao, value);
        }

        public string Prioridade
        {
            get => _prioridade;
            set
            {
                if (SetField(ref _prioridade, value))
                    OnPropertyChanged(nameof(CorPrioridade));
            }
        }

        public Color CorPrioridade => Prioridade switch
        {
            "Alta" => Color.FromArgb("#E53935"),
            "Média" => Color.FromArgb("#FB8C00"),
            _ => Color.FromArgb("#43A047")
        };

        public Tarefa Clonar() => new()
        {
            Id = Id,
            Titulo = Titulo,
            Descricao = Descricao,
            DataCriacao = DataCriacao,
            Prioridade = Prioridade
        };

        public void CopiarDe(Tarefa outra)
        {
            Titulo = outra.Titulo;
            Descricao = outra.Descricao;
            DataCriacao = outra.DataCriacao;
            Prioridade = outra.Prioridade;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? nome = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nome));

        protected bool SetField<T>(ref T campo, T valor, [CallerMemberName] string? nome = null)
        {
            if (EqualityComparer<T>.Default.Equals(campo, valor))
                return false;

            campo = valor;
            OnPropertyChanged(nome);
            return true;
        }
    }
}
