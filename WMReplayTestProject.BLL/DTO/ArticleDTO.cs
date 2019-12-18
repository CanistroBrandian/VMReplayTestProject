using System;
using System.Collections.Generic;
using System.Text;

namespace WMReplayTestProject.BLL.DTO
{
   public class ArticleDTO
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public string TagId { get; set; }
        public DateTime PublishedDateTime { get; set; }
    }
}
