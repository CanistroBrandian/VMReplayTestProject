using System.ComponentModel.DataAnnotations;

namespace WMReplayTestProject.WEB.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
