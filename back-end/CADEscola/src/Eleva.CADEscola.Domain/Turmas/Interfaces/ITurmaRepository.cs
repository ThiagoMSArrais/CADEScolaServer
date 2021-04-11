using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eleva.CADEscola.Domain.Turmas.Interfaces
{
    public interface ITurmaRepository
    {
        Task AdicionarTurma(Turma turma);
        Task<IEnumerable<Turma>> ObterTurmas();
    }
}
