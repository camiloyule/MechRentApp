using Microsoft.AspNetCore.Mvc;
using MechRent.Application.DTOs;
using MechRent.Application.Services;

namespace MechRent.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObrasPublicasController : ControllerBase
    {
        private readonly IObraPublicaService _obraPublicaService;

        public ObrasPublicasController(IObraPublicaService obraPublicaService)
        {
            _obraPublicaService = obraPublicaService;
        }

        [HttpGet("horas-estimadas")]
        public async Task<ActionResult<IEnumerable<ObraPublicaDto>>> GetContractsWithEstimatedHours()
        {
            var contracts = await _obraPublicaService.GetContractsWithEstimatedHoursAsync();
            return Ok(contracts);
        }

        [HttpGet("maquinas-alquiladas")]
        public async Task<ActionResult<IEnumerable<ObraPublicaDto>>> GetContractsWithRentedMachinesDetails()
        {
            var contracts = await _obraPublicaService.GetContractsWithRentedMachinesDetailsAsync();
            return Ok(contracts);
        }

        [HttpPost("{contractId}/maquinas/{machineId}/horas")]
        public async Task<ActionResult> AddRentedHours(int contractId, int machineId, [FromBody] int hours)
        {
            await _obraPublicaService.AddRentedHoursAsync(contractId, machineId, hours);
            return Ok();
        }

        [HttpGet("{contractId}/maquinas/{machineId}/valor-total")]
        public async Task<ActionResult<decimal>> CalculateTotalValue(int contractId, int machineId)
        {
            var totalValue = await _obraPublicaService.CalculateTotalValueAsync(contractId, machineId);
            return Ok(totalValue);
        }
    }
}
