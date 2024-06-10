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

        // GET: api/Notas
        [HttpGet]
        // public ActionResult<IEnumerable<Nota>> GetNotas()
        // {
        //     return Ok(_notaService.GetAll());
        // }
        [HttpGet]
        public ActionResult<IEnumerable<NotaDto>> GetNotas()
        {
            var notas = _notaService.GetAll().Select(n => new NotaDto
            {
                NomeAluno = n.NomeAluno,
                NomeMateria = n.NomeMateria,
                Conceito = n.Conceito
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
