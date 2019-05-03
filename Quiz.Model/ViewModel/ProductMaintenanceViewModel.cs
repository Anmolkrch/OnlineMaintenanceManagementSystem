using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.ViewModel
{
    public class ProductMaintenanceViewModel
    {
        
            public long Id { get; set; }

            public long ProductId { get; set; }

            public long engineerId { get; set; }

            public DateTime DateOfService { get; set; }

            public long? SpairPartId { get; set; }

            public string Cost { get; set; }
        }
}
