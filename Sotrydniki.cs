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
    
    public partial class Sotrydniki
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sotrydniki()
        {
            this.Avtorizacia = new HashSet<Avtorizacia>();
            this.Sclad = new HashSet<Sclad>();
        }
    
        public int ID { get; set; }
        public string Familia { get; set; }
        public string Ima { get; set; }
        public string Otchestvo { get; set; }
        public string Telefon { get; set; }
        public string Seria_pasporta { get; set; }
        public string Nomer_pasporta { get; set; }
        public string Data_rojdenia { get; set; }
        public string Doljnost { get; set; }
        public string Login { get; set; }
        public string Parol { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Avtorizacia> Avtorizacia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sclad> Sclad { get; set; }
    }
}
