using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models
{
   interface IPerson
    {
       
       string Email { get; set; }
       string Name { get; set; }
       void Walk();

    }
}
