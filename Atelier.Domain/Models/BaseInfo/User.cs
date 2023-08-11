using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Domain.Models.BaseInfo.Favorites;

namespace Atelier.Domain.Models.BaseInfo
{
    public class User 
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public TypeUser TypeUser { get; set; }
		public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? EditedDate { get; set; }
        public DateTime? DeletedDate { get; set; }


        #region Navigation Property
        public ICollection<Favorite> Favorites { get; set; }
        #endregion

	}

	public enum TypeUser
    {
        User,
        Admin,
        Atelier
    }
}
