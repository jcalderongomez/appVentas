using Core.Entidades;
using Core.Dto;
using Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private ResponseDto _response;

        public CategoriaController(ApplicationDbContext db)
        {
            _db = db;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias(){
            var lista = await _db.Categoria.ToListAsync();
            _response.Resultado = lista;
            _response.Mensjae="Listado de Categorias";

            return Ok(_response);
        }
        
       [HttpGet("{id}", Name = "GetCategoria")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id){
            var cat = await _db.Categoria.FindAsync(id);
            _response.Resultado = cat;
            _response.Mensjae="Datos de las Categorias" + cat.CategoriaId;

            return Ok(_response);
        }
        
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria([FromBody] Categoria categoria){
            await _db.Categoria.AddAsync(categoria);
            await _db.SaveChangesAsync();
            return CreatedAtRoute("GetCategoria", new {id = categoria.CategoriaId}, categoria);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCategoria(int id,[FromBody] Categoria categoria){
            if(id != categoria.CategoriaId) {
                return BadRequest("Id de la categoria no coincide");
            }
            _db.Update(categoria);
            await _db.SaveChangesAsync();
            return Ok(categoria);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategoria(int id){
            var categ = await _db.Categoria.FindAsync(id);
            if(categ == null) {
                return NotFound();
            }
            _db.Categoria.Remove(categ);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}