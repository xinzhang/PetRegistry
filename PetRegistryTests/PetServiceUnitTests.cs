using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using ServiceContracts;
using Rhino.Mocks;
using Services;
using System.IO;
using Newtonsoft.Json;

namespace PetRegistryTests
{
    /// <summary>
    /// Summary description for PetServiceUnitTests
    /// </summary>
    [TestClass]
    public class PetServiceUnitTests
    {
        private IPetOwnerRepository repository;
        private IPetOwnerService service;

        [TestInitialize]
        public void Init()
        {
            var listOwners = LoadOwnersFromFile();

            var _mockDAO = MockRepository.GenerateMock<IPetOwnerRepository>();
            _mockDAO.Stub(dao => dao.GetOwnersFromRest())
                .Return(listOwners);

            service = new PetOwnerService(_mockDAO);
        }

        //utility function to load test data directly
        private List<Owner> LoadOwnersFromFile()
        {
            string jsonstr = File.ReadAllText("testdata.json");
            return JsonConvert.DeserializeObject<List<Owner>>(jsonstr);
        }

        [TestMethod]
        public void shouldReturnCats()
        {
            var result = service.GetPetsByGender("Cat");

            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.ContainsKey("Female"));
            Assert.IsTrue(result.ContainsKey("Male"));

        }

    }
}
