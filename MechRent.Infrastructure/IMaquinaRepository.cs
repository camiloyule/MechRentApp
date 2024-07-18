using MechRent.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechRent.Infrastructure
{
    public interface IMaquinaRepository : IRepository<Maquina>
    {
        Task<IEnumerable<Maquina>> GetMachinesNeedingMaintenanceAsync(int hoursThreshold);
    }
}
