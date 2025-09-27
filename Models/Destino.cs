using System.ComponentModel.DataAnnotations;

namespace lohran_mendes_DR4_AT_S2.Models;

public class Destino
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Pais { get; set; }
}