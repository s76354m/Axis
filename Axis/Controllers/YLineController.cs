using Microsoft.AspNetCore.Mvc;
using ProgramManagement.DataTransferObjects;
using ProgramManagement.Services;
using AutoMapper;
using Microsoft.Extensions.Logging;
using ProgramManagement.Models;

namespace ProgramManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class YLineController : ControllerBase
    {
        private readonly IYLineService _yLineService;
        private readonly IMapper _mapper;

        public YLineController(IYLineService yLineService, IMapper mapper)
        {
            _yLineService = yLineService;
            _mapper = mapper;
        }

        [HttpGet("project/{projectId}")]
        public async Task<ActionResult<IEnumerable<YLineDTO>>> GetYLines(string projectId)
        {
            var yLines = await _yLineService.GetYLinesByProjectId(projectId);
            return Ok(_mapper.Map<IEnumerable<YLineDTO>>(yLines));
        }

        [HttpGet("optional/{projectId}")]
        public async Task<ActionResult<IEnumerable<YLineDTO>>> GetOptionalYLines(string projectId)
        {
            var yLines = await _yLineService.GetOptionalYLines(projectId);
            return Ok(_mapper.Map<IEnumerable<YLineDTO>>(yLines));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<YLineDTO>> GetYLine(int id)
        {
            var yLine = await _yLineService.GetYLineById(id);
            if (yLine == null)
                return NotFound();

            return Ok(_mapper.Map<YLineDTO>(yLine));
        }

        [HttpPost]
        public async Task<ActionResult<YLineDTO>> CreateYLine(CreateYLineDTO createYLineDTO)
        {
            var yLine = _mapper.Map<YLine>(createYLineDTO);
            var createdYLine = await _yLineService.CreateYLine(yLine);
            return CreatedAtAction(nameof(GetYLine), new { id = createdYLine.YLineId },
                _mapper.Map<YLineDTO>(createdYLine));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<YLineDTO>> UpdateYLine(int id, YLineDTO yLineDTO)
        {
            if (id != yLineDTO.YLineId)
                return BadRequest();

            var yLine = _mapper.Map<YLine>(yLineDTO);
            var updatedYLine = await _yLineService.UpdateYLine(yLine);
            return Ok(_mapper.Map<YLineDTO>(updatedYLine));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteYLine(int id)
        {
            var result = await _yLineService.DeleteYLine(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
