using System.ComponentModel.DataAnnotations;

namespace lohran_mendes_DR4_AT_S2.Models;

public class Cliente
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MinLength(2, ErrorMessage = "O nome deve ter no mínimo 2 caracteres.")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "O email é obrigatório.")]
    [MinLength(2, ErrorMessage = "O email deve ter no mínimo 2 caracteres.")]
    public string Email { get; set; }
    public List<Reserva>? Reservas { get; set; }
}