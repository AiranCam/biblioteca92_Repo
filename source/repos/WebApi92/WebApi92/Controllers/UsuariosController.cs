using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi92.Services;

namespace WebApi92.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosServices _usuariosServices;
        public UsuariosController(IUsuariosServices usuariosServices)
        {
            _usuariosServices = usuariosServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var response = _usuariosServices.GetUsuarios();

            return Ok(response.Result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _usuariosServices.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] UsuariosResponse request)
        {
            var response = _usuariosServices.CrearUsuario(request);
            return Ok(response.Result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] UsuariosResponse request)
        {
            try
            {
                var response = await _usuariosServices.ActualizarUsuario(id, request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                var response = await _usuariosServices.EliminarUsuario(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
