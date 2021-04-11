using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eleva.CADEscola.Domain.Escolas.Interfaces
{
    public interface IEscolaService
    {
        Task AdicionarEscola(Escola escola);
        Task<IEnumerable<Escola>> ObterEscolas();
    }
}
