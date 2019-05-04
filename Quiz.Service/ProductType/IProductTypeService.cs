using Quiz.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Service.ProductTypeService
{
    public interface IProductTypeService
    {

        List<ProductTypeViewModel> ProductTypeList();
        dynamic ProductTypeRequest(int? id);
        bool SaveProductTypeRequests(ProductTypeViewModel atten);
        bool DeleteProductTypeRequest(int id);
        //bool SaveServiceRequestsStatus(ProductTypeViewModel atten);
    }
}
