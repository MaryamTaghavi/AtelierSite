using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Domain.Models.BaseInfo
{
    public class Atelier : BaseEntity<int>
    {
        public string Address { get; set; }
        public string Phone { get; set; }
		public string Instagram { get; set; }
		public string Status { get; set; }
        public DateTime ExpirationDate { get; set; }


	}
}
