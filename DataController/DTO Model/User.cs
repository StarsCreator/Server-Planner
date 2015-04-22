using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataController.DTO_Model
{
    public class User
    {

        public User()
        {
            //CreatedProjects = new List<Project>();
            //WorkProjects = new List<Project>();
            //ManagedProjects = new List<Project>();
            //CreatedReclamations = new List<Reclamation>();
            //ManagedReclamations = new List<Reclamation>();
            //WorkReclamations = new List<Reclamation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int DeptId { get; set; }
        public string Mail { get; set; }
        public int AccountId { get; set; }
        public string Comment { get; set; }
        public object AllProjectsRow { get; set; }
        public object SelfProjectsRow { get; set; }
        public object AllReclamationRow { get; set; }
        public object SelfReclamationRow { get; set; }
    
        public Account Account { get; set; }
        public Dept Dept { get; set; }

        public override string ToString()
        {
            return Name;
        }

        //public virtual List<Project> CreatedProjects { get; set; }
        //public virtual List<Project> ManagedProjects { get; set; }
        //public virtual List<Project> WorkProjects { get; set; }
        //public virtual List<Reclamation> CreatedReclamations { get; set; }
        //public virtual List<Reclamation> ManagedReclamations { get; set; }
        //public virtual List<Reclamation> WorkReclamations { get; set; }
    }
}
