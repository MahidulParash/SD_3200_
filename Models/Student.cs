using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace SD_3200_.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public student()
        {
            this.attempts = new HashSet<attempt>();
            this.enrolls = new HashSet<enroll>();
            this.feedbacks = new HashSet<feedback>();
        }
    
        public int studentID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Email")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")] 
        public string studentEmail { get; set; }
        [Required(ErrorMessage ="This field is required")]
        [DisplayName("Name")]
        public string studentName { get; set; }
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$",ErrorMessage ="Password must contain Capital letter and symbol")]
        [StringLength(50, ErrorMessage = "Must be between 5 and 50 characters", MinimumLength = 5)]
        public string studentPass { get; set; }
        
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("studentPass")]
        public string confirmPass { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<attempt> attempts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<enroll> enrolls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<feedback> feedbacks { get; set; }
    }
}
