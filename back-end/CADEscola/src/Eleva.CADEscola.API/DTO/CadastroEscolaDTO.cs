using System;

namespace Eleva.CADEscola.API.DTO
{
    public class CadastroEscolaDTO
    {
        public CadastroEscolaDTO()
        {
            EscolaId = Guid.NewGuid();
        }

        public Guid EscolaId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
