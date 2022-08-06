using Core.Entidades;
using Core.Dto;
using Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
       private readonly ApplicationDbContext _db;
        private ResponseDto _response;

        public VentaController(ApplicationDbContext db)
        {
            _db = db;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> GetVentas(){
            var lista = await _db.Venta.ToListAsync();
            _response.Resultado = lista;
            _response.Mensjae="Listado de Ventas";

            return Ok(_response);
        }
        
       [HttpGet("{id}", Name = "GetVenta")]
        public async Task<ActionResult<Venta>> GetVenta(int id){
            var usu = await _db.Venta.FindAsync(id);
            _response.Resultado = usu;
            _response.Mensjae="Datos de las Ventas" + usu.VentaId;

            return Ok(_response);
        }
        
        [HttpPost]
        public async Task<ActionResult<Venta>> PostVenta([FromBody] Venta venta){
            await _db.Venta.AddAsync(venta);
            await _db.SaveChangesAsync();
            return CreatedAtRoute("GetVenta", new {id = venta.VentaId}, venta);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> PutVenta(int id,[FromBody] Venta venta){
            if(id != venta.VentaId) {
                return BadRequest("Id de la venta no coincide");
            }
            _db.Update(venta);
            await _db.SaveChangesAsync();
            return Ok(venta);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVenta(int id){
            var ven = await _db.Venta.FindAsync(id);
            if(ven == null) {
                return NotFound();
            }
            _db.Venta.Remove(ven);
            await _db.SaveChangesAsync();
            return NoContent();
        } 
    }
}