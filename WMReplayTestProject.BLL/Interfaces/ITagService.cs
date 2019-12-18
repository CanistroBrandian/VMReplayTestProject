using System.Collections.Generic;
using System.Threading.Tasks;
using WMReplayTestProject.BLL.DTO;
using WMReplayTestProject.DAL.Entities;

namespace WMReplayTestProject.BLL.Interfaces
{
    public interface ITagService
    {
        Task<IEnumerable<TagDTO>> GetAllAsync();
        Task<TagDTO> GetByIdAsync(int id);
        Task UpdateAsync(TagDTO item);
        Task DeleteAsync(int id);
        Task<TagDTO> CreateAsync(TagDTO item);
        Task<IEnumerable<TagDTO>> GetAllAsync(string tag = null);
    }
}
