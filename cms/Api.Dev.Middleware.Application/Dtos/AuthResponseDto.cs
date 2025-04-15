using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dev.Middleware.Application.Dtos
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public string Message { get; set; }
    }
}
