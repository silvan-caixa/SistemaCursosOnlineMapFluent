using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SistemaCursosOnlineMaoFluent.Data.Mappings;
using SistemaCursosOnlineMaoFluent.Models;

namespace SistemaCursosOnlineMaoFluent.Data;

public class DataContext : DbContext
{
    public DbSet<Aula> Aulas { get; set; }
    public DbSet<Avaliacao> Avaliacoes { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Instrutor> Instrutores { get; set; }
    public DbSet<Matricula> Matriculas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AulaMap());
        modelBuilder.ApplyConfiguration(new AvaliacaoMap());
        modelBuilder.ApplyConfiguration(new CategoriaMap());
        modelBuilder.ApplyConfiguration(new CursoMap());
        modelBuilder.ApplyConfiguration(new InstrutorMap());
        modelBuilder.ApplyConfiguration(new MatriculaMap());
        modelBuilder.ApplyConfiguration(new UsuarioMap());
    }

    public static string ConnectionString = "Server=develope.database.windows.net;Database=develope;User ID=dev;Password=Silvan@12345";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
    }

    public static void TestConection()
    {
        using var conexao = new SqlConnection(ConnectionString);
        try
        {
            conexao.Open();
            System.Console.WriteLine("Conexão realizada com sucesso!");
        }
        catch (SqlException ex)
        {

            System.Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
        }
    }
}