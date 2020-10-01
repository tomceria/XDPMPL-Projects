﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourDuLich_GUI.Models
{
    public class TourGroup
    {
        [Key, Display(AutoGenerateField = false)]
        public int ID { get; set; }


        [ForeignKey("Tour"), Display(Name = "Tour")]
        public int TourID { get; set; }

        [Required, Display(Name = "Tên đoàn")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Required, Display(Name = "Thời gian bắt đầu")]
        public DateTime DateStart { get; set; }

        [DataType(DataType.Date)]
        [Required, Display(Name = "Thời gian kết thúc")]
        public DateTime DateEnd { get; set; }

        [Required, Display(Name = "Giá của đoàn")]
        public long PriceGroup { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
