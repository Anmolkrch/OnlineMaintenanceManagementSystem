
using ServiceMaintanance.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMaintanance.Service.ProductMaintenanceService
{
    public interface IProductMaintenanceService
    {

        List<ProductMaintenanceViewModel> ProductMaintenanceList();
        dynamic ProductMaintenanceRequest(int? id);
        bool SaveProductMaintenanceRequests(ProductMaintenanceViewModel atten);
        bool DeleteProductMaintenanceRequest(int id);
  
    }
}
