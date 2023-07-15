using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Atelier.Domain.DTOs.BaseInfoDTOs.UsersDTOs
{
	public class UserDto : BaseDto<int>
	{
		[Display(Name = "نام و نام خانوادگی")]
		[MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
		public string FullName { get; set; }

		[Display(Name = "نام کاربری")]
		[MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
		public string UserName { get; set; }

		[Display(Name = "رمز عبور")]
			[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
		public string Password { get; set; }

		[Display(Name = "تکرار رمز عبور")]
		[MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
		[Compare(nameof(Password), ErrorMessage = "پسورد با تکرار آن یکی نیست")]
		public string RePassword { get; set; }


		[Display(Name = "شماره همراه")]
		[RegularExpression(@"^(\+98|0)?9\d{9}$", ErrorMessage = "شماره موبایل فرمت نامناسب دارد")]
		public string PhoneNumber { get; set; }
	}
}
