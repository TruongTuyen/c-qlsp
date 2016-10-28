namespace TT_QLSP2.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhomSanPham")]
    public partial class NhomSanPham
    {
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Tên nhóm")]
        public string TenNhom { get; set; }

        [Display(Name = "Mô tả")]
        [Column(TypeName = "text")]
        public string MoTa { get; set; }

        [Display(Name = "Chọn ảnh")]
        [StringLength(250)]
        public string Anh { get; set; }
    }
}
