using MediSmartTestProjAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediSmartTestProjAPI.Utility
{
    public class Utilities : IUtilities
    {
        private readonly MediSmartDBContext _context;

        public Utilities(MediSmartDBContext context)
        {
            _context = context;
        }

        public async Task<Registration> GetRegistration(int id)
        {
            var result = await _context.Registrations.FirstOrDefaultAsync(u => u.id == id);
            return result;
        }

        public async Task<List<Registration>> GetAllRegistrationTask()
        {
            return await _context.Registrations.ToListAsync();
        }

        public async Task<Registration> GetRegistrationById(int id)
        {
            return await _context.Registrations.FirstOrDefaultAsync(x => x.id == id);
        }
    }
}
