//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FrameworkApp.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class RandomObject
    {
        public int RandomObjectID { get; set; }
        public string RandomString { get; set; }
        public System.DateTimeOffset RandomDateTimeOffset { get; set; }
        public int SeedId { get; set; }
        public int RandomInt { get; set; }
    
        public virtual Seed Seed { get; set; }
    }
}
