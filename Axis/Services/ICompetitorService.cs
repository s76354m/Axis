using Microsoft.EntityFrameworkCore;
using ProgramManagement.Data;
using ProgramManagement.Models;

namespace ProgramManagement.Services
{
    public interface ICompetitorService
    {
        Task<IEnumerable<Competitor>> GetCompetitorsByProjectId(string projectId);
        Task<Competitor> GetCompetitorById(int competitorId);
        Task<Competitor> CreateCompetitor(Competitor competitor);
        Task<Competitor> UpdateCompetitor(Competitor competitor);
        Task<bool> DeleteCompetitor(int competitorId);
    }
}
