using AutoMapper;
using Entities.DTO;
using LoggerService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using powerplant_payload.Calculation;
using System.Reflection.Emit;

namespace powerplant_payload.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class LoadController : Controller
    {

        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;


        public LoadController(ILoggerManager logger, IMapper mapper, IConfiguration configuration)
        {
            _logger = logger;
            _mapper = mapper;
            _configuration = configuration;
        }


        // POST: api/Load/Productionplan
        /// <summary>
        /// Productionplan.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///  POST: api/Load/Productionplan
        ///  {
        ///   }
        /// </remarks>
        /// <param name="payloadinfo"></param>
        /// <returns>Request has succeeded</returns>
        /// <response code="200">Request has succeeded</response>
        /// <response code="400">The element is null or not valid</response>  
        /// <response code="500">Something went wrong inside</response>  
        [ProducesResponseType(StatusCodes.Status200OK)]     //  Request has succeeded
        [ProducesResponseType(StatusCodes.Status400BadRequest)]  // BadRequest
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]  // Internal Server Error
        [HttpPost]
        public async Task<IActionResult> Productionplan([FromBody] Payload payloadinfo)
        {
            try
            {
                if (payloadinfo == null)
                {
                    _logger.LogError("payloadinfo object sent from registerUser is null.");
                    return BadRequest("payloadinfo object is null");
                }

                // Calculate merit-order based on fuel cost per MWh
                var meritOrder = payloadinfo.PowerPlants.OrderBy(p => Dispatch.GetFuelCost(payloadinfo.Fuels, p)).ToList();

                // Calculate the available wind energy
                var windEnergyAvailable = payloadinfo.Fuels.WindPercentage / 100.0 * Dispatch.GetTotalWindCapacity(payloadinfo.PowerPlants);


                // Calculate generation plan
                var generationPlan = Dispatch.EconomicDispatch(payloadinfo, meritOrder, windEnergyAvailable);

                return Ok(generationPlan);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Register action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
