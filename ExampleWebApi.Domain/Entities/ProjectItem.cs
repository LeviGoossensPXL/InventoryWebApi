using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApi.Domain.Entities
{
    public class ProjectItem
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int VoidItemId { get; set; }
        public VoidItem VoidItem { get; set; }

        public int Amount { get; set; }
    }
}
