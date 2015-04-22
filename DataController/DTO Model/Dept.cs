using System.Collections.Generic;

namespace DataController.DTO_Model
{
    public class Dept
    {
        public Dept()
        {
            //Projects = new List<Project>();
            //Users = new List<User>();
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        //public virtual List<Project> Projects { get; set; }
        //public virtual List<User> Users { get; set; }
    }
}
