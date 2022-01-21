using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class AnimalTypeMetaData
    {
        [Key]
        public int AnimalTypeId { get; set; }

        [Display(Name = "نوع حیوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(50)]
        public string AnimalType_Name { get; set; }

    }
    [MetadataType(typeof(AnimalTypeMetaData))]
    public partial class AnimalType
    {

    }
}
