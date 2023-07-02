using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;

namespace Atelier.Domain.DTOs.BaseInfoDTOs.GroupingDtos
{
	public class GroupingDto : BaseDto<int>
	{
		[Display(Name = "عنوان")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
		public string Title { get; set; }

		[Display(Name = "تصویر")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public IFormFile GropuPic { get; set; }
    }

    public class GroupingSelectDto
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "ردیف")]
        public int Row { get; set; }

        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "تصویر")]
        public string GropuPic { get; set; }

        [Display(Name = "عملیات")]
        public string Operation { get; set; }
    }

}
