using System;

namespace Eleva.CADEscola.Domain.Turmas
{

    public class Turma
    {

        public Turma()  { }

        public Guid TurmaId { get; private set; }
        public string Nome { get; private set; }
        public string Sala { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public int LimiteTurma { get; private set; }
        public Guid? EscolaId { get; private set; }
        public string NomeEscola { get; set; }
    }
}
