using System;
using System.Collections.Generic;
using System.Text;
using TrucksProject.Domain.Enums;

namespace TrucksProject.Domain.Entities
{
    public class ModelTruck
    {
        public ModelTruck(ETrucksModel name)
        {
            Name = name;
        }

        public ETrucksModel Name { get; set; }

        public IList<Truck> Trucks { get; set; }
    }
}
