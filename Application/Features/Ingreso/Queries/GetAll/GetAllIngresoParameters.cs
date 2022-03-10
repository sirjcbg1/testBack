using Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ingreso.Queries.GetAll
{
    public class GetAllIngresoParameters : RequestParameter
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
