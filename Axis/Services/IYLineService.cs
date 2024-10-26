using System.Numerics;

namespace Axis.Services
{
    public interface IYLineService
    {
        Task<IEnumerable<YLine>> GetYLinesByProjectId(string projectId);
        Task<YLine> GetYLineById(int yLineId);
        Task<YLine> CreateYLine(YLine yLine);
        Task<YLine> UpdateYLine(YLine yLine);
        Task<bool> DeleteYLine(int yLineId);
        Task<IEnumerable<YLine>> GetOptionalYLines(string projectId);
    }
}
