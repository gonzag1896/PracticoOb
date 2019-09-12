using DataAccessLayer.Model;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer.Model
{
    public class DALEmployeesEF : IDALEmployees
    {
        public void AddEmployee(Employee emp)
        {
            using (Model.PracticoObligatorioEntities1 en = new Model.PracticoObligatorioEntities1())
            {
                Model.Employee empNuevo;
                if (emp.GetType() == typeof(Shared.Entities.FullTimeEmployee))
                {
                    FullTimeEmployee empFT = (FullTimeEmployee)emp;
                    empNuevo = new Model.FullTimeEmployee()
                    {
                        EMP_ID = empFT.EMP_ID,
                        NAME = empFT.NAME,
                        SALARY = empFT.SALARY,
                        START_DATE = empFT.START_DATE
                    };
                    en.EmployeesTPH.Add(empNuevo);
                    en.SaveChanges();
                }
                else
                {
                    PartTimeEmployee empPT = (PartTimeEmployee)emp;
                    empNuevo = new Model.PartTimeEmployee()
                    {
                        EMP_ID = empPT.EMP_ID,
                        NAME = empPT.NAME,
                        SALARY = empPT.SALARY,
                        START_DATE = empPT.START_DATE
                    };
                    en.EmployeesTPH.Add(empNuevo);
                    en.SaveChanges();
                }

            }
        }

        public void DeleteEmployee(int id)
        {
            using (Model.PracticoObligatorioEntities1 en = new Model.PracticoObligatorioEntities1())
            {
                Model.Employee e = en.EmployeesTPH.FirstOrDefault(x => x.EMP_ID == id);
                if (e != null)
                {
                    en.EmployeesTPH.Remove(e);
                }
                else
                    return;
            }
        }

        public void UpdateEmployee(Employee emp)
        {
            using (Model.PracticoObligatorioEntities1 en = new Model.PracticoObligatorioEntities1())
            {
                if (emp.GetType() == typeof(Shared.Entities.FullTimeEmployee))
                {
                    FullTimeEmployee FullTimeEmp = (FullTimeEmployee)emp;
                    Model.Employee e = en.EmployeesTPH.Find(emp.EMP_ID);
                    if (e != null)
                    {
                        Model.FullTimeEmployee empFT = (Model.FullTimeEmployee)e;
                        empFT.NAME = FullTimeEmp.NAME;
                        empFT.SALARY = FullTimeEmp.SALARY;
                        empFT.START_DATE = FullTimeEmp.START_DATE;
                        en.SaveChanges();
                    }
                }else
                {
                    PartTimeEmployee PartTimeEmp = (PartTimeEmployee)emp;
                    Model.Employee e = en.EmployeesTPH.Find(emp.EMP_ID);
                    if (e != null)
                    {
                        Model.PartTimeEmployee empFT = (Model.PartTimeEmployee)e;
                        empFT.NAME = PartTimeEmp.NAME;
                        empFT.SALARY = PartTimeEmp.SALARY;
                        empFT.START_DATE = PartTimeEmp.START_DATE;
                        en.SaveChanges();
                    }
                }
            }
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> result = new List<Employee>();
            using (Model.PracticoObligatorioEntities1 en = new Model.PracticoObligatorioEntities1())
            {
                en.EmployeesTPH.ToList().ForEach(x =>
                {
                    if (x.GetType() == typeof(Shared.Entities.FullTimeEmployee))
                    {
                        Employee e = en.EmployeesTPH.Find(x.EMP_ID);
                        FullTimeEmployee empFull = (FullTimeEmployee)e;
                        {
                            empFull.EMP_ID = x.EMP_ID;
                            empFull.NAME = x.NAME;
                            empFull.SALARY = x.SALARY;
                            empFull.START_DATE = x.START_DATE;
                        }
                        result.Add(empFull);
                    }
                    else if (x.GetType() == typeof(Shared.Entities.PartTimeEmployee))
                    {
                        Employee e = en.EmployeesTPH.Find(x.EMP_ID);
                        PartTimeEmployee empPart = (PartTimeEmployee)e;
                        {
                            empPart.EMP_ID = x.EMP_ID;
                            empPart.NAME = x.NAME;
                            empPart.SALARY = x.SALARY;
                            empPart.START_DATE = x.START_DATE;
                        }
                        result.Add(empPart);
                    }
                });
                return result;
            }
        }

        public Employee GetEmployee(int id)
        {           
            using (Model.PracticoObligatorioEntities1 en = new Model.PracticoObligatorioEntities1())
            {
                Model.Employee e = en.EmployeesTPH.Find(id);
                if (e.GetType() == typeof(Shared.Entities.FullTimeEmployee)){
                    FullTimeEmployee fullTime = (FullTimeEmployee)e;
                    return new FullTimeEmployee()
                    {
                        EMP_ID = fullTime.EMP_ID,
                        NAME = fullTime.NAME,
                        SALARY = fullTime.SALARY,
                        START_DATE = fullTime.START_DATE,
                    };
                }
                else{
                    PartTimeEmployee partTime = (PartTimeEmployee)e;
                    return new PartTimeEmployee()
                    {
                        EMP_ID = partTime.EMP_ID,
                        NAME= partTime.NAME,
                        RATE= partTime.RATE,
                        START_DATE= partTime.START_DATE,
                    };
                }
            }
        }
    }
}

