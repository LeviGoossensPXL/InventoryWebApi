using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApi.Domain.DTOs
{
    public class AddUsersToGroupDto
    {
        public int GroupId { get; set; }
        public IEnumerable<Guid> UserIds { get; set; }
    }
}
