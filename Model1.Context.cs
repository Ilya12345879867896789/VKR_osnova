﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Avtorizacia> Avtorizacia { get; set; }
        public virtual DbSet<Gotovaya_prodykcia> Gotovaya_prodykcia { get; set; }
        public virtual DbSet<Materiali> Materiali { get; set; }
        public virtual DbSet<Postavchik1> Postavchik1 { get; set; }
        public virtual DbSet<Postavka> Postavka { get; set; }
        public virtual DbSet<Sclad> Sclad { get; set; }
        public virtual DbSet<Sotrydniki> Sotrydniki { get; set; }
        public virtual DbSet<Tovarnaya_nakladnaya> Tovarnaya_nakladnaya { get; set; }
        public virtual DbSet<Transportnaya_nakladnaya> Transportnaya_nakladnaya { get; set; }
        public virtual DbSet<Zakaz> Zakaz { get; set; }
    }
}
