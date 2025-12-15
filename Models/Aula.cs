using SistemaCursosOnlineMaoFluent.Models;

namespace SistemaCursosOnlineMaoFluent;

public class Aula
{
    public int Id { get; set; }
    public int CursoId { get; set; }
    public Curso? Curso { get; set; }

    public string Titulo { get; set; } = string.Empty;
    public string UrlVideo { get; set; } = string.Empty;
    public int Ordem { get; set; }

}