using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Domain.Models.BaseInfo.Ateliers;

namespace Atelier.Domain.Models.BaseInfo.Groupings
{
	public class Grouping : BaseEntityWithOutUser<int>
	{

		public string GroupPic { get; set; }

		#region Navigation Property

		public ICollection<AtelierGroup> AtelierGroups { get; set; }
		#endregion
	}
}
