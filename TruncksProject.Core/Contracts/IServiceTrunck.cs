using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TruncksProject.Core.InputViewModel;
using TruncksProject.Domain.DTOs;
using TruncksProject.Domain.Entities;

namespace TruncksProject.Core.Contracts
{
    public interface IServiceTrunck
    {
        Task<TrunckDTO> GetByIdAsync( Guid command);

        Task<List<TrunckDTO>> GetAllAsync();

        Task<bool> UpdateAsync(TrunckInput command);

        Task<TrunckDTO> CreateAsync(TrunckInput command);

        Task<bool> DeleteAsync(Guid command);

    }
}
