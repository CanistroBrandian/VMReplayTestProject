using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WMReplayTestProject.DAL.Context;
using WMReplayTestProject.DAL.Entities;
using WMReplayTestProject.DAL.Interfaces;

namespace WMReplayTestProject.DAL.Repositories
{
    public class ArticleRepository : CommonRepository<Article>, IArticleRepository
    {
        public ArticleRepository(EFContext context) : base(context)
        {
        }
        public override async Task<IEnumerable<Article>> GetAllAsync(Expression<Func<Article, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _context.Set<Article>().Include(e => e.Category).Include(u => u.Tag).AsNoTracking().ToListAsync();
            }
            return await _context.Set<Article>().Where(predicate).Include(e => e.Category).Include(u => u.Tag).AsNoTracking().ToListAsync();
        }

        public override async Task<Article> FindByIdAsync(int id)
        {
            return await _context.Set<Article>().Include(e => e.Category).Include(u => u.Tag).AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public override async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _context.Set<Article>().Include(e => e.Category).Include(u => u.Tag).AsNoTracking().ToListAsync();
        }
    }
}
