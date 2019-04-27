using ExpressMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using React.Core.EntityModel;
using React.ViewModel.Model.Users;
using React.ViewModel;
using React.Model.Users;
using React.Model.Master;
using ReactModel.ViewModel;
using System.Data.Entity;

namespace React.Service.Employee
{
    public class EmployeeService : IEmployeeService
    {
       
        private EmployeeMGMTEntities _Context = new EmployeeMGMTEntities();
        #region Public_Methods

        
        public dynamic EmployeeList()
        {
            List<React.ViewModel.EmployeeViewModel> EmpList = new List<React.ViewModel.EmployeeViewModel>();

            //var emp = _Context.Employees.Include(e => e.Benefit).Include(e => e.Department).
            //   Include(e => e.Designation).Include(e => e.Division).Include(e => e.Employee_Type).Include(e => e.Grade).Include(e => e.Section);
             return EmpList.ToList();
        }
        public EmployeeViewModel Employee(int? id)
        {
            EmployeeViewModel emp = new EmployeeViewModel();
            try
            {
                if (id != 0 && id != null)
                {
                     //var employee = _Context.Employees.Find(id);
                    //Mapper.Map(employee, emp);
                }
            }
            catch (Exception EX)
            {

            }
            return emp;
        }
        public bool SaveEmployee(React.ViewModel.EmployeeViewModel emp)
        {
            //React.Core.EntityModel.Employee tblemp = new React.Core.EntityModel.Employee();
            bool result = false;
            //try
            //{
            //    if (emp.EmpID == 0)
            //    {
            //        Mapper.Map(emp, tblemp);
            //        _Context.Employees.Add(tblemp);
            //        _Context.SaveChanges();
            //        result = true;
            //    }
            //    else
            //    {
            //        Mapper.Map(emp, tblemp);
            //        _Context.Entry(tblemp).State = EntityState.Modified;
            //        _Context.SaveChanges();
            //        result = true;
            //    }
            //}
            //catch (Exception EX)
            //{
            //    result = false;
            //}
           return result;
        }
        public bool DeleteEmployee(int id)
        {
            try
            {
                //React.Core.EntityModel.Employee employee = _Context.Employees.Find(id);
                //_Context.Employees.Remove(employee);
                //_Context.SaveChanges();
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
