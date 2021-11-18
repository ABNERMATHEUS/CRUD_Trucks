using System;
using System.Collections.Generic;
using System.Text;
using TruncksProject.Domain.Enums;

namespace TruncksProject.Domain.DTOs
{
    public class TrunckDTO
    {
        public TrunckDTO()
        {
            success = false;
        }

        public TrunckDTO(Guid _Id,int yearFabrication, int yearModel, ETruncksModel modelTrunck)
        {
            YearFabrication = yearFabrication;
            YearModel = yearModel;
            ModelTrunck = modelTrunck;
            Id = _Id;
            success = true;
        }

        public Guid Id { get; set; }

        public int YearFabrication { get;  set; }

        public int YearModel { get;  set; }

        public ETruncksModel ModelTrunck { get;  set; }

        public bool success { get; set; }

    }
}
