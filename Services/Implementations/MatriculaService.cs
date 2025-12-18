using SistemaCursosOnlineMaoFluent.Data;
using SistemaCursosOnlineMaoFluent.Services.Interfaces;

namespace SistemaCursosOnlineMaoFluent.Services.Implementations;

public class MatriculaService : IMatriculaService
{
    private readonly DataContext? _context;

    public MatriculaService(DataContext context)
    {
        _context = context;
    }

    public void CriarMatricula(int UsuarioId, int CursoId)
    {
        bool existe = _context!.Matriculas
            .Any(m => m.UsuarioId == UsuarioId && m.CursoId == CursoId);
        if (existe)
            throw new InvalidOperationException("Matrícula já existe");
    }
}