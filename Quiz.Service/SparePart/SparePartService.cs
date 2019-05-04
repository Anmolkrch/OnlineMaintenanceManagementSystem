using ExpressMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Quiz.Core.EntityModel;

using System.Data.Entity;
using Quiz.ViewModel;

namespace Quiz.Service.SparePartService
{

    public class SparePartService : ISparePartService
    {
       
        private EmployeeMGMTEntities _Context = new EmployeeMGMTEntities();
        #region Public_Methods

        
        public List<ProductViewModel> ProductList()
        {
            List<ProductViewModel> cvm = new List<ProductViewModel>();
            var ProductRequest = _Context.tblProducts.ToList();
            Mapper.Map(ProductRequest, cvm);
            return cvm;
        }
        public dynamic ProductRequest(int? id)
        {
            ProductViewModel productRequest = new ProductViewModel();
            try
            {
                if (id != 0 && id != null)
                {
                   var ProductRequest = _Context.tblProducts.Find(id);
                    Mapper.Map(ProductRequest, productRequest);
                }
            }
            catch (Exception EX)
            {

            }
            return productRequest;
        }
        public bool SaveProductRequests(ProductViewModel productRequest)
        {
            Quiz.Core.EntityModel.tblProduct tblProduct = new Quiz.Core.EntityModel.tblProduct();
            bool result = false;
            try
            {
                if (productRequest.Id == 0)
                {
                    Mapper.Map(productRequest, tblProduct);
                    
                    tblProduct.CreatedOn = DateTime.Now;
                    if (tblProduct.ManufactureDate== DateTime.MinValue)
                    {
                        tblProduct.DateOfPurchase = DateTime.Now;
                        tblProduct.ManufactureDate = DateTime.Now;
                    }
                    tblProduct.CreatedOn = DateTime.Now;
                    tblProduct.CreatedBy = 101;
                    tblProduct.IsActive = true;
                    tblProduct.IsDeleted = false;
                    _Context.tblProducts.Add(tblProduct);
                    _Context.SaveChanges();
                    result = true;
                }
                else
                {
                    Mapper.Map(productRequest, tblProduct);
                    _Context.Entry(tblProduct).State = EntityState.Modified;
                    _Context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception EX)
            {
                result = false;
            }
           return result;
        }
        public bool DeleteProductRequest(int id)
        {
            try
            {

                Quiz.Core.EntityModel.tblProduct productRequest = _Context.tblProducts.Find(id);
                _Context.tblProducts.Remove(productRequest); ;
                _Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
        //public bool SaveServiceRequestsStatus(ProductViewModel serviceRequest)
        //{
        //    Quiz.Core.EntityModel.ServiceRequestStatu tblProductStatus = new Quiz.Core.EntityModel.ServiceRequestStatu();
        //    bool result = false;
        //    try
        //    {
        //        //if (serviceRequest.Id == 0)
        //        //{

        //            tblProductStatus.CreatedOn = DateTime.Now;
        //            tblProductStatus.Status = (int)serviceRequest.UserId;
        //            tblProductStatus.CreatedBy = 101;
        //            tblProductStatus.ServiceRequestId = serviceRequest.Id;
        //            tblProductStatus.Comment = serviceRequest.Comment;
        //        _Context.ServiceRequestStatus.Add(tblProductStatus);
        //            _Context.SaveChanges();
        //            result = true;
        //        //}
        //        //else
        //        //{
        //        //    Mapper.Map(serviceRequest, tblProduct);
        //        //    _Context.Entry(tblProduct).State = EntityState.Modified;
        //        //    _Context.SaveChanges();
        //        //    result = true;
        //        //}
        //    }
        //    catch (Exception EX)
        //    {
        //        result = false;
        //    }
        //    return result;
        //}
        #endregion
    }
}
