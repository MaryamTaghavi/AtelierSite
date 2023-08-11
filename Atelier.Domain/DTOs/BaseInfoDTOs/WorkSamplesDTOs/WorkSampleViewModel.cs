using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Atelier.Domain.DTOs.BaseInfoDTOs.WorkSamplesDTOs
{
	public class WorkSampleViewModel : BaseDto<int>
	{
		[Display(Name = "نمونه کار")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public IFormFile WorkSamplePic { get; set; }
		public int GroupId { get; set; }
		public int AtelierId { get; set; }
	}

	public class WorkSampleShowViewModel
	{
		[Key]
		public int Id { get; set; }

		[Display(Name = "نمونه کار")]
		public string WorkSamplePic { get; set; }

		[Display(Name = "گروه بندی")]
		public string GroupTitle { get; set; }
	}

	public class WorkSampleShowDetailes
	{
		public string GroupTitle { get; set; }
		public List<string> WorkSamplesPic { get; set; }

	}


}
