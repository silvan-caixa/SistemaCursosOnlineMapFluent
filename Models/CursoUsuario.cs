namespace SistemaCursosOnlineMaoFluent.Models;

public class CursoUsuario 
{
    public int UsuarioId { get; set; }
    public int CursoId { get; set; }    
    public DateTime DataCadastro { get; set; } = DateTime.Now;
    
}