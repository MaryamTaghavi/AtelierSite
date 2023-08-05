using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Atelier.Domain.DTOs.BaseInfoDTOs.PhotographerDTOs
{
    public class PhotographersViewModel: BaseDto<int>
    {
        [Display(Name = "نام عکاس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string FullName { get; set; }

        public int AtelierId { get; set; }

    }

    public class PhotographersShowViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام عکاس")]
        public string FullName { get; set; }

    }
}
