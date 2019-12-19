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
        public int CategoryId { get; set; }
        public int TagId { get; set; }
        public DateTime PublishedDateTime { get; set; }
        public CategoryDTO Category { get; set; }
        public TagDTO Tag { get; set; }
    }
}
