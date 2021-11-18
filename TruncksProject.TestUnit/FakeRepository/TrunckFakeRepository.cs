using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruncksProject.Domain.Entities;
using TruncksProject.Domain.Repository;

namespace TruncksProject.TestUnit.FakeRepository
{
    public class TrunckFakeRepository : ITrunckRepository
    {
        private readonly List<Trunck> _truncks;
        public TrunckFakeRepository()
        {
            _truncks = new List<Trunck>();
        }

        public async Task<Trunck> SaveAsync(Trunck obj)
        {
            return  await Task.Run(()=>
            {
                _truncks.Add(obj);
                return obj;
            });
            
        }

        public async Task<Trunck> UpdateAsync(Trunck obj)
        {
            return  await Task.Run(()=>
            {
                var trunckDatabase = _truncks.FirstOrDefault((x) => x.Id == obj.Id);
                _truncks.Remove(trunckDatabase);
                _truncks.Add(obj);
                return obj;
            });
        }

        public async Task<Trunck> GetByIdAsync(Guid id)
        {
            return  await Task.Run(()=>
            {
                return _truncks.FirstOrDefault((x) => x.Id == id);
            });
        }

        public async Task<IReadOnlyCollection<Trunck>> GetAllAsync()
        {
            return  await Task.Run(()=> _truncks);
        }

        public async Task<Trunck> DeleteAsync(Trunck obj)
        {
            return  await Task.Run(()=>
            {
                _truncks.Remove(obj);
                return obj;
            });
        }
    }
}