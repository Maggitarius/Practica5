//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Practica5
{
    using System;
    using System.Collections.Generic;
    
    public partial class Items
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Items()
        {
            this.Trading_Platform = new HashSet<Trading_Platform>();
        }
    
        public int ID_Item { get; set; }
        public string Name_Item { get; set; }
        public string Type_Item { get; set; }
        public Nullable<decimal> Price { get; set; }
        public int Game_ID { get; set; }
    
        public virtual Games Games { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trading_Platform> Trading_Platform { get; set; }
    }
}
