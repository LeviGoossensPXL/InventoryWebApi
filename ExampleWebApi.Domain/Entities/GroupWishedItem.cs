using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleWebApi.Domain.Entities
{
    public class GroupWishedItem
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int WishedItemId { get; set; }
        public WishedItem WishedItem { get; set; }
    }

}
