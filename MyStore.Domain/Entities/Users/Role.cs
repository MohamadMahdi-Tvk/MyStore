using MyStore.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Entities.Users
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}
