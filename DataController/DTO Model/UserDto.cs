using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataController.DTO_Model
{
    public class UserDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int DeptId { get; set; }
        public string Mail { get; set; }
        public int AccountId { get; set; }
        public string Comment { get; set; }
        public int QueryId { get; set; }
        public object AllProjectsRow { get; set; }
        public object SelfProjectsRow { get; set; }
        public object AllReclamationRow { get; set; }
        public object SelfReclamationRow { get; set; }
    
        public AccountDto AccountDto { get; set; }
        public DeptDto DeptDto { get; set; }

        //public virtual List<Project> CreatedProjects { get; set; }
        //public virtual List<Project> ManagedProjects { get; set; }
        //public virtual List<Project> WorkProjects { get; set; }
        //public virtual List<Reclamation> CreatedReclamations { get; set; }
        //public virtual List<Reclamation> ManagedReclamations { get; set; }
        //public virtual List<Reclamation> WorkReclamations { get; set; }
    }
}
