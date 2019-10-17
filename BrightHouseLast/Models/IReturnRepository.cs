using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrightHouseLast.Models
{
    public interface IReturnRepository
    {
        Task Add(Returns returns);
        Task Update(Returns returns);
        Task Delete(string id);
        Task<Returns> GetReturnItems(string id);
        Task<IEnumerable<Returns>> GetReturnItems();
    }

}

