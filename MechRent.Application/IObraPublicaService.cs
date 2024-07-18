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
        Task AddRentedHoursAsync(int nombreObra, int nombreMaquina, int hours);
        Task<double> CalculateTotalValueAsync(int nombreObra, int nombreMaquina);
        Task<IEnumerable<MaquinaDto>> GetMachinesNeedingMaintenanceAsync();
        Task AddNewMachineAsync(MaquinaDto MachinDto);
    }
}
