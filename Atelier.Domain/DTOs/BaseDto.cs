using System;
using System.ComponentModel.DataAnnotations;

namespace Atelier.Domain.DTOs
{
    public abstract class BaseDto<TKey>
    {
        public TKey Id { get; set; }

    }

    public abstract class BaseDto: BaseDto<int>
    {

    }

    public abstract class BaseCustomDto : BaseDto<int>
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string Title { get; set; }

        [Display(Name = "کد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(10)]
        public string Code { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(100)]
        public string Desc { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

    }

    public abstract class BaseSelectDto : BaseDto<int>
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public string CreateDate { get; set; }
        public string UserName { get; set; }
    }
}
