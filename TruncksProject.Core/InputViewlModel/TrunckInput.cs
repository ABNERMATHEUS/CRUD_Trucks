using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TruncksProject.Domain.Enums;

namespace TruncksProject.Core.InputViewModel
{
    public class TrunckInput
    {
        
        public TrunckInput()
        { 
        }

       public TrunckInput(Guid _Id, int yearFabrication, int yearModel, ETruncksModel modelTruck)
        {
            YearFabrication = yearFabrication;
            YearModel = yearModel;
            Model = modelTruck;
            Id = _Id;
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "É obrigatório.")]
        public ETruncksModel Model { get; set; }

        [Required(ErrorMessage = "É obrigatório.")]
        public int YearFabrication { get; set; } = DateTime.Now.Year;

        [Required(ErrorMessage = "É obrigatório.")]
        [Range(2021, int.MaxValue, ErrorMessage = "Valor deve ser igual ou maior do que o ano atual")]
        public int YearModel { get;  set; }



    }
}
