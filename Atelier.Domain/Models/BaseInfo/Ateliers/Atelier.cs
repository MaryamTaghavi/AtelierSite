using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Domain.Models.BaseInfo.Cities;
using Atelier.Domain.Models.BaseInfo.Favorites;
using Atelier.Domain.Models.BaseInfo.Photographers;
using Atelier.Domain.Models.BaseInfo.WorkSamples;

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
		public ICollection<Photographer> Photographers { get; set; }
		public ICollection<WorkSample> WorkSamples { get; set; }
		public ICollection<Favorite> Favorites { get; set; }

		[ForeignKey(nameof(CityId))]
		public City City { get; set; }

		#endregion

	}
}
