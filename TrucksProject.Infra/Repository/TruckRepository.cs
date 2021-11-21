using System;
using System.Collections.Generic;
using System.Text;
using TrucksProject.Domain.Entities;
using TrucksProject.Domain.Repository;
using TrucksProject.Infra.DataContext;

namespace TrucksProject.Infra.Repository
{
    public class TruckRepository : BaseRepository<Truck>,ITruckRepository
    {
        public TruckRepository(Context context) : base(context)
        {
        }
    }
}
