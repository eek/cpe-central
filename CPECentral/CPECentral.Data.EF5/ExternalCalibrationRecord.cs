
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
    
public partial class ExternalCalibrationRecord
{

    public int Id { get; set; }

    public int GaugeId { get; set; }

    public System.DateTime CalibratedOn { get; set; }

    public string SupplierName { get; set; }

    public bool Passed { get; set; }



    public virtual Gauge Gauge { get; set; }

}

}
