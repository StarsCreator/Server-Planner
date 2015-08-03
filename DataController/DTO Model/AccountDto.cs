using System.Collections.Generic;

namespace DataController.DTO_Model
{
    public class AccountDto
    {

        public AccountDto()
        {
            //Users = new List<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool AllowCreateAll { get; set; }
        public bool AllowCreateSelf { get; set; }
        public bool AllowCommment { get; set; }
        public bool AllowRow { get; set; }
        public bool AllowReclamation { get; set; }

        //public virtual List<User> Users { get; set; }
    }
}
