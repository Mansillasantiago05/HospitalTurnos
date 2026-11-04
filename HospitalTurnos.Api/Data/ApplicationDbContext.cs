using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    private string path = "database.db"; // ruta de la base de datos

    // Constructor para que funcione con WebApi (AddDbContext)
    public ApplicationDbContext() {}
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Turno> Turnos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // sobreescribimos OnConfiguring
    {
        if (!optionsBuilder.IsConfigured) // solo si no viene configurado del Program.cs
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={path}"); // crea la base en sqlite
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) // RF5 evita superposicion
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Turno>().HasIndex(t => new { t.MedicoId, t.FechaHora }).IsUnique();
    }
}