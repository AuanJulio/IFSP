using System.ComponentModel.DataAnnotations;

namespace TP03.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Display(Name = "Nome do produto")]
        [Required(ErrorMessage = "Informe o nome do produto.")]
        [StringLength(80, MinimumLength = 2,
            ErrorMessage = "O nome deve ter entre {2} e {1} caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Informe uma descrição para o produto.")]
        [StringLength(500, ErrorMessage = "A descrição pode ter no máximo {1} caracteres.")]
        public string Descricao { get; set; } = string.Empty;

        [Display(Name = "Preço (R$)")]
        [Required(ErrorMessage = "Informe o preço do produto.")]
        [Range(0.01, 999999.99,
            ErrorMessage = "O preço deve estar entre R$ 0,01 e R$ 999.999,99.")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        [Display(Name = "Quantidade em estoque")]
        [Required(ErrorMessage = "Informe a quantidade em estoque.")]
        [Range(0, 1000000, ErrorMessage = "A quantidade deve estar entre {1} e {2}.")]
        public int QuantidadeEstoque { get; set; }
    }
}
