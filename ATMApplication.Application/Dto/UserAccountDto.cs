using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApplication.Application.Dto
{
    public class UserAccountDto
    {
        public string UserName { get; set; } = string.Empty;
        public int Password { get; set; }
    }
}
