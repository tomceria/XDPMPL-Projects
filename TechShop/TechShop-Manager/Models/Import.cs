using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TechShop_Manager.BUS
{
    public partial class Import
    {
        [DisplayName("Mã PN")]
        public int Id { get; set; }
        
        [DisplayName("Ngày giờ")]
        public DateTime Date { get; set; } = DateTime.Now;
        
        [DisplayName("Nhà cung cấp")]
        public string Supplier { get; set; }
        
        public virtual ICollection<ImportDetail> ImportDetails { get; set; }

    }
}