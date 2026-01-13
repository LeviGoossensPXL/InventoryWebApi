using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApi.Domain.DTOs
{
    public class AddItemsToGroupDTO
    {
        public int GroupId { get; set; }
        public IEnumerable<int> ItemIds { get; set; }
    }
}
