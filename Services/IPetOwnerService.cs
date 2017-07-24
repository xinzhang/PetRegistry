using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface IPetOwnerService
    {
        Dictionary<string, List<string>> GetPetsByGender(string petType);
    }

}
