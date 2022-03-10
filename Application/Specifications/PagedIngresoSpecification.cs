using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Specifications
{
    public class PagedIngresoSpecification : Specification<Ingreso>
    {
        public PagedIngresoSpecification(int paseSize, int pageNumber, string name, string lastname)
        {
            Query.Skip((pageNumber - 1) * paseSize)
                .Take(paseSize);

            if(!string.IsNullOrEmpty(name))
            {
                Query.Search(x => x.Name, "%" + name + "%");
            }

            if (!string.IsNullOrEmpty(lastname))
            {
                Query.Search(x => x.LastName, "%" + lastname + "%");
            }
        }
    }
}
