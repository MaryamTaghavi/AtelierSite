﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Domain.DTOs.BaseInfoDTOs.SearchDtos
{
	public class SearchDto
	{
		public string Title { get; set; }
		public int GroupingId { get; set; }
		public int CityId { get; set; }
	}
}
