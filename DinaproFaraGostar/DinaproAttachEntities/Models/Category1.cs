//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace rrrrrrrrrrrrrrrrrrr
{
    using System;
    using System.Collections.Generic;
    
    public partial class Category1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category1()
        {
            this.Category11 = new HashSet<Category1>();
            this.Category_TypeInvgdss = new HashSet<Category_TypeInvgdss>();
            this.OrderManual_TypeInvgdss = new HashSet<OrderManual_TypeInvgdss>();
        }
    
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Nullable<int> parentId { get; set; }
        public Nullable<double> Ordr_Cat { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category1> Category11 { get; set; }
        public virtual Category1 Category12 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category_TypeInvgdss> Category_TypeInvgdss { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderManual_TypeInvgdss> OrderManual_TypeInvgdss { get; set; }
    }
}