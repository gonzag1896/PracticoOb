using DataAccessLayer;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Entities;
using Shared.Exception;
using DataAccessLayer.Model;

namespace BusinessLogicLayer
{
    public class BLEmployees : IDALEmployees
    {
       private IDALEmployees _dal;

        public BLEmployees(IDALEmployees dal)
        {
            _dal = dal;
        }

        public void AddEmployee(DataAccessLayer.Model.Employee emp)
        {
            _dal.AddEmployee(emp);
        }

        public void DeleteEmployee(int id)
        {
            _dal.DeleteEmployee(id);
        }

        public void UpdateEmployee(DataAccessLayer.Model.Employee emp)
        {
            _dal.UpdateEmployee(emp);
        }

        public List<DataAccessLayer.Model.Employee> GetAllEmployees()
        {
            return _dal.GetAllEmployees();
            
        }

        public DataAccessLayer.Model.Employee GetEmployee(int id)
        {
            return _dal.GetEmployee(id);
        }

        public double CalcPartTimeEmployeeSalary(int idEmployee, int hours)
        {
            throw new ExistExceptions();
        }
    }
}
