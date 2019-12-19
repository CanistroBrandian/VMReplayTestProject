using System;
using System.Collections.Generic;
using System.Text;

namespace WMReplayTestProject.DAL.Entities
{
    public class Tag : BaseEntity
    {
        public IEnumerable<Article> Articles {get;set;}
    }
}
