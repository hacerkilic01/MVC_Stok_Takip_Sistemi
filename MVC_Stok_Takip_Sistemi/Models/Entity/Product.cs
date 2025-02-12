//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_Stok_Takip_Sistemi.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    //using System.Web.WebPages.Html;
    using System.Web.Mvc;


    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Sales = new HashSet<Sale>();
            this.BrandList = new List<SelectListItem>();
            BrandList.Insert(0, new SelectListItem{Text="Firstly you should choose Category", Value=""});
        }

        public int ID { get; set; }
        [Required(ErrorMessage = "Cannot be left blank.")]

        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Cannot be left blank.")]
        public int BrandID { get; set; }
        [Required(ErrorMessage = "Cannot be left blank.")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Cannot be left blank.")]
        public string BarcodeNo { get; set; }
        [Required(ErrorMessage = "Cannot be left blank.")]
        public decimal? PurchasePrice { get; set; }
        [Required(ErrorMessage = "Cannot be left blank.")]
        public decimal? SalePrice { get; set; }
        [Required(ErrorMessage = "Cannot be left blank.")]
        public int UnitID { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime Date { get; set; }
        [Required(ErrorMessage = "Cannot be left blank.")]
        public Nullable<decimal> Amount { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual Unit Unit { get; set; }
        public List<SelectListItem> CategoryList {get; set; }
        public List<SelectListItem> ProductList {get;set; }

        public List<SelectListItem> UnitList {get; set; }
        public List<SelectListItem> BrandList {get; set; }

    }
}
