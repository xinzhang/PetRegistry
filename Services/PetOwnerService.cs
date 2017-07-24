using Entities;
using Newtonsoft.Json;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PetOwnerService : IPetOwnerService
    {
        private IPetOwnerRepository petRepository;

        public PetOwnerService(IPetOwnerRepository repository)
        {
            this.petRepository = repository;
        }

        public Dictionary<string, List<string>> GetPetsByGender(string petType)
        {
            var petOwners = petRepository.GetOwnersFromRest();

            //flat map the list and considered the pets are null
            var qry = petOwners.Where(x => x.Pets != null)
                    .SelectMany(x => x.Pets, (a, b) => new { Gender = a.Gender, PetName = b.Name, Type = b.Type})
                    .Where(t => t.Type == petType)                    
                    .OrderBy(y => y.PetName)
                    .ToList();

            //group the data and conver to dictionary
            var ret = qry.GroupBy(x => x.Gender)
                        .ToDictionary(grp => grp.Key, grp => grp.Select(x=>x.PetName).ToList());

            return ret;
        }
    }
}
