namespace Axis.Services
{
    public class CompetitorService : ICompetitorService
    {
        private readonly ProgramManagementContext _context;

        public CompetitorService(ProgramManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Competitor>> GetCompetitorsByProjectId(string projectId)
        {
            return await _context.Competitors
                .Where(c => c.ProjectId == projectId)
                .ToListAsync();
        }

        public async Task<Competitor> GetCompetitorById(int competitorId)
        {
            return await _context.Competitors.FindAsync(competitorId);
        }

        public async Task<Competitor> CreateCompetitor(Competitor competitor)
        {
            _context.Competitors.Add(competitor);
            await _context.SaveChangesAsync();
            return competitor;
        }

        public async Task<Competitor> UpdateCompetitor(Competitor competitor)
        {
            _context.Entry(competitor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return competitor;
        }

        public async Task<bool> DeleteCompetitor(int competitorId)
        {
            var competitor = await _context.Competitors.FindAsync(competitorId);
            if (competitor == null)
                return false;

            _context.Competitors.Remove(competitor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
