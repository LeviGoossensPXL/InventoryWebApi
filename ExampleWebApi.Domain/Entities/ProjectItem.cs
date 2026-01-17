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
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int Amount { get; set; }
    }
}
