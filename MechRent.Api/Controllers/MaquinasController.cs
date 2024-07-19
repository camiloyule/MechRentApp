using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MechRent.Application;

namespace MechRent.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinasController : ControllerBase
    {
        private readonly IObraPublicaService _obraPublicaService;

        public MaquinasController(IObraPublicaService obraPublicaService)
        {
            _obraPublicaService = obraPublicaService;
        }

        [HttpGet("maintenance")]
        public async Task<ActionResult<IEnumerable<MaquinaDto>>> GetMachinesNeedingMaintenance()
        {
            var maquinas = await _obraPublicaService.GetMachinesNeedingMaintenanceAsync();
            return Ok(maquinas);
        }

        [HttpPost]
        public async Task<ActionResult> AddNewMachine([FromBody] MaquinaDto machineDto)
        {
            await _obraPublicaService.AddNewMachineAsync(machineDto);
            return CreatedAtAction(nameof(GetMachinesNeedingMaintenance), null);
        }
    }
}
