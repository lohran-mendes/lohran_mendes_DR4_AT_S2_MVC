using System.ComponentModel.DataAnnotations;

namespace lohran_mendes_DR4_AT_S2.Models;

public class Destino
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Pais { get; set; }
    public ICollection<DestinosPacotes>? DestinosPacotes { get; set; }
}