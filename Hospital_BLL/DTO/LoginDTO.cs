using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_BLL.DTO
{
    public class LoginDTO
    {
        public int LoginID { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Type { get; set; }
    }

}
