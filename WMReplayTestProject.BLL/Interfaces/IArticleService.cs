using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WMReplayTestProject.BLL.DTO;
using WMReplayTestProject.DAL.Entities;

namespace WMReplayTestProject.BLL.Interfaces
{
    public interface IArticleService
    {
        Task<IEnumerable<ArticleDTO>> GetAllAsync();
        Task<ArticleDTO> GetByIdAsync(int id);
        Task UpdateAsync(ArticleDTO item);
        Task DeleteAsync(int id);
        Task<ArticleDTO> CreateAsync(ArticleDTO item);
        Task<IEnumerable<ArticleDTO>> GetAllAsync(string category = null, string tag = null);
    }
}
