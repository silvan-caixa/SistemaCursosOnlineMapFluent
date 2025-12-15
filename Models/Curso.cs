namespace SistemaCursosOnlineMaoFluent.Models;

public class Curso
{
    public const int DescricaoMaxLength = 250;
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
    public int InstrutorId { get; set; }
    public Instrutor? Instrutor { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public List<Aula> Aulas { get; set; } = new();
    public List<Usuario> Usuarios { get; set; } = new();
    public List<Matricula> Matriculas { get; set; } = new();
    public List<Avaliacao> Avaliacoes { get; set; } = new();

}