using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WMReplayTestProject.BLL.DTO;

namespace WMReplayTestProject.WEB.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        public DateTime PublishedDateTime { get; set; }
        public string CategoryId { get; set; }
        public string TagId { get; set; }
        public CategoryDTO Category { get; set; }
        public TagDTO Tag { get; set; }
    }
}
