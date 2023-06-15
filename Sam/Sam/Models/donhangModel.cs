using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sam.Models
{
    public class donhangModel
    {
        public int madonhang { get; set; }

        public int? makh { get; set; }

        public string diachi { get; set; }
        public string tenkh { get; set; }
        public string ghichu { get; set; }

        public string sodienthoai { get; set; }

        public string ngaydat { get; set; }

        public string trangthaidon { get; set; }

        public int? tongtien { get; set; }

        public int? manv { get; set; }

        public virtual ICollection<chitietdonhang> chitietdonhangs { get; set; }
    }
}