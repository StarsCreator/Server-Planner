//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataController
{
    using System;
    using System.Collections.Generic;
    
    public partial class AccountDb
    {
        public AccountDb()
        {
            this.UserDbs = new HashSet<UserDb>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public bool AllowCreateAll { get; set; }
        public bool AllowCreateSelf { get; set; }
        public bool AllowCommment { get; set; }
        public bool AllowRow { get; set; }
        public bool AllowReclamation { get; set; }
    
        public virtual ICollection<UserDb> UserDbs { get; set; }
    }
}
