using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtmoreChamber.Models
{
    public class UserRoles
    {
        public ApplicationUser User { set; get; }
        public List<string> Roles { set; get; }
    }
}