using Entities;
using ServiceContracts;
using Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetRegistryConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string rest_base_url = ConfigurationManager.AppSettings["rest_base_url"];
            string rest_json_url = ConfigurationManager.AppSettings["rest_json_url"];

            IPetOwnerRepository rep = new PetOwnerRepository(rest_base_url, rest_json_url);            
            IPetOwnerService svc = new PetOwnerService(rep);

            var dictionary = svc.GetPetsByGender("Cat");

            foreach (string k in dictionary.Keys)
            {
                Console.WriteLine(k);
                Console.WriteLine("------------------------------------------");
                Console.WriteLine( String.Join("\n",  dictionary[k].ToArray()));
                Console.WriteLine("");
                Console.WriteLine("");
            }

            Console.ReadLine();

        }
    }
}
