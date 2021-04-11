using Eleva.CADEscola.Domain.Turmas;
using System;
using System.Collections.Generic;

namespace Eleva.CADEscola.Domain.Escolas
{
    public class Escola
    {

        public Escola() { }

        public Guid EscolaId { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public List<Turma> Turmas { get; set; }
    }
}
