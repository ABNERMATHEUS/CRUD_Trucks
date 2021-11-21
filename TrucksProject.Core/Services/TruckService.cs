using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrucksProject.Core.Contracts;
using TrucksProject.Core.DTOs;
using TrucksProject.Core.InputViewlModel;
using TrucksProject.Domain.Entities;

using TrucksProject.Domain.Repository;

namespace TrucksProject.Core.Services
{
    public class TruckService : IServiceTruck
    {
        private readonly ITruckRepository _truckRepository;

        public TruckService(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }

        public async Task<TruckDTO> CreateAsync(TruckInput command)
        {
            if (!ValidateBusiness(command))
            {
                return new TruckDTO();
            }
            
            var truck = new Truck(command.Model,
                      command.YearFabrication,
                      command.YearModel);

            await _truckRepository.SaveAsync(truck);
            
            return new TruckDTO(truck.Id, truck.YearFabrication, truck.YearModel, truck.IdModelTruck);
        }

        public async Task<bool> DeleteAsync(Guid command)
        {
            var truck = await _truckRepository.GetByIdAsync(command);
            if(truck == null){
                return false;
            }
            await _truckRepository.DeleteAsync(truck);
            return true;
        }

        public async Task<List<TruckDTO>> GetAllAsync()
        {
            var trucks = await _truckRepository.GetAllAsync();
            var list = new List<TruckDTO>();
            trucks.ToList().ForEach(truck => list.Add(new TruckDTO(truck.Id,truck.YearFabrication, truck.YearModel, truck.IdModelTruck)));
            return list;
        }

        public async Task<TruckDTO> GetByIdAsync(Guid command)
        {
           
            var truck = await _truckRepository.GetByIdAsync(command);
            if (truck == null)
            {
                return null;
            }

            return new TruckDTO(truck.Id,truck.YearFabrication, truck.YearModel, truck.IdModelTruck);
        }

        public async Task<bool> UpdateAsync(TruckInput command)
        {
            if (!ValidateBusiness(command))
            {
                return false;
            }

            var truck = await _truckRepository.GetByIdAsync(command.Id);
            if (truck == null)
            {
                return false;
            }
            truck.IdModelTruck = command.Model;
            truck.YearFabrication = command.YearFabrication;
            truck.YearModel = command.YearModel;            
            await _truckRepository.UpdateAsync(truck);
            return true;
        }

        private bool ValidateBusiness(TruckInput truck)
        {
            if (truck.YearFabrication == truck.YearModel )
                return true;
            if ( truck.YearFabrication <= truck.YearModel)
                return true;
            return false;
        }
    }
}
