using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechRent.Application
{
    public interface IObraPublicaService
    {
        Task<IEnumerable<ObraPublicaDto>> GetContractsWithEstimatedHoursAsync();
        Task<IEnumerable<ObraPublicaDto>> GetContractsWithRentedMachinesDetailsAsync();
        Task AddRentedHoursAsync(int obraId, int maquinaId, int horas);
        Task<double> CalculateTotalValueAsync(int obraId, int maquinaId);
        Task<IEnumerable<MaquinaDto>> GetMachinesNeedingMaintenanceAsync();
        Task AddNewMachineAsync(MaquinaDto maquinaDto);
    }
}
