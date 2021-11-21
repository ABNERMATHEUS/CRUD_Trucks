using System;
using System.Collections.Generic;
using System.Text;
using TrucksProject.Domain.Enums;

namespace TrucksProject.Domain.Entities
{
    public class Truck : Entity
    {
        public Truck()
        {
        }

        public Truck(ETrucksModel model, int yearFabrication, int yearModel) : base() 
        {
            IdModelTruck = model;
            YearFabrication = yearFabrication;
            YearModel = yearModel;
        }

        public Truck(int yearFabrication, int yearModel, ETrucksModel idModelTruck, ModelTruck modelTruck):base()
        {
            YearFabrication = yearFabrication;
            YearModel = yearModel;
            IdModelTruck = idModelTruck;
            ModelTruck = modelTruck;
        }

        public int YearFabrication { get;  set; }

        public int YearModel { get;  set; }

        public ETrucksModel IdModelTruck { get;  set; }   
        public ModelTruck ModelTruck { get;  set; }

    }
}
