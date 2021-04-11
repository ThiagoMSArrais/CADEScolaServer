using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eleva.CADEscola.Domain.Turmas.Interfaces
{
    public interface ITurmaService
    {
        Task AdicionarTurma(Turma turma);
        Task<IEnumerable<Turma>> ObterTurmas();
    }
}
