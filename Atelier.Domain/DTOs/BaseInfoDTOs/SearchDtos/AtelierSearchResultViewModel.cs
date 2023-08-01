using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Domain.DTOs.BaseInfoDTOs.SearchDtos
{
    public class AtelierSearchResultViewModel : BaseDto
    {
        public string Title { get; set; }
        public string Logo { get; set; }
        public string Banner { get; set; }
        
        public string cityTitle { get; set; }
	}
}
