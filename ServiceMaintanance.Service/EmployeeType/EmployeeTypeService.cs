using ExpressMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Quiz.Core.EntityModel;
using Quiz.ViewModel.Model.Users;
using Quiz.ViewModel;
using Quiz.Model.Users;
using Quiz.Model.Master;
using QuizModel.ViewModel;
using System.Data.Entity;

namespace Quiz.Service.EmployeeType
{
    public class EmployeeTypeService : IEmployeeTypeService
    {
       
        private EmployeeMGMTEntities _Context = new EmployeeMGMTEntities();
        #region Public_Methods

        
        public List<Employee_TypeViewModel> EmployeeTypeList()
        {
            List<Employee_TypeViewModel> dep = new List<Employee_TypeViewModel>();
            //var dept = _Context.em.ToList();
            //Mapper.Map(dept, dep);
            return dep;
        }
        public Employee_TypeViewModel EmployeeType(int? id)
        {
            Employee_TypeViewModel comp = new Employee_TypeViewModel();
            try
            {
                if (id != 0 && id != null)
                {
                    //Quiz.Core.EntityModel.Employee_Type EntComp = _Context.Employee_Type.Find(id);
                    //Mapper.Map(EntComp, comp);
                }
            }
            catch (Exception EX)
            {

            }
            return comp;
        }
        public bool SaveEmployeeType(Employee_TypeViewModel empType)
        {
          
            bool result = false;
           
            return result;
        }
        public bool DeleteEmployeeType(int id)
        {
            try
            {

                //Quiz.Core.EntityModel.Employee_Type empType = _Context.Employee_Type.Find(id);
                //_Context.Employee_Type.Remove(empType); ;
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
