using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourDuLich_GUI.BUS {
    public partial class Tour {
        public Tour()
        {
            TourDetails = new List<TourDetail>();
            TourPrices = new List<TourPrice>();
            TourGroups = new List<TourGroup>();
        }

        public Tour(Tour tour)
        {
            ID = tour.ID;
            Name = tour.Name;
            Description = tour.Description;
            PriceRef = tour.PriceRef;
            TourTypeID = tour.TourTypeID;
            CurrentPrice = tour.CurrentPrice;
            TourType = tour.TourType;
            TourDetails = tour.TourDetails;
            TourPrices = tour.TourPrices;
            TourGroups = tour.TourGroups;
        }

        [Key, Display(AutoGenerateField = false, Name = "Mã số tour")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required, Display(Name = "Tên gọi tour")]
        public string Name { get; set; }

        [Required, Display(Name = "Đặc điểm")]
        public string Description { get; set; }

        [Required, Display(Name = "Giá tham khảo")]
        public long PriceRef { get; set; }

        [ForeignKey("TourType"), Display(Name = "Loại tour")]
        public int TourTypeID { get; set; }

        [NotMapped, Display(Name = "Giá hiện tại")]
        public long CurrentPrice { get; set; }

        public virtual TourType TourType { get; set; }

        public virtual ICollection<TourDetail> TourDetails { get; set; }
        public virtual ICollection<TourPrice> TourPrices { get; set; }
        public virtual ICollection<TourGroup> TourGroups { get; set; }

        public override string ToString() {
            return $"{this.Name}";
        }
    }
}
