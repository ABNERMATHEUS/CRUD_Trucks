using System;
using System.Collections.Generic;
using System.Text;
using TrucksProject.Domain.Enums;

namespace TrucksProject.Core.DTOs
{
    public class TruckDTO
    {
        public TruckDTO()
        {
            success = false;
        }

        public TruckDTO(Guid _Id, int yearFabrication, int yearModel, ETrucksModel modelTruck)
        {
            YearFabrication = yearFabrication;
            YearModel = yearModel;
            ModelTruck = modelTruck;
            Id = _Id;
            success = true;
        }

        public Guid Id { get; set; }

        public int YearFabrication { get; set; }

        public int YearModel { get; set; }

        public ETrucksModel ModelTruck { get; set; }

        public bool success { get; set; }

    }
}
