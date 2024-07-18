using MechRent.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechRent.Infrastructure
{
    public class ObraPublicaRepository: Repository<ObraPublica>, IObraPublicaRepository
    {
        public ObraPublicaRepository(AppDbContext context): base(context) { }

        public async Task<IEnumerable<ObraPublica>> GetContractsWithMachinesAsync()
        {
            return await _context.ObrasPublicas.
                Include(c => c.estimacionMaquinas)
                .ThenInclude(cm => cm.Maquina)
                .ToListAsync();
        }
      
    }
}
