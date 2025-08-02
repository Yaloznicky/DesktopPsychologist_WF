using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopPsychologist_WF.EntityModels
{
    [Table("users")] // Указываем имя таблицы в БД
    internal class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Включуние автоинкремента
        [Column("Id")] // Явное указание имени столбца
        public int Id { get; set; }

        [Required]
        [Column("Login")]
        public string Login { get; set; }

        [Required]
        [Column("Gender")]
        public string Gender { get; set; }

        [Required]
        [Column("Password")]
        public string Password { get; set; }

        [Required]
        [Column("AvatarImage")]
        public string AvatarImage { get; set; }
    }
}
