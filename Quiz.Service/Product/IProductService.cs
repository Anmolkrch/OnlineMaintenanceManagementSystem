using Quiz.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Service.ProductService
{
    public interface IProductService
    {

        List<ProductViewModel> ProductList();
        dynamic ProductRequest(int? id);
        bool SaveProductRequests(ProductViewModel atten);
        bool DeleteProductRequest(int id);
        //bool SaveServiceRequestsStatus(ProductViewModel atten);
    }
}
