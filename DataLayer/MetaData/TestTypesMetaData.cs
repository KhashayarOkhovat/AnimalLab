using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DataLayer
{
    public class TestTypesMetaData
    {
        [Key]
        public int TestId { get; set; }
        [Display(Name = "نوع آزمایش")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")] 
        [MaxLength(150)]
        public string TestType_Name { get; set; }
    }
    [MetadataType(typeof(TestTypesMetaData))]
    public partial class TestType
    {

    }
}
