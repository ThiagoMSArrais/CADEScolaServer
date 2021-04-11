using AutoMapper;
using Eleva.CADEscola.API.DTO;
using Eleva.CADEscola.Domain.Turmas;
using Eleva.CADEscola.Domain.Turmas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eleva.CADEscola.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TurmasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITurmaService _turmaService;

        public TurmasController(IMapper mapper,
                                ITurmaService turmaService)
        {
            _mapper = mapper;
            _turmaService = turmaService;
        }

        // GET: api/v1/Turmas
        [HttpGet]
        public async Task<IEnumerable<TurmaDTO>> Get()
        {
            return  _mapper.Map<IEnumerable<TurmaDTO>>(await _turmaService.ObterTurmas()).ToList();

        }

        // POST: api/v1/Turmas
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TurmaDTO turmaDTO)
        {
            await _turmaService.AdicionarTurma(_mapper.Map<Turma>(turmaDTO));

            return Ok(new
            {
                success = true,
                data = turmaDTO
            });
        }
    }
}
