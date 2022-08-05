using Core.Entidades;
using Core.Dto;
using Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private ResponseDto _response;

        public ProductoController(ApplicationDbContext db)
        {
            _db = db;
            _response = new ResponseDto();

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProdcutos(){
            var lista = await _db.Producto.ToListAsync();
            _response.Resultado = lista;
            _response.Mensjae="Listado de Productos";

            return Ok(_response);

        }

        [HttpGet("{id}", Name = "GetProducto")]
        public async Task<ActionResult<Producto>> GetProdcuto(int id){
            var prod = await _db.Producto.FindAsync(id);
            _response.Resultado = prod;
            _response.Mensjae="Datos de los productos" + prod.ProductoId;
            return Ok(_response);
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto([FromBody] Producto producto){
            await _db.Producto.AddAsync(producto);
            await _db.SaveChangesAsync();
            return CreatedAtRoute("GetProducto", new {id = producto.ProductoId}, producto);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> PutProducto(int id,[FromBody] Producto producto){
            if(id != producto.ProductoId) {
                return BadRequest("Id del prodcuto no coincide");
            }
            _db.Update(producto);
            await _db.SaveChangesAsync();
            return Ok(producto);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProducto(int id){
            var prod = await _db.Producto.FindAsync(id);
            if(prod == null) {
                return NotFound();
            }
            _db.Producto.Remove(prod);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}