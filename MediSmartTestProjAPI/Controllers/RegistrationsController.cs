using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediSmartTestProjAPI.Models;
using Omu.ValueInjecter;
using MediSmartTestProjAPI.Utility;
using Microsoft.AspNetCore.Authorization;

namespace MediSmartTestProjAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly MediSmartDBContext _context;
        private readonly IUtilities _utilities;
        private string serverResponse = "Sorry,something went wrong while processing your request! We've noted it and we are going to fix this asap.";

        public RegistrationsController(MediSmartDBContext context, IUtilities utilities)
        {
            _context = context;
            _utilities = utilities;
        }

        // GET: api/Registrations
        [HttpGet]
        [Route("getall")]
        public async Task<ActionResult<IEnumerable<Registration>>> GetRegistrations()
        {
            try
            {
                var result = await _utilities.GetAllRegistrationTask();

                if (result == null)
                {
                    return Ok(new JsonMessage<string>()
                    {
                        Success = false,
                        ErrorMessage = "No Record Found"
                    });
                }

                return Ok(new JsonMessage<Registration>()
                {
                    Success = true,
                    Results = result
                });
            }
            catch(Exception ex)
            {
                return Ok(new JsonMessage<string>()
                {
                    Success = false,
                    ErrorMessage = serverResponse
                });
            }
            
        }

        // GET: api/Registrations/5
        [AllowAnonymous]
        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<Registration>> GetRegistration(int id)
        {
            try
            {
                var registration = await _utilities.GetRegistrationById(id);

                if (registration == null)
                {
                    return Ok(new JsonMessage<string>()
                    {
                        Success = false,
                        ErrorMessage = "No Record Found"
                    });
                }

                return Ok(new JsonMessage<Registration>()
                {
                    Success = true,
                    Results = new List<Registration> { registration }
                });
            }
            catch (Exception ex)
            {
                return Ok(new JsonMessage<string>()
                {
                    Success = false,
                    ErrorMessage = serverResponse
                });
            }

        }

        // PUT: api/Registrations/5
        [HttpPut()]
        [Route("update/{id}")]
        public async Task<IActionResult> PutRegistration(int id, RegistrationDTOW registration)
        {
            try
            {
                var result = await _utilities.GetRegistration(id);

                if (result != null)
                {
                    result.InjectFrom(registration);

                    _context.Entry(result).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return Ok(new JsonMessage<Registration>()
                    {
                        Success = true
                    });
                }

                return Ok(new JsonMessage<string>()
                {
                    Success = false,
                    ErrorMessage = "No Record Found"
                });
            }
            catch (Exception ex)
            {
                return Ok(new JsonMessage<string>()
                {
                    Success = false,
                    ErrorMessage = serverResponse
                });

            }
        }

        // POST: api/Registrations
        [HttpPost]
        public async Task<IActionResult> PostRegistration(Registration registration)
        {
            try
            {
                var result = _context.Registrations.Add(registration);

                if (result == null)
                {
                    return Ok(new JsonMessage<string>()
                    {
                        Success = false,
                        ErrorMessage = "No Record Found"
                    });
                }
                await _context.SaveChangesAsync();

                return Ok(new JsonMessage<string>()
                {
                    Success = true,
                });

            }

            catch (Exception ex)
            {
                return Ok(new JsonMessage<string>()
                {
                    Success = false,
                    ErrorMessage = serverResponse
                });

            }
        }

        // DELETE: api/Registrations/5
        [HttpDelete()]
        [Route("delete/{id}")]
        public async Task<ActionResult<Registration>> DeleteRegistration(int id)
        {
            try
            {
                var registration = await _utilities.GetRegistration(id);
                if (registration == null)
                {
                    return Ok(new JsonMessage<string>()
                    {
                        Success = true,
                        ErrorMessage = "No Record Found"
                    });
                }

                _context.Registrations.Remove(registration);
                await _context.SaveChangesAsync();
                return Ok(new JsonMessage<string>()
                {
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return Ok(new JsonMessage<string>()
                {
                    Success = false,
                    ErrorMessage = serverResponse
                });

            }
        }


    }
}
