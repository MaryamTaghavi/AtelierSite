using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Domain.Models.BaseInfo.Cities;

namespace Atelier.Domain.Models.BaseInfo.Ateliers
{
    public class Atelier : BaseEntity<int>
    {
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Banner { get; set; }
        public string Logo { get; set; }
        public string Instagram { get; set; }
        public string Status { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int CityId { get; set; }

		#region Navigation Property

		public ICollection<AtelierGroup> AtelierGroups { get; set; }

        [ForeignKey(nameof(CityId))]
		public City city { get; set; }

		#endregion

	}
}
