using System;
using System.Collections.Generic;
using System.Text;

namespace WMReplayTestProject.DAL.Entities
{
   public class Category:BaseEntity
    {
        public Article Article { get; set; }
    }
}
