//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace finalDBMSPRo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int OrId { get; set; }
        public Nullable<System.DateTime> Or_Date { get; set; }
        public Nullable<int> Customer_id { get; set; }
        public Nullable<int> Employee_id { get; set; }
        public long Or_Item { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
