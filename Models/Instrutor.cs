namespace SistemaCursosOnlineMaoFluent.Models;

public class Instrutor
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public List<Curso> Cursos { get; set; } = new();
}