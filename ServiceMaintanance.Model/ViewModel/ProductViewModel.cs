using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMaintanance.ViewModel
{
    public class ProductViewModel
    {
        public long Id { get; set; }

        public long? ProductCode { get; set; }

        public int ProductType { get; set; }

        public string Brand { get; set; }

        public string SerialNumber { get; set; }

        public string ProductName { get; set; }

        public string Model { get; set; }

        public DateTime ManufactureDate { get; set; }

        public DateTime? WarrantyTillDate { get; set; }

        public int YearOfWarranty { get; set; }

        public string OriginalCost { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }


    }

}
