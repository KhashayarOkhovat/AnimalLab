using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DataLayer
{

    public class RulesMetaData
    {
        [Key]
        public int RoleId { get; set; }

        [Display(Name ="سمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(50)]
        public string Role_Type { get; set; }
    }

    [MetadataType(typeof(RulesMetaData))]
    public partial class Role
    {

    } 
}
