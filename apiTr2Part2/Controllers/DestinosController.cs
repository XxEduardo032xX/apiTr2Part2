using apiTr2Part2.Data;
using apiTr2Part2.Model;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;

namespace apiTr2Part2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinosController : Controller
    {
        private IDestinos _destinos;

        public DestinosController(IDestinos destinos)
        {
            _destinos = destinos;
        }

        [HttpGet]
        public async Task<IActionResult> ListarDestino()
        {
            return Ok(await _destinos.ListarDestino());
        }


        [HttpGet("{codigo}")]
        public async Task<IActionResult> MostrarDestino(String codigo)
        {
            return Ok(await _destinos.MostrarDestino(codigo));
        }


        [HttpPost]
        public async Task<IActionResult> RegistrarDestino([FromBody] Destinos destinos)
        {
            if (destinos == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var registro = await _destinos.RegistrarDestino(destinos);
            return Created("Destino registrado...", registro);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarDestino([FromBody] Destinos destinos)
        {
            if (destinos == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var registro = await _destinos.ActualizarDestino(destinos);
            return Created("Destino actualizado...", registro);
        }


        [HttpDelete]
        public async Task<IActionResult> EliminarDestino(String codigo)
        {
            var registro = await _destinos.EliminarDestino(codigo);
            return Created("Destino Eliminado...", registro);
        }

    }
}
