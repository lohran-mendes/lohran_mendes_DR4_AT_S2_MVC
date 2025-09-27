using Microsoft.EntityFrameworkCore;

namespace lohran_mendes_DR4_AT_S2.DAL;

public class Contexto: DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Models.Cliente> Clientes { get; set; }
    public DbSet<Models.Reserva> Reservas { get; set; }
    public DbSet<Models.PacoteTuristico> PacotesTuristicos { get; set; }
    public DbSet<Models.Destino> Destinos { get; set; }
}