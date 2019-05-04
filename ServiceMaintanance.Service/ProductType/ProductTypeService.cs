using ExpressMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ServiceMaintanance.Core.EntityModel;

using System.Data.Entity;
using ServiceMaintanance.ViewModel;
using ServiceMaintanance.Model.ViewModel;

namespace ServiceMaintanance.Service.ProductTypeService
{

    public class ProductTypeService : IProductTypeService
    {
       
        private ServiceMaintainanceEntities _Context = new ServiceMaintainanceEntities();
        #region Public_Methods

        
        public List<ProductTypeViewModel> ProductTypeList()
        {
            List<ProductTypeViewModel> cvm = new List<ProductTypeViewModel>();
            var ProductTypeRequest = _Context.tblProductTypes.ToList();
            Mapper.Map(ProductTypeRequest, cvm);
            return cvm;
        }
        public dynamic ProductTypeRequest(int? id)
        {
            ProductTypeViewModel ProductTypeRequest = new ProductTypeViewModel();
            try
            {
                if (id != 0 && id != null)
                {
                   var Product = _Context.tblProductTypes.Find(id);
                    Mapper.Map(Product, ProductTypeRequest);
                }
            }
            catch (Exception EX)
            {

            }
            return ProductTypeRequest;
        }
        public bool SaveProductTypeRequests(ProductTypeViewModel ProductTypeRequest)
        {
            ServiceMaintanance.Core.EntityModel.tblProductType tblProductType = new ServiceMaintanance.Core.EntityModel.tblProductType();
            bool result = false;
            try
            {
                if (ProductTypeRequest.Id == 0)
                {
                    Mapper.Map(ProductTypeRequest, tblProductType);
                    
                    tblProductType.CreatedOn = DateTime.Now;
                   
                    tblProductType.CreatedOn = DateTime.Now;
                    tblProductType.CreatedBy = 101;
                    tblProductType.IsActive = true;
                    tblProductType.IsDeleted = false;
                    _Context.tblProductTypes.Add(tblProductType);
                    _Context.SaveChanges();
                    result = true;
                }
                else
                {
                    Mapper.Map(ProductTypeRequest, tblProductType);
                    _Context.Entry(tblProductType).State = EntityState.Modified;
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
        public bool DeleteProductTypeRequest(int id)
        {
            try
            {

                ServiceMaintanance.Core.EntityModel.tblProductType ProductTypeRequest = _Context.tblProductTypes.Find(id);
                _Context.tblProductTypes.Remove(ProductTypeRequest); ;
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
        //    ServiceMaintanance.Core.EntityModel.ServiceRequestStatu tblProductStatus = new ServiceMaintanance.Core.EntityModel.ServiceRequestStatu();
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
