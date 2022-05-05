using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DomainModel;
using WebApplication1.UnitOfWork;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<WarehouseController> _logger;

        public WarehouseController(ILogger<WarehouseController> logger, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<ValuesController>
        [HttpGet("GetCarsSortedByDateAsc")]
        public IActionResult GetCarsSortedByDateAsc(int page = 1)
        {
            try
            {
                return Ok(unitOfWork.WarehouseRepository.GetCarsByDateAddedAsc(page, 10));
            }
            catch (ArgumentException argumentException)
            {
                _logger.LogWarning(argumentException, "Argument Exception in Get");
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some unknown error has occurred.");
                return BadRequest();
            }

        }

            // GET api/<ValuesController>/5
            [HttpGet("GetMoreInfo/{vehicleId}")]
        public IActionResult GetMoreInfo(int vehicleId)
        {
            try
            {
                return Ok(unitOfWork.WarehouseRepository.GetCarDetails(vehicleId));
            }
            catch (ArgumentException argumentException)
            {
                _logger.LogWarning(argumentException, "Argument Exception in Get");
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some unknown error has occurred.");
                return BadRequest();
            }
        }

    }
}
