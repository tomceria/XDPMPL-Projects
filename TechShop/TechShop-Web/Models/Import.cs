using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TechShop_Web.Models
{
    public class Import
    {
        [DisplayName("Mã PN")]
        public int Id { get; set; }
        
        [DisplayName("Ngày giờ")]
        public DateTime Date { get; set; }
        
        [DisplayName("Nhà cung cấp")]
        public string Supplier { get; set; }
        
        public virtual ICollection<ImportDetail> ImportDetails { get; set; }
    }
}