using System;
using System.Collections.Generic;
using System.Text;
using TruncksProject.Domain.Enums;

namespace TruncksProject.Domain.Entities
{
    public class Trunck : Entity
    {
        public Trunck()
        {
        }

        public Trunck(ETruncksModel model, int yearFabrication, int yearModel) : base() 
        {
            IdModelTrunck = model;
            YearFabrication = yearFabrication;
            YearModel = yearModel;
        }

        public Trunck(int yearFabrication, int yearModel, ETruncksModel idModelTrunck, ModelTrunck modelTrunck):base()
        {
            YearFabrication = yearFabrication;
            YearModel = yearModel;
            IdModelTrunck = idModelTrunck;
            ModelTrunck = modelTrunck;
        }

        public int YearFabrication { get;  set; }

        public int YearModel { get;  set; }

        public ETruncksModel IdModelTrunck { get;  set; }   
        public ModelTrunck ModelTrunck { get;  set; }

    }
}
