using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using React.Model.Master;
using React.Model.Users;
using React.ViewModel;

namespace React.Service.Employee
{
    public interface IEmployeeService
    {
        /// <summary>
        /// User authentication on login
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        dynamic EmployeeList();
        EmployeeViewModel Employee(int? id);
        bool SaveEmployee(React.ViewModel.EmployeeViewModel emp);
        bool DeleteEmployee(int id);
    }
}
