using System;
using System.Collections.Generic;
using System.Text;

namespace WMReplayTestProject.DAL.Entities
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
