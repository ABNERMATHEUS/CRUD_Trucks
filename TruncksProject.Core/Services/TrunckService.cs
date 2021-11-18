using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruncksProject.Core.Contracts;
using TruncksProject.Core.InputViewModel;
using TruncksProject.Domain.DTOs;
using TruncksProject.Domain.Entities;

using TruncksProject.Domain.Repository;

namespace TruncksProject.Core.Services
{
    public class TrunckService : IServiceTrunck
    {
        private readonly ITrunckRepository _trunckRepository;

        public TrunckService(ITrunckRepository trunckRepository)
        {
            _trunckRepository = trunckRepository;
        }

        public async Task<TrunckDTO> CreateAsync(TrunckInput command)
        {
            if (!ValidateBusiness(command))
            {
                return new TrunckDTO();
            }
            
            var trunck = new Trunck(command.Model,
                      command.YearFabrication,
                      command.YearModel);

            await _trunckRepository.SaveAsync(trunck);
            
            return new TrunckDTO(trunck.Id, trunck.YearFabrication, trunck.YearModel, trunck.IdModelTrunck);
        }

        public async Task<bool> DeleteAsync(Guid command)
        {
            var trunck = await _trunckRepository.GetByIdAsync(command);
            if(trunck == null){
                return false;
            }
            await _trunckRepository.DeleteAsync(trunck);
            return true;
        }

        public async Task<List<TrunckDTO>> GetAllAsync()
        {
            var truncks = await _trunckRepository.GetAllAsync();
            var list = new List<TrunckDTO>();
            truncks.ToList().ForEach(trunck => list.Add(new TrunckDTO(trunck.Id,trunck.YearFabrication, trunck.YearModel, trunck.IdModelTrunck)));
            return list;
        }

        public async Task<TrunckDTO> GetByIdAsync(Guid command)
        {
           
            var trunck = await _trunckRepository.GetByIdAsync(command);
            if (trunck == null)
            {
                return null;
            }

            return new TrunckDTO(trunck.Id,trunck.YearFabrication, trunck.YearModel, trunck.IdModelTrunck);
        }

        public async Task<bool> UpdateAsync(TrunckInput command)
        {
            if (!ValidateBusiness(command))
            {
                return false;
            }

            var trunck = await _trunckRepository.GetByIdAsync(command.Id);
            if (trunck == null)
            {
                return false;
            }
            trunck.IdModelTrunck = command.Model;
            trunck.YearFabrication = command.YearFabrication;
            trunck.YearModel = command.YearModel;            
            await _trunckRepository.UpdateAsync(trunck);
            return true;
        }

        private bool ValidateBusiness(TrunckInput trunck)
        {
            if (trunck.YearFabrication == trunck.YearModel )
                return true;
            if ( trunck.YearFabrication <= trunck.YearModel)
                return true;
            return false;
        }
    }
}
