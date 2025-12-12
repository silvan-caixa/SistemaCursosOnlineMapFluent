using SistemaCursosOnlineMaoFluent.Models;

namespace SistemaCursosOnlineMaoFluent;

public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    public List<Curso> Cursos { get; set; } = new();
}