namespace Sam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("chitietdonhang")]
    public partial class chitietdonhang
    {
        [Key]
        public int? machitietdh { get; set; }

        public int? madonhang { get; set; }

        public int masp { get; set; }

        public int? soluong { get; set; }

        public int? dongia { get; set; }

        public virtual donhang donhang { get; set; }

        public virtual sanpham sanpham { get; set; }

    }
}
