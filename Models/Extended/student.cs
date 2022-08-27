using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SD_3200_.Models
{
    [MetadataType(typeof(studentMetaData))]
    public partial class student
    {
        public string ConfirmPassword { get; set; }
    }
    public class studentMetaData
    {
        [Display(Name = "Name")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Name required")]
        public string studentName { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email required")]
        public string studentEmail { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage ="Password must be 6 character long")]
        public string studentPass { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("studentPass", ErrorMessage ="Confirm password and password do not match")]
        public string ConfirmPassword { get; set; }

    }
    
}