using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasAgendaWFA
{
    internal class Contato
    {

        private int id;
        private string email;
        private string nome;
        private Data dtNasc;
        private List<Telefone> telefones = new List<Telefone>();

        public string Email { get => email; set => email = value; }
        public string Nome { get => nome; set => nome = value; }
        internal Data DtNasc { get => dtNasc; set => dtNasc = value; }
        internal List<Telefone> Telefones { get => telefones; set => telefones = value; }
        public int Id { get => id; set => id = value; }
        public string DataNascimentoStr => DtNasc.ToString();
        public string TelefonePrincipalStr => getTelefonePrincipal();

        public Contato(int id, string email, string nome, Data dtNasc, List<Telefone> telefones)
        {
            Id = id;
            Email = email;
            Nome = nome;
            DtNasc = dtNasc;
            Telefones = telefones;
        }
        public Contato(int id) : this(id, "", "", new Data(), new List<Telefone>())
        {
            this.id = id;
        }
        public int getIdade()
        {
            return (DateTime.Now.Year - dtNasc.Ano);
        }
        public void adicionarTelefone(Telefone t)
        {
            if (t != null && !string.IsNullOrWhiteSpace(t.Numero))
            {
                if (telefones.Count == 0)
                    t.Principal = true;

                foreach (Telefone telefone in telefones)
                {
                    if (telefone.Numero == t.Numero)
                    {
                        Console.WriteLine("Este número já está cadastrado!");
                        return;
                    }
                    else if (t.Principal == true && telefone.Principal == true)
                    {
                        telefone.Principal = false;
                    }
                }
                telefones.Add(t);
                Console.WriteLine("Telefone adicionado com sucesso!");
            }
            else { Console.WriteLine("Telefone inválido!"); }
        }
        public string getTelefonePrincipal()
        {
            foreach (Telefone telefone in telefones)
            {
                if (telefone.Principal)
                    return telefone.Numero.ToString();
            }
            return "Não foi possivel encontrar";
        }
        public override string ToString()
        {
            string todosTelefones = "";
            foreach (Telefone telefone in telefones)
            {
                todosTelefones += telefone.Principal
                    ? $"{telefone.Numero}:Principal | "
                    : $"{telefone.Numero}, ";
            }

            return $"{this.email} - {this.nome} - {this.dtNasc.ToString()} - " +
                   $"Telefone Principal: {getTelefonePrincipal()} - " +
                   $"Outros: {todosTelefones}";
        }
        public override bool Equals(object obj)
        {
            return (this.Id == ((Contato)obj).Id);
        }

    }
}
