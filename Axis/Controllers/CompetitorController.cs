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
    public class CompetitorController : ControllerBase
    {
        private readonly ICompetitorService _competitorService;
        private readonly IMapper _mapper;

        public CompetitorController(ICompetitorService competitorService, IMapper mapper)
        {
            _competitorService = competitorService;
            _mapper = mapper;
        }

        [HttpGet("project/{projectId}")]
        public async Task<ActionResult<IEnumerable<CompetitorDTO>>> GetCompetitors(string projectId)
        {
            var competitors = await _competitorService.GetCompetitorsByProjectId(projectId);
            return Ok(_mapper.Map<IEnumerable<CompetitorDTO>>(competitors));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompetitorDTO>> GetCompetitor(int id)
        {
            var competitor = await _competitorService.GetCompetitorById(id);
            if (competitor == null)
                return NotFound();

            return Ok(_mapper.Map<CompetitorDTO>(competitor));
        }

        [HttpPost]
        public async Task<ActionResult<CompetitorDTO>> CreateCompetitor(CreateCompetitorDTO createCompetitorDTO)
        {
            var competitor = _mapper.Map<Competitor>(createCompetitorDTO);
            var createdCompetitor = await _competitorService.CreateCompetitor(competitor);
            return CreatedAtAction(nameof(GetCompetitor), new { id = createdCompetitor.CompetitorId },
                _mapper.Map<CompetitorDTO>(createdCompetitor));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CompetitorDTO>> UpdateCompetitor(int id, CompetitorDTO competitorDTO)
        {
            if (id != competitorDTO.CompetitorId)
                return BadRequest();

            var competitor = _mapper.Map<Competitor>(competitorDTO);
            var updatedCompetitor = await _competitorService.UpdateCompetitor(competitor);
            return Ok(_mapper.Map<CompetitorDTO>(updatedCompetitor));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompetitor(int id)
        {
            var result = await _competitorService.DeleteCompetitor(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
