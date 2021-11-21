using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TrucksProject.Domain.Enums;

namespace TrucksProject.Core.InputViewlModel
{
    public class TruckInput
    {

        public TruckInput()
        {
        }

        public TruckInput(Guid _Id, int yearFabrication, int yearModel, ETrucksModel modelTruck)
        {
            YearFabrication = yearFabrication;
            YearModel = yearModel;
            Model = modelTruck;
            Id = _Id;
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "É obrigatório.")]
        public ETrucksModel Model { get; set; }

        [Required(ErrorMessage = "É obrigatório.")]
        public int YearFabrication { get; set; } = DateTime.Now.Year;

        [Required(ErrorMessage = "É obrigatório.")]
        [Range(2021, int.MaxValue, ErrorMessage = "Valor deve ser igual ou maior do que o ano atual")]
        public int YearModel { get; set; }



    }
}
