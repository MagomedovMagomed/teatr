﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1.ApplicationData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        private static Entities _context;
        public Entities()
            : base("name=Entities")
        {
        }

        public static Entities GetContext()
        {
            if (_context == null)
            {
                _context = new Entities();
            }
            return _context;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Akter> Akter { get; set; }
        public virtual DbSet<Akter_and_Spectacle> Akter_and_Spectacle { get; set; }
        public virtual DbSet<Pointer> Pointer { get; set; }
        public virtual DbSet<Postanovshik> Postanovshik { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Screenwriter> Screenwriter { get; set; }
        public virtual DbSet<Spectacle> Spectacle { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Zanr> Zanr { get; set; }
    }
}