using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleWebApi.Domain.Entities
{
    public class GroupOwnedItem
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int OwnedItemId { get; set; }
        public OwnedItem OwnedItem { get; set; }
    }
}
