//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class User
    {
        public int id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int idRole { get; set; }
        public string Surename { get; set; }
        public string Name { get; set; }
        public string Father_name { get; set; }
        public decimal Teleph { get; set; }
        public System.DateTime Data_Birth { get; set; }
        public string Email { get; set; }
    
        public virtual Role Role { get; set; }
    }
}
