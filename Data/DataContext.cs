using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace SistemaCursosOnlineMaoFluent.Data;

public class DataContext : DbContext
{
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