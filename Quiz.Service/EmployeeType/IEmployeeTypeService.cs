using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using React.Model.Master;
using React.Model.Users;
using React.ViewModel;

namespace React.Service.EmployeeType
{
    public interface IEmployeeTypeService
    {

        List<Employee_TypeViewModel> EmployeeTypeList();
        Employee_TypeViewModel EmployeeType(int? id);
        bool SaveEmployeeType(Employee_TypeViewModel empType);
        bool DeleteEmployeeType(int id);
    }
}
