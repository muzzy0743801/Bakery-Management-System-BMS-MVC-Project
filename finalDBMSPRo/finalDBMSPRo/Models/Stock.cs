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
    
    public partial class Stock
    {
        public int StId { get; set; }
        public long Quantity { get; set; }
        public Nullable<int> Product_id { get; set; }
        public Nullable<int> Supplier_id { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
