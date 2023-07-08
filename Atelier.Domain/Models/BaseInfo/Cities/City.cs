using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Domain.Models.BaseInfo.Cities
{
	public class City: BaseEntityWithOutUser<int>
	{

		#region Navigation Property

		public ICollection<Ateliers.Atelier> Atelier { get; set; }

		#endregion
	}
}
