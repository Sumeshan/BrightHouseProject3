using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrightHouseLast.Models
{
    public interface IOrderRepository
    {
        Task Add(Orders order);
        Task Update(Orders order);
        Task Delete(string id);
        Task<Orders> GetOrders(string id);
        Task<IEnumerable<Orders>> GetOrders();
    }
}
