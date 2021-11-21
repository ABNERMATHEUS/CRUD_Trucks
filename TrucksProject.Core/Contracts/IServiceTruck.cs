using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrucksProject.Core.DTOs;
using TrucksProject.Core.InputViewlModel;
using TrucksProject.Domain.Entities;

namespace TrucksProject.Core.Contracts
{
    public interface IServiceTruck
    {
        Task<TruckDTO> GetByIdAsync( Guid command);

        Task<List<TruckDTO>> GetAllAsync();

        Task<bool> UpdateAsync(TruckInput command);

        Task<TruckDTO> CreateAsync(TruckInput command);

        Task<bool> DeleteAsync(Guid command);

    }
}
