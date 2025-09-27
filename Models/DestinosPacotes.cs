namespace lohran_mendes_DR4_AT_S2.Models;

public class DestinosPacotes
{
    public int id { get; set; }
    
    public int DestinoId { get; set; }
    public Destino? Destino { get; set; }
    
    public int PacoteTuristicoId { get; set; }
    public PacoteTuristico? PacoteTuristico { get; set; }
}