using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrucksProject.Domain.Entities;
using TrucksProject.Domain.Repository;

namespace TrucksProject.TestUnit.FakeRepository
{
    public class TruckFakeRepository : ITruckRepository
    {
        private readonly List<Truck> _trucks;
        public TruckFakeRepository()
        {
            _trucks = new List<Truck>();
        }

        public async Task<Truck> SaveAsync(Truck obj)
        {
            return  await Task.Run(()=>
            {
                _trucks.Add(obj);
                return obj;
            });
            
        }

        public async Task<Truck> UpdateAsync(Truck obj)
        {
            return  await Task.Run(()=>
            {
                var truckDatabase = _trucks.FirstOrDefault((x) => x.Id == obj.Id);
                _trucks.Remove(truckDatabase);
                _trucks.Add(obj);
                return obj;
            });
        }

        public async Task<Truck> GetByIdAsync(Guid id)
        {
            return  await Task.Run(()=>
            {
                return _trucks.FirstOrDefault((x) => x.Id == id);
            });
        }

        public async Task<IReadOnlyCollection<Truck>> GetAllAsync()
        {
            return  await Task.Run(()=> _trucks);
        }

        public async Task<Truck> DeleteAsync(Truck obj)
        {
            return  await Task.Run(()=>
            {
                _trucks.Remove(obj);
                return obj;
            });
        }
    }
}