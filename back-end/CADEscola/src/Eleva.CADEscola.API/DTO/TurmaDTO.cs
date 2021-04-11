using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eleva.CADEscola.API.DTO
{
    public class TurmaDTO
    {
        public TurmaDTO()
        {
            TurmaId = Guid.NewGuid();
        }

        public Guid TurmaId { get; set; }
        public string Nome { get; set; }
        public string Sala { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int LimiteTurma { get; set; }
        public Guid? EscolaId { get; set; }
        public string NomeEscola { get; set; }
    }
}
