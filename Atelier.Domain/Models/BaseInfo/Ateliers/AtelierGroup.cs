using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Domain.Models.BaseInfo.Groupings;

namespace Atelier.Domain.Models.BaseInfo.Ateliers
{
	public class AtelierGroup : BaseInterfaceEntity<int>
	{
		public int GroupId { get; set; }
		public int AtelierId { get; set; }

		#region Navigation Property

		[ForeignKey(nameof(GroupId))]
		public Grouping Grouping { get; set; }

		[ForeignKey(nameof(AtelierId))]
		public Atelier Atelier { get; set; }

		#endregion
	}
}
