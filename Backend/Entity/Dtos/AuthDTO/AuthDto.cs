using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.AuthDTO
{
    public class AuthDto
    {
        public  string Token { get; set; }
        public DateTime Expiracion { get; set; }
    }

}
