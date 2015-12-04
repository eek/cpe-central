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
    
    public partial class DItem
    {
        public DItem()
        {
            this.DItemMatTraces = new HashSet<DItemMatTrace>();
            this.DItemPartTraces = new HashSet<DItemPartTrace>();
            this.DItemSubConTraces = new HashSet<DItemSubConTrace>();
            this.DItemToolTraces = new HashSet<DItemToolTrace>();
        }
    
        public int DItem_Reference { get; set; }
        public int Batch_Reference { get; set; }
        public double Quantity { get; set; }
        public string Description { get; set; }
        public string Drawing_Number { get; set; }
        public string Drawing_Issue { get; set; }
        public string Delivery_Notes { get; set; }
        public string CoC_Notes { get; set; }
        public Nullable<int> DNote_Reference { get; set; }
        public int Client_Reference { get; set; }
        public System.DateTime Date_Created { get; set; }
        public System.DateTime Date_Last_Modified { get; set; }
        public bool Added_To_Stock { get; set; }
        public string Delivery_Status { get; set; }
    
        public virtual DNote DNote { get; set; }
        public virtual ICollection<DItemMatTrace> DItemMatTraces { get; set; }
        public virtual ICollection<DItemPartTrace> DItemPartTraces { get; set; }
        public virtual ICollection<DItemSubConTrace> DItemSubConTraces { get; set; }
        public virtual ICollection<DItemToolTrace> DItemToolTraces { get; set; }
    }
}
