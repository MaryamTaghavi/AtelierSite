using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Domain.Models.BaseInfo.Groupings
{
	public class Grouping : BaseInterfaceEntity<int>
	{
		public string Tilte { get; set; }
		public string GroupPic { get; set; }
	}
}
