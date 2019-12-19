using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WMReplayTestProject.DAL.Entities
{
   public class Category:BaseEntity
    {
        // [Key]
        //  [ForeignKey("Article")]
        //  public override int Id { get; set; }
      
      //  public int ArticleId { get; set; }
       // [ForeignKey("Id")]
        public Article Article { get; set; }
    }
}
