﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Atelier.Domain.DTOs.BaseInfoDTOs.CitiesDto
{
	public class CityViewModel : BaseDto<int>
	{
		[Display(Name = "عنوان")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
		public string Title { get; set; }
	}

	public class CityShowViewModel
	{
		[Key]
		public int Id { get; set; }

		[Display(Name = "عنوان")]
		public string Title { get; set; }

	}
}
