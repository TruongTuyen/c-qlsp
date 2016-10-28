namespace TT_QLSP2.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        public int ID { get; set; }

        public int ID_Nhom { get; set; }

        [Required]
        [StringLength(200)]
        public string TenSanPham { get; set; }
        
        public double GiaSanPham { get; set; }

        [Column(TypeName = "text")]
        public string MoTa { get; set; }

        [StringLength(250)]
        public string AnhSanPham { get; set; }
    }
}
