namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
    }
    
    public partial class ProductMetaData
    {
        [Required]
        public int ProductId { get; set; }
        
        [StringLength(80, ErrorMessage="欄位長度不得大於 80 個字元")]
        [Required(ErrorMessage = "請輸入產品名稱 {0}")]
        [DisplayName("產品名稱")]
        [商品名稱不能有Austin字串(ErrorMessage = "商品名稱不能有Austin字串")]
        public string ProductName { get; set; }
        [Required]
        [Range(1, 99999, ErrorMessage = "請輸入範圍介於 1 - 99999 之間的數值")]
        [DisplayFormat(DataFormatString = "NT$ {0:N0}")]
        public Nullable<decimal> Price { get; set; }
        [Required]
        public Nullable<bool> Active { get; set; }
        [Required]
        public Nullable<decimal> Stock { get; set; }
    
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
