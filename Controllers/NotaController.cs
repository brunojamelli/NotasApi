using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MinhaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasController : ControllerBase
    {
       private readonly INotaService _notaService;
        
        public NotasController(INotaService notaService)
        {
            _notaService = notaService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<NotaDto>> GetNotas()
        {
            var notas = _notaService.GetAll().Select(n => new NotaDto
            {
                Id = n.Id,
                NomeAluno = n.NomeAluno,
                NomeMateria = n.NomeMateria,
                Conceito = n.Conceito,
                NotasAdicionais = n.NotasAdicionais
            });
            return Ok(notas);
        }
        // GET: api/Notas/5
        [HttpGet("{id}")]
        public ActionResult<Nota> GetNota(int id)
        {
            var nota = _notaService.GetById(id);
            if (nota == null)
            {
                return NotFound();
            }
            return Ok(nota);
        }

        // POST: api/Notas
        [HttpPost]
        public ActionResult<Nota> PostNota(Nota nota)
        {
            var createdNota = _notaService.Create(nota);
            return CreatedAtAction(nameof(GetNota), new { id = createdNota.Id }, createdNota);
        }

        // PUT: api/Notas/5
        

        // DELETE: api/Notas/5
        
    }
}
