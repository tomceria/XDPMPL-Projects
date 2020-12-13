using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TechShop_Manager.BUS
{
    public class Import
    {
        public int Id { get; set; }
        
        [DisplayName("Ngày giờ")]
        public DateTime Date { get; set; }
        
        [DisplayName("Nhà cung cấp")]
        public string Supplier { get; set; }
        
        public virtual ICollection<ImportDetail> ImportDetails { get; set; }

    }
}