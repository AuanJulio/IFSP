using System.ComponentModel.DataAnnotations;

namespace TP02.Models
{
    public class BL
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o número do BL.")]
        [StringLength(50)]
        [Display(Name = "Número")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Informe o Consignee.")]
        [StringLength(100)]
        [Display(Name = "Consignee")]
        public string Consignee { get; set; }

        [Required(ErrorMessage = "Informe o navio.")]
        [StringLength(100)]
        [Display(Name = "Navio")]
        public string Navio { get; set; }

        public ICollection<Container> Containers { get; set; } = new List<Container>();
    }
}
