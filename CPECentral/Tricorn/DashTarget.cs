//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tricorn
{
    using System;
    using System.Collections.Generic;
    
    public partial class DashTarget
    {
        public int ID { get; set; }
        public int TargetTypeID { get; set; }
        public Nullable<int> TargetWeek { get; set; }
        public Nullable<int> TargetMonth { get; set; }
        public Nullable<int> TargetQuarter { get; set; }
        public Nullable<int> TargetYear { get; set; }
        public Nullable<int> TargetFYear { get; set; }
        public string TargetFYearDesc { get; set; }
        public Nullable<decimal> TargetValue { get; set; }
        public string TargetMonthYear { get; set; }
        public string TargetYearMonth { get; set; }
    }
}
