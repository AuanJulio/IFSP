using System;
using System.Text;

// Auan Julio Galvão dos Santos - CB3030369

namespace LivrariaCore
{
    public class Book
    {
        private string name;
        private Author[] authors;
        private double price;
        private int qty = 0;

        public Book(string name, Author[] authors, double price)
        {
            this.name = name;
            this.authors = authors;
            this.price = price;
            this.qty = 0;
        }

        public Book(string name, Author[] authors, double price, int qty)
        {
            this.name = name;
            this.authors = authors;
            this.price = price;
            this.qty = qty;
        }

        public string GetName() => name;

        public Author[] GetAuthors() => authors;

        public double GetPrice() => price;

        public void SetPrice(double price) => this.price = price;

        public int GetQty() => qty;

        public void SetQty(int qty) => this.qty = qty;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Book[name=").Append(name).Append(",authors={");

            for (int i = 0; i < authors.Length; i++)
            {
                sb.Append(authors[i].ToString());
                if (i < authors.Length - 1)
                    sb.Append(",");
            }

            sb.Append("},price=").Append(price).Append(",qty=").Append(qty).Append("]");
            return sb.ToString();
        }

        public string GetAuthorNames()
        {
            var nomes = new string[authors.Length];
            for (int i = 0; i < authors.Length; i++)
                nomes[i] = authors[i].GetName();

            return string.Join(",", nomes);
        }
    }
}
