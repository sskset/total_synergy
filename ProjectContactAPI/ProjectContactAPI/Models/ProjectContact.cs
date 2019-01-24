using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectContactAPI.Models
{
    public class ProjectContact
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
