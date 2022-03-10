using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ingreso: AuditableBaseEntity
    {
        private int _edad;
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Identification { get; set; }
        public string House { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public int Edad
        {
            get
            {
                if (this._edad <= 0)
                {
                    this._edad = new DateTime(DateTime.Now.Subtract(this.FechaNacimiento).Ticks).Year - 1;
                }
                return this._edad;
            }
        }
    }
}
