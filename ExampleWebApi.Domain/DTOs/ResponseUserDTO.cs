using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApi.Domain.DTOs
{
    public class ResponseUserDTO
    {
        public string NickName { get; set; }
        
        public string Email { get; set; }
        
        public string? PhoneNumber { get; set; }
    }
}
