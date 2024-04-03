using TaskManager.BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace TaskManager.BusinessLogic
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriLogController : ControllerBase
    {
        private IRepository _repository;

        public SeriLogController(IRepository logRepository)
        {
            _repository = logRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var logs = await _repository.GetAllAsync();
            return Ok(logs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var log = await _repository.GetByIdAsync(id);
            if (log == null)
            {
                return NotFound();
            }
            return Ok(log);
        }

        [HttpGet("count-by-day")]
        public async Task<IActionResult> GetLogCountByDay()
        {
            var logs = await _repository.GetLogCountByDayAsync();
            return Ok(logs);
        }

        [HttpGet("get-by-logLevel")]
        public async Task<IActionResult> GetByLogLevel(string logLevel)
        {
            var logs = await _repository.GetByLogLevelAsync(logLevel);
            return Ok(logs);
        }

        [HttpGet("get-by-message")]
        public async Task<IActionResult> GetByMessage(string message)
        {
            var logs = await _repository.GetByMessageAsync(message);
            return Ok(logs);
        }
    }
}
