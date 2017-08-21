using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    [ServiceContract]
    public interface IServiceEmployees
    {
        [OperationContract]
        [WebInvoke]
        void AddEmployee(Employee emp);

        [OperationContract]
        [WebInvoke]
        void DeleteEmployee(int id);

        [OperationContract]
        [WebInvoke]
        void UpdateEmployee(Employee emp);

        [OperationContract]
        [WebInvoke]
        List<Employee> GetAllEmployees();

        [OperationContract]
        [WebInvoke]
        Employee GetEmployee(int id);

        [OperationContract]
        [WebInvoke]
        double CalcPartTimeEmployeeSalary(int idEmployee, int hours);
    }
}
