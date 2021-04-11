using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eleva.CADEscola.Domain.Escolas.Interfaces
{
    public interface IEscolaRepository
    {
        Task AdicionarEscola(Escola escola);
        Task<IEnumerable<Escola>> ObterEscolas();
    }
}
