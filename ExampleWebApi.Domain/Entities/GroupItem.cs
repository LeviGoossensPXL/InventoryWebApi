using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleWebApi.Domain.Entities
{
    public class GroupItem
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
    }

}
