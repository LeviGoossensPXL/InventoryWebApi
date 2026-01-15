using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApi.Domain.DTOs
{
    public class AddWishedItemsToGroupDTO
    {
        public int GroupId { get; set; }
        public IEnumerable<int> WishedItemIds { get; set; }
    }
}
