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
    
    public partial class Customer
    {
        public Customer()
        {
            this.WOrders = new HashSet<WOrder>();
        }
    
        public int Customer_Reference { get; set; }
        public string External_Customer { get; set; }
        public string Name { get; set; }
        public string Terms { get; set; }
        public Nullable<decimal> Credit_Amount { get; set; }
        public string Notes { get; set; }
        public bool CoC_Required { get; set; }
        public Nullable<int> Contact_Reference { get; set; }
        public Nullable<int> Location_Reference { get; set; }
        public int Client_Reference { get; set; }
        public System.DateTime Date_Created { get; set; }
        public System.DateTime Date_Last_Modified { get; set; }
        public string VAT_No { get; set; }
        public bool Approved { get; set; }
        public string Sales_Identification { get; set; }
        public string Tax_Code { get; set; }
        public byte[] Notes2 { get; set; }
        public string Country_Code { get; set; }
        public bool On_Stop { get; set; }
        public bool Allow_Quotes { get; set; }
        public bool Allow_Works_Orders { get; set; }
        public byte[] Approval_Notes { get; set; }
        public string Terms_Code { get; set; }
        public Nullable<int> Created_By { get; set; }
        public Nullable<int> Owned_By { get; set; }
        public Nullable<int> Last_Modified { get; set; }
        public string Customer_Status { get; set; }
        public Nullable<int> Days_Early { get; set; }
        public Nullable<int> Days_Late { get; set; }
        public Nullable<int> NumFileAttachments { get; set; }
        public Nullable<int> NumBrokenLinks { get; set; }
        public Nullable<bool> Always_Acknowledge { get; set; }
        public int Delivery_Location_Reference { get; set; }
        public int Invoice_Location_Reference { get; set; }
        public Nullable<int> PlanningColour { get; set; }
        public Nullable<int> Priority { get; set; }
    
        public virtual ICollection<WOrder> WOrders { get; set; }
    }
}
