using Quiz.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Service.ServiceRequest
{
    public interface IServiceRequestService
    {

        dynamic ServiceRequestsList();
        dynamic serviceRequest(int? id);
        bool SaveServiceRequests(ServiceRequestViewModel atten);
        bool DeleteserviceRequest(int id);
        bool SaveServiceRequestsStatus(ServiceRequestViewModel atten);
    }
}
