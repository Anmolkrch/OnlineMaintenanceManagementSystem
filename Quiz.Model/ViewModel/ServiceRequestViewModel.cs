using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.ViewModel
{
    public class ServiceRequestViewModel
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string FirsName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string ProductTybe { get; set; }

        public string Brand { get; set; }

        public DateTime DateOfRequest { get; set; }

        public string Address { get; set; }

        public string Pincode { get; set; }

        public string Complaint { get; set; }

        public string Comment { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

    }
}
