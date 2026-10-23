using ClinicaVida.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVida.Web.Data;

public class ClinicaContext : DbContext
{
    public ClinicaContext(DbContextOptions<ClinicaContext> options) : base(options) { }

    public DbSet<Paciente> Pacientes => Set<Paciente>();
    public DbSet<Medico> Medicos => Set<Medico>();
    public DbSet<Especialidade> Especialidades => Set<Especialidade>();
    public DbSet<Consulta> Consultas => Set<Consulta>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Especialidade>().HasData(
            new Especialidade { Id = 1, Nome = "Clínica Geral", Descricao = "Rotina e encaminhamentos" },
            new Especialidade { Id = 2, Nome = "Cardiologia",   Descricao = "Coração e circulação" },
            new Especialidade { Id = 3, Nome = "Pediatria",     Descricao = "Crianças e adolescentes" },
            new Especialidade { Id = 4, Nome = "Dermatologia",  Descricao = "Pele, cabelos e unhas" }
        );
    }
}