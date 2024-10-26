using Microsoft.EntityFrameworkCore;
using ProgramManagement.Data;
using ProgramManagement.Models;

namespace ProgramManagement.Services
{
    public class YLineService : IYLineService
    {
        private readonly ProgramManagementContext _context;

        public YLineService(ProgramManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<YLine>> GetYLinesByProjectId(string projectId)
        {
            return await _context.YLines
                .Where(y => y.ProjectId == projectId)
                .OrderBy(y => y.IsPreAward)
                .ThenBy(y => y.IsOptional)
                .ToListAsync();
        }

        public async Task<YLine> GetYLineById(int yLineId)
        {
            return await _context.YLines.FindAsync(yLineId);
        }

        public async Task<YLine> CreateYLine(YLine yLine)
        {
            _context.YLines.Add(yLine);
            await _context.SaveChangesAsync();
            return yLine;
        }

        public async Task<YLine> UpdateYLine(YLine yLine)
        {
            _context.Entry(yLine).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return yLine;
        }

        public async Task<bool> DeleteYLine(int yLineId)
        {
            var yLine = await _context.YLines.FindAsync(yLineId);
            if (yLine == null)
                return false;

            _context.YLines.Remove(yLine);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<YLine>> GetOptionalYLines(string projectId)
        {
            return await _context.YLines
                .Where(y => y.ProjectId == projectId && y.IsOptional)
                .ToListAsync();
        }
    }
}
