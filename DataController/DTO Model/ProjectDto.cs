using System;

namespace DataController.DTO_Model
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public int UserId { get; set; }
        public int ManagerId { get; set; }
        public int CreatorId { get; set; }
        public int State { get; set; }
        public int Priority { get; set; }
        public string Comment { get; set; }
        public int DeptId { get; set; }
        public DateTime CreationDate { get; set; }
        public bool AllowChanges { get; set; }

        public virtual DeptDto DeptsDto { get; set; }
        public virtual UserDto Creator { get; set; }
        public virtual UserDto Manager { get; set; }
        public virtual UserDto Worker { get; set; }
    }
}
