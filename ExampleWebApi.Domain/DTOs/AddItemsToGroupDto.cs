using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApi.Domain.DTOs
{
    public class AddItemsToGroupDto
    {
        public int GroupId { get; set; }
        // public IEnumerable<int> ItemIds { get; set; }
        public IEnumerable<int> OwnedItemIds { get; set; }
        public IEnumerable<int> WishedItemIds { get; set; }
    }
}
