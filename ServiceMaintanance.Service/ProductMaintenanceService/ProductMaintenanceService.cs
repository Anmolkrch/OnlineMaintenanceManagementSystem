using ExpressMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using System.Data.Entity;
using ServiceMaintanance.ViewModel;
using ServiceMaintanance.Core.EntityModel;

namespace ServiceMaintanance.Service.ProductMaintenanceService
{

    public class ProductMaintenanceService : IProductMaintenanceService
    {
       
        private ServiceMaintainanceEntities _Context = new ServiceMaintainanceEntities();
        #region Public_Methods

        
        public List<ProductMaintenanceViewModel> ProductMaintenanceList()
        {
            List<ProductMaintenanceViewModel> cvm = new List<ProductMaintenanceViewModel>();
            var ProductRequest = _Context.tblProductMaintenances.ToList();
            Mapper.Map(ProductRequest, cvm);
            return cvm;
        }
        public dynamic ProductMaintenanceRequest(int? id)
        {
            ProductMaintenanceViewModel productRequest = new ProductMaintenanceViewModel();
            try
            {
                if (id != 0 && id != null)
                {
                   var ProductRequest = _Context.tblProductMaintenances.Find(id);
                    Mapper.Map(ProductRequest, productRequest);
                }
            }
            catch (Exception EX)
            {

            }
            return productRequest;
        }
        public bool SaveProductMaintenanceRequests(ProductMaintenanceViewModel ProductMaintenanceRequest)
        {
            ServiceMaintanance.Core.EntityModel.tblProductMaintenance tblProductMaintenance = new ServiceMaintanance.Core.EntityModel.tblProductMaintenance();
            bool result = false;
            try
            {
                if (ProductMaintenanceRequest.Id == 0)
                {
                    Mapper.Map(ProductMaintenanceRequest, tblProductMaintenance);
                    
                    tblProductMaintenance.CreatedOn = DateTime.Now;
                    if (tblProductMaintenance.DateOfService== DateTime.MinValue)
                    {
                        tblProductMaintenance.DateOfService = DateTime.Now;
                       
                    }
                    tblProductMaintenance.CreatedOn = DateTime.Now;
                    tblProductMaintenance.CreatedBy = 101;
                    tblProductMaintenance.IsActive = true;
                    tblProductMaintenance.IsDeleted = false;
                    _Context.tblProductMaintenances.Add(tblProductMaintenance);
                    _Context.SaveChanges();
                    result = true;
                }
                else
                {
                    var tbl = _Context.tblProductMaintenances.Where(x => x.Id == ProductMaintenanceRequest.Id).FirstOrDefault();
                    tbl.Cost = ProductMaintenanceRequest.Cost;
                    tbl.DateOfService = ProductMaintenanceRequest.DateOfService;
                    tbl.engineerId = ProductMaintenanceRequest.engineerId;
                    tbl.SpairPartId = ProductMaintenanceRequest.SpairPartId;
                    tbl.ProductId = ProductMaintenanceRequest.ProductId;
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
        public bool DeleteProductMaintenanceRequest(int id)
        {
            try
            {

                ServiceMaintanance.Core.EntityModel.tblProductMaintenance productRequest = _Context.tblProductMaintenances.Find(id);
                _Context.tblProductMaintenances.Remove(productRequest); ;
                _Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
        
        #endregion
    }
}
