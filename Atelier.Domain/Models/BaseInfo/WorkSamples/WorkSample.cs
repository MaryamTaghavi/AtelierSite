using Atelier.Domain.Models.BaseInfo.Ateliers;
using Atelier.Domain.Models.BaseInfo.Groupings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Domain.Models.BaseInfo.WorkSamples
{
    public class WorkSample
    {
        public int Id { get; set; }
        public string WorkSamplePic { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? EditedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int GroupId { get; set; }
        public int AtelierId { get; set; }


        #region Navigation Property

        [ForeignKey(nameof(GroupId))]
        public Grouping Grouping { get; set; }

        [ForeignKey(nameof(AtelierId))]
        public Ateliers.Atelier Atelier { get; set; }

        #endregion
    }
}
