using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Atelier.Domain.DTOs.BaseInfoDTOs.AtelierGroupDTOs
{
    public class AtelierGroupViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        public string Title { get; set; }

        public int GroupId { get; set; }
        public int AtelierId { get; set; }
    }
}
