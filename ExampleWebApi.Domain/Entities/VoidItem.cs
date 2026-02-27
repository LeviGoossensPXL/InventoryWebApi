using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApi.Domain.Entities
{
    public class VoidItem
    {
        public int Id { get; set; }
        public ICollection<ProjectItem> ProjectItems { get; set; } = new List<ProjectItem>();
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
