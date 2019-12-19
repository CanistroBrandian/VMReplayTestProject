using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WMReplayTestProject.WEB.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDateTime { get; set; }
        public string CategoryId { get; set; }
        public string TagId { get; set; }
    }
}
