using System;

namespace DataController.DTO_Model
{
    public class Reclamation
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public int ManagerId { get; set; }
        public int UserId { get; set; }
        public int CreatorId { get; set; }
        public DateTime Send { get; set; }
        public string Production { get; set; }
        public string Nomenclature { get; set; }
        public string Act { get; set; }
        public int Count { get; set; }
        public int State { get; set; }
        public string Comment { get; set; }
        public bool Solution { get; set; }
        public string Client { get; set; }
        public string ReclamationAct { get; set; }
        public bool AllowChanges { get; set; }

        public virtual User Creator { get; set; }
        public virtual User Manager { get; set; }
        public virtual User Worker { get; set; }
    }
}
