﻿#region Using directives

using System.Collections.Generic;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.ViewModels
{
    public class PartLibraryViewModel
    {
        public int? LastViewedPartId { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Part> Parts { get; set; }
    }
}