using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourDuLich_GUI.Models
{
    public class TourType
    {
        [Key, Display(AutoGenerateField = false, Name = "Mã loại Tour")]
        public int ID { get; set; }

        [Required, Display(Name = "Tên")]
        public string Name { get; set; }
    }
}
