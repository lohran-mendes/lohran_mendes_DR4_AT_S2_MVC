using System.ComponentModel.DataAnnotations;

namespace lohran_mendes_DR4_AT_S2.Models;

public class PacoteTuristico
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public DateTime DataInicio { get; set; }
    public int CapacidadeMaxima { get; set; }
    public decimal Preco { get; set; }
    public List<Destino>? Destinos { get; set; }
    public ICollection<DestinosPacotes>? DestinosPacotes { get; set; }
}