using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities
{
    [Table("Article")]
    public class Article
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required, StringLength(50)]
        public string Author { get; set; }
        [Required, StringLength(50)]
        public string CategoryName { get; set; }
        [Required, StringLength(50)]
        public string ArticleData { get; set; }
        [Required, StringLength(50)]
        public string Title { get; set; }
        [Required, StringLength(50)]
        public string ImageUrl { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int ReadingCount { get; set; }
        [Required]
        public string Content { get; set; }
        [Required, StringLength(150)]
        public string ArticleUrl { get; set; }
        [Required, StringLength(250)]
        public string Tags { get; set; }

    }
}
