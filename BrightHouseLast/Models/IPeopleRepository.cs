using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrightHouseLast.Models
{
    public interface IPeopleRepository
    {

        Task Add(People people);
        Task Update(People people);
        Task Delete(string id);
        Task<People> GetMember(string id);
        Task<IEnumerable<People>> GetMembers();
    }
}
