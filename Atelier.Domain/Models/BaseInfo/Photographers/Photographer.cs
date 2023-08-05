using Atelier.Domain.Models.BaseInfo.Cities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Domain.Models.BaseInfo.Groupings;

namespace Atelier.Domain.Models.BaseInfo.Photographers
{
    public class Photographer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? EditedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int AtelierId { get; set; }


        [ForeignKey(nameof(AtelierId))]
        public Ateliers.Atelier Atelier { get; set; }


    }
}
