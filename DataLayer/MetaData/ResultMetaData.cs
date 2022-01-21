using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ResultMetaData
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "جواب آزمایش")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]

        public string Result_Description { get; set; }

        [Display(Name = "نام حیوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]

        public int Result_Animal_Id { get; set; }
    }
    [MetadataType(typeof(ResultMetaData))]
    public partial class Result
    {

    }
}
