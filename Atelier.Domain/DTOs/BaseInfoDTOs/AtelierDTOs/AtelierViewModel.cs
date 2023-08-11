using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Domain.DTOs.BaseInfoDTOs.WorkSamplesDTOs;
using Atelier.Domain.Models.BaseInfo.WorkSamples;
using Microsoft.AspNetCore.Http;

namespace Atelier.Domain.DTOs.BaseInfoDTOs.AtelierDTOs
{
    public class AtelierViewModel : BaseDto<int>
	{

	    [Display(Name = "عنوان")]
	    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
	    [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
	    public string Title { get; set; }

	    [Display(Name = "آدرس")]
	    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
	    [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
		public string Address { get; set; }

		[Display(Name = "تلفن")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string Phone { get; set; }

		[Display(Name = "بنر")]
		//[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public IFormFile Banner { get; set; }

		[Display(Name = "لوگو")]
		//[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public IFormFile Logo { get; set; }

		[Display(Name = "اینستاگرام")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string Instagram { get; set; }

		[Display(Name = "گروهبندی")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public List<int> GroupingIds { get; set; }
		[Display(Name = "شهر")]

		public int CityId { get; set; }

		public int UserId { get; set; }
		//public string Status { get; set; }
	 //   public DateTime ExpirationDate { get; set; }

	}

    public class AtelierShowViewModel
    {
	    [Key]
	    public int Id { get; set; }

	    [Display(Name = "عنوان")]
	    public string Title { get; set; }

	    [Display(Name = "شهر")]
	    public string City { get; set; }

	    [Display(Name = "لوگو")]
	    public string Logo { get; set; }

	    [Display(Name = "بنر")]
	    public string Banner { get; set; }

	    [Display(Name = "آدرس")]
	    public string Address { get; set; }

	    [Display(Name = "تلفن")]
	    public string Phone { get; set; }

	    [Display(Name = "اینستاگرام")]
	    public string Instagram { get; set; }

	    [Display(Name = "گروه بندی")]
	    public List<string> GroupingTitles { get; set; }
	    public string GroupingTitle { get; set; }
	    public bool IsUserLiked { get; set; }

	    public List<string> Photographers { get; set; }
	    public string Photographer { get; set; }
	    public List<WorkSample> WorkSamples { get; set; }

    }

    

}
