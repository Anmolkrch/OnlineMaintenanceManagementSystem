using ExpressMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using System.Data.Entity;
using ServiceMaintanance.ViewModel;
using ServiceMaintanance.Core.EntityModel;

namespace ServiceMaintanance.Service.ServiceRequest
{

    public class ServiceRequestService : IServiceRequestService
    {
       
        private ServiceMaintainanceEntities _Context = new ServiceMaintainanceEntities();
        #region Public_Methods

        
        public List<ServiceRequestViewModel> ServiceRequestsList()
        {
            List<ServiceRequestViewModel> cvm = new List<ServiceRequestViewModel>();
            var serviceRequest = _Context.ServiceRequests.ToList();
            Mapper.Map(serviceRequest, cvm);
            return cvm;
        }
        public dynamic serviceRequest(int? id)
        {
            ServiceRequestViewModel serviceRequest = new ServiceRequestViewModel();
            try
            {
                if (id != 0 && id != null)
                {
                   var EntserviceRequest = _Context.ServiceRequests.Find(id);
                    Mapper.Map(EntserviceRequest, serviceRequest);
                }
            }
            catch (Exception EX)
            {

            }
            return serviceRequest;
        }
        public bool SaveServiceRequests(ServiceRequestViewModel serviceRequest)
        {
            ServiceMaintanance.Core.EntityModel.ServiceRequest tblServiceRequest = new ServiceMaintanance.Core.EntityModel.ServiceRequest();
            bool result = false;
            try
            {
                if (serviceRequest.Id == 0)
                {
                    Mapper.Map(serviceRequest, tblServiceRequest);
                    tblServiceRequest.UserId = 2;
                    tblServiceRequest.CreatedOn = DateTime.Now;
                    if (tblServiceRequest.DateOfRequest== DateTime.MinValue)
                    {
                        tblServiceRequest.DateOfRequest = DateTime.Now;
                    }
                    tblServiceRequest.CreatedOn = DateTime.Now;
                    tblServiceRequest.CreatedBy = 101;
                    _Context.ServiceRequests.Add(tblServiceRequest);
                    _Context.SaveChanges();
                    result = true;
                }
                else
                {
                    Mapper.Map(serviceRequest, tblServiceRequest);
                    _Context.Entry(tblServiceRequest).State = EntityState.Modified;
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
        public bool DeleteserviceRequest(int id)
        {
            try
            {

                ServiceMaintanance.Core.EntityModel.ServiceRequest serviceRequest = _Context.ServiceRequests.Find(id);
                _Context.ServiceRequests.Remove(serviceRequest); ;
                _Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
        public bool SaveServiceRequestsStatus(ServiceRequestViewModel serviceRequest)
        {
            ServiceMaintanance.Core.EntityModel.ServiceRequestStatu tblServiceRequestStatus = new ServiceMaintanance.Core.EntityModel.ServiceRequestStatu();
            bool result = false;
            try
            {
                //if (serviceRequest.Id == 0)
                //{

                    tblServiceRequestStatus.CreatedOn = DateTime.Now;
                    tblServiceRequestStatus.Status = (int)serviceRequest.UserId;
                    tblServiceRequestStatus.CreatedBy = 101;
                    tblServiceRequestStatus.ServiceRequestId = serviceRequest.Id;
                    tblServiceRequestStatus.Comment = serviceRequest.Comment;
                _Context.ServiceRequestStatus.Add(tblServiceRequestStatus);
                    _Context.SaveChanges();
                    result = true;
                //}
                //else
                //{
                //    Mapper.Map(serviceRequest, tblServiceRequest);
                //    _Context.Entry(tblServiceRequest).State = EntityState.Modified;
                //    _Context.SaveChanges();
                //    result = true;
                //}
            }
            catch (Exception EX)
            {
                result = false;
            }
            return result;
        }
        #endregion
    }
}
