using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WMReplayTestProject.WEB.Models
{
    public class IndexViewModel
    {
        public IEnumerable<ArticleViewModel> articleViewModels { get; set; }
        public IEnumerable<TagViewModel> tagViewModels { get; set; }
        public IEnumerable<CategoryViewModel> categoryViewModels { get; set; }
    }
}
