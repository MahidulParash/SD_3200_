//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SD_3200_.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public question()
        {
            this.answers = new HashSet<answer>();
        }
    
        public int question_ID { get; set; }
        public Nullable<int> course_ID { get; set; }
        public Nullable<int> quiz_ID { get; set; }
        public string question1 { get; set; }
    
        public virtual cours cours { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<answer> answers { get; set; }
        public virtual quiz quiz { get; set; }
    }
}
