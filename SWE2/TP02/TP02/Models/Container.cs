using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP02.Models
{
    public enum TipoContainer
    {
        Dry,
        Reefer
    }

    public class Container
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o número do container.")]
        [StringLength(11, ErrorMessage = "O número deve ter até 11 caracteres.")]
        [Display(Name = "Número")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Informe o tipo do container.")]
        [Display(Name = "Tipo")]
        public TipoContainer Tipo { get; set; }

        [Required(ErrorMessage = "Informe o tamanho do container.")]
        [Display(Name = "Tamanho (pés)")]
        public int Tamanho { get; set; } // 20 ou 40

        [Required(ErrorMessage = "O container deve estar associado a um BL.")]
        [Display(Name = "BL")]
        public int BLId { get; set; }

        [ForeignKey("BLId")]
        [ValidateNever]
        public BL BL { get; set; }
    }
}
