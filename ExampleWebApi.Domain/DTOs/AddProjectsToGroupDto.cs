using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApi.Domain.DTOs
{
    public class AddProjectsToGroupDto
    {
        public IEnumerable<int> ProjectIds { get; set; }
    }
}
