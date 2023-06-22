using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Atelier.Domain.Models.BaseInfo;

namespace Atelier.Domain.Models
{
    public interface IEntity
    {

    }

    public abstract class BaseEntity<TKey> : IEntity
    {
        [Key]
        public TKey Id { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Title { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? EditedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Desc { get; set; }

        [Display(Name = "نام ایجاد کننده")]
        public int UserId { get; set; }

        [Display(Name = "کد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(20, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Code { get; set; }

        #region Navigation Property

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        #endregion

    }

    public abstract class BaseInterfaceEntity<TKey> : IEntity
    {
        [Key]
        public TKey Id { get; set; }

    }

    public abstract class BaseEntity : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

    }
}
