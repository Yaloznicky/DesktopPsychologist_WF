using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopPsychologist_WF.EntityModels
{
    [Table("reviews")] // Указываем имя таблицы в БД
    internal class ReviewEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Включуние автоинкремента
        [Column("Id")] // Явное указание имени столбца
        public int id { get; set; }

        [Required]
        [Column("DateTimeReview")]
        public string dateTimeReview { get; set; }

        [DataType(DataType.Text)]
        public string text { get; set; } // Для больших текстов можно использовать [DataType(DataType.Text)]

        [Required]
        [Column("UsersId")]
        public int userId { get; set; }
    }
}
