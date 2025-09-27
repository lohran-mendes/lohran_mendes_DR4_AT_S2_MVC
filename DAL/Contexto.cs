using Microsoft.EntityFrameworkCore;
using lohran_mendes_DR4_AT_S2.Models;

namespace lohran_mendes_DR4_AT_S2.DAL;

public class Contexto: DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Models.Cliente> Clientes { get; set; }
    public DbSet<Models.Reserva> Reservas { get; set; }
    public DbSet<Models.PacoteTuristico> PacotesTuristicos { get; set; }
    public DbSet<Models.Destino> Destinos { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Cliente>().HasKey(c => c.Id);
        modelBuilder.Entity<Models.Reserva>().HasKey(r => r.Id);
        modelBuilder.Entity<Models.PacoteTuristico>().HasKey(p => p.Id);
        modelBuilder.Entity<Models.Destino>().HasKey(d => d.Id);
        modelBuilder.Entity<Models.DestinosPacotes>().HasKey(dp => dp.id);
        
        
        
        modelBuilder.Entity<Models.Cliente>()
            .HasMany(c => c.Reservas)
            .WithOne(r => r.Cliente)
            .HasForeignKey(r => r.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Models.DestinosPacotes>()
            .HasOne(dp => dp.Destino)
            .WithMany(d => d.DestinosPacotes)
            .HasForeignKey(dp => dp.DestinoId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Models.DestinosPacotes>()
            .HasOne(dp => dp.PacoteTuristico)
            .WithMany(p => p.DestinosPacotes)
            .HasForeignKey(dp => dp.PacoteTuristicoId)
            .OnDelete(DeleteBehavior.Cascade);
        
        
    }

public DbSet<lohran_mendes_DR4_AT_S2.Models.DestinosPacotes> DestinosPacotes { get; set; } = default!;
}