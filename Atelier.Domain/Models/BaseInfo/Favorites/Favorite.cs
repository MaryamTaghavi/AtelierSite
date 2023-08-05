using Atelier.Domain.Models.BaseInfo.Groupings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Domain.Models.BaseInfo.Favorites
{
    public class Favorite
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? EditedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int UserId { get; set; }
        public int AtelierId { get; set; }

        #region Navigation Property

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [ForeignKey(nameof(AtelierId))]
        public Ateliers.Atelier Atelier { get; set; }

        #endregion
    }
}
