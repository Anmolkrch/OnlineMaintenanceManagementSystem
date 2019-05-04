using Quiz.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Service.SparePartService
{
    public interface ISparePartService
    {

        List<ProductViewModel> SparePartList();
        dynamic SparePartRequest(int? id);
        bool SaveSparePartRequests(ProductViewModel atten);
        bool DeleteSparePartRequest(int id);
        //bool SaveServiceRequestsStatus(ProductViewModel atten);
    }
}
