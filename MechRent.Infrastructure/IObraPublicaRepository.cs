using MechRent.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechRent.Infrastructure
{
    public interface IObraPublicaRepository: IRepository<ObraPublica>
    {
        Task<IEnumerable<ObraPublica>> GetContractsWithMachinesAsync();
    }
}
