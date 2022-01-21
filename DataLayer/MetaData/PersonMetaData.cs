using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DataLayer
{
    public class PersonMetaData
    {
        [Key]
        public int PersonId { get; set; }
        [Display(Name ="نام")]
        [Required(ErrorMessage ="لطفا {0} را وارد نمایید")]
        [MaxLength(80)]
        public string Person_FirstName { get; set; }
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(100)]
        public string Person_LastName { get; set; }
        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(15)]
        public string Person_PhoneNumber { get; set; }
        [Display(Name = "نقش")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public int Person_RoleId { get; set; }
      
    }
    [MetadataType(typeof(PersonMetaData))]
    public partial class Person
    {

    }
}
