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
    
    public partial class FactoryDayPlan
    {
        public int FactoryDayPlanID { get; set; }
        public bool GLOBAL { get; set; }
        public bool INCREASE_CAPACITY { get; set; }
        public int WCID { get; set; }
        public System.DateTime START_DATE { get; set; }
        public System.DateTime END_DATE { get; set; }
        public int ParentDayPlanID { get; set; }
    }
}
