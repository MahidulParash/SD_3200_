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
    
    public partial class enroll
    {
        public int enroll_ID { get; set; }
        public Nullable<int> course_ID { get; set; }
        public Nullable<int> student_ID { get; set; }
        public Nullable<System.DateTime> enroll_date { get; set; }
        public string paymentStatus { get; set; }

        public virtual cours cours { get; set; }
        public virtual student student { get; set; }
    }
}
