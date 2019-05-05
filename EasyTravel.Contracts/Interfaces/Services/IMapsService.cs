using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyTravel.Contracts.Interfaces.Services
{
    public interface IMapsService
    {
        Task<IEnumerable<string>> FindLocationsBetweenAsync(string from, string to);
    }
}