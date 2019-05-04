using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMaintanance.Utility
{
    public class Enums
    {
        public enum AccountStatus
        {
            Active = 1,
            Inactive = 2,
            Suspended = 3,
            Deactivated = 4,
            Delete = 5
        }
        public enum Gender
        {
            Male = 1,
            Female = 2,
            Transgender = 3
        }
        public enum IsActive
        {
            Active = 1,
            Inactive = 0
        }

        public enum NotificationStatus
        {
            Initiated = 1,
            Sent = 2,
            Failed = 3

        }
        public enum MailType
        {
            AccountCreation = 1,
            AccountActivation = 2,
            SendAllDriver = 3
        }
        public enum PaymentProcessLevel
        {
            NA = 0,
            ReadyToInitiate = 1,
            Initiated = 2,
            Completed = 3
        }

        public enum ImageType
        {
            Logo = 1,
            Banner = 2,
            UserProfile = 3,
            Cheque = 4
        }

        public enum MediaFor
        {
            UserProfile = 1,
            Cheque = 2
        }
        public enum BookingRequestStatus
        {
            All = 0,
            Initiated = 1,
            Modified = 2,
            Allocated = 3,
            ModifiedAllocation = 4,
            Completed = 5

        }
        public enum VehicleStatus
        {
            All = 0,
            Available = 1,
            Allocated = 2,
            UnderMaintenance = 3,
            Accidented = 4,
        }
        public enum VehicleAllocationStatus
        {
            All = 0,            
            Allocated = 1
        }
        public enum Flag
        {
            TripAllocation = 1,
            VehicleAllocation = 2,
        }
        public enum MaintenanceStatus
        {            
            Completed = 1
        }
        public enum UserType
        {
            Admin=1,
            SuperAdmin=2,
            Student = 3
        }
    }
}
