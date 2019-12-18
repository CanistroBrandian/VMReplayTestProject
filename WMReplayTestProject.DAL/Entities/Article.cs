using System;
using System.Collections.Generic;
using System.Text;

namespace WMReplayTestProject.DAL.Entities
{
   public class Article :BaseEntity
    {
        public string CategoryId { get; set; }
        public string TagId { get; set; }
        public DateTime PublishedDateTime { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Tag> Tags { get; set; }

    }
}
