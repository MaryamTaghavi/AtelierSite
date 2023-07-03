using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Domain.Models.BaseInfo
{
    public class User 
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? EditedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

    }
}
