using MechRent.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechRent.Infrastructure
{
    public class MaquinaRepository : Repository<Maquina>, IMaquinaRepository
    {
        public MaquinaRepository(AppDbContext context) : base(context)
        {
              
        }
        public async Task<IEnumerable<Maquina>> GetMachinesNeedingMaintenanceAsync(int hoursThreshold)
        {
            return await _context.Maquinas
                .Where(m => m.frecuenciaMantenimiento - hoursThreshold<=120)
                .ToListAsync();
        }
    }
}
