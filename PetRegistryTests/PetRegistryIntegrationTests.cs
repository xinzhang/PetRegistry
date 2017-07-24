using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using System.Collections.Generic;
using ServiceContracts;
using Services;
using System.IO;
using Newtonsoft.Json;

namespace PetRegistryTests
{
    [TestClass]
    public class PetRegistryIntegrationTests
    {
        private List<Owner> owners;
        private IPetOwnerRepository repository;

        private string API_URL_base = "http://agl-developer-test.azurewebsites.net";
        private string API_URL_json = "/people.json";

        [TestInitialize]
        public void LoadJson()
        {
            repository = new PetOwnerRepository(API_URL_base, API_URL_json);            
        }
       
        /// <summary>
        /// this is an integration test, need to mock the rest testing 
        /// </summary>
        [TestMethod]
        public void shouldReturnFromRestPetAPI()
        {
            var result = repository.GetOwnersFromRest();
            Assert.AreEqual(6, result.Count);
            Assert.AreEqual(2, result[0].Pets.Count);
        }

    }
}
