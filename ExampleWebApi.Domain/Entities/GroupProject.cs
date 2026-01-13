using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleWebApi.Domain.Entities
{
    public class GroupProject
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }

}
