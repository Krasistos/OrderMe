using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMe.Core.Contracts
{
    public interface IHomeService
    {
        Task RefreshVehiclesAndDriversAsync();
    }
}
