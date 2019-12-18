using System;
using System.Collections.Generic;
using System.Text;
using WMReplayTestProject.DAL.Context;
using WMReplayTestProject.DAL.Entities;
using WMReplayTestProject.DAL.Interfaces;

namespace WMReplayTestProject.DAL.Repositories
{
    public class TagRepository : CommonRepository<Tag>, ITagRepository
    {
        public TagRepository(EFContext context) : base(context)
        {
        }
    }
}