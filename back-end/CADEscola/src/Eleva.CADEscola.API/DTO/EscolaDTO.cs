using System;
using System.Collections.Generic;

namespace Eleva.CADEscola.API.DTO
{
    public class EscolaDTO
    {

        public EscolaDTO()
        {
            EscolaId = Guid.NewGuid();
        }

        public Guid EscolaId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public List<TurmaDTO> Turmas { get; set; }
    }
}

