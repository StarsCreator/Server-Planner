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
    
    public partial class DeptDb
    {
        public DeptDb()
        {
            this.ProjectDbs = new HashSet<ProjectDb>();
            this.UserDbs = new HashSet<UserDb>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<ProjectDb> ProjectDbs { get; set; }
        public virtual ICollection<UserDb> UserDbs { get; set; }
    }
}
