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
    
    public partial class attempt
    {
        public int attempt_ID { get; set; }
        public Nullable<int> student_ID { get; set; }
        public Nullable<int> quiz_ID { get; set; }
        public string grade { get; set; }
    
        public virtual quiz quiz { get; set; }
        public virtual student student { get; set; }
    }
}
