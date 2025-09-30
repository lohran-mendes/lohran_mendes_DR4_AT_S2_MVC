using System.ComponentModel.DataAnnotations;

namespace lohran_mendes_DR4_AT_S2.Models;

public class Destino
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MinLength(2, ErrorMessage = "O nome deve ter no mínimo 2 caracteres.")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "O país é obrigatório.")]
    [MinLength(2, ErrorMessage = "O país deve ter no mínimo 2 caracteres.")]
    public string Pais { get; set; }
    public ICollection<DestinosPacotes>? DestinosPacotes { get; set; }
}