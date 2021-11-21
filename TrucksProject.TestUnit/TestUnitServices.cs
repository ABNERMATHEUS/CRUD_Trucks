using System;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrucksProject.Core.Contracts;
using TrucksProject.Core.InputViewlModel;
using TrucksProject.Core.Services;
using TrucksProject.Domain.Enums;
using TrucksProject.TestUnit.FakeRepository;

namespace TrucksProject.TestUnit
{
    [TestClass]
    public class UnitTest1
    {
        
        private IServiceTruck _serviceTruck = new TruckService(new TruckFakeRepository());
        private TruckInput _trunkInputValid = new TruckInput(Guid.NewGuid(), 2021, 2022, ETrucksModel.FH);
        private TruckInput _trunkInputInvalid = new TruckInput(Guid.NewGuid(), 2021, 2020, ETrucksModel.FH);
        [TestMethod]
        [Category("TESTE COM CAMINHÃO VÁLIDO")]
        public void Validation_Insert_Truck_Valid()
        {
            var result = _serviceTruck.CreateAsync(_trunkInputValid);
            Assert.AreEqual(true,result.Result.success);
        }
        
        [TestMethod]
        [Category("TESTE COM CAMINHÃO INVÁLIDO")]
        public void Validation_Insert_Truck_Invalid()
        {
            var result = _serviceTruck.CreateAsync(_trunkInputInvalid);
            Assert.AreEqual(false,result.Result.success);
        }
        
        [TestMethod]
        [Category("TESTE Atualizando caminhão que não existe")]
        public void Validation_Update_Truck_Not_Exist()
        {
            var result = _serviceTruck.UpdateAsync(_trunkInputValid);
            Assert.AreEqual(false,result.Result);
        }
        
        [TestMethod]
        [Category("TESTE Atualizando caminhão valido ")]
        public void Validation_Update_Truck_Valid()
        {
            
            var truck_created = _serviceTruck.CreateAsync(_trunkInputValid).Result;
            _trunkInputValid.Model = ETrucksModel.FM;
            _trunkInputValid.Id = truck_created.Id;
            var result = _serviceTruck.UpdateAsync(_trunkInputValid);
            Assert.AreEqual(true,result.Result);
            var truck = _serviceTruck.GetByIdAsync(_trunkInputValid.Id);
            Assert.AreEqual(ETrucksModel.FM,truck.Result.ModelTruck);
        }
        
        [TestMethod]
        [Category("TESTE Atualizando caminhão inválido ")]
        public void Validation_Update_Truck_Invalid()
        {
            
            var truck_created = _serviceTruck.CreateAsync(_trunkInputValid).Result;
            var truck_invalid = _trunkInputValid;
            truck_invalid.Id = truck_created.Id;
            truck_invalid.YearModel = 1900;
            var result = _serviceTruck.UpdateAsync(_trunkInputValid).Result;
            Assert.AreEqual(false,result);
        }
        
        [TestMethod]
        [Category("TESTE buscando caminhão com Id inválido ")]
        public void Validation_GetById_Invalid()
        {
            var result = _serviceTruck.GetByIdAsync(Guid.NewGuid()).Result;
            Assert.AreEqual(null,result);
        }
        
        [TestMethod]
        [Category("TESTE Deletando caminhão válido ")]
        public void Validation_Delete_valid()
        {
            var truck_created = _serviceTruck.CreateAsync(_trunkInputValid).Result;
            var result = _serviceTruck.DeleteAsync(truck_created.Id).Result;
            Assert.AreEqual(true,result);
        }
    }
}
