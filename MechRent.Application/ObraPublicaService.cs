using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using MechRent.Core;
using MechRent.Core.Models;
using MechRent.Infrastructure;


namespace MechRent.Application
{
    public class ObraPublicaService : IObraPublicaService
    {
        private readonly IObraPublicaRepository _obraPublicaRepository;
        private readonly IMaquinaRepository _maquinaRepository;
        public ObraPublicaService( IObraPublicaRepository obraPublicaRepository, IMaquinaRepository maquinaRepository)
        {
            _obraPublicaRepository = obraPublicaRepository;
            _maquinaRepository = maquinaRepository;
        }

        public async Task<IEnumerable<ObraPublicaDto>> GetContractsWithEstimatedHoursAsync()
        {
            var obrasPublicas = await _obraPublicaRepository.GetContractsWithMachinesAsync();
            return obrasPublicas.Select(MapToObraPublicaDto);
        }

        public async Task<IEnumerable<ObraPublicaDto>> GetContractsWithRentedMachinesDetailsAsync()
        {
            var obrasPublicas = await _obraPublicaRepository.GetContractsWithMachinesAsync();
            return obrasPublicas.Select(MapToObraPublicaDto);
        }

        public async Task AddRentedHoursAsync(int obraId, int maquinaId, int horas)
        {
            var obraPublica = await _obraPublicaRepository.GetByIdAsync(obraId);
            var estimacionMaquina = obraPublica.estimacionMaquinas.FirstOrDefault(cm => cm.id == maquinaId);

            if (estimacionMaquina == null)
            {
                throw new ArgumentException("Maquina no encontrada en la obra publica");
            }

            estimacionMaquina.horas += horas;
            await _obraPublicaRepository.UpdateAsync(obraPublica);
        }

        public async Task<double> CalculateTotalValueAsync(int obraId, int maquinaId)
        {
            
            var obraPublica = await _obraPublicaRepository.GetByIdAsync(obraId);
            var estimacionMaquina = obraPublica.estimacionMaquinas.FirstOrDefault(cm => cm.id == maquinaId);

            if (estimacionMaquina == null )
            {
                throw new ArgumentException("Maquina no encontrada en la obra publica");
            }

            
            var maquina = await _maquinaRepository.GetByIdAsync(maquinaId);
            return estimacionMaquina.horas * maquina.precioHora;
            
            
            
            
        }

        public async Task<IEnumerable<MaquinaDto>> GetMachinesNeedingMaintenanceAsync()
        {
            var machines = await _maquinaRepository.GetMachinesNeedingMaintenanceAsync(120);
            return machines.Select(MapToMachineDto);
        }

        public async Task AddNewMachineAsync(MaquinaDto maquinaDto)
        {
            var maquina = new Maquina
            {
                nombreMaquina = maquinaDto.nombreMaquina,
                precioHora = maquinaDto.precioHora,
                frecuenciaMantenimiento = maquinaDto.frecuenciaMantenimiento
            };

            await _maquinaRepository.AddAsync(maquina);
        }

        private ObraPublicaDto MapToObraPublicaDto(ObraPublica obraPublica)
        {
            return new ObraPublicaDto
            {
                Id = obraPublica.Id,
                nombreObra = obraPublica.nombreObra,
                descripcion = obraPublica.descripcion,
                ciudad = obraPublica.ciudad,
                departamento = obraPublica.departamento,
                direccion = obraPublica.direccion,
                estimacionMaquinas = obraPublica.estimacionMaquinas.Select(cm => new EstimacionMaquinaDto
                {
                    id = cm.id,
                    maquina = MapToMachineDto(cm.maquina),
                    horas = cm.horas
                }).ToList()
            };
        }

        private MaquinaDto MapToMachineDto(Maquina maquina)
        {
            return new MaquinaDto
            {
                Id = maquina.Id,
                nombreMaquina = maquina.nombreMaquina,
                precioHora = maquina.precioHora,
                frecuenciaMantenimiento = maquina.frecuenciaMantenimiento
            };
        }

    }
  
}
