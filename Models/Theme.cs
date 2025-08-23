using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesktopPsychologist_WF.Models
{
    public class Theme
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string pathImage { get; set; }
        public string themeName { get; set; }
        public string text { get; set; }
    }
}
