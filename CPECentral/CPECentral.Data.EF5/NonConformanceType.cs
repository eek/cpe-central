
//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace CPECentral.Data.EF5
{

using System;
    using System.Collections.Generic;
    
public partial class NonConformanceType
{

    public NonConformanceType()
    {

        this.NonConformances = new HashSet<NonConformance>();

    }


    public int Id { get; set; }

    public string Name { get; set; }



    public virtual ICollection<NonConformance> NonConformances { get; set; }

}

}
