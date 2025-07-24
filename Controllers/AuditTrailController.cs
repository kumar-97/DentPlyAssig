using Microsoft.AspNetCore.Mvc;
using AuditTrailAPI.Models;
using AuditTrailAPI.Services;

namespace AuditTrailAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditTrailController : ControllerBase
    {
        private readonly AuditTrailService _auditService;

        public AuditTrailController()
        {
            _auditService = new AuditTrailService();
        }

        [HttpPost("log")]
        public IActionResult LogChange([FromBody] AuditRequest request)
        {
            if (request == null)
                return BadRequest("Invalid request");

            var result = _auditService.GenerateAudit(request);
            return Ok(result);
        }
    }
}