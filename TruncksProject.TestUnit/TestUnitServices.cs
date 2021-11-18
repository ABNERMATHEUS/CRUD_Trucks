using System;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TruncksProject.Core.Contracts;
using TruncksProject.Core.InputViewModel;
using TruncksProject.Core.Services;
using TruncksProject.Domain.Enums;
using TruncksProject.TestUnit.FakeRepository;

namespace TruncksProject.TestUnit
{
    [TestClass]
    public class UnitTest1
    {
        
        private IServiceTrunck _serviceTrunck = new TrunckService(new TrunckFakeRepository());
        private TrunckInput _trunkInputValid = new TrunckInput(Guid.NewGuid(), 2021, 2022, ETruncksModel.FH);
        private TrunckInput _trunkInputInvalid = new TrunckInput(Guid.NewGuid(), 2021, 2020, ETruncksModel.FH);
        [TestMethod]
        [Category("TESTE COM CAMINHÃO VÁLIDO")]
        public void Validation_Insert_Trunck_Valid()
        {
            var result = _serviceTrunck.CreateAsync(_trunkInputValid);
            Assert.AreEqual(true,result.Result.success);
        }
        
        [TestMethod]
        [Category("TESTE COM CAMINHÃO INVÁLIDO")]
        public void Validation_Insert_Trunck_Invalid()
        {
            var result = _serviceTrunck.CreateAsync(_trunkInputInvalid);
            Assert.AreEqual(false,result.Result.success);
        }
        
        [TestMethod]
        [Category("TESTE Atualizando caminhão que não existe")]
        public void Validation_Update_Trunck_Not_Exist()
        {
            var result = _serviceTrunck.UpdateAsync(_trunkInputValid);
            Assert.AreEqual(false,result.Result);
        }
        
        [TestMethod]
        [Category("TESTE Atualizando caminhão valido ")]
        public void Validation_Update_Trunck_Valid()
        {
            
            var trunck_created = _serviceTrunck.CreateAsync(_trunkInputValid).Result;
            _trunkInputValid.Model = ETruncksModel.FM;
            _trunkInputValid.Id = trunck_created.Id;
            var result = _serviceTrunck.UpdateAsync(_trunkInputValid);
            Assert.AreEqual(true,result.Result);
            var trunck = _serviceTrunck.GetByIdAsync(_trunkInputValid.Id);
            Assert.AreEqual(ETruncksModel.FM,trunck.Result.ModelTrunck);
        }
        
        [TestMethod]
        [Category("TESTE Atualizando caminhão inválido ")]
        public void Validation_Update_Trunck_Invalid()
        {
            
            var trunck_created = _serviceTrunck.CreateAsync(_trunkInputValid).Result;
            var trunck_invalid = _trunkInputValid;
            trunck_invalid.Id = trunck_created.Id;
            trunck_invalid.YearModel = 1900;
            var result = _serviceTrunck.UpdateAsync(_trunkInputValid).Result;
            Assert.AreEqual(false,result);
        }
        
        [TestMethod]
        [Category("TESTE buscando caminhão com Id inválido ")]
        public void Validation_GetById_Invalid()
        {
            var result = _serviceTrunck.GetByIdAsync(Guid.NewGuid()).Result;
            Assert.AreEqual(null,result);
        }
        
        [TestMethod]
        [Category("TESTE Deletando caminhão válido ")]
        public void Validation_Delete_valid()
        {
            var trunck_created = _serviceTrunck.CreateAsync(_trunkInputValid).Result;
            var result = _serviceTrunck.DeleteAsync(trunck_created.Id).Result;
            Assert.AreEqual(true,result);
        }
    }
}
