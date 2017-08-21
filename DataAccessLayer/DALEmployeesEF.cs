using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALEmployeesEF : IDALEmployees
    {
        public void AddEmployee(Employee emp)
        {
            using (Model.Practico1Entities en = new Model.Practico1Entities())
            {
                if (emp is FullTimeEmployee)
                {
                    FullTimeEmployee empft = (FullTimeEmployee)emp;

                    Model.FullTimeEmployee emp1 = new Model.FullTimeEmployee
                    {
                        EMP_ID = empft.Id,
                        NAME = empft.Name,
                        SALARY = empft.Salary,
                        START_DATE = empft.StartDate
                    };
                    en.EmployeesTPH.Add(emp1);
                }
                else {
                    PartTimeEmployee emppt = (PartTimeEmployee)emp;

                    Model.PartTimeEmployee emp1 = new Model.PartTimeEmployee
                    {
                        EMP_ID = emppt.Id,
                        NAME = emppt.Name,
                        RATE = emppt.HourlyRate,
                        START_DATE = emppt.StartDate
                    };
                    en.EmployeesTPH.Add(emp1);
                }
            }

        }

        public void DeleteEmployee(int id)
        {
            using (Model.Practico1Entities en = new Model.Practico1Entities())
            {
                Model.FullTimeEmployee emp1 = (from e
                                               in en.EmployeesTPH.OfType<Model.FullTimeEmployee>()
                                               where e.EMP_ID == id
                                               select e).FirstOrDefault();
                if (emp1 != null)
                    en.EmployeesTPH.Remove(emp1);

                Model.PartTimeEmployee emp2 = (from e
                                               in en.EmployeesTPH.OfType<Model.PartTimeEmployee>()
                                               where e.EMP_ID == id
                                               select e).FirstOrDefault();
                if (emp2 != null)
                    en.EmployeesTPH.Remove(emp2);
            }
        }

        public void UpdateEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> result = new List<Employee>();
            using (Model.Practico1Entities en = new Model.Practico1Entities())
            {
                //LINQ
                foreach (Model.FullTimeEmployee emp in en.EmployeesTPH.OfType<Model.FullTimeEmployee>()){
                    Employee aux = new FullTimeEmployee()
                    {
                        Id = emp.EMP_ID,
                        Name = emp.NAME,
                        Salary =(int) emp.SALARY,
                        StartDate = emp.START_DATE
                    };
                    result.Add(aux);
                }

                foreach (Model.PartTimeEmployee emp in en.EmployeesTPH.OfType<Model.PartTimeEmployee>())
                {
                    Employee aux = new PartTimeEmployee()
                    {
                        Id = emp.EMP_ID,
                        Name = emp.NAME,
                        HourlyRate = (float)emp.RATE,
                        StartDate = emp.START_DATE
                    };
                    result.Add(aux);
                }
            }
            return result;
        }

        public Employee GetEmployee(int id)
        {
            using (Model.Practico1Entities en = new Model.Practico1Entities())
            {
                //LINQ
                Model.FullTimeEmployee emp1 = (from e 
                                               in en.EmployeesTPH.OfType<Model.FullTimeEmployee>()
                                               where e.EMP_ID == id
                                               select e).FirstOrDefault();
                if (emp1 != null)
                    return emp1.GetShareEntity();

                Model.PartTimeEmployee emp2 = (from e
                                               in en.EmployeesTPH.OfType<Model.PartTimeEmployee>()
                                               where e.EMP_ID == id
                                               select e).FirstOrDefault();
                if (emp2 != null)
                    return emp2.GetShareEntity();


                return null;

                //Lambda 
                //Model.FullTimeEmployee emp2 = en.EmployeesTPH.OfType<Model.FullTimeEmployee>().FirstOrDefault(e => e.EMP_ID == id);

            }
        }
    }
}
