using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public partial class FullTimeEmployee
    {
        public Shared.Entities.FullTimeEmployee GetShareEntity() {
            return new Shared.Entities.FullTimeEmployee() {
                Id= this.EMP_ID,
                Name = this.NAME,
                Salary = (int)this.SALARY,
                StartDate = START_DATE
            };
        }
    }
}
