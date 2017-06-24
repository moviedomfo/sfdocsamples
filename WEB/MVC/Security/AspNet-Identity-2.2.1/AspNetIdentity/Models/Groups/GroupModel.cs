using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;

namespace IdentitySample.Models
{
    /// <summary>
    /// Groups have a many-to-many relationship with both Users, and Roles. One user can belong to zero or more Groups, and one group can have zero or more users.
    /// A single role can be assigned to zero or more groups, and a single Group can have zero or more roles.
    /// </summary>
    public class ApplicationGroup
    {
        public ApplicationGroup()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ApplicationRoles = new List<ApplicationGroupRole>();
            this.ApplicationUsers = new List<ApplicationUserGroup>();
        }

        public ApplicationGroup(string name)
            : this()
        {
            this.Name = name;
        }

        public ApplicationGroup(string name, string description)
            : this(name)
        {
            this.Description = description;
        }

        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ApplicationGroupRole> ApplicationRoles { get; set; }
        public virtual ICollection<ApplicationUserGroup> ApplicationUsers { get; set; }
    }


    public class ApplicationUserGroup
    {
        public string ApplicationUserId { get; set; }
        public string ApplicationGroupId { get; set; }
    }

    public class ApplicationGroupRole
    {
        public string ApplicationGroupId { get; set; }
        public string ApplicationRoleId { get; set; }
    }



   


  

}