using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopPsychologist_WF.EntityModel
{
    //[Table("themes")] // Указываем имя таблицы в БД
    //internal class ThemeEntity
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Включуние автоинкремента
    //    [Column("Id")] // Явное указание имени столбца
    //    public int id { get; set; }

    //    [Required]
    //    [Column("PathImage")]
    //    [MaxLength(255)] // Ограничение длины для пути к изображению
    //    public string pathImage { get; set; }

    //    [Required]
    //    [Column("ThemeName")]
    //    [MaxLength(100)]
    //    public string themeName { get; set; }

    //    [DataType(DataType.Text)]
    //    public string Text { get; set; } // Для больших текстов можно использовать [DataType(DataType.Text)]
    //}
}
