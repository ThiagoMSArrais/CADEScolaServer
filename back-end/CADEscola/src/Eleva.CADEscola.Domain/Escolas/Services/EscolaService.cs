using Eleva.CADEscola.Domain.Escolas.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eleva.CADEscola.Domain.Escolas.Services
{
    public class EscolaService : IEscolaService
    {
        private readonly IEscolaRepository _escolaRepository;

        public EscolaService(IEscolaRepository escolaRepository)
        {
            _escolaRepository = escolaRepository;
        }

        public async Task AdicionarEscola(Escola escola)
        {
            await _escolaRepository.AdicionarEscola(escola);

        }

        public async Task<IEnumerable<Escola>> ObterEscolas()
        {
            return await _escolaRepository.ObterEscolas();
        }
    }
}
