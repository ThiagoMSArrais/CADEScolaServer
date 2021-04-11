using AutoMapper;
using Eleva.CADEscola.API.DTO;
using Eleva.CADEscola.Domain.Escolas;
using Eleva.CADEscola.Domain.Escolas.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eleva.CADEscola.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EscolaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEscolaService _escolaServices;

        public EscolaController(IMapper mapper,
                                IEscolaService escolaServices)
        {
            _mapper = mapper;
            _escolaServices = escolaServices;
        }

        // GET: api/v1/Escola
        [HttpGet]
        public async Task<IEnumerable<EscolaDTO>> Get()
        {
            return _mapper.Map<IEnumerable<EscolaDTO>>(await _escolaServices.ObterEscolas()).ToList();

        }

        // POST: api/v1/Escola
        [HttpPost]
        public async Task<ActionResult<CadastroEscolaDTO>> Post([FromBody] CadastroEscolaDTO cadastroEscolaDTO)
        {
            await _escolaServices.AdicionarEscola(_mapper.Map<Escola>(cadastroEscolaDTO));

            return Ok(new
            {
                success = true,
                data = cadastroEscolaDTO
            });
        }
    }
}
