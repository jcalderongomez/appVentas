using Core.Entidades;
using Core.Dto;
using Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private ResponseDto _response;

        public UsuarioController(ApplicationDbContext db)
        {
            _db = db;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios(){
            var lista = await _db.Usuario.ToListAsync();
            _response.Resultado = lista;
            _response.Mensjae="Listado de Usuarios";

            return Ok(_response);
        }
        
       [HttpGet("{id}", Name = "GetUsuario")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id){
            var usu = await _db.Usuario.FindAsync(id);
            _response.Resultado = usu;
            _response.Mensjae="Datos de las Usuarios" + usu.UsuarioId;

            return Ok(_response);
        }
        
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario([FromBody] Usuario usuario){
            await _db.Usuario.AddAsync(usuario);
            await _db.SaveChangesAsync();
            return CreatedAtRoute("GetUsuario", new {id = usuario.UsuarioId}, usuario);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> PutUsuario(int id,[FromBody] Usuario usuario){
            if(id != usuario.UsuarioId) {
                return BadRequest("Id de la usuario no coincide");
            }
            _db.Update(usuario);
            await _db.SaveChangesAsync();
            return Ok(usuario);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsuario(int id){
            var categ = await _db.Usuario.FindAsync(id);
            if(categ == null) {
                return NotFound();
            }
            _db.Usuario.Remove(categ);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}