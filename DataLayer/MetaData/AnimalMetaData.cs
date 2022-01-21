using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AnimalMetaData
    {
        [Key]
        public int AnimalId { get; set; }

        [Display(Name = "نام کامل")]
        
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]

        public string Animal_FullName { get; set; }
        [Display(Name = "شماره اختصاصی")]
        
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Animal_Number { get; set; }
        [Display(Name = "نام صاحب")]
        
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public Nullable<int> Animal_PersonId { get; set; }
        [Display(Name = "نوع تست")]
        
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public int Animal_TestId { get; set; }
        [Display(Name = "نوع حیوان")]
        
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public int Animal_AnimalTypeId { get; set; }
    }
    
    [MetadataType(typeof(AnimalMetaData))]
    public partial class Animal
    {

    }
    
}
