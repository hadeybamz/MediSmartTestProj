using MediSmartTestProjAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediSmartTestProjAPI.Utility
{
    public interface IUtilities
    {
        Task<Registration> GetRegistration(int id);
        Task<List<Registration>> GetAllRegistrationTask();
        Task<Registration> GetRegistrationById(int id);
    }
}