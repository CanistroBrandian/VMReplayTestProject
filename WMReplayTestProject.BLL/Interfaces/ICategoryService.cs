using System.Collections.Generic;
using System.Threading.Tasks;
using WMReplayTestProject.BLL.DTO;
using WMReplayTestProject.DAL.Entities;

namespace WMReplayTestProject.BLL.Interfaces
{
    public  interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllAsync();
        Task<CategoryDTO> GetByIdAsync(int id);
        Task UpdateAsync(CategoryDTO item);
        Task DeleteAsync(int id);
        Task<CategoryDTO> CreateAsync(CategoryDTO item);
        Task<IEnumerable<CategoryDTO>> GetAllAsync(string category = null);
    }
}
