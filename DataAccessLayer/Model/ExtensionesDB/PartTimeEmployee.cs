using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public partial class PartTimeEmployee
    {
        public Shared.Entities.PartTimeEmployee GetShareEntity()
        {
            return new Shared.Entities.PartTimeEmployee()
            {
                Id = this.EMP_ID,
                Name = this.NAME,
                HourlyRate = (float)this.RATE,
                StartDate = START_DATE
            };
        }
    }
}
