namespace SistemaCursosOnlineMaoFluent.Models;

public class Avaliacao
{
    public const int ComentarioMaxLength = 250;
    public int Id { get; set; }
    public Usuario? Usuario { get; set; }
    public int UsuarioId { get; set; }
    public Curso? Curso { get; set; }
    public int CursoId { get; set; }
    public int Nota { get; set; }
    public string? Comentario { get; set; }
    public DateTime DataAvaliacao { get; set; } = DateTime.Now;

}