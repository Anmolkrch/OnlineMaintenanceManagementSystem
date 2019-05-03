
using Quiz.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Service.ProductMaintenanceService
{
    public interface IProductMaintenanceService
    {

        List<ProductMaintenanceViewModel> ProductMaintenanceList();
        dynamic ProductMaintenanceRequest(int? id);
        bool SaveProductMaintenanceRequests(ProductMaintenanceViewModel atten);
        bool DeleteProductMaintenanceRequest(int id);
  
    }
}
