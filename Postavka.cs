//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sklad_mebeli
{
    using System;
    using System.Collections.Generic;
    
    public partial class Postavka
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Postavka()
        {
            this.Transportnaya_nakladnaya = new HashSet<Transportnaya_nakladnaya>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ID_postavchika { get; set; }
        public Nullable<int> ID_materiala { get; set; }
        public string Data { get; set; }
    
        public virtual Materiali Materiali { get; set; }
        public virtual Postavchik1 Postavchik1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transportnaya_nakladnaya> Transportnaya_nakladnaya { get; set; }
    }
}
