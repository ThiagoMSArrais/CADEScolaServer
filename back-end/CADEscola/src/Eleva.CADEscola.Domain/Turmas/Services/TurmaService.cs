using Eleva.CADEscola.Domain.Turmas.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eleva.CADEscola.Domain.Turmas.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaService(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        public async Task AdicionarTurma(Turma turma)
        {
            await _turmaRepository.AdicionarTurma(turma);
        }

        public async Task<IEnumerable<Turma>> ObterTurmas()
        {
            return await _turmaRepository.ObterTurmas();
        }
    }
}
