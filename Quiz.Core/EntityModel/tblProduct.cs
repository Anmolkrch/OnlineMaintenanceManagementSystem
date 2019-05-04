//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceMaintanance.Core.EntityModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblProduct()
        {
            this.tblProductMaintenances = new HashSet<tblProductMaintenance>();
        }
    
        public long Id { get; set; }
        public Nullable<long> ProductCode { get; set; }
        public int ProductType { get; set; }
        public string Brand { get; set; }
        public string SerialNumber { get; set; }
        public string ProductName { get; set; }
        public string Model { get; set; }
        public System.DateTime ManufactureDate { get; set; }
        public Nullable<System.DateTime> WarrantyTillDate { get; set; }
        public int YearOfWarranty { get; set; }
        public string OriginalCost { get; set; }
        public System.DateTime DateOfPurchase { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProductMaintenance> tblProductMaintenances { get; set; }
    }
}
