using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace celam.api.common.BE
{
    public class UserBEList : List<SecurityUserBE>
    { }

    public class SecurityUserBE
    {
        //public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public Guid UserId { get; set; }
        public string[] Roles { get; set; }
        public string Email { get; set; }
        //public byte[] photo { get; set; }

        public Guid PersonId { get; set; }
        public PersonBE Person { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsLockedOut { get; set; }

        public override string ToString()
        {
            return String.Concat("Usuario: ", UserName, " Lastname ", Lastname);
        }


     
    }
}

